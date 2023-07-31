namespace Web.SysAquarismo.Services.LoginService;

public interface ILoginService
{
    Task<bool> Login(string username, string password);
}
