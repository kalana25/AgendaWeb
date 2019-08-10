using System;
using System.Collections.Generic;
using System.Text;
using AgendaWeb.Core.Interfaces;
using AgendaWeb.Repositories;
using AgendaWeb.Models;
using System.Threading.Tasks;
using AutoMapper;

namespace AgendaWeb.UseCases.General.ResourceProfiles.GetResourceProfile
{
    public class GetResourceProfileUseCase:UseCase
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public int Id { get; set; }

        public GetResourceProfileUseCase(
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public async Task<ResourceProfile> Execute()
        {
            return await unitOfWork.ResourceProfile.Get(this.Id);
        }
    }
}
