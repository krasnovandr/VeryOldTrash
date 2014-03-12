using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

namespace TaskShop.Models
{
    public class ShopContext : DbContext
    {
        //public ShopContext()
        //    : base("TaskShopConnection")
        //{
        //}
        public DbSet<Battery> Batteries { get; set; }
        public DbSet<Earphone> Earphones { get; set; }
        public DbSet<MemoryCard> MemoryCards { get; set; }
        public DbSet<Monitor> Monitors { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Order> Orders { get; set; }
    }

    public class Battery
    {
        [Key]
        public int Id { get; set; }
        public string Producer { get; set; }
        public int Capacity { get; set; }
        public int Voltage { get; set; }
        public int Price { get; set; }
    }

    public class Earphone
    {
        [Key]
        public int Id { get; set; }
        public string Producer { get; set; }
        public double CableLength { get; set; }
        public int Resistance { get; set; }
        public int MaxFrequency { get; set; }
        public int Price { get; set; }
    }

    public class MemoryCard
    {
        [Key]
        public int Id { get; set; }
        public string Producer { get; set; }
        public int Size { get; set; }
        public int WriteSpeed { get; set; }
        public int ReadSpeed { get; set; }
        public int Price { get; set; }
    }

    public class Monitor
    {
        [Key]
        public int Id { get; set; }
        public string Producer { get; set; }
        public string Resolution { get; set; }
        public int Frequency { get; set; }
        public string MatrixType { get; set; }
        public int Price { get; set; }
    }

    public class Cart
    {
        [Key]
        public int Id { get; set; }
        public int GoodsId { get; set; }
        public string GoodsCategory { get; set; }
        public int Count { get; set; }
        public int Price { get; set; }
        public int OrderId { get; set; }
    }

    public class Order
    {
        [Key]
        public int Id { get; set; }
        public int TotalGoodsPrice { get; set; }
        public int DeliveryPrice { get; set; }
        public int TotalCount { get; set; }
        public int Discount { get; set; }
        public string Email { get; set; }

        public string City { get; set; }
        public string Street { get; set; }
        public int House { get; set; }

        public string CardNumber { get; set; }
    }

}