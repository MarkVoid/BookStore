using BookStore.Entities;
using BookStore.Repositories;
using BookStore.ViewModels.Home;
using BookStore.ViewModels.Users;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BookStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserRepository _userRepository;

        public HomeController(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public ActionResult Index()
        {
            var userJson = HttpContext.Session.GetString("loggedUser");
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            LoginVM model = new LoginVM();
            return View(model);
        }

        [HttpPost]
        public ActionResult Login(LoginVM model)
        {

            if (!ModelState.IsValid)
                return View(model);

            User loggedUser = _userRepository.GetUsernameAndPassword(model.Username, model.Password);

            if (loggedUser == null)
                ModelState.AddModelError("AuthenticationFailed", "Authentication Failed !!!!!!!");

            HttpContext.Session.SetString("loggedUser", JsonConvert.SerializeObject(loggedUser));

            return RedirectToAction("Index", "Home");

        }
        public ActionResult Register()
        {
            EditVM model = new EditVM();
            return View(model);
        }
        public ActionResult Logout()
        {
            HttpContext.Session.Remove("loggedUser");

            return RedirectToAction("Login", "Home");
        }
    }
}