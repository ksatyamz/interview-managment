using RatingMicroServiceApi.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RatingMicroServiceApi.Tests.MockData
{
    public static class RatingMockData
    {
        public static List<Rating> GetRatings()
        {
            return new List<Rating>()
            {

                new(){Id=1,TechRating=3,TechComment="Good",HrRating=4,HrComment="VeryGood",CandidateId=1},
                new(){Id=2,TechRating=2,TechComment="Ok",HrRating=3,HrComment="Good",CandidateId=2},
                new(){Id=3,TechRating=4,TechComment="VeryGood",HrRating=2,HrComment="Ok",CandidateId=3},
                new(){Id=4,TechRating=5,TechComment="Excellent",HrRating=3,HrComment="Good",CandidateId=4},

            };
        }
        public static List<Rating> EmptyRatingList()
        {
            return new List<Rating>();
        }
        public static Rating rating()
        {
            return new Rating()
            {
                Id = 5,
                TechRating = 3,
                TechComment="Good",
                HrRating=5,
                HrComment="Excellent",
                CandidateId = 5
            };
        }
        public static Rating EmptyRating()
        {
            return null;
        }
    }
}
