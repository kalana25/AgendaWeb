using System;
using System.Collections.Generic;
using System.Text;
using AgendaWeb.Models.Enums;

namespace AgendaWeb.UseCases.DTO
{
    public class CommunicationInfoDTO
    {
        public int Id { get; set; }

        public CommunicationMedium Medium { get; set; }

        public string Value { get; set; }

        public string Comment { get; set; }
    }
}
