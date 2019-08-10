using System;
using System.Collections.Generic;
using System.Text;
using AgendaWeb.Core.Interfaces;
using AgendaWeb.Repositories;
using AgendaWeb.Models;
using System.Threading.Tasks;
using AgendaWeb.UseCases.DTO;
using AutoMapper;

namespace AgendaWeb.UseCases.General.ResourceProfiles.DeleteResourceProfile
{
    public class DeleteResourceProfileUseCase : UseCase
    {
        public int Id { get; set; }

        private readonly IUnitOfWork unitOfWork;

        public DeleteResourceProfileUseCase(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<int> Execute()
        {
            var resourceProfile = await unitOfWork.ResourceProfile.Get(Id);
            unitOfWork.ResourceProfile.Remove(resourceProfile);
            var result = unitOfWork.Complete();
            return resourceProfile.Id;
        }
    }
}
