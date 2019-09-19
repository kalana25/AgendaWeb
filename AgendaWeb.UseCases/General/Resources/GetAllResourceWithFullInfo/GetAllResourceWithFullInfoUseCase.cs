using System.Text;
using AutoMapper;
using AgendaWeb.UseCases.DTO;
using AgendaWeb.Models;
using AgendaWeb.Repositories;
using System.Threading.Tasks;
using AgendaWeb.Core.Interfaces;
using System.Collections.Generic;

namespace AgendaWeb.UseCases.General.Resources.GetAllResourceWithFullInfo
{
    public class GetAllResourceWithFullInfoUseCase:UseCase
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public GetAllResourceWithFullInfoUseCase(IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public async Task<object> Execute()
        {
            IEnumerable<Resource> resources = await unitOfWork.Resources.GetAllResourceWithFullInfo();
            IEnumerable<ResourceWithFullInfoDTO> result = mapper.Map<IEnumerable<Resource>, IEnumerable<ResourceWithFullInfoDTO>>(resources);
            return result;
        }
    }
}
