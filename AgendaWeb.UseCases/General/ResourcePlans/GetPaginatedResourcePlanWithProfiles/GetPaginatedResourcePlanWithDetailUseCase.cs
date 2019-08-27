using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AgendaWeb.UseCases.DTO;
using AgendaWeb.Core.Interfaces;
using AgendaWeb.Models;
using AgendaWeb.Repositories;

namespace AgendaWeb.UseCases.General.ResourcePlans.GetPaginatedResourcePlanWithProfiles
{
    public class GetPagintedResourcePlanWithDetailUseCase : UseCase
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }

        public readonly IMapper mapper;
        public readonly IUnitOfWork unitOfWork;

        public GetPagintedResourcePlanWithDetailUseCase(
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<ResourcePlanWithProfileInfoDTO>> Execute()
        {
            IEnumerable<ResourcePlan> resourcePlans = await this.unitOfWork.ResourcePlans.GetPaginatedResourcePlanWithProfiles(this.PageIndex,this.PageSize);
            IEnumerable<ResourcePlanWithProfileInfoDTO> result = mapper.Map<IEnumerable<ResourcePlan>, IEnumerable<ResourcePlanWithProfileInfoDTO>>(resourcePlans);
            return result;
        }

    }
}
