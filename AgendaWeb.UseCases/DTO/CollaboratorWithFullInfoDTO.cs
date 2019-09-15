using System;
using System.Collections.Generic;
using System.Text;

namespace AgendaWeb.UseCases.DTO
{
    public class CollaboratorWithFullInfoDTO
    {
        public int Id { get; set; }

        public string FristName { get; set; }

        public string LastName { get; set; }

        public string OtherNames { get; set; }

        public string NIC { get; set; }

        public string RegistrationNo { get; set; }

        public AddressInfoDTO Address { get; set; }

        public CommunicationInfoDTO Communication { get; set; }
    }
}
