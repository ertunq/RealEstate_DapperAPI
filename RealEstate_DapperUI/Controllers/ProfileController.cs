using Microsoft.AspNetCore.Mvc;

namespace RealEstate_DapperUI.Controllers
{
    public class ProfileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
