
namespace RatingMicroServiceApi.Models.Dto
{
    public class RatingDto
    {
        public int Id { get; set; }

        public int TechRating { get; set; }
        public string TechComment { get; set; }
        public int HrRating { get; set; }
        public string HrComment { get; set; }
        public int? CandidateId { get; set; }
        public string Status { get; set; }
    }
}
