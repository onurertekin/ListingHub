namespace DatabaseModel.Entities
{
    public class District
    {
        public District()
        {
            Neighbourhoods = new HashSet<Neighbourhood>();
        }

        public int Id { get; set; }
        public int CityId { get; set; }
        public string Name { get; set; }

        #region Navigation Properties

        public virtual City City { get; set; }
        public virtual ISet<Neighbourhood> Neighbourhoods { get; set; }

        #endregion
    }
}
