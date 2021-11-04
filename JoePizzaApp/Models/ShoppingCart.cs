using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JoePizzaApp.Models
{
    public class ShoppingCart
    {
        private AppDbContext appDbContext;

        public string ShoppingCartId { get; set; }
        public List<ShoppingCartItem> ShoppingCartItems { get; set; }
        private ShoppingCart(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public static ShoppingCart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            var context = services.GetService<AppDbContext>();
            string cartId = session.GetString("CardId") ?? Guid.NewGuid().ToString();
            session.SetString("CardId", cartId);
            return new ShoppingCart(context) { ShoppingCartId = cartId };
        }

        public void AddToCart(Pizza pizza, int qty)
        {
            var shoppingCartItem = appDbContext.ShoppingCartItems.SingleOrDefault(s => s.Pizza.PizzaId == pizza.PizzaId && s.ShoppingCartId == ShoppingCartId);
            if (shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItem
                {
                    ShoppingCartId = ShoppingCartId,
                    Pizza = pizza,
                    Qty = 1
                };

                appDbContext.ShoppingCartItems.Add(shoppingCartItem);
            }
            else
            {
                shoppingCartItem.Qty++;
            }
            appDbContext.SaveChanges();
        }
        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            return ShoppingCartItems ??
                (ShoppingCartItems =
                    appDbContext.ShoppingCartItems.Where(c => c.ShoppingCartId == ShoppingCartId)
                    .Include(s => s.Pizza)
                    .ToList());
        }
        public decimal GetShoppingCartTotal()
        {
            var total = appDbContext.ShoppingCartItems.Where(c => c.ShoppingCartId == ShoppingCartId)
                .Select(c => c.Pizza.Cost * c.Qty).Sum();
            return total;
        }
        public void ClearCart()
        {
            var cartItems = appDbContext.ShoppingCartItems.Where(cart => cart.ShoppingCartId == ShoppingCartId);
            appDbContext.ShoppingCartItems.RemoveRange(cartItems);
            appDbContext.SaveChanges();
        }
        public int RemoveFromCart(Pizza pizza)
        {
            var shoppingCartItem = appDbContext.ShoppingCartItems.SingleOrDefault(s => s.Pizza.PizzaId == pizza.PizzaId && s.ShoppingCartId == ShoppingCartId);
            var localAmount = 0;
            if (shoppingCartItem != null)
            {
                if (shoppingCartItem.Qty > 1)
                {
                    shoppingCartItem.Qty--;
                    localAmount = shoppingCartItem.Qty;
                }
                else
                {
                    appDbContext.ShoppingCartItems.Remove(shoppingCartItem);
                }
            }
            appDbContext.SaveChanges();
            return localAmount;
        }
    }
}
