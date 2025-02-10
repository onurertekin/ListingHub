using DatabaseModel.Entities;

namespace DomainService.Interface
{
    public interface INeighbourhoodOperations
    {
        IList<Neighbourhood> Search(int? districtId, string? name, string sortBy, string sortDirection, int pageSize, int pageNumber, out int totalCount);
        Neighbourhood GetSingle(int id);
    }
}
