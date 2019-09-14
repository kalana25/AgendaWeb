using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AgendaWeb.Core.Interfaces;
using AgendaWeb.Repositories;
using AgendaWeb.Models;
using AgendaWeb.UseCases.DTO;

namespace AgendaWeb.UseCases.General.Patients.UpdatePatient
{
    public class UpdatePatientUseCase:UseCase
    {
        public int Id { get; set; }
        public PatientUpdateDTO DTO { get; set; }

        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public UpdatePatientUseCase(IMapper mapper,IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public async Task<Patient> Execute()
        {
            var existingPatient = await unitOfWork.Patients.Get(Id);
            Patient updatedPatient = this.mapper.Map<PatientUpdateDTO, Patient>(DTO, existingPatient);
            var existingAddress = await unitOfWork.Addresses.Get(DTO.Address.Id);
            Address address = this.mapper.Map<AddressInfoDTO, Address>(DTO.Address, existingAddress);
            var existingCommunication = await unitOfWork.Communications.Get(DTO.Communication.Id);
            Communication communication = this.mapper.Map<CommunicationInfoDTO, Communication>(DTO.Communication, existingCommunication);
            int result = await unitOfWork.Complete();
            return updatedPatient;
        }
    }
}
