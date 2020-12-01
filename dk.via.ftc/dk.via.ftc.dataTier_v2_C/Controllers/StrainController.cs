using Microsoft.AspNetCore.Mvc;

namespace dk.via.ftc.dataTier_v2_C.Controllers
{
    public class StrainController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}