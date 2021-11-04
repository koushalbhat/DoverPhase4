﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JoePizzaApp.Models
{
    public class OrderCheckout
    {
        private readonly AppDbContext context;
        private readonly ShoppingCart shoppingCart;

        public OrderCheckout(AppDbContext context, ShoppingCart shoppingCart)
        {
            this.context = context;
            this.shoppingCart = shoppingCart;
        }
        public void CreateOrder(Order order)
        {
            order.OrderPlaced = DateTime.Now;

            var shoppingCartItems = shoppingCart.ShoppingCartItems;
            order.OrderTotal = shoppingCart.GetShoppingCartTotal();

            order.OrderDetails = new List<OrderDetail>();

            foreach (var shoppingCartItem in shoppingCartItems)
            {
                var orderDetail = new OrderDetail
                {
                    Qty = shoppingCartItem.Qty,
                    PizzaId = shoppingCartItem.Pizza.PizzaId,
                    Price = shoppingCartItem.Pizza.Cost
                };
                order.OrderDetails.Add(orderDetail);
            }
            context.Orders.Add(order);
            context.SaveChanges();
        }
    }
}
