using Microsoft.EntityFrameworkCore;
using RatingMicroServiceApi.Data;
using RatingMicroServiceApi.Models.Domain;

namespace RatingMicroServiceApi.Repositories
{
    public class RatingRepository : IRatingRepository
    {
        public RatingRepository ratingRepository;
        public readonly RatingDbContext ratingDbContext;
        public RatingRepository(RatingDbContext _ratingDbContext)
        {
            ratingDbContext = _ratingDbContext;
        }
        public async Task<IEnumerable<Rating>> GetRatingsAsync()
        {
            return await ratingDbContext.ratings.ToListAsync();
        }

        public async Task<Rating> AddRatingAsync(Rating rating)
        {
            await ratingDbContext.AddAsync(rating);
            await ratingDbContext.SaveChangesAsync();
            return rating;
        }
        public async Task<Rating> GetRatingAsync(int id)
        {
            return await ratingDbContext.ratings.FirstOrDefaultAsync(x => x.CandidateId == id);
        }



        public async Task<Rating> UpdateHrRatingAsync(int id, Rating rating)
        {
            var rat = await ratingDbContext.ratings.FirstOrDefaultAsync(x => x.CandidateId == id);
            if (rat == null)
            {
                return null;
            }
            else
            {
                
                rat.HrRating = rating.HrRating;
                rat.HrComment = rating.HrComment;
                ratingDbContext.Update(rat);
                await ratingDbContext.SaveChangesAsync();
            }
            return rat;
        }
        public async Task<Rating> UpdateStatusAsync(int id, Rating rating)
        {
            var rat = await ratingDbContext.ratings.FirstOrDefaultAsync(x => x.CandidateId == id);
            if (rat == null)
            {
                return null;
            }
            else
            {


                rat.Status = rating.Status;
                ratingDbContext.Update(rat);
                await ratingDbContext.SaveChangesAsync();
            }
            return rat;
        }

    }
}
