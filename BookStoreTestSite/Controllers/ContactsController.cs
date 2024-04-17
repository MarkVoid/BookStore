﻿using BookStore.Entities;
using BookStore.Repositories;
using BookStore.ViewModels.Contacts;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BookStore.Controllers
{
    public class ContactsController : Controller
    {
        private readonly ContactsRepository _contactsRepository;

        public ContactsController(ContactsRepository contactsRepository)
        {
            _contactsRepository = contactsRepository;
        }
        public ActionResult Index()
        {
            var userJson = HttpContext.Session.GetString("loggedUser");

            if (userJson == null)
            {
                return RedirectToAction("Login", "Home");
            }

            var loggedUser = JsonConvert.DeserializeObject<User>(userJson);

            List<Contact> items = _contactsRepository.GetAll(loggedUser.UserId);

            ViewData["items"] = items;

            return View();
        }
        [HttpGet]
        public ActionResult Edit(int? id)
        {

            if (HttpContext.Session.GetString("loggedUser") == null)
            {
                return RedirectToAction("Login", "Home");
            }

            Contact item = id == null ? new Contact() : _contactsRepository.GetById(id.Value);

            EditVM model = new EditVM();
            model.ContactId = item.ContactId;
            model.PhoneNumber = item.PhoneNumber;



            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(EditVM model)
        {
            if (HttpContext.Session.GetString("loggedUser") == null)
            {
                return RedirectToAction("Login", "Home");
            }
            if (!ModelState.IsValid)
                return View(model);

            Contact item = new Contact();
            item.ContactId = model.ContactId;
            item.PhoneNumber = model.PhoneNumber;


            if (item.ContactId > 0)
                _contactsRepository.Update(item);
            else
                _contactsRepository.Insert(item);

            return RedirectToAction("Index", "Contacts");
        }
        public ActionResult Delete(int id)
        {
            if (HttpContext.Session.GetString("loggedUser") == null)
            {
                return RedirectToAction("Login", "Home");
            }

            _contactsRepository.Delete(id);


            return RedirectToAction("Index");

        }
    }
}
