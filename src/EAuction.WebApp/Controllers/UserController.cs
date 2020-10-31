using EAuction.Core;
using EAuction.WebApp.Data;
using EAuction.WebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace EAuction.WebApp.Controllers
{
    public class UserController : Controller
    {
        private readonly IRepository<User> _repository;

        public UserController(IRepository<User> repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public IActionResult Insert(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            _repository.Insert(new User
            {
                Email = model.Email,
                Password = model.Password,
                Interested = new Interested(model.Name)
            });

            return RedirectToAction("Thank");
        }

        [HttpGet]
        public IActionResult Thank()
        {
            return View();
        }
    }
}