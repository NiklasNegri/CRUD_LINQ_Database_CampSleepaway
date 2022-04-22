using System;
using System.Collections.Generic;

#nullable disable

namespace EFCore.Entities
{
    public partial class CamperNextOfKin
    {
        public int Id { get; set; }
        public int CamperId { get; set; }
        public int NextOfKinId { get; set; }

        public virtual Camper Camper { get; set; }
        public virtual NextOfKin NextOfKin { get; set; }
    }
}
