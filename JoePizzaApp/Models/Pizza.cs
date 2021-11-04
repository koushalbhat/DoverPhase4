using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JoePizzaApp.Models
{
    public class Pizza
    {
        public int PizzaId { get; set; }
        public string PizzaType { get; set; }
        public int Cost { get; set; }
        public bool Toppings { get; set; }
        public string ImageUrl { get; set; }
    }
}
