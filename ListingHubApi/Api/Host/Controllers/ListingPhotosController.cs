using Amazon.S3.Model;
using Amazon.S3;
using Contract.Response.ListingPhotos;
using DomainService.Interface;
using GreenPipes.Caching.Internals;
using Microsoft.AspNetCore.Mvc;

namespace Host.Controllers
{
    [ApiController]
    [Route("listing-api/listings/{listingId}/photos")]
    public class ListingPhotosController : ControllerBase
    {
        private readonly IListingPhotoOperations listingPhotoOperations;
        private readonly IConfiguration configuration;
        private readonly IAmazonS3 amazonS3;
        private readonly string bucketName;

        public ListingPhotosController(IListingPhotoOperations listingPhotoOperations, IConfiguration configuration, IAmazonS3 amazonS3)
        {
            this.listingPhotoOperations = listingPhotoOperations;
            this.configuration = configuration;
            this.amazonS3 = amazonS3;
            this.bucketName = configuration["AWS:BucketName"];
        }

        [HttpGet]
        public ActionResult<SearchListingPhotosResponse> Search(int listingId)
        {
            var listingPhotos = listingPhotoOperations.Search(listingId);

            var response = new SearchListingPhotosResponse();
            response.photos = listingPhotos.Select(x => x.PhotoName).ToList();

            return new JsonResult(response);
        }

        [HttpPost]
        public async Task Create(int listingId, [FromForm] CreateListingPhotosRequest request)
        {
            if (request.file != null && request.file.Length > 0)
            {

                var extension = Path.GetExtension(request.file.FileName).ToLower(); // Dosya uzantısını küçük harfe çevir
                var allowedExtensions = new List<string> { ".png", ".jpeg", ".jpg" }; // İzin verilen uzantılar
                var allowedMimeTypes = new List<string> { "image/png", "image/jpeg" }; // İzin verilen MIME türleri

                if (!allowedExtensions.Contains(extension) || !allowedMimeTypes.Contains(request.file.ContentType.ToLower()))
                {
                    throw new InvalidOperationException("Sadece PNG ve JPEG formatında dosyalar yüklenebilir.");
                }

                // Dosya adını uzantıyla oluşturma
                var photoName = $"{Guid.NewGuid()}{extension}";

                #region S3

                PutObjectRequest putObjectRequest = new()
                {
                    BucketName = bucketName,
                    Key = photoName,
                    InputStream = request.file.OpenReadStream(),
                    ContentType = request.file.ContentType
                };
                putObjectRequest.Metadata.Add("Content-Type", request.file.ContentType);
                await amazonS3.PutObjectAsync(putObjectRequest);

                #endregion

                listingPhotoOperations.Create(listingId, photoName);
            }
        }


        public class CreateListingPhotosRequest
        {
            public IFormFile file { get; set; }
        }
    }
}
