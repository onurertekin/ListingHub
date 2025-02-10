using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseModel.Entities
{
    public class City
    {
        public City()
        {
            Districts = new HashSet<District>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int PlateCode { get; set; }

        #region Navigation Properties

        public ISet<District> Districts { get; set; }

        #endregion
    }
}
