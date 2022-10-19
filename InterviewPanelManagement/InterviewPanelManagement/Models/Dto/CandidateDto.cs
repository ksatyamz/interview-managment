namespace InterviewPanelManagement.Models.Dto
{
    public class CandidateDto
    {
        public int CandidateId { get; set; }

        
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        

        public string Email { get; set; }
        
        public long Phone { get; set; }
        public string Primary_skill { get; set; }

        public string Secondary_skill { get; set; }

        public string Designation { get; set; }

        public string Experience { get; set; }
        
        public string Qualification { get; set; }
       
        public string NoticePeriod { get; set; }
        
        public string location { get; set; }
    }
}
