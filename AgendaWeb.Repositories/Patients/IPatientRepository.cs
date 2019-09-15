using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AgendaWeb.Models;
using AgendaWeb.Core.DI;

namespace AgendaWeb.Repositories.Patients
{
    [AutoDIService]
    public interface IPatientRepository:IRepository<Patient>
    {
        Task<Patient> GetPatientWithFullInfor(int id);
        Task<IEnumerable<Patient>> GetAllPatientsWithFullInfo();
        Task<IEnumerable<Patient>> GetPaginatedPatientWithFullInfo(int pageIndex, int pageSize);
    }
}
