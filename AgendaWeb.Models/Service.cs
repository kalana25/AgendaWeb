using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgendaWeb.Models
{
    public class Service
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Enabled { get; set; }

        [ForeignKey("Speciality")]
        public int SpecialityId { get; set; }
        [ForeignKey("Style")]
        public int StyleId { get; set; }

        public Style Style { get; set; }
        public Speciality Speciality { get; set; }
    }
}
