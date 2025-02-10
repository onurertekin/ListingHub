using System.ComponentModel.DataAnnotations;

namespace DatabaseModel.Entities
{
    public class Category
    {
        public int Id { get; set; }

        [StringLength(100)]
        public string Name { get; set; }
        public int? ParentCategoryId { get; set; }
        public int? FieldType { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }

        #region Navigation Properties
        public virtual Category ParentCategory { get; set; }

        #endregion
    }
}
