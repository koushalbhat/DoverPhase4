using JoePizzaApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JoePizzaApp.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly AppDbContext appDbContext;
        private readonly ShoppingCart shoppingCart;

        public ShoppingCartController(AppDbContext appDbContext, ShoppingCart shoppingCart)
        {
            this.appDbContext = appDbContext;
            this.shoppingCart = shoppingCart;
        }
        public ViewResult Index()
        {
            var items = shoppingCart.GetShoppingCartItems();
            shoppingCart.ShoppingCartItems = items;
            var shoppingCartViewModel = new ShoppingCartViewModel
            {
                ShoppingCart = shoppingCart,
                ShoppingCartTotal = shoppingCart.GetShoppingCartTotal()
            };
            return View(shoppingCartViewModel);
        }
        public RedirectToActionResult AddToShoppingCart(int pizzaId)
        {
            var selectedPizza = appDbContext.Pizzas.FirstOrDefault(l => l.PizzaId == pizzaId);
            if (selectedPizza != null)
            {
                shoppingCart.AddToCart(selectedPizza, 1);
            }
            return RedirectToAction("Index");
        }
        public RedirectToActionResult RemoveFromCart(int pizzaId)
        {
            var selectedPizza = appDbContext.Pizzas.FirstOrDefault(l => l.PizzaId == pizzaId);
            if (selectedPizza != null)
            {
                shoppingCart.RemoveFromCart(selectedPizza);
            }
            return RedirectToAction("Index");
        }
    }
}
