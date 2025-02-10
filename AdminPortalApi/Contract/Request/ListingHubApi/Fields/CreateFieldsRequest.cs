namespace Contract.Request.Fields
{
    public class CreateFieldsRequest
    {
        public int fieldType { get; set; }
        public string fieldName { get; set; }
        public bool isRequired { get; set; }
    }
}
