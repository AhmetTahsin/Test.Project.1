using Microsoft.AspNetCore.Mvc;

namespace Test.Project.Areas.Admin.Controllers
{
    public class AdminUILayoutController : Controller
    {
        public IActionResult _UILayout()
        {
            return View();
        }
    }
}
