using System;
using System.Collections.Generic;
using System.Text;

namespace AgendaWeb.UseCases.DTO
{
    public class StyleDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string BackgroundColor { get; set; }
        public string FontColor { get; set; }
        public bool CustomStyle { get; set; }
    }
}
