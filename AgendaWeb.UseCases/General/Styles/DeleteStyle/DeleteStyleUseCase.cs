using System;
using System.Collections.Generic;
using System.Text;
using AgendaWeb.Core.Interfaces;
using AgendaWeb.Repositories;
using AgendaWeb.Models;
using System.Threading.Tasks;
using AgendaWeb.UseCases.DTO;
using AutoMapper;

namespace AgendaWeb.UseCases.General.Styles.DeleteStyle
{
    public class DeleteStyleUseCase : UseCase
    {
        public int Id { get; set; }

        private readonly IUnitOfWork unitOfWork;

        public DeleteStyleUseCase(
            IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;   
        }

        public async Task<int> Execute()
        {
            var style = await unitOfWork.Styles.Get(Id);
            unitOfWork.Styles.Remove(style);
            var result = unitOfWork.Complete();
            return style.Id;
        }
    }
}
