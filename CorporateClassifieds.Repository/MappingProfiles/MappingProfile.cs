using AutoMapper;
using CorporateClassifieds.Models.CoreModels;
using CorporateClassifieds.Models.Enums;
using CorporateClassifieds.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace CorporateClassifieds.Repository.MappingProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Classified, Dapper.Entities.Classified>()
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => (short)src.Type))
                .ForMember(dest => dest.RemovedBy, opt => opt.MapFrom(src => src.RemovedBy==null?0:(short)src.RemovedBy))
                .ReverseMap()
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => (ClassifiedType)src.RemovedBy))
                .ForMember(dest => dest.RemovedBy, opt => opt.MapFrom(src => (Role)src.RemovedBy));

            CreateMap<ClassifiedField, Dapper.Entities.ClassifiedField>()
                .ForMember(dest => dest.Value, opt => opt.MapFrom(src => JsonSerializer.Serialize(src.Value, new JsonSerializerOptions())))
                .ReverseMap()
                .ForMember(dest => dest.Value, opt => opt.MapFrom(src => JsonSerializer.Deserialize<ClassifiedFieldValue>(src.Value, new JsonSerializerOptions())));

            CreateMap<ClassifiedView, Classified>()
                .ForMember(dest => dest.RemovedBy, opt => opt.MapFrom(src => src.RemovedBy == null ? 0 :(Role)src.RemovedBy))
                .ReverseMap()
                .ForMember(dest => dest.RemovedBy, opt => opt.MapFrom(src => (short)src.RemovedBy));

            CreateMap<Attachment, Dapper.Entities.Attachment>()
                .ReverseMap();

            CreateMap<ClassifiedFormView, Classified>()
                .ReverseMap();

            CreateMap<ClassifiedFieldView, ClassifiedField>()
                .ReverseMap();

        }

    }
}
