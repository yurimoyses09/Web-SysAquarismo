using Microsoft.AspNetCore.Mvc;

namespace Web.SysAquarismo.Controllers;

public class CadastroPeixeController : Controller
{
    [Route("/CadastroPeixe")]
    public ActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult CadastraPeixe() 
    {
        try
        {
            return Ok();
        }
        catch (Exception)
        {
            throw;
        }
    }
}
