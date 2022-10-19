using AutoMapper;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using RatingMicroServiceApi.Controllers;
using RatingMicroServiceApi.Models.Domain;
using RatingMicroServiceApi.Repositories;
using RatingMicroServiceApi.Tests.MockData;

namespace RatingMicroServiceApi.Tests.Systems
{
    public class TestRatingController
    {
    
        [Fact]
        public async Task GetRatByIdAsync_ShouldBe200StatusCode()
        {
            //Arrange
            var ratingRepository = new Mock<IRatingRepository>();
            var mapper = new Mock<IMapper>();
            int candidateId = 1;
            ratingRepository.Setup(x => x.GetRatingAsync(candidateId)).ReturnsAsync(RatingMockData.rating());
            var sut = new RatingController(ratingRepository.Object, mapper.Object);

            //Act
            var result = await sut.GetRatByIdAsync(candidateId);

            //Assert
            result.GetType().Should().Be(typeof(OkObjectResult));
            (result as OkObjectResult).StatusCode.Should().Be(200);
        }
        [Fact]
        public async Task GetRatByIdAsync_ShouldBe204StatusCode()
        {
            //Arrange
            var ratingRepository=new Mock<IRatingRepository>();
            var mapper=new Mock<IMapper>();
            int candidateId = 1;
            ratingRepository.Setup(x => x.GetRatingAsync(candidateId)).ReturnsAsync(RatingMockData.EmptyRating);
            var sut= new RatingController(ratingRepository.Object, mapper.Object);
            //Act
            var result = await sut.GetRatByIdAsync(candidateId);
            //Assert
            result.GetType().Should().Be(typeof(NoContentResult));
            (result as NoContentResult).StatusCode.Should().Be(204);
        }
        [Fact]
        public async Task AddRatAsync_ShouldBe201StatusCode()
        {
            //Arrange
            var ratingRepository= new Mock<IRatingRepository>();
            var mapper= new Mock<IMapper>();
            var ratStruct = new Mock<Rating>();
            ratingRepository.Setup(x => x.AddRatingAsync(ratStruct.Object)).ReturnsAsync(RatingMockData.rating());
            var sut= new RatingController(ratingRepository.Object, mapper.Object);
            //Act
            var result=await sut.AddRatAsync(ratStruct.Object);
            //Assert
            result.GetType().Should().Be(typeof(CreatedResult));
            (result as CreatedResult).StatusCode.Should().Be(201);
        }
        [Fact]
        public async Task AddRatAsync_ShouldBe400StatusCode()
        {
            //Arrange
            var ratingRepository=new Mock<IRatingRepository>();
            var mapper=new Mock<IMapper>();
            var ratStruct=new Mock<Rating>();
            ratingRepository.Setup(x => x.AddRatingAsync(ratStruct.Object)).ReturnsAsync(RatingMockData.EmptyRating());
            var sut= new RatingController(ratingRepository.Object, mapper.Object);
            sut.ModelState.AddModelError("Key", "error message");
            //Act
            var result = await sut.AddRatAsync(ratStruct.Object);
            //Assert
            result.GetType().Should().Be(typeof(BadRequestObjectResult));
            (result as BadRequestObjectResult).StatusCode.Should().Be(400);
        }
        [Fact]
        public async Task UpdateRatingAsync_ShouldBe200StatusCode()
        {
            //Arrange
            var ratingRepository = new Mock<IRatingRepository>();
            var mapper = new Mock<IMapper>();
            var ratStruct = new Mock<Rating>();
            int candidateId = 1;
            ratingRepository.Setup(x => x.UpdateHrRatingAsync(candidateId, ratStruct.Object)).ReturnsAsync(RatingMockData.rating());
            var sut = new RatingController(ratingRepository.Object, mapper.Object);
            //Act
            var result = await sut.UpdateHrRatAsync(candidateId, ratStruct.Object);
            //Assert
            result.GetType().Should().Be(typeof(OkObjectResult));
            (result as OkObjectResult).StatusCode.Should().Be(200);
        }
        [Fact]
        public async Task UpdateRatingAsync_ShouldBe404StatusCode()
        {
            //Arrange
            var ratingRepository = new Mock<IRatingRepository>();
            var mapper = new Mock<IMapper>();
            var ratStruct = new Mock<Rating>();
            int candidateId = 1;
            ratingRepository.Setup(x => x.UpdateHrRatingAsync(candidateId, ratStruct.Object)).ReturnsAsync(RatingMockData.EmptyRating());
            var sut = new RatingController(ratingRepository.Object, mapper.Object);
            //Act
            var result = await sut.UpdateHrRatAsync(candidateId, ratStruct.Object);
            //Assert
            result.GetType().Should().Be(typeof(NotFoundResult));
            (result as NotFoundResult).StatusCode.Should().Be(404);
        }
        [Fact]
        public async Task UpdateRatingAsync_ShouldReturn400StatusCode()
        {
            //Arrange
            var ratingRepository = new Mock<IRatingRepository>();
            var mapper = new Mock<IMapper>();
            var ratStruct = new Mock<Rating>();
            int CandidateId = 1;
            ratingRepository.Setup(x => x.UpdateHrRatingAsync(CandidateId, ratStruct.Object)).ReturnsAsync(RatingMockData.EmptyRating());
            var sut = new RatingController(ratingRepository.Object, mapper.Object);
            sut.ModelState.AddModelError("Key", "error message");
            //Act
            var result = await sut.UpdateHrRatAsync(CandidateId, ratStruct.Object);
            //Assert
            result.GetType().Should().Be(typeof(BadRequestObjectResult));
            (result as BadRequestObjectResult).StatusCode.Should().Be(400);
        }

    }

}
