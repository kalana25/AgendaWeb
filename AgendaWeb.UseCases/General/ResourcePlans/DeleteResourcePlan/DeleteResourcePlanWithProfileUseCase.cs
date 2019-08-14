using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AgendaWeb.Repositories;
using AgendaWeb.Core.Interfaces;

namespace AgendaWeb.UseCases.General.ResourcePlans.DeleteResourcePlan
{
    public class DeleteResourcePlanWithProfileUseCase : UseCase
    {
        public int Id { get; set; }

        private readonly IUnitOfWork unitOfWork;

        public DeleteResourcePlanWithProfileUseCase(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<int> Execute()
        {
            var resourcePlan = await this.unitOfWork.ResourcePlans.GetResourcePlanWithProfiles(this.Id);
            unitOfWork.ResourcePlans.Delete(resourcePlan);
            var result = unitOfWork.Complete();
            return resourcePlan.Id;
        }
    }
}
