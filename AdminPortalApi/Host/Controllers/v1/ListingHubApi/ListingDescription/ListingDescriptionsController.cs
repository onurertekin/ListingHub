using Contract.Request.ListingDescriptions;
using Contract.Response.ListingDescriptions;

using Host.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Host.Controllers.v1.ListingHubApi.ListingDescription
{
    [ApiController]
    [Route("listing-api/listings/{listingId}/description")]
    public class ListingDescriptionsController : ControllerBase
    {
        private readonly HttpHelper httpHelper;
        private readonly string listingHubApiUrl;
        public ListingDescriptionsController(HttpHelper httpHelper, IConfiguration configuration)
        {
            this.httpHelper = httpHelper;
            this.listingHubApiUrl = configuration.GetValue<string>("Services:ListingHubApi");
        }

        //[Authorizable("ListingDescription_GetSingle")]
        [RequiredHeaderParameters("Token")]
        [HttpGet("{id}")]
        public async Task<ActionResult<GetSingleListingDescriptionResponse>> GetSingle(int listingId)
        {
            GetSingleListingDescriptionResponse response = new GetSingleListingDescriptionResponse();
            string url = ($"{listingHubApiUrl}/listing-api/listings/{listingId}/description");
            response = await httpHelper.Get<GetSingleListingDescriptionResponse>(url);
            return new JsonResult(response);
        }

        //[Authorizable("ListingDescription_Update")]
        [RequiredHeaderParameters("Token")]
        [HttpPut]
        public async Task Update([FromBody] UpdateListingDescriptionsRequest request, int listingId)
        {
            await httpHelper.Update($"{listingHubApiUrl}/listing-api/listings/{listingId}/description", request);
        }
    }
}
