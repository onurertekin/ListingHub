using Contract.Request.ListingDescriptions;
using Contract.Response.ListingDescriptions;
using DomainService.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Host.Controllers
{
    [ApiController]
    [Route("listing-api/listings/{listingId}/description")]
    public class ListingDescriptionsController : ControllerBase
    {
        private readonly IListingDescriptionOperations listingDescriptionOperations;
        public ListingDescriptionsController(IListingDescriptionOperations listingDescriptionOperations)
        {
            this.listingDescriptionOperations = listingDescriptionOperations;
        }

        [HttpGet]
        public ActionResult<GetSingleListingDescriptionResponse> GetSingle(int listingId)
        {
            var listingDescription = listingDescriptionOperations.GetSingle(listingId);
            var response = new GetSingleListingDescriptionResponse();

            response.description = listingDescription.Description;

            return response;
        }

        [HttpPut]
        public void Update(int listingId, [FromBody] UpdateListingDescriptionsRequest request)
        {
            listingDescriptionOperations.Update(listingId, request.description);
        }
    }
}
