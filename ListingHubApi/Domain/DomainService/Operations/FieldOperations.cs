using DatabaseModel;
using DatabaseModel.Entities;
using DatabaseModel.Enumerations;
using DomainService.Base;
using DomainService.Exceptions;
using DomainService.Extensions;
using DomainService.Interface;

namespace DomainService.Operations
{
    public class FieldOperations : DbContextHelper, IFieldOperations
    {
        private readonly MainDbContext mainDbContext;
        public FieldOperations(MainDbContext mainDbContext) : base(mainDbContext)
        {
            this.mainDbContext = mainDbContext;
        }

        public IList<Field> Search(int? fieldType, string? fieldName, bool? isRequired, string sortBy, string sortDirection, int pageSize, int pageNumber, out int totalCount)
        {
            var query = mainDbContext.Fields.AsQueryable();

            if (fieldType.HasValue)
                query = mainDbContext.Fields.Where(x => x.FieldType == (FieldTypeStatus)fieldType);

            if (!string.IsNullOrEmpty(fieldName))
                query = mainDbContext.Fields.Where(x => x.FieldName == fieldName);

            if (isRequired.HasValue)
                query = mainDbContext.Fields.Where(x => x.IsRequired == isRequired);

            return query.GetPagedAndSorted(pageNumber, pageSize, sortDirection, sortBy, out totalCount);
        }

        public Field GetSingle(int id)
        {
            var field = mainDbContext.Fields.Where(x => x.Id == id).SingleOrDefault();

            if (field == null)
                throw new BusinessException(404, "Kayıt bulunamadı.");

            return field;
        }

        public void Create(string? fieldName, bool isRequired, int fieldType)
        {
            #region Validations

            var currentFieldName = mainDbContext.Fields.Where(x => x.FieldName == fieldName).SingleOrDefault();

            if (currentFieldName != null)
                throw new BusinessException(404, "Bu alan adı mevcut.");

            #endregion

            Field field = new Field();
            field.FieldName = fieldName;
            field.IsRequired = isRequired;
            field.FieldType = (DatabaseModel.Enumerations.FieldTypeStatus)fieldType;

            SaveEntity(field);
        }

        public void Update(int id, string? fieldName, bool isRequired, int fieldType)
        {
            #region Validations

            var field = mainDbContext.Fields.Where(x => x.Id == id).SingleOrDefault();

            if (field == null)
                throw new BusinessException(404, "Kayıt bulunamadı.");

            #endregion

            field.FieldName = fieldName;
            field.IsRequired = isRequired;
            field.FieldType = (DatabaseModel.Enumerations.FieldTypeStatus)fieldType;

            UpdateEntity(field);
        }

        public void Delete(int id)
        {
            #region Validations

            var field = mainDbContext.Fields.Where(x => x.Id == id).SingleOrDefault();

            if (field == null)
                throw new BusinessException(404, "Kayıt bulunamadı.");

            #endregion

            DeleteEntity(field);
        }

    }
}
