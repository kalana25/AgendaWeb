using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using AgendaWeb.UseCases.DTO;
using AgendaWeb.Models;
using AgendaWeb.Repositories;
using System.Threading.Tasks;
using AgendaWeb.Core.Interfaces;

namespace AgendaWeb.UseCases.General.ResourcePlans.GetResourcePlanWithProfiles
{
    public class GetResourcePlanWithProfileUseCase : UseCase
    {
        public int Id { get; set; }

        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public GetResourcePlanWithProfileUseCase(
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public async Task<ResourcePlanWithProfileInfoDTO> Execute()
        {
            ResourcePlan resourcePlan = await unitOfWork.ResourcePlans.GetResourcePlanWithProfiles(this.Id);
            ResourcePlanWithProfileInfoDTO result = mapper.Map<ResourcePlan, ResourcePlanWithProfileInfoDTO>(resourcePlan);
            return result;
        }
    }
}
