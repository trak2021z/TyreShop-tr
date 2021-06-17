﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace TyreShop.Models
{
    public class Order
    {
        [BindNever]
        public int OrderID { get; set; }
        [BindNever]
        public ICollection<CartLine> Lines { get; set; }

        [BindNever]
        public bool Shipped { get; set; }

        [Required(ErrorMessage = "Proszę podać Imię i Nazwisko.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Proszę podać adres.")]
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string Line3 { get; set; }

        [Required(ErrorMessage = "Proszę podać nazwę miasta.")]
        public string City { get; set; }

        [Required(ErrorMessage = "Proszę podać nazwę wojedództwa.")]
        public string State { get; set; }
        public string Zip { get; set; }

        [Required(ErrorMessage = "Proszę podać nazwę kraju.")]
        public string Country { get; set; }

        public bool GiftWrap { get; set; }
    }
}
