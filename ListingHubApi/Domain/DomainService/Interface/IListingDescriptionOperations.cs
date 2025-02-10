using DatabaseModel.Entities;

namespace DomainService.Interface
{
    public interface IListingDescriptionOperations
    {
        ListingDescription GetSingle(int listingId);
        void Update(int listingId, string description);
    }
}
