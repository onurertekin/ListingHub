using Contract.Request.Categories;
using Contract.Response.Categories;
using DomainService.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Host.Controllers
{
    [ApiController]
    [Route("listing-api/categories")]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryOperations categoryOperations;
        public CategoriesController(ICategoryOperations categoryOperations)
        {
            this.categoryOperations = categoryOperations;
        }

        [HttpGet]
        public ActionResult<SearchCategoriesResponse> Search([FromQuery] SearchCategoriesRequest request)
        {
            var categories = categoryOperations.Search(request.name, request.parentCategoryId, request.fieldType, request.createdOn, request.updatedOn, request.sortBy, request.sortDirection, request.pageSize, request.pageNumber, out int totalCount);
            var response = new SearchCategoriesResponse();

            foreach (var category in categories)
            {
                response.categories.Add(new SearchCategoriesResponse.Category()
                {
                    id = category.Id,
                    name = category.Name,
                    parentCategoryId = category.ParentCategoryId,
                    fieldType = category.FieldType,
                    createdOn = category.CreatedOn,
                    updatedOn = category.UpdatedOn,
                });
            }
            return new JsonResult(response);
        }

        [HttpGet("{id}")]
        public ActionResult<GetSingleCategoriesResponse> GetSingle(int id)
        {
            var category = categoryOperations.GetSingle(id);
            var response = new GetSingleCategoriesResponse();

            response.id = id;
            response.name = category.Name;
            response.updatedOn = category.UpdatedOn;
            response.parentCategoryId = category.ParentCategoryId;
            response.createdOn = category.CreatedOn;
            response.fieldType = category.FieldType;

            return response;
        }

        [HttpPost]
        public void Create([FromBody] CreateCategoriesRequest request)
        {
            categoryOperations.Create(request.name, request.parentCategoryId, request.fieldType, request.createdOn);
        }

        [HttpPut("{id}")]
        public void Update([FromBody] UpdateCategoriesRequest request, int id)
        {
            categoryOperations.Update(id, request.name, request.parentCategoryId, request.fieldType, request.updatedOn);
        }

        [HttpDelete]
        public void Delete(int id)
        {
            categoryOperations.Delete(id);
        }
    }
}
