using JoePizzaApp.Models;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace JoePizzaTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>().UseSqlServer("Server=tcp:joepizza.database.windows.net,1433;Initial Catalog=PizzaAppDB;Persist Security Info=False;User ID=adminroot1;Password=Admin@234;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;").Options;
            using(var context = new AppDbContext(options))
            {
                List<Pizza> ExpectedPizza = new List<Pizza>
                {
                new Pizza{PizzaId=1, PizzaType="Cheese N Corn", Cost=450, Toppings=true, ImageUrl = "https://www.dominos.co.in//files/items/Corn_&_Cheese.jpg"},
                new Pizza{PizzaId=2, PizzaType="Peppy Paneer", Cost=500, Toppings=true, ImageUrl = "https://everydaypizza.in/wp-content/uploads/2021/08/peppy-paneer.jpg"},
                new Pizza{PizzaId=3, PizzaType="Mexican Green Wave", Cost=650, Toppings=true, ImageUrl = "https://5.imimg.com/data5/TJ/GN/MY-29540739/mexican-green-wave-500x500.png"},
                new Pizza{PizzaId=4, PizzaType="Veg Extravagenza", Cost=350, Toppings=true, ImageUrl = "https://www.dominos.co.in//files/items/Veg_Extravaganz.jpg"}
                };
                List<Pizza> actualPizza = context.Pizzas.ToList();
                for (int i = 0; i < ExpectedPizza.Count; i++)
                {
                    System.Console.WriteLine("Expected");
                    System.Console.WriteLine(ExpectedPizza[i].PizzaId);
                    System.Console.WriteLine(ExpectedPizza[i].PizzaType);
                    System.Console.WriteLine(ExpectedPizza[i].Cost);
                    System.Console.WriteLine(ExpectedPizza[i].Toppings);
                    System.Console.WriteLine(ExpectedPizza[i].ImageUrl);
                    System.Console.WriteLine("Actual");
                    System.Console.WriteLine(actualPizza[i].PizzaId);
                    System.Console.WriteLine(actualPizza[i].PizzaType);
                    System.Console.WriteLine(actualPizza[i].Cost);
                    System.Console.WriteLine(actualPizza[i].Toppings);
                    System.Console.WriteLine(actualPizza[i].ImageUrl);
                }
            }
        }
        [Test]
        public void Test2()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>().UseSqlServer("Server=tcp:joepizza.database.windows.net,1433;Initial Catalog=PizzaAppDB;Persist Security Info=False;User ID=adminroot1;Password=Admin@234;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;").Options;
            using (var context = new AppDbContext(options))
            {
                Pizza ExpectedPizza = new Pizza { PizzaId = 1, PizzaType = "Cheese N Corn", Cost = 450, Toppings = true, ImageUrl = "https://www.dominos.co.in//files/items/Corn_&_Cheese.jpg" };
                Pizza actualPizza = context.Pizzas.Single(x => x.PizzaId == 1);
                System.Console.WriteLine("Expected");
                System.Console.WriteLine(ExpectedPizza.PizzaId);
                System.Console.WriteLine(ExpectedPizza.PizzaType);
                System.Console.WriteLine(ExpectedPizza.Cost);
                System.Console.WriteLine(ExpectedPizza.Toppings);
                System.Console.WriteLine(ExpectedPizza.ImageUrl);
                System.Console.WriteLine("Actual");
                System.Console.WriteLine(actualPizza.PizzaId);
                System.Console.WriteLine(actualPizza.PizzaType);
                System.Console.WriteLine(actualPizza.Cost);
                System.Console.WriteLine(actualPizza.Toppings);
                System.Console.WriteLine(actualPizza.ImageUrl);
            }
        }
    }
}