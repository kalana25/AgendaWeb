using System;
using System.Collections.Generic;
using System.Text;
using AgendaWeb.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace AgendaWeb.UseCases.DTO
{
    public class ResourceSaveDTO
    {
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
        public int StyleId { get; set; }

        [Required]
        public int CollaboratorId { get; set; }

        public List<int> ResourceProfileIds { get; set; }
    }
}
