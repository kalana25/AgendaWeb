using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using AgendaWeb.Repositories;
using AgendaWeb.Core.Interfaces;

namespace AgendaWeb.UseCases.General.Collaborators.DeleteCollaborator
{
    public class DeleteCollaboratorUseCase:UseCase
    {
        public int Id { get; set; }

        public readonly IUnitOfWork unitOfWork;

        public DeleteCollaboratorUseCase(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<int> Execute()
        {
            var collaborator = await unitOfWork.Collaborators.GetCollaboratorWithFullInfor(Id);
            unitOfWork.Addresses.Remove(collaborator.Address);
            unitOfWork.Communications.Remove(collaborator.Communication);
            unitOfWork.Collaborators.Remove(collaborator);
            await unitOfWork.Complete();
            return collaborator.Id;
        }
    }
}
