using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using AgendaWeb.UseCases.DTO;
using AgendaWeb.Models;
using AgendaWeb.Repositories;
using System.Threading.Tasks;
using AgendaWeb.Core.Interfaces;

namespace AgendaWeb.UseCases.General.Patients.GetPaginatedPatientInfo
{
    public class GetPaginatedPatientInfoUseCase: UseCase
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }

        public readonly IMapper mapper;
        public readonly IUnitOfWork unitOfWork;

        public GetPaginatedPatientInfoUseCase(
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<PatientWithFullInfoDTO>> Execute()
        {
            var patients = await this.unitOfWork.Patients.GetPaginatedPatientsWithFullInfo(PageIndex, PageSize);
            IEnumerable<PatientWithFullInfoDTO> result = mapper.Map<IEnumerable<Patient>, IEnumerable<PatientWithFullInfoDTO>>(patients);
            return result;
        }
    }
}
