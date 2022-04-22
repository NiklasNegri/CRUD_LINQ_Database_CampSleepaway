using System;
using System.Collections.Generic;

#nullable disable

namespace EFCore.Entities
{
    public partial class NextOfKin
    {
        public NextOfKin()
        {
            CamperNextOfKins = new HashSet<CamperNextOfKin>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string EmergencyPhoneNumber { get; set; }

        public virtual ICollection<CamperNextOfKin> CamperNextOfKins { get; set; }
    }
}
