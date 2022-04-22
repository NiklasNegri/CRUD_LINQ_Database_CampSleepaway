using System;
using System.Collections.Generic;

#nullable disable

namespace EFCore.Entities
{
    public partial class Cabin
    {
        public Cabin()
        {
            CabinCampers = new HashSet<CabinCamper>();
            CabinCounselors = new HashSet<CabinCounselor>();
        }

        public int Id { get; set; }

        public virtual ICollection<CabinCamper> CabinCampers { get; set; }
        public virtual ICollection<CabinCounselor> CabinCounselors { get; set; }
    }
}
