using DatabaseModel.Entities;

namespace DomainService.Interface
{
    public interface IListingPhotoOperations
    {
        IList<ListingPhoto> Search(int listingId);
        void Create(int listingId, string photoName);
        void Delete(int id);
    }
}
