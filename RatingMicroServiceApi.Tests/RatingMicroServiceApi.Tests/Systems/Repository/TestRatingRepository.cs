
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using RatingMicroServiceApi.Data;
using RatingMicroServiceApi.Models.Domain;
using RatingMicroServiceApi.Repositories;
using RatingMicroServiceApi.Tests.MockData;

namespace RatingMicroServiceApi.Tests.Systems.Repository
{
    public class TestRatingRepository : IDisposable
    {
        private readonly RatingDbContext context;
        public TestRatingRepository()
        {
            var options = new DbContextOptionsBuilder<RatingDbContext>()
                .UseInMemoryDatabase(databaseName:Guid.NewGuid().ToString()).Options;
            context=new RatingDbContext(options);
            context.Database.EnsureCreated();
        }
        
        [Fact]
        public async Task GetById_ShouldReturnRating()
        {
            //Arrange
            context.ratings.AddRange(RatingMockData.GetRatings());
            context.SaveChanges();
            int candidateId = 2;
            
            var sut = new RatingRepository(context);
            //Act
            var result=await sut.GetRatingAsync(candidateId);
            //Assert
            result.GetType().Should().Be(typeof(Rating));
        }
        [Fact]
        public async Task AddRating_ById()
        {
            //Arrange
            context.ratings.AddRange(RatingMockData.GetRatings());
            context.SaveChanges();
            var sut=new RatingRepository(context);
            Rating rating=RatingMockData.rating();
            var result=await sut.AddRatingAsync(rating);
            result.GetType().Should().Be(typeof(Rating));
        }
        [Fact]
        public async Task UpdateRatingAsync_ById()
        {
            context.ratings.AddRange(RatingMockData.GetRatings());
            context.SaveChanges();
            var sut = new RatingRepository(context);
            var ratings = RatingMockData.GetRatings();
            Rating rating = ratings[0];
            //Act
            var result = await sut.UpdateHrRatingAsync(1, rating);
            //assert
            result.GetType().Should().Be(typeof(Rating));

        }


        public void Dispose()
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }
    }
}
