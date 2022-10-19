
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RatingMicroServiceApi.Models.Domain
{
    public class Rating
    {
        public Rating()
        {
            this.Status = "StatusNotGiven";
        }
        public int Id { get; set; }
        
        
        public int? TechRating { get; set; }
        public string? TechComment { get; set; }
        
        public int? HrRating { get; set; }
        public string? HrComment { get; set; }
        [Required]
        public int? CandidateId { get; set; }
        [DefaultValue("StatusNotGiven")]
        public string? Status { get; set; }

    }
}
