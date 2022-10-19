using System.ComponentModel.DataAnnotations;

namespace EmployeeMicroserviceAPI.Models.Domain
{
    public class EmployeeLoginDetails
    {
 
        public string Username { get; set; }
   
        public string Password { get; set; }
    }
}
