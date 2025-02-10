using Contract.Request.Fields;
using Contract.Response.Fields;
using DomainService.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Host.Controllers
{
    [ApiController]
    [Route("listing-api/fields")]
    public class FieldsController : ControllerBase
    {
        private readonly IFieldOperations fieldOperations;
        public FieldsController(IFieldOperations fieldOperations)
        {
            this.fieldOperations = fieldOperations;
        }

        [HttpGet]
        public ActionResult<SearchFieldsResponse> Search([FromQuery] SearchFieldsRequest request)
        {
            var fields = fieldOperations.Search(request.fieldType, request.fieldName, request.isRequired, request.sortBy, request.sortDirection, request.pageSize, request.pageNumber, out int totalCount);
            var response = new SearchFieldsResponse();

            foreach (var field in fields)
            {
                response.fields.Add(new SearchFieldsResponse.Field()
                {
                    id = field.Id,
                    fieldName = field.FieldName,
                    isRequired = field.IsRequired,
                    fieldType = (int)field.FieldType,
                });
            }

            return new JsonResult(response);
        }

        [HttpGet("{id}")]
        public ActionResult<GetSingleFieldsResponse> GetSingle(int id)
        {
            var field = fieldOperations.GetSingle(id);

            var response = new GetSingleFieldsResponse();
            response.fieldName = field.FieldName;
            response.fieldType = (int)field.FieldType;
            response.isRequired = field.IsRequired;
            response.id = id;

            return response;
        }

        [HttpPost]
        public void Create([FromBody] CreateFieldsRequest request)
        {
            fieldOperations.Create(request.fieldName, request.isRequired, request.fieldType);
        }

        [HttpPut("{id}")]
        public void Update([FromBody] UpdateFieldsRequest request, int id)
        {
            fieldOperations.Update(id, request.fieldName, request.isRequired, request.fieldType);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            fieldOperations.Delete(id);
        }
    }
}
