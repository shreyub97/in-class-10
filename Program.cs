using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace In_class_10
{
    class Order
    {
        public int Id { get; set; }
        public string OrderName { get; set; }

        public List<OrderDetails> orderPlaced { get; set; }

    }

    class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<OrderDetails> productPurchasal { get; set; }
    }

    class OrderDetails
    {
        public int Id { get; set; }
        public Order PlacedOrder { get; set; }
        public Product PurchasedProduct { get; set; }

        public DateTime PurchasedDate { get; set; }
    }

    class StoreContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }

        public DbSet<OrderDetails> OrderDetailss { get; set; }

        string connectionString = "Server = (localdb)\\MSSQLlocalDB;Database=ManyManyDemo;Trusted_Connection=True;MultipleActiveResultSets=true";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            using (StoreContext context = new StoreContext())
            {
                context.Database.EnsureCreated();

                Order order = new Order(OrderName = "Walmart");
                Product product = new Product(Name = " groceries ");
                OrderDetails orderDetails = new OrderDetails
                {
                    PlacedOrder = order,
                    PurchasedProduct = product,
                    PurchasedDate = DateTime.Now
                };

                context.Orders.Add(order);
                context.Products.Add(product);
                context.OrderDetailss.Add(orderDetails);

                context.SaveChanges();

            }


        }
    }
}