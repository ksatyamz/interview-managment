using CandidateMicroServiceAPI.Test.MockData;
using EmployeeAPI.Repositories.InterviewPanelManagement.Repositiory;
using FluentAssertions;
using InterviewPanelManagement.Data;
using InterviewPanelManagement.Models.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CandidateMicroServiceAPI.Test.Systems.Repositories
{
    public class TestCandidateRepository : IDisposable
    {
        private readonly InterviewDbContext context;

        public TestCandidateRepository()
        {
            var options = new DbContextOptionsBuilder<InterviewDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            context = new InterviewDbContext(options);
            context.Database.EnsureCreated();
        }
        public void Dispose()
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }

        [Fact]
        public async Task GetCandidatesAsync_ShouldReturnCandidateList()
        {
            //Arrange
            context.candidates.AddRange(CandidateMockData.GetCandidates());
            context.SaveChanges();
            var sut = new CandidateRepository(context);
            //Act
            var result = await sut.GetCandidatesAsync();
            //Assert
            result.Should().HaveCount(CandidateMockData.GetCandidates().Count);
        }

        [Fact]
        public async Task GetCandidateAsync_ShouldReturnCandidateById()
        {
            //Arrange
            context.candidates.AddRange(CandidateMockData.candidate());
            context.SaveChanges();
            var sut = new CandidateRepository(context);
            int id = 5;



            //Act
            var result = await sut.GetCandidateAsync(id);
            //Assert
            result.Should().BeOfType<Candidate>();
        }


        [Fact]
        public async Task AddCandidateAsync_ShouldReturnAddeCandidate()
        {
            //Arrange
            context.candidates.AddRange(CandidateMockData.GetCandidates());
            context.SaveChanges();
            var sut = new CandidateRepository(context);
            Candidate cdt = CandidateMockData.AddCandidate();
            //Act
            var result = await sut.AddCandidateAsync(cdt);
            //Assert
            result.Should().BeOfType<Candidate>();
        }


        [Fact]
        public async Task DeleteCandidateAsync_ShouldReturnDeletedCandidate()
        {
            //Arrange
            context.candidates.AddRange(CandidateMockData.GetCandidates());
            context.SaveChanges();
            var sut = new CandidateRepository(context);
            //Employee emp = EmployeeMockData.AddEmployee();
            //Act
            var result = await sut.DeleteCandidateAsync(3);
            //Assert
            result.Should().BeOfType<Candidate>();
        }
    }
}
