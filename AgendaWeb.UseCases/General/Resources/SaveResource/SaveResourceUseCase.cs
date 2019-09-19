using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using AgendaWeb.Models;
using System.Threading.Tasks;
using AgendaWeb.UseCases.DTO;
using AutoMapper;
using AgendaWeb.Core.Interfaces;
using AgendaWeb.Repositories;
namespace AgendaWeb.UseCases.General.Resources.SaveResource
{
    public class SaveResourceUseCase:UseCase
    {
        public ResourceSaveDTO DTO { get; set; }

        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public SaveResourceUseCase(
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public async Task<Resource> Execute()
        {
            Resource resource = this.mapper.Map<ResourceSaveDTO, Resource>(this.DTO);
            var resourceResourceProfile = DTO.ResourceProfileIds.Select(x => new ResourceResourceProfile() { ResourceProfileId = x }).ToList();
            resource.ResourceResourceProfiles = resourceResourceProfile;
            this.unitOfWork.Resources.Add(resource);
            await this.unitOfWork.Complete();
            return resource;
        }
    }
}
