using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace EmployeeApi.Models.Domain
{
    public class Employee
    {
        [Key]
        public int EmpId { get; set; }
       
        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }

        [Required, DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }
        [Required]
        public long PhoneNumber { get; set; }
        [Required]
        public string  Location { get; set; }
        public string Role { get; set; }
    }
}

