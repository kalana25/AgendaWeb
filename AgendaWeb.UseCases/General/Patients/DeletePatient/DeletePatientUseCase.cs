using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using AgendaWeb.Repositories;
using AgendaWeb.Core.Interfaces;


namespace AgendaWeb.UseCases.General.Patients.DeletePatient
{
    public class DeletePatientUseCase:UseCase
    {
        public int Id { get; set; }

        public readonly IUnitOfWork unitOfWork;

        public DeletePatientUseCase(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<int> Execute()
        {
            var patient = await unitOfWork.Patients.GetPatientWithFullInfor(Id);
            unitOfWork.Addresses.Remove(patient.Address);
            unitOfWork.Communication.Remove(patient.Communication);
            unitOfWork.Patients.Remove(patient);
            await unitOfWork.Complete();
            return patient.Id;
        }
    }
}
