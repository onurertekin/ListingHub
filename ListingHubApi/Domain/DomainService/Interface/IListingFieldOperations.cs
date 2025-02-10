using DatabaseModel.Entities;

namespace DomainService.Interface
{
    public interface IListingFieldOperations
    {
        IList<ListingField> Search(int listingId, int? fieldId, string? value, string sortBy, string sortDirection, int pageSize, int pageNumber, out int totalCount);
        void Update(int listingId, Dictionary<int, string> fields);
    }
}
