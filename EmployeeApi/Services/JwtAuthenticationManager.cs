using EmployeeApi.Repositories;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EmployeeApi.Services
{
    public class JwtAuthenticationManager : IJwtAuthenticationManager
    {
        private readonly string key;
        private readonly IEmployeeRepository employeeRepository;
        
        public JwtAuthenticationManager(string key, IEmployeeRepository repository)
        {
            this.key = key;
            this.employeeRepository = repository;
        }

        public string Authentication(string username, string password)
        {
            var users = employeeRepository.GetEmployees();

            if (!users.Any(u => u.Username == username && u.Password == password))
            {
                return null;
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes(key);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, username)
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey),
                SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);

        }
    }
}
