using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace AgendaWeb.UseCases.DTO
{
    public class ResourcePlanSaveDTO
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(250)]
        public string Description { get; set; }

        public List<int> ResourceProfileIds { get; set; }
    }
}
