using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using Web.SysAquarismo.Services.LoginService;

namespace Web.SysAquarismo.Controllers;

public class LoginController : Controller
{
    private readonly ILoginService _service;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private ISession _session => _httpContextAccessor.HttpContext.Session;
    public LoginController(ILoginService service, IHttpContextAccessor httpContextAccessor)
    {
        _service = service;
        _httpContextAccessor = httpContextAccessor;
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
            if (ModelState.IsValid)
            {
                bool validaLogin = await _service.Login(nome_usuario, senha);

                if (validaLogin)
                {
                    _session.SetString("usuarioLogado", nome_usuario);
                    return Redirect("/Principal");
                }
            }

            TempData["ErroMensagem"] = "Usuario nao possui cadastro no sistema, crie sua conta :)";
            return Redirect("/");
        }
        catch (Exception)
        {
            TempData["ErroMensagem"] = "Credenciais inválidas.";
            return Redirect("/");
        }
    }
}