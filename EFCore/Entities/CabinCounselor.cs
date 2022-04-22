using System;
using System.Collections.Generic;

#nullable disable

namespace EFCore.Entities
{
    public partial class CabinCounselor
    {
        public int Id { get; set; }
        public int CabinId { get; set; }
        public int CounselorId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsActiveBooking { get; set; }
        public virtual Cabin Cabin { get; set; }
        public virtual Counselor Counselor { get; set; }
    }
}
