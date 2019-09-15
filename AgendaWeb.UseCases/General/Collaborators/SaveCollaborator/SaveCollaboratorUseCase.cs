using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using System.Threading.Tasks;
using AgendaWeb.Models;
using AgendaWeb.UseCases.General.Patients.SavePatient;
using AgendaWeb.Core.Interfaces;
using AgendaWeb.Repositories;
using AgendaWeb.UseCases.DTO;

namespace AgendaWeb.UseCases.General.Collaborators.SaveCollaborator
{
    public class SaveCollaboratorUseCase: UseCase
    {
        public CollaboratorSaveDTO DTO { get; set; }

        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public SaveCollaboratorUseCase(IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public async Task<Collaborator> Execute()
        {
            Collaborator collaborator = this.mapper.Map<CollaboratorSaveDTO, Collaborator>(this.DTO);
            this.unitOfWork.Collaborators.Add(collaborator);
            await this.unitOfWork.Complete();
            return collaborator;
        }
    }
}
