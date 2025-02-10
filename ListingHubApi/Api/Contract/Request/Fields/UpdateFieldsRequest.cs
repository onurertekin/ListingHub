namespace Contract.Request.Fields
{
    public class UpdateFieldsRequest
    {
        public int fieldType { get; set; }
        public string fieldName { get; set; }
        public bool isRequired { get; set; }
    }
}
