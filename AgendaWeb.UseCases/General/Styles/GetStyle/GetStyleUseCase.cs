using System;
using System.Collections.Generic;
using System.Text;
using AgendaWeb.Core.Interfaces;
using AgendaWeb.Repositories;
using AgendaWeb.Models;
using System.Threading.Tasks;
using AutoMapper;

namespace AgendaWeb.UseCases.General.Styles.GetStyle
{
    public class GetStyleUseCase:UseCase
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public int Id { get; set; }

        public GetStyleUseCase(
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public async Task<Style> Execute()
        {
            return await unitOfWork.Styles.Get(this.Id);
        }
    }
}
