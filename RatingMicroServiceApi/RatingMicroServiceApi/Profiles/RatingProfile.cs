using AutoMapper;
using RatingMicroServiceApi.Models.Domain;
using RatingMicroServiceApi.Models.Dto;

namespace RatingMicroServiceApi.Profiles
{
    public class RatingProfile:Profile
    {
        public RatingProfile()
        {
            CreateMap<Rating, RatingDto>().ReverseMap();
        }
            
    }
}
