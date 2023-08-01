using Microsoft.AspNetCore.Mvc;
using System.Text;
using Web.SysAquarismo.Domain.Models;
using Web.SysAquarismo.Services.PaginaPrincipalService;

namespace Web.SysAquarismo.Controllers;

public class PrincipalController : Controller
{
    private readonly IPaginaPrincipalService _service;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private ISession _session => _httpContextAccessor.HttpContext.Session;
    public PrincipalController(IPaginaPrincipalService service, IHttpContextAccessor httpContextAccessor)
    {
        _service = service;
        _httpContextAccessor = httpContextAccessor;
    }

    [Route("/Principal")]
    public async Task<ActionResult> Index(string nome_usuario)
    {
        if (_session.IsAvailable)
        {
            Usuario dadosCliente = await _service.BuscaDadosUsuario(Encoding.UTF8.GetString(_session.Get("usuarioLogado")));

            return View(dadosCliente);
        }

        return Redirect("/Login");

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
