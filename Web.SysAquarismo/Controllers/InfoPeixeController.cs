using Microsoft.AspNetCore.Mvc;
using Web.SysAquarismo.Domain.Models;
using Web.SysAquarismo.Services.InfoPeixeService;

namespace Web.SysAquarismo.Controllers;

public class InfoPeixeController : Controller
{
    private readonly IInfoPeixeService _service;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private ISession _session => _httpContextAccessor.HttpContext.Session;
    public InfoPeixeController(IInfoPeixeService service, IHttpContextAccessor httpContextAccessor)
    {
        _service = service;
        _httpContextAccessor = httpContextAccessor;
    }

    [HttpGet]
    [Route("/InfoPeixe/{id}")]
    public async Task<IActionResult> IndexAsync([FromRoute]int id)
    {
        try
        {
            if (_session.IsAvailable)
            {
                Peixe dadosCliente = await _service.GetDadosPeixe(id);
                return View(dadosCliente);
            }

            return View("/Principal");
        }
        catch (Exception)
        {
            throw;
        }
    }
}
