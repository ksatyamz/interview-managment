namespace EmployeeApi.Services
{
    public interface IJwtAuthenticationManager
    {
        string Authentication(string username, string password);
        //it will return us Jwt string
    }
}
