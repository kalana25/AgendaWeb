﻿using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgendaWeb.Models
{
    public class Service
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(250)]
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
