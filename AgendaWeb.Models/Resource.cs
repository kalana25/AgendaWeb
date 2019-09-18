using System;
using System.Collections.Generic;
using System.Text;
using AgendaWeb.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgendaWeb.Models
{
    public class Resource
    {
        public int Id { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(250)]
        public string Description { get; set; }

        [MaxLength(5)]
        public string Abbreviation { get; set; }

        public bool Enabled { get; set; }

        public bool Plannable { get; set; }

        [Required]
        public ResourceCategory CategoryId { get; set; }

        [Required]
        [ForeignKey("Style")]
        public int StyleId { get; set; }

        public int CollaboratorId { get; set; }


        public Style Style { get; set; }

        public Collaborator Collaborator { get; set; }

        public ICollection<ResourceResourceProfile> ResourceResourceProfiles { get; set; }

    }
}
