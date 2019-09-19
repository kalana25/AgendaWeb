using System;
using System.Collections.Generic;
using AgendaWeb.Models.Enums;
using System.Text;

namespace AgendaWeb.UseCases.DTO
{
    public class ResourceWithFullInfoDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Abbreviation { get; set; }

        public bool Enabled { get; set; }

        public bool Plannable { get; set; }

        public ResourceCategory CategoryId { get; set; }


        public StyleDTO Style { get; set; }

        public CollaboratorInfoDTO Collaborator { get; set; }

        public List<ResourceProfileInfoDTO> ResourceProfiles { get; set; }

    }
}
