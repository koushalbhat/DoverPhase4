﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JoePizzaApp.Models
{
    public class ShoppingCartItem
    {
        public int ShoppingCartItemId { get; set; }
        public Pizza Pizza { get; set; }
        public int Qty { get; set; }
        public string ShoppingCartId { get; set; }
    }
}
