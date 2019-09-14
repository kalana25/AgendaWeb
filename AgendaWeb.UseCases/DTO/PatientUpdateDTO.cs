using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace AgendaWeb.UseCases.DTO
{
    public class PatientUpdateDTO
    {
        [MaxLength(100)]
        public string FristName { get; set; }

        [MaxLength(100)]
        public string LastName { get; set; }

        [MaxLength(250)]
        public string OtherNames { get; set; }

        [MaxLength(12)]
        public string NIC { get; set; }

        public AddressInfoDTO Address { get; set; }

        public CommunicationInfoDTO Communication { get; set; }
    }
}
