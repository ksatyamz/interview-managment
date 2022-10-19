using EmployeeApi.Data;
using EmployeeApi.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace EmployeeApi.Repositories
{
    public class EmployeeRepository:IEmployeeRepository
    {
        private readonly EmployeeDbContext employeeDbContext;
        public EmployeeRepository(EmployeeDbContext employeeDbContext)
        {
            this.employeeDbContext = employeeDbContext;    
        }

        public async Task<Employee> AddEmployeeAsync(Employee employee)
        {
            await employeeDbContext.AddAsync(employee);
            await employeeDbContext.SaveChangesAsync();
            return employee;
        }

        public async Task<Employee> DeleteEmployeeAsync(int id)
        {
            var emp = await employeeDbContext.Employees.SingleAsync(x => x.EmpId == id);
            if (emp == null)
            {
                return null;
            }
            else
            {
                employeeDbContext.Remove(emp);
                await employeeDbContext.SaveChangesAsync();
            }
            return emp;
        }

        public async Task<Employee> GetEmployeeByIdAsync(int id)
        {
            return await employeeDbContext.Employees.FirstOrDefaultAsync(x => x.EmpId == id);
        }

        public async Task<IEnumerable<Employee>> GetEmployeeByNameAsync(string firstname)
        {
            var tab = await employeeDbContext.Employees.ToListAsync();
            List<Employee> employee = new List<Employee>();
            foreach (var item in tab)
            {
                if (item.FirstName == firstname)
                {
                    employee.Add(item);

                }
            }
            return employee;
        }

        public async Task<IEnumerable<Employee>> GetEmployeeByRoleAsync(string role)
        {
            var tab = await employeeDbContext.Employees.ToListAsync();
            List<Employee> employee = new List<Employee>();

            foreach (var item in tab)
            {
                if (item.Role == role)
                {
                    employee.Add(item);

                }
            }
            return employee;
        }

        public async Task<IEnumerable<Employee>> GetEmployeesAsync()
        {
            return await employeeDbContext.Employees.ToListAsync();
        }

        public async Task<Employee> UpdateEmployeeAsync(Employee employee, int id)
        {
            var result = await employeeDbContext.Employees.FirstOrDefaultAsync(x => x.EmpId == id);
            if (result == null)
            {
                return null;
            }
            else
            {
                result.FirstName = employee.FirstName;
                result.LastName = employee.LastName;
                result.EmailAddress = employee.EmailAddress;
                result.Username = employee.Username;
                result.Password = employee.Password;
                result.PhoneNumber= employee.PhoneNumber;
                result.Location=employee.Location;
                result.Role = employee.Role;
                //result.RoleId = employee.RoleId;
                employeeDbContext.Update(result);
                await employeeDbContext.SaveChangesAsync();

            }
            return result;
        }
        public List<Employee> GetEmployees()
        {
            return employeeDbContext.Employees.ToList();
        }

        public object Authenticate(List<Employee> userDetails)
        {
            throw new NotImplementedException();
        }
    }
}
