using AutoMapper;
using EmployeeApi.Controllers;
using EmployeeApi.Models.Domain;
using EmployeeApi.Repositories;
using EmployeeApi.Services;
using FluentAssertions;
using InterviewManagement.Tests.MockData;
using JwtAuyhenticationManager;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace InterviewManagement.Tests.Systems.Controller
{
    public class TestEmployeeController
    {
        [Fact]
        public async Task GetEmpsAsync_ShouldReturn200StatusCode()
        {
            //Arrange
            var employeeRepository = new Mock<IEmployeeRepository>();
            var mapper = new Mock<IMapper>();
            var jwtAuthentication = new Mock<JwtTokenHandler>();
            employeeRepository.Setup(x => x.GetEmployeesAsync()).ReturnsAsync(EmployeeMockData.GetEmployees());

            var sut = new EmployeeController(employeeRepository.Object, mapper.Object, jwtAuthentication.Object);

            //Act
            var result = await sut.GetEmpsAsync();

            //Assert
            result.GetType().Should().Be(typeof(OkObjectResult));
            (result as OkObjectResult).StatusCode.Should().Be(200);
        }
        [Fact]
        public async Task GetEmpsAsync_ShouldReturn204StatusCode()
        {
            //Arrange
            var employeeRepository = new Mock<IEmployeeRepository>();
            var mapper = new Mock<IMapper>();
            var jwtAuthentication = new Mock<JwtTokenHandler>();

            employeeRepository.Setup(x => x.GetEmployeesAsync()).ReturnsAsync(EmployeeMockData.EmptyEmployeeList());

            var sut = new EmployeeController(employeeRepository.Object, mapper.Object, jwtAuthentication.Object);

            //Act
            var result = await sut.GetEmpsAsync();

            //Assert
            result.GetType().Should().Be(typeof(NoContentResult));
            (result as NoContentResult).StatusCode.Should().Be(204);
        }
        [Fact]
        public async Task GetEmpByIdAsync_ShouldReturn200StatusCode()
        {
            //Arrange
            var employeeRepository = new Mock<IEmployeeRepository>();
            var mapper = new Mock<IMapper>();
            var jwtAuthentication = new Mock<JwtTokenHandler>();
            int empId = 1;


            employeeRepository.Setup(x => x.GetEmployeeByIdAsync(empId)).ReturnsAsync(EmployeeMockData.employee());

            var sut = new EmployeeController(employeeRepository.Object, mapper.Object, jwtAuthentication.Object);

            //Act
            var result = await sut.GetEmpByIdAsync(empId);

            //Assert
            result.GetType().Should().Be(typeof(OkObjectResult));
            (result as OkObjectResult).StatusCode.Should().Be(200);
        }
        [Fact]
        public async Task GetEmpByIdAsync_ShouldReturn204StatusCode()
        {
            //Arrange
            var employeeRepository = new Mock<IEmployeeRepository>();
            var mapper = new Mock<IMapper>();
            var jwtAuthentication = new Mock<JwtTokenHandler>();
            int id = 1;

            employeeRepository.Setup(x => x.GetEmployeeByIdAsync(id)).ReturnsAsync(EmployeeMockData.EmptyEmployee());

            var sut = new EmployeeController(employeeRepository.Object, mapper.Object, jwtAuthentication.Object);

            //Act
            var result = await sut.GetEmpByIdAsync(id);

            //Assert
            result.GetType().Should().Be(typeof(NoContentResult));
            (result as NoContentResult).StatusCode.Should().Be(204);
        }
        [Fact]
        public async Task GetEmpByNameAsync_ShouldReturn200StatusCode()
        {
            //Arrange
            var employeeRepository = new Mock<IEmployeeRepository>();
            var mapper = new Mock<IMapper>();
            var jwtAuthentication = new Mock<JwtTokenHandler>();
            string fname = "Abhilash";
            

            employeeRepository.Setup(x => x.GetEmployeeByNameAsync(fname)).ReturnsAsync(EmployeeMockData.GetEmployees());

            var sut = new EmployeeController(employeeRepository.Object, mapper.Object, jwtAuthentication.Object);

            //Act
            var result = await sut.GetEmpByNameAsync(fname);

            //Assert
            result.GetType().Should().Be(typeof(OkObjectResult));
            (result as OkObjectResult).StatusCode.Should().Be(200);
        }
        [Fact]
        public async Task GetEmpByNameAsync_ShouldReturn204StatusCode()
        {
            //Arrange
            var employeeRepository = new Mock<IEmployeeRepository>();
            var mapper = new Mock<IMapper>();
            var jwtAuthentication = new Mock<JwtTokenHandler>();
            string fname = "Abhilash";
            

            employeeRepository.Setup(x => x.GetEmployeeByNameAsync(fname)).ReturnsAsync(EmployeeMockData.EmptyEmployeeList());

            var sut = new EmployeeController(employeeRepository.Object, mapper.Object, jwtAuthentication.Object);

            //Act
            var result = await sut.GetEmpByNameAsync(fname);

            //Assert
            result.GetType().Should().Be(typeof(NoContentResult));
            (result as NoContentResult).StatusCode.Should().Be(204);
        }
        [Fact]
        public async Task GetEmpByRoleAsync_ShouldReturn200StatusCode()
        {
            //Arrange
            var employeeRepository = new Mock<IEmployeeRepository>();
            var mapper = new Mock<IMapper>();
            var jwtAuthentication = new Mock<JwtTokenHandler>();
            string role = "Tech";

            employeeRepository.Setup(x => x.GetEmployeeByRoleAsync(role)).ReturnsAsync(EmployeeMockData.GetEmployees());

            var sut = new EmployeeController(employeeRepository.Object, mapper.Object, jwtAuthentication.Object);

            //Act
            var result = await sut.GetEmpByRoleAsync(role);

            //Assert
            result.GetType().Should().Be(typeof(OkObjectResult));
            (result as OkObjectResult).StatusCode.Should().Be(200);
        }
        [Fact]
        public async Task GetEmpByRoleAsync_ShouldReturn204StatusCode()
        {
            //Arrange
            var employeeRepository = new Mock<IEmployeeRepository>();
            var mapper = new Mock<IMapper>();
            var jwtAuthentication = new Mock<JwtTokenHandler>();
            string role = "Tech";

            employeeRepository.Setup(x => x.GetEmployeeByRoleAsync(role)).ReturnsAsync(EmployeeMockData.EmptyEmployeeList());

            var sut = new EmployeeController(employeeRepository.Object, mapper.Object, jwtAuthentication.Object);

            //Act
            var result = await sut.GetEmpByRoleAsync(role);

            //Assert
            result.GetType().Should().Be(typeof(NoContentResult));
            (result as NoContentResult).StatusCode.Should().Be(204);
        }
        [Fact]
        public async Task AddEmpAsync_ShouldReturn201StatusCode()
        {
            //Arrange
            var employeeRepository = new Mock<IEmployeeRepository>();
            var mapper = new Mock<IMapper>();
            var jwtAuthentication = new Mock<JwtTokenHandler>();
            var empstruct = new Mock<Employee>();

            employeeRepository.Setup(x => x.AddEmployeeAsync(empstruct.Object)).ReturnsAsync(EmployeeMockData.employee());
            var sut = new EmployeeController(employeeRepository.Object, mapper.Object, jwtAuthentication.Object);
            //Act
            var result = await sut.AddEmpAsync(empstruct.Object);
            //Assert
            result.GetType().Should().Be(typeof(CreatedResult));
            (result as CreatedResult).StatusCode.Should().Be(201);
        }
        [Fact]
        public async Task AddEmpAsync_ShouldReturn400StatusCode()
        {
            //Arrange
            var employeeRepository = new Mock<IEmployeeRepository>();
            var mapper = new Mock<IMapper>();
            var jwtAuthentication = new Mock<JwtTokenHandler>();
            var empstruct = new Mock<Employee>();

            employeeRepository.Setup(x => x.AddEmployeeAsync(empstruct.Object)).ReturnsAsync(EmployeeMockData.EmptyEmployee());
            var sut = new EmployeeController(employeeRepository.Object, mapper.Object, jwtAuthentication.Object);
            sut.ModelState.AddModelError("Key", "error message");
            //Act
            var result = await sut.AddEmpAsync(empstruct.Object);
            //Assert
            result.GetType().Should().Be(typeof(BadRequestObjectResult));
            (result as BadRequestObjectResult).StatusCode.Should().Be(400);
        }
        [Fact]
        public async Task DeleteEmpAsync_ShouldReturn200StatusCode()
        {
            //Arrange
            var employeeRepository = new Mock<IEmployeeRepository>();
            var mapper = new Mock<IMapper>();
            var jwtAuthentication = new Mock<JwtTokenHandler>();
            int id = 1;

            employeeRepository.Setup(x => x.DeleteEmployeeAsync(id)).ReturnsAsync(EmployeeMockData.employee());
            var sut = new EmployeeController(employeeRepository.Object, mapper.Object, jwtAuthentication.Object);

            //Act
            var result = await sut.DeleteEmpAsync(id);
            //Assert
            result.GetType().Should().Be(typeof(OkObjectResult));
            (result as OkObjectResult).StatusCode.Should().Be(200);
        }
        [Fact]
        public async Task DeleteEmpAsync_ShouldReturn404StatusCode()
        {
            //Arrange
            var employeeRepository = new Mock<IEmployeeRepository>();
            var mapper = new Mock<IMapper>();
            var jwtAuthentication = new Mock<JwtTokenHandler>();
            int id = 1;

            employeeRepository.Setup(x => x.DeleteEmployeeAsync(id)).ReturnsAsync(EmployeeMockData.EmptyEmployee());
            var sut = new EmployeeController(employeeRepository.Object, mapper.Object, jwtAuthentication.Object);

            //Act
            var result = await sut.DeleteEmpAsync(id);
            //Assert
            result.GetType().Should().Be(typeof(NotFoundResult));
            (result as NotFoundResult).StatusCode.Should().Be(404);
        }
        [Fact]
        public async Task UpdateEmpAsync_ShouldReturn200StatusCode()
        {
            //Arrange
            var employeeRepository = new Mock<IEmployeeRepository>();
            var mapper = new Mock<IMapper>();
            var jwtAuthentication = new Mock<JwtTokenHandler>();
            var empstruct = new Mock<Employee>();
            int id = 1;
            employeeRepository.Setup(x => x.UpdateEmployeeAsync(empstruct.Object, id)).ReturnsAsync(EmployeeMockData.employee());
            var sut = new EmployeeController(employeeRepository.Object, mapper.Object, jwtAuthentication.Object);

            //Act
            var result = await sut.UpdateEmpAsync(empstruct.Object, id);
            //Assert
            result.GetType().Should().Be(typeof(OkObjectResult));
            (result as OkObjectResult).StatusCode.Should().Be(200);

        }
        [Fact]
        public async Task UpdateEmpAsync_ShouldReturn404StatusCode()
        {
            //Arrange
            var employeeRepository = new Mock<IEmployeeRepository>();
            var mapper = new Mock<IMapper>();
            var jwtAuthentication = new Mock<JwtTokenHandler>();
            var empstruct = new Mock<Employee>();
            int id = 1;
            employeeRepository.Setup(x => x.UpdateEmployeeAsync(empstruct.Object, id)).ReturnsAsync(EmployeeMockData.EmptyEmployee());
            var sut = new EmployeeController(employeeRepository.Object, mapper.Object, jwtAuthentication.Object);

            //Act
            var result = await sut.UpdateEmpAsync(empstruct.Object, id);
            //Assert
            result.GetType().Should().Be(typeof(NotFoundResult));
            (result as NotFoundResult).StatusCode.Should().Be(404);

        }
        [Fact]
        public async Task UpdateEmpAsync_ShouldReturn400StatusCode()
        {
            //Arrange
            var employeeRepository = new Mock<IEmployeeRepository>();
            var mapper = new Mock<IMapper>();
            var jwtAuthentication = new Mock<JwtTokenHandler>();
            var empstruct = new Mock<Employee>();
            int id = 1;

            employeeRepository.Setup(x => x.UpdateEmployeeAsync(empstruct.Object, id)).ReturnsAsync(EmployeeMockData.EmptyEmployee());
            var sut = new EmployeeController(employeeRepository.Object, mapper.Object, jwtAuthentication.Object);
            sut.ModelState.AddModelError("Key", "error message");
            //Act
            var result = await sut.UpdateEmpAsync(empstruct.Object, id);
            //Assert
            result.GetType().Should().Be(typeof(BadRequestObjectResult));
            (result as BadRequestObjectResult).StatusCode.Should().Be(400);
        }

        //[Fact]
        //public async Task Authenticate_ShouldReturn401StatusCode()
        //{
        //    //Arrange
        //    var employeeRepository = new Mock<IEmployeeRepository>();
        //    var mapper = new Mock<IMapper>();
        //    var jwtAuthenticationManager = new Mock<JwtTokenHandler>();
        //    jwtAuthenticationManager.Setup(x => x.Authentication("user", "password")).Returns(EmployeeMockData.Token());
        //    var sut = new EmployeeController(employeeRepository.Object, mapper.Object, jwtAuthenticationManager.Object);
        //    //Act
        //    var userDetails = EmployeeMockData.EmployeeLogin();
        //    var result = sut.Authenticate(userDetails);
        //    //Assert
        //    result.GetType().Should().Be(typeof(UnauthorizedResult));
        //    (result as UnauthorizedResult).StatusCode.Should().Be(401);
        //}




        //[Fact]
        //public async Task Authenticate_ShouldReturn200StatusCode()
        //{
        //    //Arrange
        //    var employeeRepository = new Mock<IEmployeeRepository>();
        //    var mapper = new Mock<IMapper>();
        //    var jwtAuthenticationManager = new Mock<IJwtAuthenticationManager>();
        //    jwtAuthenticationManager.Setup(x => x.Authentication("arun_1", "arun@123")).Returns(EmployeeMockData.Token1());
        //    var sut = new EmployeeController(employeeRepository.Object, mapper.Object, jwtAuthenticationManager.Object);
        //    //Act
        //    var userDetails = EmployeeMockData.EmployeeLogin();
        //    var result = sut.Authenticate(userDetails);
        //    //Assert
        //    result.GetType().Should().Be(typeof(OkObjectResult));
        //    (result as OkObjectResult).StatusCode.Should().Be(200);
        //}

    }
}
