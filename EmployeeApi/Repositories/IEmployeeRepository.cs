using EmployeeApi.Models.Domain;

namespace EmployeeApi.Repositories
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetEmployeesAsync();

        Task<Employee> GetEmployeeByIdAsync(int id);
        Task<IEnumerable<Employee>> GetEmployeeByNameAsync(string firstname);

        Task<IEnumerable<Employee>> GetEmployeeByRoleAsync(string role);
        Task<Employee> AddEmployeeAsync(Employee employee);
        Task<Employee> DeleteEmployeeAsync(int id);

        Task<Employee> UpdateEmployeeAsync(Employee employee, int id);

        List<Employee> GetEmployees();

        //List<Employee> GetAllEmployees();//authentication

        ///////////////
        

    }
}
