using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using AgendaWeb.UseCases.DTO;
using AgendaWeb.Models;
using AgendaWeb.Repositories;
using System.Threading.Tasks;
using AgendaWeb.Core.Interfaces;

namespace AgendaWeb.UseCases.General.Collaborators.GetPaginatedCollaboratorInfo
{
    public class GetPaginatedCollaboratorInfoUseCase:UseCase
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }

        public readonly IMapper mapper;
        public readonly IUnitOfWork unitOfWork;

        public GetPaginatedCollaboratorInfoUseCase(
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<CollaboratorWithFullInfoDTO>> Execute()
        {
            var collaborators = await this.unitOfWork.Collaborators.GetPaginatedCollaboratorsWithFullInfo(PageIndex, PageSize);
            IEnumerable<CollaboratorWithFullInfoDTO> result = mapper.Map<IEnumerable<Collaborator>, IEnumerable<CollaboratorWithFullInfoDTO>>(collaborators);
            return result;
        }
    }
}
