using System.Collections.Generic;
using System.Linq;
using System;
using System.ComponentModel.DataAnnotations;

namespace EAuction.Core
{
    public class Auction
    {
        private Interested _lastInterested;
        private IEvaluationMode _evaluationMode;

        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Category { get; set; }
        [Required]
        public string Image { get; set; }
        public double InitialAmount { get; set; }
        public DateTime StartAuctionDate { get; set; }
        public DateTime FinishAuctionDate { get; set; }
        public AuctionState State { get; private set; }
        public IList<Bid> Bids { get; private set; }
        public IList<Favorite> Followers { get; private set; }
        public Bid Winner { get; private set; }

        private Auction() { }

        public Auction(string title, IEvaluationMode evaluationMode)
        {
            Title = title;
            Bids = new List<Bid>();
            State = AuctionState.Created;
            _evaluationMode = evaluationMode;
        }

        private bool BidIsValid(Interested interested)
        {
            return (State == AuctionState.InProgress)
                && (interested != _lastInterested);
        }

        public void ReceiveBid(Interested interested, double amount)
        {
            if (BidIsValid(interested))
            {
                Bids.Add(new Bid(interested, amount));
                _lastInterested = interested;
            }
        }

        public void StartAuction()
        {
            State = AuctionState.InProgress;
        }

        public void FinishAuction()
        {
            if (State != AuctionState.InProgress)
                throw new InvalidOperationException($"Não é possível fechar um leilão sem iniciá-lo. Utilize o método {nameof(StartAuction)}.");

            Winner = _evaluationMode.Rate(this);
            State = AuctionState.Closed;
        }

        public double CurrentBidAmount => Bids.Select(l => l.Amount).LastOrDefault();
    }

    public static class AuctionStateExtensions
    {
        public static string ToText(this AuctionState state)
        {
            switch (state)
            {
                case AuctionState.Created:
                    return "Leilão não iniciado";
                case AuctionState.InProgress:
                    return "Leilão em andamento";
                case AuctionState.Closed:
                    return "Leilão encerrado";
                default:
                    return "Estado não encontrado";
            }
        }
    }

    public enum AuctionState
    {
        Created,
        InProgress,
        Closed
    }

}
