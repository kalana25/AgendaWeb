using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgendaWeb.Models
{
    public class ResourceResourceProfile
    {
        public int Id { get; set; }

        [Required]
        [ForeignKey("Resource")]
        public int ResourceId { get; set; }

        [Required]
        [ForeignKey("ResourceProfile")]
        public int ResourceProfileId { get; set; }

        public Resource Resource { get; set; }

        public ResourceProfile ResourceProfile { get; set; }

    }
}
