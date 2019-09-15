using System.Text;
using AutoMapper;
using AgendaWeb.UseCases.DTO;
using AgendaWeb.Models;
using AgendaWeb.Repositories;
using System.Threading.Tasks;
using AgendaWeb.Core.Interfaces;
using System.Collections.Generic;

namespace AgendaWeb.UseCases.General.Collaborators.GetAllCollaboratorWithFullInfo
{
    public class GetAllCollaboratorWithFullInfoUseCase: UseCase
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public GetAllCollaboratorWithFullInfoUseCase(IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<CollaboratorWithFullInfoDTO>> Execute()
        {
            IEnumerable<Collaborator> collaborators = await this.unitOfWork.Collaborators.GetAllCollaboratorsWithFullInfo();
            IEnumerable<CollaboratorWithFullInfoDTO> result = mapper.Map<IEnumerable<Collaborator>, IEnumerable<CollaboratorWithFullInfoDTO>>(collaborators);
            return result;
        }
    }
}
