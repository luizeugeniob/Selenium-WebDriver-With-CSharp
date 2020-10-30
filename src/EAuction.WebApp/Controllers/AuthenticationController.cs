using EAuction.Core;
using EAuction.WebApp.Data;
using EAuction.WebApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace EAuction.WebApp.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly IRepository<User> _repository;

        public AuthenticationController(IRepository<User> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult Login() => View();

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _repository.GetAll.First(u => u.Email == model.Login && u.Password == model.Password);
                if (user != null)
                {
                    user = _repository.GetById(user.Id);
                    HttpContext.SetAuthenticatedUser(user);
                    return RedirectToAction("Index", "Interessadas");
                }
                ModelState.AddModelError("invalidUser", "Usuário não encontrado");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.SetUnauthenticatedUser();
            return RedirectToAction("Index", new { Controller = "Home" });
        }
    }
}