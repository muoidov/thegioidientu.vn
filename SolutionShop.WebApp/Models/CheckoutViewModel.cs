﻿using SolutionShop.Sales;
using System.Collections.Generic;

namespace SolutionShop.WebApp.Models
{
    public class CheckoutViewModel
    {
        public List<CartItemViewModel> CartItems { get; set; }

        public CheckoutRequest CheckoutModel { get; set; }
    }
}