using DatabaseModel;
using DatabaseModel.Entities;
using DomainService.Base;
using DomainService.Exceptions;
using DomainService.Interface;
using Microsoft.EntityFrameworkCore;

namespace DomainService.Operations
{
    public class ListingPhotoOperations : DbContextHelper, IListingPhotoOperations
    {
        private readonly MainDbContext mainDbContext;
        public ListingPhotoOperations(MainDbContext mainDbContext) : base(mainDbContext)
        {
            this.mainDbContext = mainDbContext;
        }

        public IList<ListingPhoto> Search(int listingId)
        {
            return mainDbContext.ListingPhotos.Where(x => x.ListingId == listingId).ToList();
        }

        public void Create(int listingId, string photoName)
        {
            ListingPhoto listingPhoto = new ListingPhoto();
            listingPhoto.ListingId = listingId;
            listingPhoto.PhotoName = photoName;
            SaveEntity(listingPhoto);
        }

        public void Delete(int id)
        {
            var listingPhoto = mainDbContext.ListingPhotos.Where(x => x.Id == id).SingleOrDefault();

            if (listingPhoto == null)
                throw new BusinessException(404, "Fotoğraf bulunamadı.");

            DeleteEntity(listingPhoto);
        }
    }
}
