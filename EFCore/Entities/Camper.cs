using System;
using System.Collections.Generic;

#nullable disable

namespace EFCore.Entities
{
    public partial class Camper
    {
        public Camper()
        {
            CabinCampers = new HashSet<CabinCamper>();
            CamperNextOfKins = new HashSet<CamperNextOfKin>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int AmountCabinsVisited { get; set; }

        public virtual ICollection<CabinCamper> CabinCampers { get; set; }
        public virtual ICollection<CamperNextOfKin> CamperNextOfKins { get; set; }
    }
}
