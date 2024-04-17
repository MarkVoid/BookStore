using BookStore.Repositories;
using BookStore.Entities;
using BookStore.ViewModels.Books;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BookStore.Controllers
{
    public class BooksController : Controller
    {
        private readonly BooksRepository _booksRepository;

        public BooksController( BooksRepository booksRepository)
        {
            _booksRepository = booksRepository;
        }
        public ActionResult Index()
        {
            var userJson = HttpContext.Session.GetString("loggedUser");

            if (userJson == null)
            {
                return RedirectToAction("Login", "Home");
            }

            var loggedUser = JsonConvert.DeserializeObject<User>(userJson);

            List<Book> items = _booksRepository.GetAll(loggedUser.UserId);

            ViewData["items"] = items;

            return View();
        }
        [HttpGet]
        public ActionResult EditBook(int? id)
        {
            if (HttpContext.Session.GetString("loggedUser") == null)
            {
                return RedirectToAction("Login", "Home");
            }

            Book item = id == null ? new Book() : _booksRepository.GetById(id.Value);

            EditVM model = new EditVM();
            model.BookId = item.BookId;
            model.Author = item.Author;
            model.Genre = item.Genre;
            model.Name = item.Name;

            return View(model);
        }
        [HttpPost]
        public ActionResult EditBook(EditVM model)
        {
            if (!ModelState.IsValid)
                return View(model);

            Book item = new Book();
            item.BookId = model.BookId;
            item.Author = model.Author;
            item.Genre = model.Genre;
            item.Name = model.Name;


            if (item.BookId > 0)
                _booksRepository.Update(item);
            else
                _booksRepository.Insert(item);

            return RedirectToAction("Index", "Books");
        }
        public ActionResult Delete(int id)
        {
            if (HttpContext.Session.GetString("loggedUser") == null)
            {
                return RedirectToAction("Login", "Home");
            }

            _booksRepository.Delete(id);


            return RedirectToAction("Index");

        }
    }
}
