using Contract.Response.ListingPhotos;
using Host.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using static Contract.Response.Listings.SearchListingsResponse;

namespace Host.Controllers.v1.ListingHubApi.ListingPhoto
{
    [ApiController]
    [Route("listing-api/listings/{listingId}/photos")]
    public class ListingPhotosController : ControllerBase
    {
        private readonly HttpHelper httpHelper;
        private readonly string listingHubApiUrl;
        public ListingPhotosController(HttpHelper httpHelper, IConfiguration configuration)
        {
            this.httpHelper = httpHelper;
            this.listingHubApiUrl = configuration.GetValue<string>("Services:ListingHubApi");
        }

        [HttpGet]
        public async Task<ActionResult<SearchListingPhotosResponse>> Search(int listingId)
        {
            SearchListingPhotosResponse response = new SearchListingPhotosResponse();
            string url = ($"{listingHubApiUrl}/listing-api/listings/{listingId}/photos");
            response = await httpHelper.Get<SearchListingPhotosResponse>(url);
            return new JsonResult(response);
        }

        [HttpPost]
        public async Task Create([FromForm] CreateListingPhotosRequest request, int listingId)
        {
            if (request.file != null && request.file.Length > 0)
            {
                #region Image to Byte

                byte[] data;
                using (var br = new BinaryReader(request.file.OpenReadStream()))
                {
                    data = br.ReadBytes((int)request.file.OpenReadStream().Length);
                }

                var bytes = new ByteArrayContent(data);

                #endregion

                var multiContent = new MultipartFormDataContent();
                multiContent.Add(bytes, "file", request.file.FileName);

                using (HttpClient client = new HttpClient())
                {
                    var apiResponse = await client.PostAsync($"{listingHubApiUrl}/listing-api/listings/{listingId}/photos", multiContent);
                }
            }
        }


        public class CreateListingPhotosRequest
        {
            public IFormFile file { get; set; }
        }
    }
}
