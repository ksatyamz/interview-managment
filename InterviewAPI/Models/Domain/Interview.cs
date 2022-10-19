using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InterviewMicroserviceApi.Models.Domain
{
    public class Interview
    {
        [Required]
        [Key]
        public int InterviewId { get; set; }
        [Required]
       // [ForeignKey("Panel")]
        public int? PanelId { get; set; }
        //public Panel Panel { get; set; }
        [Required]
       // [ForeignKey("Candidate")]
        public int? CandidateId { get; set; }
       // public Candidate Candidate { get; set; }
        [Required]
        public DateTime DateTime { get; set; }
        [Required]
        public int Duration { get; set; }


    }
}
