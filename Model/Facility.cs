using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Facility
    {
        public Facility(int facilityId, string name)
        {
            FacilityID = facilityId;
            Name = name;
        }
        public int FacilityID { get; set; }
        public string Name { get; set; }

        public Facility()
        {
            
        }

        public override string ToString()
        {
            return $"FacilityID: {FacilityID}, Name: {Name}";
        }
    }
}
