using Contract.Request.ListingFields;
using Contract.Response.ListingFields;

using Host.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Host.Controllers.v1.ListingHubApi.ListingField
{
    [ApiController]
    [Route("listing-api/listings/{listingId}/fields")]
    public class ListingFieldsController : ControllerBase
    {
        private readonly HttpHelper httpHelper;
        private readonly string listingHubApiUrl;
        public ListingFieldsController(HttpHelper httpHelper, IConfiguration configuration)
        {
            this.httpHelper = httpHelper;
            this.listingHubApiUrl = configuration.GetValue<string>("Services:ListingHubApi");
        }

        //[Authorizable("ListingFields_Search")]
        [RequiredHeaderParameters("Token")]
        [HttpGet]
        public async Task<ActionResult<SearchListingFieldsResponse>> Search([FromQuery] SearchListingFieldsRequest request, int listingId)
        {
            SearchListingFieldsResponse response = new SearchListingFieldsResponse();
            string url = ($"{listingHubApiUrl}/listing-api/listings/{listingId}/fields?value={request.value}&fieldId={request.fieldId}&pageSize={request.pageSize}&pageNumber={request.pageNumber}&sortBy={request.sortBy}&sortDirection={request.sortDirection}");
            response = await httpHelper.Get<SearchListingFieldsResponse>(url);
            return new JsonResult(response);
        }

        //[Authorizable("ListingFields_Update")]
        [RequiredHeaderParameters("Token")]
        [HttpPut]
        public async Task Update([FromBody] UpdateListingFieldsRequest request, int listingId)
        {
            await httpHelper.Update($"{listingHubApiUrl}/listing-api/listings/{listingId}/field", request);
        }
    }
}
