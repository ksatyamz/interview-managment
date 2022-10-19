using FluentAssertions;
using InterviewMicroserviceApi.Data;
using InterviewMicroserviceApi.Models.Domain;
using InterviewMicroserviceApi.Repositories;
using InterviewMicroserviceApi.Tests.MockData;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace InterviewMicroserviceApi.Tests.System.Repositories
{
    public class TestInterviewRepository : IDisposable
    {
        private readonly InterviewDbContext context;

        public TestInterviewRepository()
        {
            var options = new DbContextOptionsBuilder<InterviewDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            context = new InterviewDbContext(options);
            context.Database.EnsureCreated();
        }
        [Fact]
        public async Task GetInterviewsAsync_ShouldReturnInterviewsList()
        {
            
            context.interviews.AddRange(InterviewMockData.GetInterviews());
            context.SaveChanges();
            var sut = new InterviewRepository(context);

            
            var result = await sut.GetInterviewsAsync();

            
            result.Should().HaveCount(InterviewMockData.GetInterviews().Count);
        }
        [Fact]
        public async Task GetInterviewByIdAsync_ShouldReturnInterview()
        {
             
            context.interviews.AddRange(InterviewMockData.GetInterview());
            context.SaveChanges();
            var sut = new InterviewRepository(context);
            int id = 1;

            
            var result = await sut.GetInterviewByIdAsync(id);
            
            result.Should().BeOfType<Interview>();
        }
        [Fact]

        public async Task GetInterviewByCadIdAsync_ShouldReturnInterview()
        {
            context.interviews.AddRange(InterviewMockData.GetInterview());
            context.SaveChanges();

            var sut = new InterviewRepository(context);
            int id = 1;

            
            var result = await sut.GetInterviewByCadIdAsync(id);

            
            result.GetType().Should().Be(typeof(List<Interview>));
        }

        [Fact]
        public async Task GetInterviewByPanIdAsync_ShouldReturnInterviews()
        {
            context.interviews.AddRange(InterviewMockData.GetInterview());
            context.SaveChanges();

            var sut = new InterviewRepository(context);
            int id = 1;

            
            var result = await sut.GetInterviewByPanIdAsync(id);


            result.GetType().Should().Be(typeof(List<Interview>));
        }
        [Fact]
         

        public async Task AddInterviewAsync_ShouldReturnAddedInterview()
        {
             
            context.interviews.AddRange(InterviewMockData.GetInterviews());
            context.SaveChanges();
            var sut = new InterviewRepository(context);
            Interview inter = InterviewMockData.Interview();
            
            var result = await sut.AddInterviewAsync(inter);
            
            result.GetType().Should().Be(typeof(Interview));
        }

        [Fact]
        public async Task UpdateInterviewAsync_ShouldReturnUpdatedInterview()
        {
             
            context.interviews.AddRange(InterviewMockData.GetInterviews());
            context.SaveChanges();
            var sut = new InterviewRepository(context);
            Interview inter = InterviewMockData.GetInterview();
            
            var result = await sut.UpdateInterviewAsync(inter, 3);
            
            result.Should().BeOfType<Interview>();
        }





        public void Dispose()
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }
    }
}
