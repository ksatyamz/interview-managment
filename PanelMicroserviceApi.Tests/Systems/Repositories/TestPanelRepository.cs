using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using PanelMicroservice.Data;
using PanelMicroservice.Models.Domain;
using PanelMicroservice.Repository;
using PanelMicroserviceApi.Tests.MockData;

namespace PanelMicroserviceApi.Tests.Systems.Repositories
{
    public class TestPanelRepository : IDisposable
    {
        private readonly PanelDbContext context;

        public TestPanelRepository()
        {
            var options = new DbContextOptionsBuilder<PanelDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            context = new PanelDbContext(options);
            context.Database.EnsureCreated();
        }

        [Fact]
        public async Task GetPanelsAsync_ShouldReturnPanelList()
        {
            //Arrange
            context.panels.AddRange(PanelMockData.GetPanelsAsync());
            context.SaveChanges();
            var sut = new   PanelRepository(context);
            //Act
            var result = await sut.GetPanelsAsync();
            //Assert
            result.Should().HaveCount(PanelMockData.GetPanelsAsync().Count);
        }


        [Fact]
        public async Task GetPanelByIdAsync_ShouldReturnPanelById()
        {
            //Arrange
            context.panels.AddRange(PanelMockData.GetPanelsAsync());
            context.SaveChanges();
            var sut = new PanelRepository(context);
            int id = 1;



            //Act
            var result = await sut.GetPanelByIdAsync(id);
            //Assert
            result.Should().BeOfType(typeof(Panel));
        }

        [Fact]
        public async Task AddAsync_ShouldReturnAddedEmployee()
        {
            //Arrange
            context.panels.AddRange(PanelMockData.panel());
            context.SaveChanges();
            var sut = new PanelRepository(context);
            Panel emp = PanelMockData.panel();
            //Act
            var result = await sut.AddPanelAsync(emp);
            //Assert
            result.Should().BeNull();
        }

        [Fact]
        public async Task DelPanelAsync_ShouldReturnDeletedEmployee()
        {
            //Arrange
            context.panels.AddRange(PanelMockData.GetPanelsAsync());
            context.SaveChanges();
            var sut = new PanelRepository(context);
            //Employee emp = EmployeeMockData.AddEmployee();
            //Act
            var result = await sut.DelPanelAsync(2);
            //Assert
            result.Should().BeOfType(typeof(List<Panel>));
        }

        [Fact]
        public async Task DelPanelByIdAsync_ShouldReturnDeletedEmployee()
        {
            //Arrange
            context.panels.AddRange(PanelMockData.panel());
            context.SaveChanges();
            var sut = new PanelRepository(context);
            //Employee emp = EmployeeMockData.AddEmployee();
            //Act
            var result = await sut.DelPanelByIdAsync(2,1);
            //Assert
            result.Should().BeOfType(typeof(Panel));
        }


        public void Dispose()
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }
    }
}
