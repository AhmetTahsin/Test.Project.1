using Microsoft.AspNetCore.Mvc;

namespace Test.Project.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
