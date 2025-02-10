using Contract.Request.Fields;
using Contract.Response.Fields;

using Host.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Host.Controllers.v1.ListingHubApi.Field
{
    [ApiController]
    [Route("listing-api/fields")]
    public class FieldsController : ControllerBase
    {
        private readonly HttpHelper httpHelper;
        private readonly string listingHubApiUrl;
        public FieldsController(HttpHelper httpHelper, IConfiguration configuration)
        {
            this.httpHelper = httpHelper;
            this.listingHubApiUrl = configuration.GetValue<string>("Services:ListingHubApi");
        }

        [HttpGet]
        //[Authorizable("Fields_List")]
        [RequiredHeaderParameters("Token")]
        public async Task<ActionResult<SearchFieldsResponse>> Search([FromQuery] SearchFieldsRequest request)
        {
            SearchFieldsResponse response = new SearchFieldsResponse();
            string url = ($"{listingHubApiUrl}/listing-api/fields?fieldName={request.fieldName}&fieldType={request.fieldType}&isRequired={request.isRequired}&pageSize={request.pageSize}&pageNumber={request.pageNumber}&sortBy={request.sortBy}&sortDirection={request.sortDirection}");
            response = await httpHelper.Get<SearchFieldsResponse>(url);
            return new JsonResult(response);
        }

        [HttpGet("{id}")]
        //[Authorizable("Fields_GetSingle")]
        [RequiredHeaderParameters("Token")]
        public async Task<ActionResult<GetSingleFieldsResponse>> GetSingle(int id)
        {
            GetSingleFieldsResponse response = new GetSingleFieldsResponse();
            string url = ($"{listingHubApiUrl}/listing-api/fields/{id}");
            response = await httpHelper.Get<GetSingleFieldsResponse>(url);
            return new JsonResult(response);
        }

        [HttpPost]
        //[Authorizable("Fields_Create")]
        [RequiredHeaderParameters("Token")]
        public async Task Create([FromBody] CreateFieldsRequest request)
        {
            await httpHelper.Create($"{listingHubApiUrl}/listing-api/fields", request);
        }

        [HttpPut("{id}")]
        //[Authorizable("Fields_Update")]
        [RequiredHeaderParameters("Token")]
        public async Task Update([FromBody] UpdateFieldsRequest request, int id)
        {
            await httpHelper.Update($"{listingHubApiUrl}/listing-api/fields/{id}", request);
        }

        [HttpDelete("{id}")]
        //[Authorizable("Fields_Delete")]
        [RequiredHeaderParameters("Token")]
        public async Task Delete(int id)
        {
            await httpHelper.Delete($"{listingHubApiUrl}/listing-api/fields/{id}");
        }
    }
}
