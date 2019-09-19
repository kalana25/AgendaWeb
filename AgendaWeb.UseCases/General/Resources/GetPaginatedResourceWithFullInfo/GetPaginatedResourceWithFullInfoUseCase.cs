using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using AgendaWeb.UseCases.DTO;
using AgendaWeb.Models;
using AgendaWeb.Repositories;
using System.Threading.Tasks;
using AgendaWeb.Core.Interfaces;

namespace AgendaWeb.UseCases.General.Resources.GetPaginatedResourceWithFullInfo
{
    public class GetPaginatedResourceWithFullInfoUseCase:UseCase
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }

        public readonly IMapper mapper;
        public readonly IUnitOfWork unitOfWork;

        public GetPaginatedResourceWithFullInfoUseCase(
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<ResourceWithFullInfoDTO>> Execute()
        {
            var resources = await this.unitOfWork.Resources.GetPaginatedResourceWithFullInfo(PageIndex, PageSize);
            IEnumerable<ResourceWithFullInfoDTO> result = mapper.Map<IEnumerable<Resource>, IEnumerable<ResourceWithFullInfoDTO>>(resources);
            return result;
        }
    }
}
