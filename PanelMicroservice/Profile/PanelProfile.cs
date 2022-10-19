using AutoMapper;
using PanelMicroservice.Models.Domain;
using PanelMicroservice.Models.Dto;

namespace InterviewPanelManagement.Profiles
{
    public class PanelProfile : Profile
    {
        public PanelProfile()
        {
            CreateMap<Panel,PanelDto>().ReverseMap();
        }
    }
}
