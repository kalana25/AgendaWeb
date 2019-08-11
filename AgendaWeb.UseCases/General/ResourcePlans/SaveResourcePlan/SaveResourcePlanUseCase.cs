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

namespace AgendaWeb.UseCases.General.ResourcePlans.SaveResourcePlan
{
    public class SaveResourcePlanUseCase : UseCase
    {
        public ResourcePlanSaveDTO DTO { get; set; }

        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public SaveResourcePlanUseCase(
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public async Task<ResourcePlan> Execute()
        {
            ResourcePlan resourcePlan = this.mapper.Map<ResourcePlanSaveDTO, ResourcePlan>(this.DTO);
            var resourcePlanProfiles = DTO.ResourceProfileIds.Select(x => new ResourcePlanProfile() { ResourceProfileId = x }).ToList();
            resourcePlan.PlanProfiles = resourcePlanProfiles;
            this.unitOfWork.ResourcePlans.Add(resourcePlan);
            int result = await this.unitOfWork.Complete();
            return resourcePlan;
        }
    }
}
