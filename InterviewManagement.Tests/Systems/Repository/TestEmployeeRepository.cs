using EmployeeApi.Data;
using EmployeeApi.Models.Domain;
using EmployeeApi.Repositories;
using EmployeeApi.Services;
using FluentAssertions;
using InterviewManagement.Tests.MockData;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace InterviewManagement.Tests.Systems.Repository
{
    public class TestEmployeeRepository : IDisposable
    {
        private readonly EmployeeDbContext context;
        public void Dispose()
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }
        public TestEmployeeRepository()
        {
            var options = new DbContextOptionsBuilder<EmployeeDbContext>()
                .UseInMemoryDatabase(databaseName:Guid.NewGuid().ToString())
                .Options;   
            context = new EmployeeDbContext(options);
            context.Database.EnsureCreated();
        }
        [Fact]
        public async Task GetEmployeesAsync_ShouldReturnEmployeeList()
        {
            //Arrange 
            context.Employees.AddRange(EmployeeMockData.GetEmployees());
            context.SaveChanges();
            var sut = new EmployeeRepository(context);
            //Act
            var result = await sut.GetEmployeesAsync();
            //Assert
            result.Should().HaveCount(EmployeeMockData.GetEmployees().Count);
        }
        [Fact]
        public async Task GetEmployeeByIdAsync_ShouldReturnEmployeeById()
        {
            //Arrange 
            context.Employees.AddRange(EmployeeMockData.employee());
            context.SaveChanges();
            var sut = new EmployeeRepository(context);
            int id = 1;

            //Act
            var result = await sut.GetEmployeeByIdAsync(id);
            //Assert
            result.Should().BeOfType<Employee>();

        }
        [Fact]
        public async Task GetEmployeeByNameAsync_ShouldReturnEmployeeListByName()
        {
            //Arrange 
            context.Employees.AddRange(EmployeeMockData.GetEmployees());
            context.SaveChanges();
            var sut = new EmployeeRepository(context);
            string firstname= "Abhilash";
            //Act
            var result = await sut.GetEmployeeByNameAsync(firstname);
            //Assert
            result.Should().HaveCount(2);

        }
        [Fact]
        public async Task GetEmployeeByNameAsync_ShouldReturnEmployeeListByRole()
        {
            //Arrange 
            context.Employees.AddRange(EmployeeMockData.GetEmployees());
            context.SaveChanges();
            var sut = new EmployeeRepository(context);
            string Role="Tech";
            //Act
            var result = await sut.GetEmployeeByRoleAsync(Role);
            //Assert
            result.Should().HaveCount(4);

        }
        [Fact]
        public async Task AddEmpAsync_ShouldReturnAddedEmployee()
        {
            //Arrange 
            context.Employees.AddRange(EmployeeMockData.GetEmployees());
            context.SaveChanges();
            var sut = new EmployeeRepository(context);
            Employee emp = EmployeeMockData.AddEmployee();
            //Act
            var result = await sut.AddEmployeeAsync(emp);
            //Assert
            result.Should().BeOfType<Employee>(); 
        }
        [Fact]
        public async Task UpdateEmpAsync_ShouldReturnUpdatedEmployee()
        {
            //Arrange 
            context.Employees.AddRange(EmployeeMockData.GetEmployees());
            context.SaveChanges();
            var sut = new EmployeeRepository(context);
            Employee emp = EmployeeMockData.AddEmployee();
            //Act
            var result = await sut.UpdateEmployeeAsync(emp,3);
            //Assert
            result.Should().BeOfType<Employee>();
        }
        [Fact]
        public async Task DeleteEmpAsync_ShouldReturnDeletedEmployee()
        {
            //Arrange 
            context.Employees.AddRange(EmployeeMockData.GetEmployees());
            context.SaveChanges();
            var sut = new EmployeeRepository(context);
            //Act
            var result = await sut.DeleteEmployeeAsync(3);
            //Assert
            result.Should().BeOfType<Employee>();
        }

        [Fact]
        public async Task Authenticate_ShouldReturnString()
        {
            //Arrange
            context.Employees.AddRange(EmployeeMockData.GetEmployees());
            context.SaveChanges();

            var employeeRepository = new Mock<EmployeeRepository>(context);
            string key = Guid.NewGuid().ToString();
            var sut = new JwtAuthenticationManager(key, employeeRepository.Object);

            //Act
            var result = sut.Authentication("arun_1", "arun@123");

            result.GetType().Should().Be(typeof(String));

        }

      
    }
}
