using System;
using System.Collections.Generic;
using System.Text;
using AgendaWeb.Core.Interfaces;
using AgendaWeb.Repositories;
using AgendaWeb.Models;
using System.Threading.Tasks;
using AgendaWeb.UseCases.DTO;
using AutoMapper;

namespace AgendaWeb.UseCases.General.Styles.UpdateStyle
{
    public class UpdateStyleUseCase : UseCase
    {
        public StyleDTO DTO { get; set; }

        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public UpdateStyleUseCase(
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public async Task<Style> Execute()
        {
            Style style = this.mapper.Map<StyleDTO, Style>(this.DTO);
            Style alreadyExistOne = await this.unitOfWork.Styles.Get(style.Id);
            style.Id = alreadyExistOne.Id;
            alreadyExistOne = style;
            int result = await this.unitOfWork.Complete();
            return style;
        }
    }
}
