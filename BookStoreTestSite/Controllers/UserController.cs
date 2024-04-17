using BookStore.Entities;
using BookStore.Repositories;
using BookStore.ViewModels.Users;
using Microsoft.AspNetCore.Mvc;


namespace BookStore.Controllers
{
    public class UserController : Controller
    {
        private readonly UserRepository _userRepository;

        public UserController(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public ActionResult Index()
        {
            if (HttpContext.Session.GetString("loggedUser") == null)
            {
                // User is not logged in; handle accordingly
                return RedirectToAction("Login", "Home");
            }

            List<User> items = _userRepository.GetAll();

            ViewData["items"] = items;


            return View();
        }
        [HttpGet]
        public ActionResult EditUser(int? id)
        {
            if (HttpContext.Session.GetString("loggedUser") == null)
            {
                return RedirectToAction("Login", "Home");
            }

            User item = id == null ? new User() : _userRepository.GetById(id.Value);

            EditVM model = new EditVM();

            model.UserId = item.UserId;
            model.Username = item.Username;
            model.Password = item.Password;
            model.FirstName = item.FirstName;
            model.LastName = item.LastName;

            return View(model);
        }
        [HttpPost]
        public ActionResult EditUser(EditVM model)
        {
            if (!ModelState.IsValid)
                return View(model);

            User item = new User();

            item.UserId = model.UserId;
            item.Username = model.Username;
            item.Password = model.Password;
            item.FirstName = model.FirstName;
            item.LastName = model.LastName;


            if (item.UserId > 0)
                _userRepository.Update(item);
            else
                _userRepository.Insert(item);

            return RedirectToAction("Index", "User");
        }


        public ActionResult Delete(int id)
        {
            if (HttpContext.Session.GetString("loggedUser") == null)
            {
                return RedirectToAction("Login", "Home");
            }

            _userRepository.Delete(id);

            return RedirectToAction("Index");
        }
    }
}
