using DatabaseModel;
using DatabaseModel.Entities;
using DomainService.Base;
using DomainService.Exceptions;
using DomainService.Extensions;
using DomainService.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace DomainService.Operations
{
    public class ListingFieldOperations : DbContextHelper, IListingFieldOperations
    {
        private readonly MainDbContext mainDbContext;
        public ListingFieldOperations(MainDbContext mainDbContext) : base(mainDbContext)
        {
            this.mainDbContext = mainDbContext;
        }

        public IList<ListingField> Search(int listingId, int? fieldId, string? value, string sortBy, string sortDirection, int pageSize, int pageNumber, out int totalCount)
        {
            var query = mainDbContext.ListingFields.Include(x => x.Field).AsQueryable();
         
            query = query.Where(x => x.ListingId == listingId);

            if (fieldId.HasValue)
                query = query.Where(x => x.FieldId == fieldId);

            if (!string.IsNullOrEmpty(value))
                query = query.Where(x => x.Value == value);

            return query.GetPagedAndSorted(pageNumber, pageSize, sortDirection, sortBy, out totalCount);
        }

        public void Update(int listingId, Dictionary<int, string> fields)
        {
            var listing = mainDbContext.Listings.Include(x => x.ListingFields).Where(x => x.Id == listingId).SingleOrDefault();
            if (listing == null)
                throw new BusinessException(404, "İlan bulunamadı");

            foreach (var field in fields)
            {
                var _field = listing.ListingFields.SingleOrDefault(x => x.FieldId == field.Key);

                if (_field == null)
                {
                    //Ekleme yap.
                    var newField = new ListingField
                    {
                        FieldId = field.Key, // Foreign Key olan FieldId'yi ayarlıyoruz
                        Value = field.Value,
                        ListingId = listingId
                    };

                    SaveEntity(newField);
                }
                else
                {
                    //Güncelleme yap.
                    _field.Value = field.Value;
                    UpdateEntity(_field);
                }
            }
        }

    }
}
