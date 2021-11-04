using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JoePizzaApp.Models
{
    public class OrderDetail
    {
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public int PizzaId { get; set; }
        public int Qty { get; set; }
        public decimal Price { get; set; }
        public Pizza Pizza { get; set; }
        public Order Order { get; set; }
    }
}
