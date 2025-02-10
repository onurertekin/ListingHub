using Contract.Request.Categories;
using Contract.Response.Categories;

using Host.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Host.Controllers.v1.ListingHubApi.Category
{
    [ApiController]
    [Route("listing-api/categories")]
    public class CategoriesController : ControllerBase
    {
        private readonly HttpHelper httpHelper;
        private readonly string listingHubApiUrl;
        public CategoriesController(HttpHelper httpHelper, IConfiguration configuration)
        {
            this.httpHelper = httpHelper;
            this.listingHubApiUrl = configuration.GetValue<string>("Services:ListingHubApi");
        }

        ////[Authorizable("Categories_List")]
        //[RequiredHeaderParameters("Token")]
        [HttpGet]
        public async Task<ActionResult<SearchCategoriesResponse>> Search([FromQuery] SearchCategoriesRequest request)
        {
            SearchCategoriesResponse response = new SearchCategoriesResponse();
            string url = ($"{listingHubApiUrl}/listing-api/categories?name={request.name}&parentCategoryId={request.parentCategoryId}&fieldType={request.fieldType}&createdOn={request.createdOn}&updatedOn={request.updatedOn}&pageSize={request.pageSize}&pageNumber={request.pageNumber}&sortDirection={request.sortDirection}&sortBy={request.sortBy}");
            response = await httpHelper.Get<SearchCategoriesResponse>(url);
            return new JsonResult(response);
        }

        //[Authorizable("Categories_GetSingle")]
        [RequiredHeaderParameters("Token")]
        [HttpGet("{id}")]
        public async Task<ActionResult<GetSingleCategoriesResponse>> GetSingle(int id)
        {
            GetSingleCategoriesResponse response = new GetSingleCategoriesResponse();
            string url = ($"{listingHubApiUrl}/listing-api/categories/{id}");
            response = await httpHelper.Get<GetSingleCategoriesResponse>(url);
            return new JsonResult(response);
        }

        //[Authorizable("Categories_Create")]
        [RequiredHeaderParameters("Token")]
        [HttpPost]
        public async Task Create([FromBody] CreateCategoriesRequest request)
        {
            await httpHelper.Create($"{listingHubApiUrl}/listing-api/categories", request);
        }

        //[Authorizable("Categories_Update")]
        [RequiredHeaderParameters("Token")]
        [HttpPut("{id}")]
        public async Task Update([FromBody] UpdateCategoriesRequest request, int id)
        {
            await httpHelper.Update($"{listingHubApiUrl}/listing-api/categories/{id}", request);
        }

        //[Authorizable("Categories_Delete")]
        [RequiredHeaderParameters("Token")]
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await httpHelper.Delete($"{listingHubApiUrl}/listing-api/categories/{id}");
        }
    }
}
