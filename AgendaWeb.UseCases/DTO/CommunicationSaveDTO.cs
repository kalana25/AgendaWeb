using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace AgendaWeb.UseCases.DTO
{
    public class CommunicationSaveDTO
    {
        public int Medium { get; set; }

        [MaxLength(100)]
        public string Value { get; set; }

        [MaxLength(250)]
        public string Comment { get; set; }
    }
}
