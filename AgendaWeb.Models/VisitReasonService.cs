using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgendaWeb.Models
{
    public class VisitReasonService
    {
        public int Id { get; set; }

        [Required]
        [ForeignKey("Service")]
        public int ServiceId { get; set; }

        [Required]
        [ForeignKey("VisitReason")]
        public int VisitReasonId { get; set; }

        public VisitReason VisitReason { get; set; }
        public Service Service { get; set; }
    }
}
