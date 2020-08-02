using Abp.Auditing;
using Microsoft.AspNetCore.Mvc;

namespace Framework.Web.Controllers
{
    public class HomeController : FrameworkControllerBase
    {
        [DisableAuditing]
        public IActionResult Index()
        {
            return RedirectToAction("Index", "Ui");
        }
    }
}
