using DatabaseModel.Entities;

namespace DomainService.Interface
{
    public interface ICityOperations
    {
        IList<City> Search(string? name, int? plateCode, string sortBy, string sortDirection, int pageSize, int pageNumber, out int totalCount);
        City GetSingle(int id);

    }
}
