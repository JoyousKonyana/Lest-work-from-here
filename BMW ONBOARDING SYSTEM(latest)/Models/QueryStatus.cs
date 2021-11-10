using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BMW_ONBOARDING_SYSTEM.Models
{
    public class QueryStatus
    {
        public int Id { get; set; }
        [StringLength(255)]
        public string EquipmentQueryDescription { get; set; }

        public virtual List<EquipmentQuery> EquipmentQueries { get; set; }

        public QueryStatus()
        {
            EquipmentQueries = new List<EquipmentQuery>();
        }
    }
}
