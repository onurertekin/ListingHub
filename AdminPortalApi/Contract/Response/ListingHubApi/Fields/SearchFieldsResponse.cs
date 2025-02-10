using System.Collections.Generic;

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
            Fields = new List<Field>();
        }
        public List<Field> Fields { get; set; }
    }
}
