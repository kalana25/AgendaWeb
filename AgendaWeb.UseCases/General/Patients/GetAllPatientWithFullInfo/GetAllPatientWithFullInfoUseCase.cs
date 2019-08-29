using System.Text;
using AutoMapper;
using AgendaWeb.UseCases.DTO;
using AgendaWeb.Models;
using AgendaWeb.Repositories;
using System.Threading.Tasks;
using AgendaWeb.Core.Interfaces;
using System.Collections.Generic;

namespace AgendaWeb.UseCases.General.Patients.GetAllPatientWithFullInfo
{
    public class GetAllPatientWithFullInfoUseCase : UseCase
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public GetAllPatientWithFullInfoUseCase(IMapper mapper,IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<PatientWithFullInfoDTO>> Execute()
        {
            IEnumerable<Patient> patients = await this.unitOfWork.Patients.GetAllPatientsWithFullInfo();
            IEnumerable<PatientWithFullInfoDTO> result = mapper.Map<IEnumerable<Patient>,IEnumerable<PatientWithFullInfoDTO>>(patients);
            return result;
        }
    }
}
