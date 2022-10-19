using AutoMapper;
using EmployeeApi.Models.Domain;
using EmployeeApi.Models.Dto;
using EmployeeApi.Repositories;
using EmployeeApi.Services;
using EmployeeMicroserviceAPI.Models.Domain;
using JwtAuyhenticationManager;
using JwtAuyhenticationManager.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository employeeRepository;
        private readonly IMapper mapper;
        private readonly JwtTokenHandler jwtAuthenticationManager;
        public EmployeeController(IEmployeeRepository employeeRepository, IMapper mapper, JwtTokenHandler jwtAuthenticationManager)
        {
            this.employeeRepository = employeeRepository;
            this.mapper = mapper;
            this.jwtAuthenticationManager = jwtAuthenticationManager;

        }
        //public EmployeeController(IJwtAuthenticationManager jwtAuthenticationManager)
        //{
        //    this.jwtAuthenticationManager = jwtAuthenticationManager;
        //}
        [HttpPost("Login")]
        public ActionResult<AuthenticationResponse> Authenticate([FromBody] AuthenticationRequest employee) //Model Building
        {
            var token = jwtAuthenticationManager.GenerateToken(employee);
            if (token == null)
            {
                return Unauthorized();
            }
            return Ok(token);
        }
        [HttpGet]
        //[Authorize(Roles = "Admin")]

        public async Task<IActionResult> GetEmpsAsync()
        {
            
            var allEmployees = await employeeRepository.GetEmployeesAsync();
            
            if (allEmployees.Count() == 0)
            {
                return NoContent();
            }
            var employeesDto = mapper.Map<List<EmployeeDto>>(allEmployees);
            return Ok(employeesDto);
        }
        [HttpGet("EmpId")]
       // [Authorize]
        public async Task<IActionResult> GetEmpByIdAsync(int id)
        {
            var employee = await employeeRepository.GetEmployeeByIdAsync(id);
            if (employee == null)
            {
                return NoContent();
            }
            var employeeDto = mapper.Map<EmployeeDto>(employee);
            return Ok(employeeDto);    
        }
        [HttpGet("Name")]
       // [Authorize]
        public async Task<IActionResult> GetEmpByNameAsync(string firstname)
        {
            var employeesByName = await employeeRepository.GetEmployeeByNameAsync(firstname);
            if (employeesByName.Count() == 0)
            {
                return NoContent();
            }
            var employeesDto = mapper.Map<List<EmployeeDto>>(employeesByName);
            return Ok(employeesDto);

        }


        [HttpGet("Role")]
        //[Authorize]
        public async Task<IActionResult> GetEmpByRoleAsync(string role)
        {
            var employeeByRole = await employeeRepository.GetEmployeeByRoleAsync(role);
            if (employeeByRole.Count() == 0)
            {
                return NoContent();
            }
            var employeeDto = mapper.Map<List<EmployeeDto>>(employeeByRole);
            return Ok(employeeByRole);
        }


        [HttpPost("Register")]
        public async Task<IActionResult> AddEmpAsync(Employee emp)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                var employee = await employeeRepository.AddEmployeeAsync(emp);
                var empDto = mapper.Map<EmployeeDto>(employee);
                return Created("Succesfully created",empDto);
            }
        }
        [HttpDelete("{EmpId}")]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteEmpAsync(int id)
        {
            var emp = await employeeRepository.DeleteEmployeeAsync(id);
            if (emp == null)
            {
                return NotFound();
            }
            var empDto = mapper.Map<EmployeeDto>(emp);
            return Ok(empDto);
        }
        [HttpPut("{EmpId}")]
       // [Authorize]
        public async Task<IActionResult> UpdateEmpAsync(Employee employee, int id)
        {
            var emp = await employeeRepository.UpdateEmployeeAsync(employee, id);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else if (emp == null)
            {
                return NotFound();
            }
            else
            {
                var empDto = mapper.Map<Employee>(emp);
                return Ok(empDto);
            }
        }

       
    }
}
