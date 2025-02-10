using DatabaseModel;
using DatabaseModel.Entities;
using DomainService.Base;
using DomainService.Exceptions;
using DomainService.Extensions;
using DomainService.Interface;

namespace DomainService.Operations
{
    public class CategoryOperations : DbContextHelper, ICategoryOperations
    {
        private readonly MainDbContext mainDbContext;
        public CategoryOperations(MainDbContext mainDbContext) : base(mainDbContext)
        {
            this.mainDbContext = mainDbContext;
        }

        public IList<Category> Search(string? name, int? parentCategoryId, int? fieldType, DateTime? createdOn, DateTime? updatedOn, string sortBy, string sortDirection, int pageSize, int pageNumber, out int totalCount)
        {
            var query = mainDbContext.Categories.AsQueryable();

            if (!string.IsNullOrEmpty(name))
                query = mainDbContext.Categories.Where(x => x.Name == name);

            if (parentCategoryId.HasValue)
            {
                if (parentCategoryId.Value == -1)
                {
                    // parentCategoryId -1 ise null olanları getir
                    query = mainDbContext.Categories.Where(x => x.ParentCategoryId == null);
                }
                else
                {
                    query = mainDbContext.Categories.Where(x => x.ParentCategoryId == parentCategoryId);
                }
            }

            if (fieldType.HasValue)
                query = mainDbContext.Categories.Where(x => x.FieldType == fieldType);

            if (createdOn.HasValue)
                query = mainDbContext.Categories.Where(x => x.CreatedOn == createdOn);

            if (updatedOn.HasValue)
                query = mainDbContext.Categories.Where(x => x.UpdatedOn == updatedOn);

            return query.GetPagedAndSorted(pageNumber, pageSize, sortDirection, sortBy, out totalCount);
        }

        public Category GetSingle(int id)
        {
            var categories = mainDbContext.Categories.Where(x => x.Id == id).SingleOrDefault();

            if (categories == null)
                throw new BusinessException(404, "Kategori bulunamadı.");

            return categories;
        }

        public void Create(string name, int? parentCategoryId, int? fieldType, DateTime createdOn)
        {
            Category category = new Category();
            category.Name = name;
            category.ParentCategoryId = parentCategoryId;
            category.FieldType = fieldType;
            category.CreatedOn = DateTime.Now;

            SaveEntity(category);
        }
        public void Update(int id, string name, int? parentCategoryId, int? fieldType, DateTime updatedOn)
        {
            #region Validations
            var categories = mainDbContext.Categories.Where(x => x.Id == id).SingleOrDefault();

            if (categories == null)
                throw new BusinessException(404, "Kategori bulunamadı.");
            #endregion

            categories.Name = name;
            categories.ParentCategoryId = parentCategoryId;
            categories.FieldType = fieldType;
            categories.UpdatedOn = DateTime.Now;

            UpdateEntity(categories);
        }

        public void Delete(int id)
        {
            #region Validations
            var categories = mainDbContext.Categories.Where(x => x.Id == id).SingleOrDefault();

            if (categories == null)
                throw new BusinessException(404, "Kategori bulunamadı.");
            #endregion

            DeleteEntity(categories);
        }

    }
}
