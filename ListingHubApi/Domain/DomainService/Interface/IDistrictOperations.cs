using DatabaseModel.Entities;

namespace DomainService.Interface
{
    public interface IDistrictOperations
    {
        IList<District> Search(string? name, int? cityId, string sortBy, string sortDirection, int pageSize, int pageNumber, out int totalCount);
        District GetSingle(int id);
    }
}
