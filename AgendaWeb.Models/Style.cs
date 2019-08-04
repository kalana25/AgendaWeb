using System;
using System.Collections.Generic;
using System.Text;

namespace AgendaWeb.Models
{
    public class Style
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string BackgroundColor { get; set; }
        public string FontColor { get; set; }
        public bool CustomStyle { get; set; }

        public ICollection<Service> Services { get; set; }
    }
}
