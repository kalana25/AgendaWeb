using System;
using System.Collections.Generic;
using System.Text;
using AgendaWeb.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgendaWeb.Models
{
    public class Patient
    {
        public int Id { get; set; }

        [MaxLength(100)]
        public string FristName { get; set; }

        [MaxLength(100)]
        public string LastName { get; set; }

        [MaxLength(250)]
        public string OtherNames { get; set; }

        [MaxLength(12)]
        public string NIC { get; set; }

        [ForeignKey("Address")]
        public int AddressId { get; set; }

        [ForeignKey("Communication")]
        public int CommunicationId { get; set; }

        public Address Address { get; set; }

        public Communication Communication { get; set; }

    }
}
