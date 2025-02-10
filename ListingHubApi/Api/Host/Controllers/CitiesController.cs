using Contract.Request.Cities;
using Contract.Response.Cities;
using DomainService.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Host.Controllers
{
    [ApiController]
    [Route("listing-api/cities")]
    public class CitiesController : ControllerBase
    {
        private readonly ICityOperations cityOperations;
        public CitiesController(ICityOperations cityOperations)
        {
            this.cityOperations = cityOperations;
        }

        [HttpGet]
        public ActionResult<SearchCitiesResponse> Search([FromQuery] SearchCitiesRequest request)
        {
            var cities = cityOperations.Search(request.name, request.plateCode, request.sortBy, request.sortDirection, request.pageSize, request.pageNumber, out int totalCount);
            var response = new SearchCitiesResponse();

            foreach (var city in cities)
            {
                response.cities.Add(new SearchCitiesResponse.City()
                {
                    id = city.Id,
                    name = city.Name,
                    plateCode = city.PlateCode,
                });
            }
            return new JsonResult(response);
        }

        [HttpGet("{id}")]
        public ActionResult<GetSingleCityResponse> GetSingle(int id)
        {
            var city = cityOperations.GetSingle(id);
            var response = new GetSingleCityResponse();

            response.id = city.Id;
            response.name = city.Name;
            response.plateCode = city.PlateCode;

            return response;
        }


    }
}
