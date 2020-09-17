using AutoMapper;
using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Discussions
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Discussion, DiscussionDto>()
                .ForMember(d => d.UserName, o => o.MapFrom(s => s.Author.UserName))
                .ForMember(d => d.DisplayName, o => o.MapFrom(s => s.Author.Name));
        }
    }
}
