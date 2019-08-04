using System;
using System.Collections.Generic;
using System.Text;
using AgendaWeb.Core.Interfaces;
using AgendaWeb.Repositories;
using AgendaWeb.Models;
using System.Threading.Tasks;
using AutoMapper;

namespace AgendaWeb.UseCases.General.Styles.GetAllStyle
{
    public class GetAllStyleUseCase :UseCase
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public GetAllStyleUseCase(
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Style>> Execute()
        {
            return await unitOfWork.Styles.GetAll();
        }
    }
}
