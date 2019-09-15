using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AgendaWeb.Core.Interfaces;
using AgendaWeb.Repositories;
using AgendaWeb.Models;
using AgendaWeb.UseCases.DTO;

namespace AgendaWeb.UseCases.General.Collaborators.UpdateCollaborator
{
    public class UpdateCollaboratorUseCase : UseCase
    {
        public int Id { get; set; }
        public CollaboratorUpdateDTO DTO { get; set; }

        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public UpdateCollaboratorUseCase(IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public async Task<Collaborator> Execute()
        {
            var existingCollaborator = await unitOfWork.Collaborators.Get(Id);
            Collaborator updatedCollaborator = this.mapper.Map<CollaboratorUpdateDTO, Collaborator>(DTO, existingCollaborator);
            var existingAddress = await unitOfWork.Addresses.Get(DTO.Address.Id);
            Address address = this.mapper.Map<AddressInfoDTO, Address>(DTO.Address, existingAddress);
            var existingCommunication = await unitOfWork.Communications.Get(DTO.Communication.Id);
            Communication communication = this.mapper.Map<CommunicationInfoDTO, Communication>(DTO.Communication, existingCommunication);
            int result = await unitOfWork.Complete();
            return updatedCollaborator;
        }
    }
}
