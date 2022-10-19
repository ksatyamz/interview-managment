using InterviewMicroserviceApi.Models.Domain;

namespace InterviewMicroserviceApi.Models.Dto
{
    public class InterviewDto
    {
        public int InterviewId { get; set; }
        
        
        public int? PanelId { get; set; }
        //public PanelDto Panel { get; set; }
        
        
        public int? CandidateId { get; set; }
        //public CandidateDto Candidate { get; set; }
        
        public DateTime DateTime { get; set; }
        
        public int Duration { get; set; }
    }
}
