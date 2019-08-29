using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using AgendaWeb.UseCases.DTO;
using AgendaWeb.Models;
using AgendaWeb.Repositories;
using System.Threading.Tasks;
using AgendaWeb.Core.Interfaces;

namespace AgendaWeb.UseCases.General.Patients.GetPatientWithFullInfo
{
    public class GetPatientWithFullInfoUseCase :UseCase
    {
        public int Id { get; set; }

        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public GetPatientWithFullInfoUseCase(IMapper mapper,IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public async Task<PatientWithFullInfoDTO> Execute()
        {
            Patient patient = await this.unitOfWork.Patients.GetPatientWithFullInfor(this.Id);
            PatientWithFullInfoDTO result = mapper.Map<Patient,PatientWithFullInfoDTO>(patient);
            return result;
        }

    }
}
