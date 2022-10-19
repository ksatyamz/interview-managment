using AutoMapper;
using FluentAssertions;
using InterviewMicroserviceApi.Controllers;
using InterviewMicroserviceApi.Models.Domain;
using InterviewMicroserviceApi.Repositories;
using InterviewMicroserviceApi.Tests.MockData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Moq;
using Xunit;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace InterviewMicroserviceApi.Tests.System.Controllers
{
    public class TestInterviewController
    {
        [Fact]
        public async Task GetInterAsync_ShouldReturn200StatusCode()
        {
            //Arrange
            var interviewRepository = new Mock<IInterviewRepository>();
            var mapper = new Mock<IMapper>();
            interviewRepository.Setup(x => x.GetInterviewsAsync()).ReturnsAsync(InterviewMockData.GetInterviews());
            var sut = new InterviewController(interviewRepository.Object, mapper.Object);

            //Act
            var result = await sut.GetInterAsync();
            //Assert
            result.GetType().Should().Be(typeof(OkObjectResult));
            (result as OkObjectResult).StatusCode.Should().Be(200);

        }
        [Fact]
        public async Task GetInterAsync_ShouldReturn204ReturnStatus()
        {
            var interviewRepository = new Mock<IInterviewRepository>();
            var mapper = new Mock<IMapper>();
            interviewRepository.Setup(x => x.GetInterviewsAsync()).ReturnsAsync(InterviewMockData.GetEmptyList());
            var sut = new InterviewController(interviewRepository.Object, mapper.Object);

            //Act
            var result = await sut.GetInterAsync();
            //Assert
            result.GetType().Should().Be(typeof(NoContentResult));
            (result as NoContentResult).StatusCode.Should().Be(204);

        }

        [Fact]
        public async Task  GetInterByIdAsync_ShouldReturnStatusCode200()
        {
            var interviewRepository=new Mock<IInterviewRepository>();
            var mapper=new Mock<IMapper>();
            int id = 1;
            interviewRepository.Setup(x => x.GetInterviewByIdAsync(id)).ReturnsAsync(InterviewMockData.GetInterview());
            var sut= new InterviewController(interviewRepository.Object, mapper.Object);

            var result = await sut.GetInterByIdAsync(id);

            result.GetType().Should().Be(typeof(OkObjectResult));
            (result as OkObjectResult).StatusCode.Should().Be(200);
        }

        [Fact]
        public async Task GetInterByIdAsync_ShouldReturnStatusCode204()
        {
            var interviewRepository = new Mock<IInterviewRepository>();
            var mapper = new Mock<IMapper>();
            int id = 1;
            interviewRepository.Setup(x=>x.GetInterviewByIdAsync(id)).ReturnsAsync(InterviewMockData.GetEmptyInterview());
            var sut=new InterviewController(interviewRepository.Object, mapper.Object);

            var result =await  sut.GetInterByIdAsync(id);

            result.GetType().Should().Be(typeof(NoContentResult));
            (result as NoContentResult).StatusCode.Should().Be(204);

        }
        [Fact]
        public async Task GetInterByCadIdAsync_ShouldReturnStatusCode200()
        {
            var interviewRepository = new Mock<IInterviewRepository>();
            var mapper = new Mock<IMapper>();
            int id = 1;
            interviewRepository.Setup(x => x.GetInterviewByCadIdAsync(id)).ReturnsAsync(InterviewMockData.GetInterviews());
            var sut = new InterviewController(interviewRepository.Object, mapper.Object);

            var result = await sut.GetInterByCadIdAsync(id);

            result.GetType().Should().Be(typeof(OkObjectResult));
            (result as OkObjectResult).StatusCode.Should().Be(200);
        }

        [Fact]
        public async Task GetInterByCadIdAsync_ShouldReturnStatusCode204()
        {
            var interviewRepository = new Mock<IInterviewRepository>();
            var mapper = new Mock<IMapper>();
            int id = 1;
            interviewRepository.Setup(x => x.GetInterviewByCadIdAsync(id)).ReturnsAsync(InterviewMockData.GetEmptyList());
            var sut = new InterviewController(interviewRepository.Object, mapper.Object);

            var result = await sut.GetInterByCadIdAsync(id);

            result.GetType().Should().Be(typeof(NoContentResult));
            (result as NoContentResult).StatusCode.Should().Be(204);

        }
        [Fact]
        public async Task GetInterByPanIdAsync_ShouldReturnStatusCode200()
        {
            var interviewRepository = new Mock<IInterviewRepository>();
            var mapper = new Mock<IMapper>();
            int id = 1;
            interviewRepository.Setup(x => x.GetInterviewByPanIdAsync(id)).ReturnsAsync(InterviewMockData.GetInterviews());
            var sut = new InterviewController(interviewRepository.Object, mapper.Object);

            var result = await sut.GetInterByPanIdAsync(id);

            result.GetType().Should().Be(typeof(OkObjectResult));
            (result as OkObjectResult).StatusCode.Should().Be(200);
        }

        [Fact]
        public async Task GetInterByPanIdAsync_ShouldReturnStatusCode204()
        {
            var interviewRepository = new Mock<IInterviewRepository>();
            var mapper = new Mock<IMapper>();
            int id = 1;
            interviewRepository.Setup(x => x.GetInterviewByPanIdAsync(id)).ReturnsAsync(InterviewMockData.GetEmptyList());
            var sut = new InterviewController(interviewRepository.Object, mapper.Object);

            var result = await sut.GetInterByPanIdAsync(id);

            result.GetType().Should().Be(typeof(NoContentResult));
            (result as NoContentResult).StatusCode.Should().Be(204);

        }
        [Fact]
        public async Task AddInterviewAsync_ShouldReturnStatusCode200()
        {
            var interviewRepository = new Mock<IInterviewRepository>();
            var mapper = new Mock<IMapper>();
            var interview = new Mock<Interview>();
            interviewRepository.Setup(x => x.AddInterviewAsync(interview.Object)).ReturnsAsync(InterviewMockData.GetInterview());
            var sut= new InterviewController(interviewRepository.Object, mapper.Object);
            var result = await sut.AddInterviewAsync(interview.Object);
            result.GetType().Should().Be(typeof(OkObjectResult));
            (result as OkObjectResult).StatusCode.Should().Be(200);

        }
        [Fact]
        public async Task AddInterviewAsync_ShouldReturnStatusCode400()
        {
            var interviewRepository = new Mock<IInterviewRepository>();
            var mapper = new Mock<IMapper>();
            interviewRepository.Setup(x => x.AddInterviewAsync(InterviewMockData.GetInterview())).ReturnsAsync(InterviewMockData.GetInterview());
            var sut = new InterviewController(interviewRepository.Object, mapper.Object);
            sut.ModelState.AddModelError("Key", "error message");
            var result = await sut.AddInterviewAsync(InterviewMockData.GetInterview());
            result.GetType().Should().Be(typeof(BadRequestObjectResult));
            (result as BadRequestObjectResult).StatusCode.Should().Be(400);

        }
        [Fact]

        public async Task UpdateInterviewAsync_ShouldReturnStatusCode200()
        {
            var interviewRepository = new Mock<IInterviewRepository>();
            var mapper = new Mock<IMapper>();
            var interview = new Mock<Interview>();
            int id = 1;
            interviewRepository.Setup(x => x.UpdateInterviewAsync(interview.Object,id)).ReturnsAsync(InterviewMockData.GetInterview());
            var sut = new InterviewController(interviewRepository.Object, mapper.Object);

            var result = await sut.UpdateInterviewAsync(interview.Object, id);

            result.GetType().Should().Be(typeof(OkObjectResult));
            (result as OkObjectResult).StatusCode.Should().Be(200);
        }


            [Fact]
            public async Task UpdateInterviewAsync_ShouldReturnStatusCode204()
            {
                var interviewRepository = new Mock<IInterviewRepository>();
                var mapper = new Mock<IMapper>();
                int id = 1;
                interviewRepository.Setup(x => x.UpdateInterviewAsync(InterviewMockData.GetInterview(), id)).ReturnsAsync(InterviewMockData.GetEmptyInterview());
                var sut = new InterviewController(interviewRepository.Object, mapper.Object);
                var result = await sut.UpdateInterviewAsync(InterviewMockData.GetInterview(), id);
                result.GetType().Should().Be(typeof(NoContentResult));
                (result as NoContentResult).StatusCode.Should().Be(204);

            }






        }
}
