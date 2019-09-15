using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using AgendaWeb.UseCases.DTO;
using AgendaWeb.Models;
using AgendaWeb.Repositories;
using System.Threading.Tasks;
using AgendaWeb.Core.Interfaces;

namespace AgendaWeb.UseCases.General.Collaborators.GetCollaboratorWithFullInfo
{
    public class GetCollaboratorWithFullInfoUseCase: UseCase
    {
        public int Id { get; set; }

        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public GetCollaboratorWithFullInfoUseCase(IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public async Task<CollaboratorWithFullInfoDTO> Execute()
        {
            Collaborator collaborator = await this.unitOfWork.Collaborators.GetCollaboratorWithFullInfor(this.Id);
            CollaboratorWithFullInfoDTO result = mapper.Map<Collaborator, CollaboratorWithFullInfoDTO>(collaborator);
            return result;
        }
    }
}
