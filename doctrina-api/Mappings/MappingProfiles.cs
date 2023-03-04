using System;
using doctrine_api.RequestModels;
using doctrine_api.DataModels;
using AutoMapper;

namespace doctrine_api.Mappings
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<AccountDetails, Account>()
            .ForMember(dest => dest.USERNAME, opt => opt.MapFrom(src => src.USERNAME))
            .ForMember(dest => dest.PASSWORD, opt => opt.MapFrom(src => src.PASSWORD))
            .ForMember(dest => dest.FIRST_NAME, opt => opt.MapFrom(src => src.FIRST_NAME))
            .ForMember(dest => dest.MIDDEL_NAME, opt => opt.MapFrom(src => src.MIDDLE_NAME))
            .ForMember(dest => dest.LAST_NAME, opt => opt.MapFrom(src => src.LAST_NAME))
            .ForMember(dest => dest.EMAIL, opt => opt.MapFrom(src => src.EMAIL))
            .ForMember(dest => dest.PHONE_NUMBER, opt => opt.MapFrom(src => src.PHONE_NUMBER));

            CreateMap<RequestModels.AssistanceRequest, DataModels.AssistanceReuest>()
                .ForMember(dest => dest.DETAILS, opt => opt.MapFrom(src => src.DETAILS))
                .ForMember(dest => dest.CATEGORY, opt => opt.MapFrom(src => src.REQUEST_CATEGORY))
                .ForMember(dest => dest.EDUCATION_LEVEL, opt => opt.MapFrom(src => src.EDUCATION_LEVEL))
                .ForMember(dest => dest.SETUP_MEETING, opt => opt.MapFrom(src => src.SETUP_MEETING));
        }
    }
}

