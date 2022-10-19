using AutoMapper;
using InterviewMicroserviceApi.Models.Domain;
using InterviewMicroserviceApi.Models.Dto;

namespace InterviewMicroserviceApi.Profiles
{
    public class InterviewProfile:Profile
    {
        public InterviewProfile()
        {
            CreateMap<Interview, InterviewDto>().ReverseMap();
        }
    }
}
