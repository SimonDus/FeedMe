using System.Web.Mvc;
using System.Web.Http.Cors;

namespace FeedMe.Controllers
{
    public class HomeController : Controller
    {
        [EnableCors(origins:"http://feedme-bf.azurewebsites.net/api", headers: "*", methods: "$")]
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

    }
}
