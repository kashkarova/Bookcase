using System.Web.Mvc;
using Bookcase.BLL.Services.Interfaces;


namespace Bookcase.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(IBookService books)
        {

            
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}