using System;
using System.Collections.Generic;
using System.Text;
using AgendaWeb.Models;
using System.Threading.Tasks;
using AgendaWeb.Core.Interfaces;
using AgendaWeb.Repositories;

namespace AgendaWeb.UseCases.General.ResourcePlans.GetAllResourcePlansWithProfiles
{
    public class GetAllResourcePlansWithProfileUseCase : UseCase
    {
        private readonly IUnitOfWork unitOfWork;

        public GetAllResourcePlansWithProfileUseCase(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<ResourcePlan>> Execute()
        {
            return await this.unitOfWork.ResourcePlans.GetAllResourcePlanWithProfiles();
        }
    }
}
