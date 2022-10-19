using EmployeeApi.Models.Domain;
using EmployeeMicroserviceAPI.Models.Domain;

namespace InterviewManagement.Tests.MockData
{
    public static class EmployeeMockData
    {
        public static List<Employee> GetEmployees()
        {
            return new List<Employee>
            {
                new(){EmpId=1,FirstName="Arun",LastName="V",Username="arun_1",Password="arun@123",EmailAddress="arun.v@gmail.com",PhoneNumber=6234512221,Location="Pune",Role="Admin"},
                new(){EmpId=2,FirstName="Sidharth",LastName="Benoi",Username="sidhu_1",Password="sid@123",EmailAddress="sidharthb@gmail.com",PhoneNumber=6234512331,Location="Bhopal",Role="Tech"},
                new(){EmpId=3,FirstName="Sandeep",LastName="Satheeshan",Username="sandy_1",Password="sandy@123",EmailAddress="sandy10@yahoo.com",PhoneNumber=6234512211,Location="Trivandrum",Role="HR"},
                new(){EmpId=4,FirstName="Sreerag",LastName="V",Username="svg_1",Password="svg@123",EmailAddress="sreerag.svg@gmail.com",PhoneNumber=7244512221,Location="Kochi",Role = "Tech"},
                new(){EmpId=5,FirstName="Abhilash",LastName="M",Username="abhi_1",Password="abhi@123",EmailAddress="abhi@gmail.com",PhoneNumber=7776512221,Location="Kakkanad", Role ="Tech"},
                new(){EmpId=6,FirstName="Niranjan",LastName="P",Username="njn14_1",Password="njn14@123",EmailAddress="niru@gmail.com",PhoneNumber=6234511122,Location="Delhi", Role = "HR"},
                new(){EmpId=7,FirstName="Akshay",LastName="Kudukan",Username="akshay_1",Password="kudukan@123",EmailAddress="akudukan@gmail.com",PhoneNumber=6237712221,Location="Goa", Role = "HR"},
                new(){EmpId=8,FirstName="Abhilash",LastName="M",Username="abhilashm_1",Password="abhilashm@123",EmailAddress="abhilashm@gmail.com",PhoneNumber=7734512221,Location="Kozhikode", Role = "Tech"},
                new(){EmpId=9,FirstName="Arun",LastName="V",Username="arun.v_1",Password="arunvshank@123",EmailAddress="arunanv@gmail.com",PhoneNumber=6266512221,Location="Kolkata", Role = "HR"},
            };
        }
        public static List<Employee> EmptyEmployeeList()
        {
            return new List<Employee>();
        }
       
        public static Employee employee()
        {
            return new Employee()
            {
                EmpId = 1,
                FirstName = "Arun",
                LastName = "V",
                Username = "arun_1",
                Password = "arun@123",
                EmailAddress = "arun.v@gmail.com",
                PhoneNumber = 7878984712,
                Location = "Pune",
                Role= "Tech"
            };

        }
        public static EmployeeLoginDetails EmployeeLogin()
        {
            return new EmployeeLoginDetails()
            {
                Username = "username",
                Password =" password"
            };
        }
        public static Employee EmptyEmployee()
        {
            return null;
        }
        public static Employee AddEmployee()
        {
            return new Employee()
            {
                FirstName = "Arun",
                LastName = "V",
                Username = "arun_1",
                Password = "arun@123",
                EmailAddress = "arun.v@gmail.com",
                PhoneNumber = 7878984712,
                Location = "Pune",
                Role = "Tech"
            };

        }
        public static string Token()
        {
            return "Unauthorized";
        }

        public static string Token1()
        {
            return "Success";
        }
    }
}