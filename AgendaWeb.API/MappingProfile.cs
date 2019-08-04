using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AgendaWeb.Models;
using AgendaWeb.UseCases.DTO;

namespace AgendaWeb.API
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region DTOToModel

            CreateMap<StyleDTO, Style>()
                .ForMember(d => d.CustomStyle, m => m.MapFrom(o => o.CustomStyle))
                .ForMember(d => d.BackgroundColor, m => m.MapFrom(o => o.BackgroundColor))
                .ForMember(d => d.FontColor, m => m.MapFrom(o => o.FontColor))
                .ForMember(d => d.Id, m => m.MapFrom(o => o.Id))
                .ForMember(d => d.Name, m => m.MapFrom(o => o.Name));

            #endregion

            #region ModelToDTO


            #endregion
        }
    }
}
