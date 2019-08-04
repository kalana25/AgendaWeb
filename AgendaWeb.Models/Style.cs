using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace AgendaWeb.Models
{
    public class Style
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        public string BackgroundColor { get; set; }
        [Required]
        public string FontColor { get; set; }
        public bool CustomStyle { get; set; }

        public ICollection<Service> Services { get; set; }
    }
}
