﻿using System;
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
using AgendaWeb.Repositories.Collaborators;
using AgendaWeb.Repositories.Resources;

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
        public ICollaboratorRepository Collaborators { get; set; }
        public IResourceRepository Resources { get; set; }

        public UnitOfWork(DataBaseContext context,
            IStyleRepository styleRepository,
            IResourcePlanRepository resourcePlanRepository,
            IResourceProfileRepository resourceProfileRepository,
            IPatientRepository patientRepository,
            IAddressRepository addressRepository,
            ICollaboratorRepository collaboratorRepository,
            ICommunicationRepository communicationRepository,
            IResourceRepository resourceRepository)
        {
            this.context = context;
            Styles = styleRepository;
            ResourcePlans = resourcePlanRepository;
            ResourceProfile = resourceProfileRepository;
            Patients = patientRepository;
            Addresses = addressRepository;
            Communications = communicationRepository;
            Collaborators = collaboratorRepository;
            Resources = resourceRepository;
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
