using DatabaseModel;
using DatabaseModel.Entities;
using DomainService.Base;
using DomainService.Exceptions;
using DomainService.Extensions;
using DomainService.Interface;
using Microsoft.EntityFrameworkCore;

namespace DomainService.Operations
{
    public class ListingOperations : DbContextHelper, IListingOperations
    {
        private readonly MainDbContext mainDbContext;
        public ListingOperations(MainDbContext mainDbContext) : base(mainDbContext)
        {
            this.mainDbContext = mainDbContext;
        }

        public IList<Listing> Search(int? categoryId, string title, decimal? minPrice, decimal? maxPrice, int? cityId, int? districtId, int? neighbourhoodId, int? subNeighbourhoodId, int? userId, DateTime? listingDate, string latlong, string sortBy, string sortDirection, int pageSize, int pageNumber, out int totalCount)
        {
            var query = mainDbContext.Listings.Include(x => x.Category).Include(x => x.ListingPhotos).AsQueryable();

            #region Where Conditions

            if (categoryId.HasValue)
                query = mainDbContext.Listings.Where(x => x.CategoryId == categoryId);

            if (!string.IsNullOrEmpty(title))
                query = mainDbContext.Listings.Where(x => x.Title == title);

            if (minPrice.HasValue)
                query = mainDbContext.Listings.Where(x => x.Price >= minPrice);

            if (maxPrice.HasValue)
                query = mainDbContext.Listings.Where(x => x.Price <= maxPrice);

            if (cityId.HasValue)
                query = mainDbContext.Listings.Where(x => x.CityId == cityId);

            if (districtId.HasValue)
                query = mainDbContext.Listings.Where(x => x.DistrictId == districtId);

            if (neighbourhoodId.HasValue)
                query = mainDbContext.Listings.Where(x => x.NeighbourhoodId == neighbourhoodId);

            if (subNeighbourhoodId.HasValue)
                query = mainDbContext.Listings.Where(x => x.SubNeighbourhoodId == subNeighbourhoodId);

            if (userId.HasValue)
                query = mainDbContext.Listings.Where(x => x.UserId == userId);

            if (listingDate.HasValue)
                query = mainDbContext.Listings.Where(x => x.ListingDate == listingDate);

            if (!string.IsNullOrEmpty(latlong))
                query = mainDbContext.Listings.Where(x => x.LatLong == latlong);

            #endregion

            return query.GetPagedAndSorted(pageNumber, pageSize, sortDirection, sortBy, out totalCount);
        }

        public Listing GetSingle(int id, bool includeDescription = false, bool includeFields = false)
        {
            var query = mainDbContext.Listings.Where(x => x.Id == id).AsQueryable();
            
            if (includeDescription)
                query = query.Include(x => x.Description);

            if (includeFields)
                query = query.Include(x => x.ListingFields);

            var listing = query.SingleOrDefault();
            if (listing == null)
                throw new BusinessException(404, "Kayıt bulunamadı.");

            return listing;
        }

        public void Create(int categoryId, string title, decimal price, int cityId, int districtId, int neighbourhoodId, int subNeighbourhoodId, int userId, DateTime listingDate, string latlong)
        {
            #region Validations

            var currentCategory = mainDbContext.Categories.Where(x => x.Id == categoryId).SingleOrDefault();
            if (currentCategory == null)
                throw new BusinessException(404, "Kategori mevcut değil.");

            var currentCityId = mainDbContext.Cities.Where(x => x.Id == cityId).SingleOrDefault();
            if (currentCityId == null)
                throw new BusinessException(404, "Şehir mevcut değil.");

            var currentDistrictId = mainDbContext.Districts.Where(x => x.Id == districtId);
            if (currentDistrictId == null)
                throw new BusinessException(404, "İlçe mevcut değil.");

            var currentNeighbourhood = mainDbContext.Neighbourhoods.Where(x => x.Id == neighbourhoodId);
            if (currentNeighbourhood == null)
                throw new BusinessException(404, "Semt mevcut değil.");

            var currentSubNeighbourhood = mainDbContext.SubNeighbourhoods.Where(x => x.Id == neighbourhoodId);
            if (currentSubNeighbourhood == null)
                throw new BusinessException(404, "Mahalle mevcut değil.");


            #endregion

            var listing = new Listing();
            listing.NeighbourhoodId = neighbourhoodId;
            listing.SubNeighbourhoodId = subNeighbourhoodId;
            listing.CategoryId = categoryId;
            listing.Title = title;
            listing.CityId = cityId;
            listing.Price = price;
            listing.DistrictId = districtId;
            listing.LatLong = latlong;
            listing.UserId = userId;
            listing.ListingDate = listingDate;
            listing.Description = new ListingDescription()
            {
                Description = ""
            };

            SaveEntity(listing);
        }

        public void Update(int id, int categoryId, string title, decimal price, int cityId, int districtId, int neighbourhoodId, int subNeighbourhoodId, int userId, DateTime listingDate, string latlong)
        {
            #region Validations

            var listing = mainDbContext.Listings.Where(x => x.Id == id).SingleOrDefault();
            if (listing == null)
                throw new BusinessException(404, "İlan mevcut değil.");

            var currentCategory = mainDbContext.Categories.Where(x => x.Id == categoryId).SingleOrDefault();
            if (currentCategory == null)
                throw new BusinessException(404, "Kategori mevcut değil.");

            var currentCityId = mainDbContext.Cities.Where(x => x.Id == cityId).SingleOrDefault();
            if (currentCityId == null)
                throw new BusinessException(404, "Şehir mevcut değil.");

            var currentDistrictId = mainDbContext.Districts.Where(x => x.Id == districtId);
            if (currentDistrictId == null)
                throw new BusinessException(404, "İlçe mevcut değil.");

            var currentNeighbourhood = mainDbContext.Neighbourhoods.Where(x => x.Id == neighbourhoodId);
            if (currentNeighbourhood == null)
                throw new BusinessException(404, "Semt mevcut değil.");

            var currentSubNeighbourhood = mainDbContext.SubNeighbourhoods.Where(x => x.Id == neighbourhoodId);
            if (currentSubNeighbourhood == null)
                throw new BusinessException(404, "Mahalle mevcut değil.");

            #endregion

            listing.NeighbourhoodId = neighbourhoodId;
            listing.SubNeighbourhoodId = subNeighbourhoodId;
            listing.CategoryId = categoryId;
            listing.Title = title;
            listing.CityId = cityId;
            listing.Price = price;
            listing.DistrictId = districtId;
            listing.LatLong = latlong;
            listing.UserId = userId;
            listing.ListingDate = listingDate;

            UpdateEntity(listing);
        }

        public void Delete(int id)
        {
            var listing = mainDbContext.Listings.Where(x => x.Id == id).SingleOrDefault();

            if (listing == null)
                throw new BusinessException(404, "İlan mevcut değil.");

            DeleteEntity(listing);
        }
    }
}
