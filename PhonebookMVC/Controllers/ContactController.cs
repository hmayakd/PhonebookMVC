using Microsoft.AspNetCore.Mvc;
using PhonebookMVC.Models;
using PhonebookMVC.Services;

namespace PhonebookMVC.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;
        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }
        public IActionResult Index()
        {
            _contactService.Create(25);
            var contacts = _contactService.GetAll();
            return View(contacts);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Contact contact)
        {
            _contactService.Create(contact);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(Guid id)
        {
            Contact? contact = _contactService.Get(id);
            return View(contact);
        }
        [HttpPost]
        public IActionResult Delete(Contact contact)
        {
            _contactService.Delete(contact.Id);
            return RedirectToAction("Index");
        }
        public IActionResult Details(Guid id)
        {
            Contact? contact = _contactService.Get(id);
            return View(contact);
        }
        public IActionResult Edit(Guid id)
        {
            Contact? contact = _contactService.Get(id);
            return View(contact);
        }
        [HttpPost]
        public IActionResult Edit(Contact contact)
        {
            _contactService.Update(contact);
            return RedirectToAction("Index");
        }
    }
}
