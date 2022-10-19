using RatingMicroServiceApi.Models.Domain;

namespace RatingMicroServiceApi.Repositories
{
    public interface IRatingRepository
    {
        Task<IEnumerable<Rating>> GetRatingsAsync();
        Task<Rating> AddRatingAsync(Rating rating);
        Task<Rating> GetRatingAsync(int id);
        Task<Rating> UpdateHrRatingAsync(int id,Rating rating);
        Task<Rating> UpdateStatusAsync(int id, Rating rating);
    }
}
