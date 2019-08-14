using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AgendaWeb.Core.Interfaces;
using AgendaWeb.Repositories;
using AgendaWeb.Models;
using AgendaWeb.UseCases.DTO;

namespace AgendaWeb.UseCases.General.ResourcePlans.UpdateResourcePlan
{
    public class UpdateResourcePlanUseCase : UseCase
    {
        public ResourcePlanUpdateDTO DTO { get; set; }

        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public UpdateResourcePlanUseCase(
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }
        
        public async Task<ResourcePlan> Execute()
        {
            ResourcePlan resourcePlan = this.mapper.Map<ResourcePlanUpdateDTO, ResourcePlan>(this.DTO);
            ResourcePlan alreadyExistOne = await this.unitOfWork.ResourcePlans.Get(resourcePlan.Id);
            resourcePlan.Id = alreadyExistOne.Id;
            alreadyExistOne = resourcePlan;
            int result = await this.unitOfWork.Complete();
            return resourcePlan;
        }
    }
}
