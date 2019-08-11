using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using AgendaWeb.Models;
using AgendaWeb.UseCases.DTO;
using System.Threading.Tasks;
using AgendaWeb.Core.Interfaces;
using AgendaWeb.Repositories;

namespace AgendaWeb.UseCases.General.ResourcePlans.GetAllResourcePlansWithProfiles
{
    public class GetAllResourcePlansWithProfileUseCase : UseCase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public GetAllResourcePlansWithProfileUseCase(IUnitOfWork unitOfWork,IMapper mapper)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<ResourcePlanWithProfileInfoDTO>> Execute()
        {
            IEnumerable<ResourcePlan> resourcePlans = await this.unitOfWork.ResourcePlans.GetAllResourcePlanWithProfiles();
            IEnumerable<ResourcePlanWithProfileInfoDTO> result = mapper.Map<IEnumerable<ResourcePlan>,IEnumerable<ResourcePlanWithProfileInfoDTO>>(resourcePlans);
            return result;
        }
    }
}
