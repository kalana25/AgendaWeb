using System;
using System.Collections.Generic;
using System.Text;
using AgendaWeb.Core.Interfaces;
using AgendaWeb.Repositories;
using AgendaWeb.Models;
using System.Threading.Tasks;
using AgendaWeb.UseCases.DTO;
using AutoMapper;

namespace AgendaWeb.UseCases.General.ResourceProfiles.UpdateResourceProfile
{
    public class UpdateResourceProfileUseCase:UseCase
    {
        public ResourceProfileDTO DTO { get; set; }

        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public UpdateResourceProfileUseCase(
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public async Task<ResourceProfile> Execute()
        {
            ResourceProfile resoruceProfile = this.mapper.Map<ResourceProfileDTO, ResourceProfile>(this.DTO);
            ResourceProfile alreadyExistOne = await this.unitOfWork.ResourceProfile.Get(resoruceProfile.Id);
            resoruceProfile.Id = alreadyExistOne.Id;
            alreadyExistOne = resoruceProfile;
            int result = await this.unitOfWork.Complete();
            return resoruceProfile;
        }
    }
}
