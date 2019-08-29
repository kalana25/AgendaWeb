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

namespace AgendaWeb.UseCases.General.Patients.SavePatient
{
    public class SavePatientUseCase:UseCase
    {
        public PatientSaveDTO DTO { get; set; }

        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public SavePatientUseCase(IMapper mapper,IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public async Task<Patient> Execute()
        {
            Patient patient = this.mapper.Map<PatientSaveDTO, Patient>(this.DTO);
            this.unitOfWork.Patients.Add(patient);
            await this.unitOfWork.Complete();
            return patient;
        }
    }
}
