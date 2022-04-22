using System;
using System.Collections.Generic;

#nullable disable

namespace EFCore.Entities
{
    public partial class Counselor
    {
        public Counselor()
        {
            CabinCounselors = new HashSet<CabinCounselor>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int HoursWorkedWeekly { get; set; }

        public virtual ICollection<CabinCounselor> CabinCounselors { get; set; }
    }
}
