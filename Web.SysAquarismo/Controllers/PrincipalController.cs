using Microsoft.AspNetCore.Mvc;
using Web.SysAquarismo.Services.PaginaPrincipalService;

namespace Web.SysAquarismo.Controllers;

public class PrincipalController : Controller
{
    private readonly IPaginaPrincipalService _service;
    public PrincipalController(IPaginaPrincipalService service)
    {
        _service = service;
    }

    [Route("/Principal")]
    public ActionResult Index(string nome_usuario)
    {
        BuscaDadosUsuario(nome_usuario);
        return View();
    }

    public IActionResult BuscaDadosUsuario(string nome_usuario) 
    {
        try
        {
            return (IActionResult)_service.BuscaDadosUsuario(nome_usuario);
        }
        catch (Exception)
        {
            throw;
        }
    }

}
