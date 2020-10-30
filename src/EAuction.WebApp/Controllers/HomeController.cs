using EAuction.Core;
using EAuction.WebApp.Data;
using EAuction.WebApp.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace EAuction.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepository<Auction> _auctionRepository;
        private readonly IRepository<Interested> _interestedRepository;

        public HomeController(IRepository<Auction> auctionRepository, IRepository<Interested> interestedRepository)
        {
            _auctionRepository = auctionRepository;
            _interestedRepository = interestedRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var upcomingAuctions = _auctionRepository
                .GetAll
                .Where(a => a.State == AuctionState.Created)
                .OrderBy(a => a.StartAuctionDate)
                .Take(6)
                .Select(a => a.ToViewModel())
                .ToList();

            var loggedUser = HttpContext.GetLoggedUser();
            if (loggedUser != null)
            {
                var interested = _interestedRepository.GetById(loggedUser.Interested.Id);

                upcomingAuctions
                    .ForEach(a => a.BeingFollowed = interested
                    .Favorites
                    .Select(f => f.AuctionId)
                    .Any(id => id == a.Id));
            }

            return View(upcomingAuctions);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var auction = _auctionRepository.GetById(id).ToViewModel();
            if (auction != null)
            {
                var loggedUser = HttpContext.GetLoggedUser();
                if (loggedUser != null)
                {
                    var interessada = _interestedRepository.GetById(loggedUser.Interested.Id);

                    auction.BeingFollowed = interessada
                        .Favorites
                        .Select(f => f.AuctionId)
                        .Any(auctionId => auctionId == auction.Id);
                }
                return View(auction);
            }
            return NotFound();
        }

        [HttpGet]
        public IActionResult Category(string id)
        {
            ViewData["categoria"] = id;

            var auctions = _auctionRepository
                .GetAll
                .Where(a => a.Category == id)
                .Select(a => a.ToViewModel());

            return View("Index", auctions);
        }
    }
}