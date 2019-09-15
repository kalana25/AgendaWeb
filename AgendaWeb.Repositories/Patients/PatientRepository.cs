using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using AgendaWeb.Models;
using AgendaWeb.DAL;


namespace AgendaWeb.Repositories.Patients
{
    public class PatientRepository : Repository<Patient>, IPatientRepository
    {
        public PatientRepository(DataBaseContext context):base(context)
        {

        }
        public async Task<IEnumerable<Patient>> GetAllPatientsWithFullInfo()
        {
            return await DatabaseContext.Patients
                .Include(p => p.Address)
                .Include(p => p.Communication)
                .OrderBy(p => p.FristName)
                .ToListAsync();
        }

        public async Task<Patient> GetPatientWithFullInfor(int id)
        {
            return await DatabaseContext.Patients
                .Include(p => p.Address)
                .Include(p => p.Communication)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Patient>> GetPaginatedPatientsWithFullInfo(int pageIndex, int pageSize)
        {
            return await DatabaseContext.Patients
                .Include(p => p.Communication)
                .Include(p => p.Address)
                .OrderBy(s => s.LastName)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public DataBaseContext DatabaseContext
        {
            get { return context as DataBaseContext; }
        }
    }
}
