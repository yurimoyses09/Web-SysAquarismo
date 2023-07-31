using Microsoft.AspNetCore.Mvc;
using Web.SysAquarismo.Services.LoginService;

namespace Web.SysAquarismo.Controllers;

public class LoginController : Controller
{
    private readonly ILoginService _service;
    public LoginController(ILoginService service)
    {
        _service = service;
    }

    public IActionResult Index()
    {
        return View();
    }

    /// <summary>
    /// Valida se usuario possui conta no sistema para realizar login
    /// </summary>
    /// <param name="nome_usuario">Nome de login do usuario</param>
    /// <param name="senha">Senha para logar no sistema</param>
    /// <returns>ActionResult</returns>
    [HttpPost]
    public async Task<IActionResult> Login(string nome_usuario, string senha)
    {
        try
        {
            bool validaLogin = await _service.Login(nome_usuario, senha);

            if (validaLogin) 
                return Redirect("/Principal");

            return Redirect("/");
        }
        catch (Exception ex)
        {
            return Redirect("/");
        }
    }
}