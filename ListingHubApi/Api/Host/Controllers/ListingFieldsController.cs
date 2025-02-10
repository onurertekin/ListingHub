using Contract.Request.ListingFields;
using Contract.Response.ListingFields;
using DomainService.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Host.Controllers
{
    [ApiController]
    [Route("listing-api/listings/{listingId}/fields")]
    public class ListingFieldsController : ControllerBase
    {
        private readonly IListingFieldOperations listingFieldOperations;
        public ListingFieldsController(IListingFieldOperations listingFieldOperations)
        {
            this.listingFieldOperations = listingFieldOperations;
        }

        [HttpGet]
        public ActionResult<SearchListingFieldsResponse> Search(int listingId, [FromQuery] SearchListingFieldsRequest request)
        {
            var listingFields = listingFieldOperations.Search(listingId, request.fieldId, request.value, request.sortBy, request.sortDirection, request.pageSize, request.pageNumber, out int totalCount);
            
            var response = new SearchListingFieldsResponse();
            response.Fill(listingFields);
          
            return new JsonResult(response);
        }

        [HttpPut]
        public void Update([FromBody] UpdateListingFieldsRequest request, int listingId)
        {
            var fields = request.listingFields.ToDictionary(x => x.fieldId, x => x.value);
            listingFieldOperations.Update(listingId, fields);
        }

    }
}
