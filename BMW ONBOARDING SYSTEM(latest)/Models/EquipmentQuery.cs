using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BMW_ONBOARDING_SYSTEM.Models
{
    public partial class EquipmentQuery
    {
        public int Id { get; set; }
        public virtual Equipment Equipment { get; set; }
        public int EquipmentId { get; set; }

        public virtual Onboarder Onboarder { get; set; }
        public int OnboarderID { get; set; }

        public virtual QueryStatus QueryStatus { get; set; }
        public int QueryStatusId { get; set; }

        public string EquipmentQueryDescription { get; set; }
        public DateTime? EquipmentQueryDate { get; set; }
    }
}
