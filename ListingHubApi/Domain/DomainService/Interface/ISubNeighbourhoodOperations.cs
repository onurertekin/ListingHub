using DatabaseModel.Entities;

namespace DomainService.Interface
{
    public interface ISubNeighbourhoodOperations
    {
        IList<SubNeighbourhood> Search(int? neighbourhoodId, string? name, string sortBy, string sortDirection, int pageSize, int pageNumber, out int totalCount);
        SubNeighbourhood GetSingle(int id);
    }
}
