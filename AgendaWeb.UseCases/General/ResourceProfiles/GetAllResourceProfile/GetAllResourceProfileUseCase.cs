using System;
using System.Collections.Generic;
using System.Text;
using AgendaWeb.Models;
using System.Threading.Tasks;
using AgendaWeb.Core.Interfaces;
using AgendaWeb.Repositories;

namespace AgendaWeb.UseCases.General.ResourceProfiles.GetAllResourceProfile
{
    public class GetAllResourceProfileUseCase : UseCase
    {
        private readonly IUnitOfWork unitOfWork;

        public GetAllResourceProfileUseCase(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<ResourceProfile>>Execute()
        {
            return await this.unitOfWork.ResourceProfile.GetAll();
        }
    }
}
