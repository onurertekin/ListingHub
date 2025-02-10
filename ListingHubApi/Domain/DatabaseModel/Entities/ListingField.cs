namespace DatabaseModel.Entities
{
    public class ListingField
    {
        public int Id { get; set; }
        public int ListingId { get; set; }
        public int FieldId { get; set; }
        public string Value { get; set; }

        #region Navigation Property
        public virtual Listing Listing { get; set; }
        public virtual Field Field { get; set; }
        #endregion

    }
}
