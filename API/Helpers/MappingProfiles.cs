using API.DTO;
using API.Extensions;
using AutoMapper;
using Core.Entities;
using System.Linq;

namespace API.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Publisher, PublisherToReturnDto>()
                .ForMember(d => d.PublisherTitles, s => s.MapFrom(x => x.PublisherTitles.Select(y => new PropertyDto
                {
                    Name = y.Title.Name,
                    Description = y.Title.Description
                })))
                .ForMember(d => d.Group, s => s.MapFrom(x => x.Group.Name))
                .ForMember(d => d.Age, s => s.MapFrom(x => x.BaptismDate.Age()))
                .ForMember(d => d.PhotoUrl, s => s.MapFrom<PublisherUrlResolver>());
            CreateMap<Publisher, FlatPublisherToReturnDto>()
                .ForMember(d => d.Group, s => s.MapFrom(x => x.Group.Name))
                .ForMember(d => d.Age, s => s.MapFrom(x => x.BaptismDate.Age()))
                .ForMember(d => d.PhotoUrl, s => s.MapFrom<PublisherUrlResolver>());
            CreateMap<Report, ReportToReturnDto>();
            CreateMap<Group, PropertyDto>();
            CreateMap<Status, PropertyDto>();
            CreateMap<Title, PropertyDto>();
        }
    }
}