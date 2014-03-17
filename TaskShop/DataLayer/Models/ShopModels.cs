using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace DataLayer.Models
{
    public class ShopContext : DbContext
    {

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
                        m.MapLeftKey("PropertyId");
                        m.MapRightKey("GoodsId");
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
        [Required]
        [Range(1, Int32.MaxValue)]
        public int TotalGoodsPrice { get; set; }
        [Required]
        
        [Range(1, Int32.MaxValue)]
        public int DeliveryPrice { get; set; }
        [Required]
        [Range(1, Int32.MaxValue)]
        
        public int TotalPrice { get; set; }
        [Required]
        [Range(1, Int32.MaxValue)]
       
        public int TotalCount { get; set; }
        [Required]
        [Range(1, 100)]
        public int Discount { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 4)]
        public string City { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 4)]
        public string Street { get; set; }
        [Required]
        [Range(1,1000)]
        public int House { get; set; }
        [Required]

        [RegularExpression(@"^[0-9-]{19}$")]
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