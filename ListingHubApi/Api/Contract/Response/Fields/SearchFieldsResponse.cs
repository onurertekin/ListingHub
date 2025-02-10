namespace Contract.Response.Fields
{
    public class SearchFieldsResponse
    {
        public class Field
        {
            public int id { get; set; }
            public int fieldType { get; set; }
            public string fieldName { get; set; }
            public bool isRequired { get; set; }
        }
        public SearchFieldsResponse()
        {
            fields = new List<Field>();
        }
        public List<Field> fields { get; set; }
    }
}
