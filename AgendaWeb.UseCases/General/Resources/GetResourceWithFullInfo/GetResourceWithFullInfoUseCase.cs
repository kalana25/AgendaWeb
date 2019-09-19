using AutoMapper;
using AgendaWeb.UseCases.DTO;
using AgendaWeb.Models;
using AgendaWeb.Repositories;
using System.Threading.Tasks;
using AgendaWeb.Core.Interfaces;
using System.Collections.Generic;

namespace AgendaWeb.UseCases.General.Resources.GetResourceWithFullInfo
{
    public class GetResourceWithFullInfoUseCase:UseCase
    {
        public int Id { get; set; }

        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public GetResourceWithFullInfoUseCase(IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public async Task<ResourceWithFullInfoDTO> Execute()
        {
            Resource resource = await unitOfWork.Resources.GetResourceWithFullInfo(Id);
            ResourceWithFullInfoDTO result = mapper.Map<Resource, ResourceWithFullInfoDTO>(resource);
            return result;
        }
    }
}
