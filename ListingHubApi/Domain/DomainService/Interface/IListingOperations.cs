using DatabaseModel.Entities;

namespace DomainService.Interface
{
    public interface IListingOperations
    {
        IList<Listing> Search(int? categoryId, string title, decimal? minPrice, decimal? maxPrice, int? cityId, int? districtId, int? neighbourhoodId, int? subNeighbourhoodId, int? userId, DateTime? listingDate, string latlong, string sortBy, string sortDirection, int pageSize, int pageNumber, out int totalCount);
        Listing GetSingle(int id, bool includeDescription = false, bool includeFields = false);
        void Create(int categoryId, string title, decimal price, int cityId, int districtId, int neighbourhoodId, int subNeighbourhoodId, int userId, DateTime listingDate, string latlong);
        void Update(int id, int categoryId, string title, decimal price, int cityId, int districtId, int neighbourhoodId, int subNeighbourhoodId, int userId, DateTime listingDate, string latlong);
        void Delete(int id);
    }
}
