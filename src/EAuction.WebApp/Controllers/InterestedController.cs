using EAuction.Core;
using EAuction.WebApp.Data;
using EAuction.WebApp.Filters;
using EAuction.WebApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace EAuction.WebApp.Controllers
{
    [AuthorizationFilter]
    public class InterestedController : Controller
    {
        private readonly IRepository<Auction> _auctionRepository;
        private readonly IRepository<Interested> _interestedRepository;

        public InterestedController(
            IRepository<Auction> auctionsRepository,
            IRepository<Interested> interestedRepository)
        {
            _auctionRepository = auctionsRepository;
            _interestedRepository = interestedRepository;
        }

        public IActionResult Index()
        {
            var loggedUser = HttpContext.GetLoggedUser();
            var interested = _interestedRepository.GetById(loggedUser.Interested.Id);

            return View(new InterestedDashboardViewModel
            {
                MyOffers = interested.Bids,
                FavoriteAuctions = interested.Favorites.Select(f => f.FavoriteAuction)
            });
        }

        [HttpPost]
        public IActionResult ReceiveBid(BidViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            Auction auction = _auctionRepository.GetById(model.AuctionId);
            Interested interested = _interestedRepository.GetById(model.LoggedUserId);
            auction.ReceiveBid(interested, model.Amount);
            _auctionRepository.Update(auction);
            return Ok();
        }

        [HttpPost]
        public IActionResult FollowAuction(FavoriteViewModel model)
        {
            var auction = _auctionRepository.GetById(model.AuctionId);
            if (auction == null)
                return NotFound();

            var favorite = new Favorite
            {
                AuctionId = model.AuctionId,
                InterestedId = model.InterestedId
            };

            auction.Followers.Add(favorite);
            _auctionRepository.Update(auction);

            return Ok();
        }

        [HttpPost]
        public IActionResult AbandonAuction(FavoriteViewModel model)
        {
            var auction = _auctionRepository.GetById(model.AuctionId);
            if (auction == null)
                return NotFound();

            var favorito = auction
                .Followers
                .FirstOrDefault(s =>
                    s.AuctionId == model.AuctionId &&
                    s.InterestedId == model.InterestedId);

            auction.Followers.Remove(favorito);
            _auctionRepository.Update(auction);

            return Ok();
        }
    }
}