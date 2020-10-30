using EAuction.Core;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EAuction.WebApp.Models
{
    public class AuctionViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Título")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Descrição")]
        public string Description { get; set; }

        [Required]
        public string Category { get; set; }

        public string Image { get; set; }

        public IFormFile FileImage { get; set; }

        [Required]
        [Display(Name = "Valor Inicial")]
        public double InitialAmount { get; set; }

        [Required]
        [Display(Name = "Data de Início do Leilão")]
        public DateTime StartAuctionDate { get; set; }

        [Required]
        [Display(Name = "Data de Encerramento do Leilão")]
        public DateTime FinishAuctionDate { get; set; }

        public bool BeingFollowed { get; set; }

        public AuctionState State { get; set; }

        public IEnumerable<Bid> Bids { get; set; }
    }
}
