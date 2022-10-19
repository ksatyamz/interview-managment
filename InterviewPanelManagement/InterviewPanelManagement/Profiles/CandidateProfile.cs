using AutoMapper;
using InterviewPanelManagement.Models.Domain;
using InterviewPanelManagement.Models.Dto;

namespace InterviewPanelManagement.Profiles
{
    public class CandidateProfile:Profile
    {
        public CandidateProfile()
        {
            CreateMap<Candidate, CandidateDto>().ReverseMap();
          }

    }
}
