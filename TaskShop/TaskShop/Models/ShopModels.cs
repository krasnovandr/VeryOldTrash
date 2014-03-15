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
        //public DbSet<Battery> Batteries { get; set; }
        //public DbSet<Earphone> Earphones { get; set; }
        //public DbSet<MemoryCard> MemoryCards { get; set; }
        //public DbSet<Monitor> Monitors { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Commodity> DbGoods { get; set; }
        public DbSet<Property> DbProperties { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Property>().
                HasMany(c => c.Goods).
                WithMany(p => p.Properties).
                Map(
                    m =>
                    {
                        m.MapLeftKey("GoodsId");
                        m.MapRightKey("PropertyId");
                        m.ToTable("GoodsProperties");
                    });

        }
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
        public int TotalPrice { get; set; }

        public int TotalCount { get; set; }
        public int Discount { get; set; }
        public string Email { get; set; }

        public string City { get; set; }
        public string Street { get; set; }
        public int House { get; set; }

        public string CardNumber { get; set; }
    }

    public class Commodity
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public string Producer { get; set; }
        public int Price { get; set; }
        public string Category { get; set; }
        public virtual ICollection<Property> Properties { get; set; }
        public Commodity()
        {
            Properties = new List<Property>();
        }
    }
    public class Property
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ValueChar { get; set; }
        public int ValueInt { get; set; }
        public virtual ICollection<Commodity> Goods { get; set; }
        public Property()
        {
            Goods = new List<Commodity>();
        }
    }



}