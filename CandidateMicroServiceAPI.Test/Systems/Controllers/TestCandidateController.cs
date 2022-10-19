using AutoMapper;
using CandidateMicroServiceAPI.Test.MockData;
using FluentAssertions;
using InterviewPanelManagement.Controllers;
using InterviewPanelManagement.Models.Domain;
using InterviewPanelManagement.Repositiory;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace CandidateMicroServiceAPI.Test.Systems.Controllers
{
    public class TestCandidateController
    {

        [Fact]

        public async Task GetCdtAsync_ShouldReturn200StatusCode()
        {
            //Arrenge
            var candidateRepository = new Mock<ICandidateRepository>();
            var mapper = new Mock<IMapper>();
            candidateRepository.Setup(x => x.GetCandidatesAsync()).ReturnsAsync(CandidateMockData.GetCandidates());



            var sut = new CandidateController(candidateRepository.Object, mapper.Object);

            //Act
            var result = await sut.GetCdtAsync();

            //Assert
            result.GetType().Should().Be(typeof(OkObjectResult));
            (result as OkObjectResult).StatusCode.Should().Be(200);
        }

        [Fact]
        public async Task GetCdtAsync_ShouldBe204StatusCode()
        {
            //Arrange
            var candidateRepository = new Mock<ICandidateRepository>();
            var mapper = new Mock<IMapper>();



            candidateRepository.Setup(x => x.GetCandidatesAsync()).ReturnsAsync(CandidateMockData.EmptyCandidatesList());



            var sut = new CandidateController(candidateRepository.Object, mapper.Object);



            //Act
            var result = await sut.GetCdtAsync();



            //Assert
            result.GetType().Should().Be(typeof(NoContentResult));
            (result as NoContentResult).StatusCode.Should().Be(204);
        }

        [Fact]
        public async Task GetByCdtIdAsync_ShouldBe200StatusCode()
        {
            //Arrange
            var candidateRepository = new Mock<ICandidateRepository>();
            var mapper = new Mock<IMapper>();
            int CandidateId = 3;
            candidateRepository.Setup(x => x.GetCandidateAsync(CandidateId)).ReturnsAsync(CandidateMockData.candidate());
            var sut = new CandidateController(candidateRepository.Object, mapper.Object);

            //Act
            var result = await sut.GetByCdtIdAsync(CandidateId);

            //Assert
            result.GetType().Should().Be(typeof(OkObjectResult));
            (result as OkObjectResult).StatusCode.Should().Be(200);
        }


        [Fact]
        public async Task GetByCdtIdAsync_ShouldBe204StatusCode()
        {
            //Arrange
            var candidateRepository = new Mock<ICandidateRepository>();
            var mapper = new Mock<IMapper>();
            int CandidateId = 3;
            candidateRepository.Setup(x => x.GetCandidateAsync(CandidateId)).ReturnsAsync(CandidateMockData.EmptyCandiadte());
            var sut = new CandidateController(candidateRepository.Object, mapper.Object);

            //Act
            var result = await sut.GetByCdtIdAsync(CandidateId);

            //Assert
            result.GetType().Should().Be(typeof(NoContentResult));
            (result as NoContentResult).StatusCode.Should().Be(204);
        }

        [Fact]
        public async Task AddCdtAsync_ShouldBe201StatusCode()
        {
            //Arrange
            var candidateRepository = new Mock<ICandidateRepository>();
            var mapper = new Mock<IMapper>();
            var empstruct = new Mock<Candidate>();



            candidateRepository.Setup(x => x.AddCandidateAsync(empstruct.Object)).ReturnsAsync(CandidateMockData.candidate());
            var sut = new CandidateController(candidateRepository.Object, mapper.Object);
            //Act
            var result = await sut.AddCdtAsync(empstruct.Object);
            //Assert
            result.GetType().Should().Be(typeof(CreatedResult));
            (result as CreatedResult).StatusCode.Should().Be(201);
        }

        [Fact]
        public async Task AddCdtAsync_ShouldBe400StatusCode()
        {
            //Arrange
            var employeeRepository = new Mock<ICandidateRepository>();
            var mapper = new Mock<IMapper>();
            var empstruct = new Mock<Candidate>();


            employeeRepository.Setup(x => x.AddCandidateAsync(empstruct.Object)).ReturnsAsync(CandidateMockData.EmptyCandiadte());
            var sut = new CandidateController(employeeRepository.Object, mapper.Object);
            sut.ModelState.AddModelError("Key", "error message");
            //Act
            var result = await sut.AddCdtAsync(empstruct.Object);
            //Assert
            result.GetType().Should().Be(typeof(BadRequestObjectResult));
            (result as BadRequestObjectResult).StatusCode.Should().Be(400);
        }

        [Fact]
        public async Task DeleteCandidateAsync_ShouldBe200StatusCode()
        {
            //Arrange
            var candidateRepository = new Mock<ICandidateRepository>();
            var mapper = new Mock<IMapper>();
            int CandidateId = 3;



            candidateRepository.Setup(x => x.DeleteCandidateAsync(CandidateId)).ReturnsAsync(CandidateMockData.candidate());
            var sut = new CandidateController(candidateRepository.Object, mapper.Object);



            //Act
            var result = await sut.DeleteCandidateAsync(CandidateId);
            //Assert
            result.GetType().Should().Be(typeof(OkObjectResult));
            (result as OkObjectResult).StatusCode.Should().Be(200);
        }

         [Fact]
        public async Task DeleteCandidateAsync_ShouldBe404StatusCode()
        {
            //Arrange
            var candidateRepository = new Mock<ICandidateRepository>();
            var mapper = new Mock<IMapper>();
            int CandidateId = 3;



           candidateRepository.Setup(x => x.DeleteCandidateAsync(CandidateId)).ReturnsAsync(CandidateMockData.EmptyCandiadte());
            var sut = new CandidateController(candidateRepository.Object, mapper.Object);



           //Act
            var result = await sut.DeleteCandidateAsync(CandidateId);
            //Assert
            result.GetType().Should().Be(typeof(NotFoundResult));
            (result as NotFoundResult).StatusCode.Should().Be(404);
        }
    }
}
