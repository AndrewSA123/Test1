using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Norton.Abstractions.Models;
using Norton.Services;
using Norton_Tech_Test.Models;
using System.Diagnostics;

namespace Norton_Tech_Test.Controllers
{
    public class HomeController(IBookService service, IMapper mapper) : Controller
    {
        public IActionResult Index()
        {
            var books = service.GetBooks();
            return View(books);
        }

        [HttpGet]
        public IActionResult CreateForm()
        {
            // Should probably have a ViewModel for this rather than using book, "CreateBook" or have a combined "CreateUpdateBook".
            return PartialView("_BookFormModal", new Book());
        }

        [HttpGet]
        public IActionResult EditForm(int id)
        {
            var book = service.GetBookById(id);

            return PartialView("_BookFormModal", book);
        }

        [HttpPost]
        public IActionResult Create(Book book)
        {
            service.AddBook(book);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Update(Book book)
        {
            service.UpdateBook(mapper.Map<UpdateBook>(book));

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            service.DeleteBook(id);
            return RedirectToAction("Index");
        }
    }
}
