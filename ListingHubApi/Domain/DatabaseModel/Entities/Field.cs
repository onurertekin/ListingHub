using DatabaseModel.Enumerations;

namespace DatabaseModel.Entities
{
    public class Field
    {
        public int Id { get; set; }
        public FieldTypeStatus FieldType { get; set; }
        public string FieldName { get; set; }
        public bool IsRequired { get; set; }
    }
}
