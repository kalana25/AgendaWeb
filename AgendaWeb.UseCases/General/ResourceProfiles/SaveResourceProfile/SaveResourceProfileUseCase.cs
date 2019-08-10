using System;
using System.Collections.Generic;
using System.Text;
using AgendaWeb.Core.Interfaces;
using AgendaWeb.Repositories;
using AgendaWeb.Models;
using System.Threading.Tasks;
using AgendaWeb.UseCases.DTO;
using AutoMapper;



namespace AgendaWeb.UseCases.General.ResourceProfiles.SaveResourceProfile
{
    public class SaveResourceProfileUseCase : UseCase
    {
        public ResourceProfileDTO DTO { get; set; }

        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public SaveResourceProfileUseCase(
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<ResourceProfile> Execute()
        {
            ResourceProfile resourceProfile = this.mapper.Map<ResourceProfileDTO, ResourceProfile>(this.DTO);
            this.unitOfWork.ResourceProfile.Add(resourceProfile);
            int result = await this.unitOfWork.Complete();
            return resourceProfile;
        }
    }
}
