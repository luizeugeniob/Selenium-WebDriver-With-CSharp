using EAuction.Core;
using EAuction.WebApp.Data;
using EAuction.WebApp.Extensions;
using EAuction.WebApp.Filters;
using EAuction.WebApp.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Linq;

namespace EAuction.WebApp.Controllers
{
    [AuthorizationFilter]
    public class AuctionController : Controller
    {
        private readonly IRepository<Auction> _repository;
        private readonly IHostingEnvironment _environment;

        public AuctionController(
            IRepository<Auction> repository,
            IHostingEnvironment environment)
        {
            _repository = repository;
            _environment = environment;
        }

        public IActionResult Index()
            => View(_repository.GetAll.Select(l => l.ToViewModel()));

        [HttpGet]
        public IActionResult New()
            => View();

        [HttpPost]
        public IActionResult New(AuctionViewModel model)
        {
            if (!ModelState.IsValid)
                return View("Novo", model);

            model.Image = ReturnsImageName(model.FileImage);
            var auction = model.ToModel();
            _repository.Insert(auction);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Remove(int id)
        {
            var auction = _repository.GetById(id);
            if (auction == null)
                return NotFound();

            _repository.Delete(auction);
            return RedirectToAction("Index");
        }

        private string ReturnsImageName(IFormFile upload)
        {
            if (upload != null)
                TrySaveImage(upload);

            return $"/images/{upload.FileName}";
        }

        private void TrySaveImage(IFormFile upload)
        {
            var serverFileName = Path.Combine(_environment.WebRootPath, "images", upload.FileName);
            using (var stream = new FileStream(serverFileName, FileMode.OpenOrCreate))
            {
                upload.CopyTo(stream);
            }
        }
    }
}