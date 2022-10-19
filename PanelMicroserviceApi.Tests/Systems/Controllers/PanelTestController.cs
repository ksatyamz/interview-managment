using AutoMapper;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using PanelMicroservice.Models.Domain;
using PanelMicroservice.Repository;
using PanelMicroserviceApi.Controllers;
using PanelMicroserviceApi.Tests.MockData;





namespace InterviewManagement.Tests.Systems.Controller
{
    public class TestEmployeeController
    {
        #region
        [Fact]
        public async Task GetPanelByIdAsync_ShouldBe200StatusCode()
        {
            //Arrange            
            var panelRepository = new Mock<IPanelRepository>();
            var mapper = new Mock<IMapper>();
            int panelId = 1;

            panelRepository.Setup(x => x.GetPanelByIdAsync(panelId)).ReturnsAsync(PanelMockData.panel());

            var sut = new PanelController(panelRepository.Object, mapper.Object);

            //Act            
            var result = await sut.GetPanelByIdAsync(panelId);

            //Assert            
            result.GetType().Should().Be(typeof(OkObjectResult));
            (result as OkObjectResult).StatusCode.Should().Be(200);
        }
        [Fact]
        public async Task GetEmpByIdAsync_ShouldReturn204StatusCode()
        {
            //Arrange            
            var panelRepository = new Mock<IPanelRepository>();
            var mapper = new Mock<IMapper>();
            int id = 1;

            panelRepository.Setup(x => x.GetPanelByIdAsync(id)).ReturnsAsync(PanelMockData.EmptyPanel());

            var sut = new PanelController(panelRepository.Object, mapper.Object);

            //Act            
            var result = await sut.GetPanelByIdAsync(id);

            //Assert            
            result.GetType().Should().Be(typeof(NoContentResult));
            (result as NoContentResult).StatusCode.Should().Be(204);
        }
        #endregion


        #region
        [Fact]
        public async Task GetPanelAsync_ShouldBe200StatusCode()
        {
            //Arrange            
            var panelRepository = new Mock<IPanelRepository>();
            var mapper = new Mock<IMapper>();

            panelRepository.Setup(x => x.GetPanelsAsync()).ReturnsAsync(PanelMockData.GetPanelsAsync());

            var sut = new PanelController(panelRepository.Object, mapper.Object);

            //Act            
            var result = await sut.GetPanelsAsync();

            //Assert            
            result.GetType().Should().Be(typeof(OkObjectResult));
            (result as OkObjectResult).StatusCode.Should().Be(200);
        }
        [Fact]
        public async Task GetEmpsAsync_ShouldBe204StatusCode()
        {
            //Arrange            
            var panelRepository = new Mock<IPanelRepository>();
            var mapper = new Mock<IMapper>();

            panelRepository.Setup(x => x.GetPanelsAsync()).ReturnsAsync(PanelMockData.EmptyPanelList());

            var sut = new PanelController(panelRepository.Object, mapper.Object);

            //Act            
            var result = await sut.GetPanelsAsync();

            //Assert            
            result.GetType().Should().Be(typeof(NoContentResult));
            (result as NoContentResult).StatusCode.Should().Be(204);
        }
        #endregion


        #region
        [Fact]
        public async Task AddPanelAsync_ShouldBe200StatusCode()
        {
            //Arrange
            var panelRepository = new Mock<IPanelRepository>();
            var mapper = new Mock<IMapper>();
            var pnlstruct = new Mock<Panel>();



            panelRepository.Setup(x => x.AddPanelAsync(pnlstruct.Object)).ReturnsAsync(PanelMockData.panel());
            var sut = new PanelController(panelRepository.Object, mapper.Object);
            //Act
            var result = await sut.AddPanelAsync(pnlstruct.Object);
            //Assert
            result.GetType().Should().Be(typeof(OkObjectResult));
            (result as OkObjectResult).StatusCode.Should().Be(200);
        }
        [Fact]
        public async Task AddPanelAsync_ShouldBe400StatusCode()
        {
            //Arrange
            var panelRepository = new Mock<IPanelRepository>();
            var mapper = new Mock<IMapper>();
            var pnlstruct = new Mock<Panel>();


            panelRepository.Setup(x => x.AddPanelAsync(pnlstruct.Object)).ReturnsAsync(PanelMockData.EmptyPanel());
            var sut = new PanelController(panelRepository.Object, mapper.Object);
            sut.ModelState.AddModelError("Key", "error message");
            //Act
            var result = await sut.AddPanelAsync(pnlstruct.Object);
            //Assert
            result.GetType().Should().Be(typeof(BadRequestObjectResult));
            (result as BadRequestObjectResult).StatusCode.Should().Be(400);
        }
        #endregion


        #region
        [Fact]
        public async Task DelPanelAsync_ShouldBe200StatusCode()
        {
            //Arrange
            var panelRepository = new Mock<IPanelRepository>();
            var mapper = new Mock<IMapper>();
            //int id = 1;



            panelRepository.Setup(x => x.DelPanelAsync(1)).ReturnsAsync(PanelMockData.GetPanelsAsync());
            var sut = new PanelController(panelRepository.Object, mapper.Object);



            //Act
            var result = await sut.DelPanelAsync(1);
            //Assert
            result.GetType().Should().Be(typeof(OkObjectResult));
            (result as OkObjectResult).StatusCode.Should().Be(200);
        }
        [Fact]
        public async Task DelPanelAsync_ShouldBe404StatusCode()
        {
            //Arrange
            var panelRepository = new Mock<IPanelRepository>();
            var mapper = new Mock<IMapper>();
            int id = 1;



            panelRepository.Setup(x => x.DelPanelAsync(id)).ReturnsAsync(PanelMockData.EmptyPanelList());
            var sut = new PanelController(panelRepository.Object, mapper.Object);



            //Act
            var result = await sut.DelPanelAsync(id);
            //Assert
            result.GetType().Should().Be(typeof(NotFoundObjectResult));
            (result as NotFoundObjectResult).StatusCode.Should().Be(404);
        }
        #endregion


        #region
        [Fact]
        public async Task DelPanelIdAsync_ShouldBe200StatusCode()
        {
            //Arrange
            var panelRepository = new Mock<IPanelRepository>();
            var mapper = new Mock<IMapper>();
            //int id = 1;



            panelRepository.Setup(x => x.DelPanelByIdAsync(1,2)).ReturnsAsync(PanelMockData.panel());
            var sut = new PanelController(panelRepository.Object, mapper.Object);



            //Act
            var result = await sut.DelPanelByIdAsync(1,2);
            //Assert
            result.GetType().Should().Be(typeof(OkObjectResult));
            (result as OkObjectResult).StatusCode.Should().Be(200);
        }
        [Fact]
        public async Task DelPanelByIdAsync_ShouldBe404StatusCode()
        {
            //Arrange
            var panelRepository = new Mock<IPanelRepository>();
            var mapper = new Mock<IMapper>();
            int pId = 1;
            int eId = 2;


            panelRepository.Setup(x => x.DelPanelByIdAsync(pId, eId)).ReturnsAsync(PanelMockData.EmptyPanel());
            var sut = new PanelController(panelRepository.Object, mapper.Object);



            //Act
            var result = await sut.DelPanelByIdAsync(pId,eId);
            //Assert
            result.GetType().Should().Be(typeof(NotFoundResult));
            (result as NotFoundResult).StatusCode.Should().Be(404);
        }

        #endregion

    }
}

