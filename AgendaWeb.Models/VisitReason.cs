using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgendaWeb.Models
{
    public class VisitReason
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(250)]
        public string Description { get; set; }

        [Required]
        public int Duration { get; set; }

        public bool Enabled { get; set; }

        [Required]
        public string Abreviation { get; set; }

        [Required]
        [ForeignKey("Speciality")]
        public int SpecialityId { get; set; }

        [Required]
        [ForeignKey("ResourcePlan")]
        public int ResourcePlanId { get; set; }


        public Speciality Speciality { get; set; }

        public ResourcePlan ResourcePlan { get; set; }

        public ICollection<VisitReasonService> VisitReasonServices { get; set; }

    }
}
