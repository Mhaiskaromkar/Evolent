using System.Web.Mvc;

namespace Evolent.WebAPI.Controllers
{
    /// <summary>
    /// <see cref="HomeController"/> class which inherits <see cref="Controller"/> class.
    /// </summary>
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }


    }
}
