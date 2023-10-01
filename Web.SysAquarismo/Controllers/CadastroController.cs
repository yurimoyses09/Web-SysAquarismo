using Microsoft.AspNetCore.Mvc;
using Web.SysAquarismo.Services.CadastroUsuarioService;

namespace Web.SysAquarismo.Controllers;

public class CadastroController : Controller
{
    private readonly ICadastroUsuarioService _service;
    public CadastroController(ICadastroUsuarioService service)
    {
        _service = service;
    }

    [Route("/Cadastro")]
    public ActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<ActionResult> CadastroAsync(string nome, string idade_usuario, string email_usuario, string sexo_usuario, string pais_origem, string nome_login, string senha_usuario, string telefone_usuario) 
    {
        try
        {
            await _service.Cadastro
                (
                    nome, 
                    idade_usuario, 
                    email_usuario, 
                    sexo_usuario, 
                    pais_origem, 
                    nome_login, 
                    senha_usuario, 
                    telefone_usuario
               );
            
            return Redirect("/Cadastro");
        }
        catch (Exception ex)
        {
            TempData["ErroMensagem"] = ex.Message;
            return Redirect("/");
        }
    }
}
