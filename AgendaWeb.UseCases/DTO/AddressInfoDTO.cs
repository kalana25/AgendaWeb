using System;
using System.Collections.Generic;
using System.Text;

namespace AgendaWeb.UseCases.DTO
{
    public class AddressInfoDTO
    {
        public int Id { get; set; }

        public string No { get; set; }

        public string Street { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string ZipCode { get; set; }
    }
}
