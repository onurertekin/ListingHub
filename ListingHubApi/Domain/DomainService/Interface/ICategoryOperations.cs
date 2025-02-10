using DatabaseModel.Entities;

namespace DomainService.Interface
{
    public interface ICategoryOperations
    {
        IList<Category> Search(string? name, int? parentCategoryId, int? fieldType, DateTime? createdOn, DateTime? updatedOn, string sortBy, string sortDirection, int pageSize, int pageNumber, out int totalCount);
        Category GetSingle(int id);
        void Create(string name, int? parentCategoryId, int? fieldType, DateTime createdOn);
        void Update(int id, string name, int? parentCategoryId, int? fieldType, DateTime updatedOn);
        void Delete(int id);
    }
}
