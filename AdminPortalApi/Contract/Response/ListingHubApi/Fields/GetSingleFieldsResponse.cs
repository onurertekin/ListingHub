namespace Contract.Response.Fields
{
    public class GetSingleFieldsResponse
    {
        public int id { get; set; }
        public int fieldType { get; set; }
        public string fieldName { get; set; }
        public bool isRequired { get; set; }
    }
}
