using Microsoft.AspNetCore.Mvc;
using System.Text;
using Web.SysAquarismo.Domain.Models;
using Web.SysAquarismo.Services.CadastroPeixeService;
using Web.SysAquarismo.Services.PaginaPrincipalService;

namespace Web.SysAquarismo.Controllers;

public class CadastroPeixeController : Controller
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private ISession _session => _httpContextAccessor.HttpContext.Session;
    private readonly ICadastroPeixeService _service;
    private readonly IPaginaPrincipalService _principalService;
    public CadastroPeixeController(ICadastroPeixeService service, IHttpContextAccessor httpContextAccessor, IPaginaPrincipalService principalService)
    {
        _service = service;
        _httpContextAccessor = httpContextAccessor;
        _principalService = principalService;
    }

    [Route("/CadastroPeixe")]
    public async Task<ActionResult> IndexAsync()
    {
        if (_session.IsAvailable)
        {
            Usuario dadosCliente = await _principalService.BuscaDadosUsuario(Encoding.UTF8.GetString(_session.Get("usuarioLogado")));
            return View(dadosCliente);
        }

        return View();
    }

    [HttpPost]
    public async Task<IActionResult> CadastraPeixe(string nome_peixe, string especie, string descricao_peixe, string sexo, string peso, string tamandho, string st_saude, string dt_morte, string ds_doenca, string dt_aquisao, byte[] img_peixe, string id_usuario)
    {
        try
        {
            await _service.CadastraPeixe(nome_peixe, especie, descricao_peixe, sexo, peso, tamandho, st_saude, dt_morte, ds_doenca, dt_aquisao, img_peixe, id_usuario);
            TempData["Mensagem"] = $"Peixe {nome_peixe} Cadastrado com sucesso";

            return Redirect("/CadastroPeixe");
        }
        catch (Exception ex)
        {
            TempData["ErroMensagem"] = ex.Message;
            throw;
        }
    }
}
