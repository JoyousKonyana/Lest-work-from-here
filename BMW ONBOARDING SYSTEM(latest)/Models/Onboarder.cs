using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BMW_ONBOARDING_SYSTEM.Models
{
    public class Onboarder
    {

     

        [Key]
        public int OnboarderID { get; set; }

        public virtual Employee Employee { get; set; }
        public int EmployeeID { get; set; }


        public virtual List<OnboarderCourseEnrollment> CourseEnrollments { get; set; }

        public virtual ICollection<OnboarderEquipment> OnboarderEquipment { get; set; }

        public virtual List<Achievement> Achievements { get; set; }
        public virtual List<EquipmentQuery> EquipmentQueries { get; set; }


        public Onboarder()
        {
            CourseEnrollments = new List<OnboarderCourseEnrollment>();
            OnboarderEquipment = new HashSet<OnboarderEquipment>();
            Achievements = new List<Achievement>();
            EquipmentQueries = new List<EquipmentQuery>();

        }

    }
}
