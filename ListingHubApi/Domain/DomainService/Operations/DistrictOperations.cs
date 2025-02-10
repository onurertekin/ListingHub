using DatabaseModel;
using DatabaseModel.Entities;
using DomainService.Base;
using DomainService.Exceptions;
using DomainService.Extensions;
using DomainService.Interface;

namespace DomainService.Operations
{
    public class DistrictOperations : DbContextHelper, IDistrictOperations
    {
        private readonly MainDbContext mainDbContext;
        public DistrictOperations(MainDbContext mainDbContext) : base(mainDbContext)
        {
            this.mainDbContext = mainDbContext;
        }

        public IList<District> Search(string? name, int? cityId, string sortBy, string sortDirection, int pageSize, int pageNumber, out int totalCount)
        {
            var query = mainDbContext.Districts.AsQueryable();

            if (!string.IsNullOrEmpty(name))
                query = mainDbContext.Districts.Where(x => x.Name == name);

            if (cityId.HasValue)
                query = mainDbContext.Districts.Where(x => x.CityId == cityId);

            return query.GetPagedAndSorted(pageNumber, pageSize, sortDirection, sortBy, out totalCount);
        }

        public District GetSingle(int id)
        {
            var district = mainDbContext.Districts.Where(x => x.Id == id).SingleOrDefault();

            if (district == null)
                throw new BusinessException(404, "İlçe bulunamadı.");

            return district;
        }
    }
}
