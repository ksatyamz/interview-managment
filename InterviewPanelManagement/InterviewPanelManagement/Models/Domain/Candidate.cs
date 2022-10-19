using System.ComponentModel.DataAnnotations;

namespace InterviewPanelManagement.Models.Domain
{
    public class Candidate
    {
        [Key]
        public int CandidateId { get; set; }
       
        [Required]
        public string FirstName { get; set;}
        [Required]
        public string LastName { get; set; }
        
        [Required,DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        /// <summary>
         [Required]
        /// </summary>
        public long Phone { get; set; }
        [Required]
        public string Primary_skill { get; set; }

        [Required]
        public string Secondary_skill { get; set; }

        [Required]
        public string Designation { get; set; }

        [Required]
        public string Experience { get; set; }
        [Required]
        public string Qualification { get; set; }
        [Required]
        public string NoticePeriod { get; set; }
        [Required]
        public string location { get; set; }
        


    }
}
