using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using Bookcase.BLL.DTO;
using Bookcase.BLL.Services.Interfaces;
using Bookcase.ViewModel;

namespace Bookcase.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBookService _bookService;

        public HomeController(IBookService bookService)
        {
            _bookService = bookService;
        }

        public ActionResult Index()
        {
            var bookDtos = _bookService.GetAll();
            Mapper.Initialize(cfg => cfg.CreateMap<BookDTO, BookViewModel>());
            var boo = Mapper.Map<List<BookDTO>, List<BookViewModel>>(bookDtos);
            return View(boo);
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