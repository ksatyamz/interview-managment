using System.ComponentModel.DataAnnotations;

namespace EmployeeApi.Models.Dto
{
    public class EmployeeDto
    {
        public int EmpId { get; set; }
        
        

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }

        public string EmailAddress { get; set; }
        public long PhoneNumber { get; set; }

        public string Location { get; set; }
        public string Role { get; set; }
    }
}
