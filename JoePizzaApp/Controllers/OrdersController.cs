using JoePizzaApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JoePizzaApp.Controllers
{
    public class OrdersController : Controller
    {
        private readonly OrderCheckout orderCheckout;
        private readonly ShoppingCart shoppingCart;
        private readonly AppDbContext context;

        public OrdersController(OrderCheckout orderCheckout, ShoppingCart shoppingCart, AppDbContext context)
        {
            this.orderCheckout = orderCheckout;
            this.shoppingCart = shoppingCart;
            this.context = context;
        }
        public IActionResult Checkout()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            var items = shoppingCart.GetShoppingCartItems();
            shoppingCart.ShoppingCartItems = items;
            if (shoppingCart.ShoppingCartItems.Count == 0)
            {
                ModelState.AddModelError("", "Your Cart is empty");
            }
            if (ModelState.IsValid)
            {
                orderCheckout.CreateOrder(order);
                shoppingCart.ClearCart();
                return RedirectToAction("TrackOrder", new { Id = order.OrderId });
            }
            return View(order);
        }
        public IActionResult TrackOrder(int id)
        {
            ViewBag.CheckoutCompleteMessage = "Thanks for your order. You will recieve your Pizza soon!!";
            return View(context.OrderDetails.Include(o => o.Order).Include(p => p.Pizza).Where(x => x.OrderId == id).ToList());
        }
        public IActionResult TrackYourOrder()
        {
            return View();
        }
        [HttpPost]
        public IActionResult TrackYourOrder(TrackOrderViewModel t)
        {
            var order = context.OrderDetails.FirstOrDefault(x => x.Order.PhoneNumber == t.Phone);
            if (order == null)
            {
                ViewBag.msg = "Invalid Phone";
            }
            else
            {
                return RedirectToAction("TrackOrder", new { Id = order.OrderId });
            }
            return View();
        }
    }
}
