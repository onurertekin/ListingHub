namespace DatabaseModel.Entities
{
    public class Listing
    {
        public Listing()
        {
            ListingFields = new HashSet<ListingField>();
        }
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public int CityId { get; set; }
        public int DistrictId { get; set; }
        public int NeighbourhoodId { get; set; }
        public int SubNeighbourhoodId { get; set; }
        public int UserId { get; set; }
        public DateTime ListingDate { get; set; }
        public string LatLong { get; set; }

        #region Navigation Property

        public virtual City City { get; set; }
        public virtual District District { get; set; }
        public virtual Neighbourhood Neighbourhood { get; set; }
        public virtual SubNeighbourhood SubNeighbourhood { get; set; }
        public virtual Category Category { get; set; }
        public virtual ListingDescription Description { get; set; }
        public virtual ISet<ListingField> ListingFields { get; set; }
        public ISet<ListingPhoto> ListingPhotos { get; set; }

        #endregion
    }
}