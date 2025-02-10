using DatabaseModel;
using DatabaseModel.Entities;
using DomainService.Base;
using DomainService.Exceptions;
using DomainService.Extensions;
using DomainService.Interface;

namespace DomainService.Operations
{
    public class CityOperations : DbContextHelper, ICityOperations
    {
        private readonly MainDbContext mainDbContext;
        public CityOperations(MainDbContext mainDbContex) : base(mainDbContex)
        {
            this.mainDbContext = mainDbContex;
        }

        public IList<City> Search(string? name, int? plateCode, string sortBy, string sortDirection, int pageSize, int pageNumber, out int totalCount)
        {
            var query = mainDbContext.Cities.AsQueryable();

            if (!string.IsNullOrEmpty(name))
                query = mainDbContext.Cities.Where(x => x.Name == name);

            if (plateCode.HasValue)
                query = mainDbContext.Cities.Where(x => x.PlateCode == plateCode);

            return query.GetPagedAndSorted(pageNumber, pageSize, sortDirection, sortBy, out totalCount);
        }

        public City GetSingle(int id)
        {
            var city = mainDbContext.Cities.Where(x => x.Id == id).SingleOrDefault();

            if (city == null)
                throw new BusinessException(404, "Şehir bulunamadı.");

            return city;
        }

    }
}
