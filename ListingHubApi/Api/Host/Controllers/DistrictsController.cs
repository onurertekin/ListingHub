using Contract.Request.Districts;
using Contract.Response.Districts;
using DomainService.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Host.Controllers
{
    [ApiController]
    [Route("listing-api/districts")]
    public class DistrictsController : ControllerBase
    {
        private readonly IDistrictOperations districtOperations;
        public DistrictsController(IDistrictOperations districtOperations)
        {
            this.districtOperations = districtOperations;
        }

        [HttpGet]
        public ActionResult<SearchDistrictsResponse> Search([FromQuery] SearchDistrictsRequest request)
        {
            var districts = districtOperations.Search(request.name, request.cityId, request.sortBy, request.sortDirection, request.pageSize, request.pageNumber, out int totalCount);
            var response = new SearchDistrictsResponse();

            foreach (var district in districts)
            {
                response.districts.Add(new SearchDistrictsResponse.District()
                {
                    name = district.Name,
                    cityId = district.CityId,
                });
            }

            return new JsonResult(response);
        }
        [HttpGet("{id}")]
        public ActionResult<GetSingleDistrictResponse> GetSingle(int id)
        {
            var district = districtOperations.GetSingle(id);
            var response = new GetSingleDistrictResponse();

            response.name = district.Name;
            response.cityId = district.CityId;

            return response;
        }

    }
}
