using System;
using System.Collections.Generic;
using System.Text;
using AgendaWeb.Repositories.Styles;
using AgendaWeb.Repositories.ResourceProfiles;
using System.Threading.Tasks;
using AgendaWeb.DAL;
using AgendaWeb.Repositories.ResourcePlans;
using AgendaWeb.Repositories.Patients;
using AgendaWeb.Repositories.Addresses;
using AgendaWeb.Repositories.Communications;

namespace AgendaWeb.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataBaseContext context;
        public IStyleRepository Styles { get; private set; }
        public IResourceProfileRepository ResourceProfile { get; private set; }
        public IResourcePlanRepository ResourcePlans { get; private set; }
        public IPatientRepository Patients { get; set; }
        public IAddressRepository Addresses { get; set; }
        public ICommunicationRepository Communications { get; set; }

        public UnitOfWork(DataBaseContext context,
            IStyleRepository styleRepository,
            IResourcePlanRepository resourcePlanRepository,
            IResourceProfileRepository resourceProfileRepository,
            IPatientRepository patientRepository,
            IAddressRepository addressRepository,
            ICommunicationRepository communicationRepository)
        {
            this.context = context;
            Styles = styleRepository;
            ResourcePlans = resourcePlanRepository;
            ResourceProfile = resourceProfileRepository;
            Patients = patientRepository;
            Addresses = addressRepository;
            Communications = communicationRepository;
        }

        public async Task<int> Complete()
        {
            return await context.SaveChangesAsync();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
