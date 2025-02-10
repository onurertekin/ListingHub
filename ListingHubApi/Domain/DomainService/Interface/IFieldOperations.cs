using DatabaseModel.Entities;

namespace DomainService.Interface
{
    public interface IFieldOperations
    {
        IList<Field> Search(int? fieldType, string? fieldName, bool? isRequired, string sortBy, string sortDirection, int pageSize, int pageNumber, out int totalCount);
        Field GetSingle(int id);
        void Create(string? fieldName, bool isRequired, int fieldType);
        void Update(int id, string? fieldName, bool isRequired, int fieldType);
        void Delete(int id);
    }
}
