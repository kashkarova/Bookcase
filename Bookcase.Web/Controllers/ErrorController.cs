using System.Web.Mvc;

namespace Bookcase.Web.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult Index()
        {
            return View("Index");
        }
    }
}