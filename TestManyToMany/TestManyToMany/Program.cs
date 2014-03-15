using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

public class ShopContext : DbContext
{
    public DbSet<Commodity> DbGoods { get; set; }
    public DbSet<Property> DbProperties { get; set; }

    public ShopContext()
        : base("TestManyToMany")
    {
    }
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

namespace TestManyToMany
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new ShopContext())
            {
                var monitor = new Commodity();
                var battery = new Commodity();

                monitor.Model = "y570";
                monitor.Price = 2120;
                monitor.Producer = "Lenovo";
                monitor.Category = "Monitors";

                //battery.Model = "sl10";
                //battery.Price = 20;
                //battery.Producer = "lenovo";
                //battery.Category = "Batteries";

                db.DbGoods.Add(monitor);
                //db.DbGoods.Add(battery);

                var prop = new Property
                {
                    Name = "ScreenSize",
                    ValueChar = "1920x1080",
                };
                var prop2 = new Property
                {
                    Name = "Resolution",
                    ValueChar = "1920x1080",
                };

                //Person john = new Person();
                //john.FirstName = "John";
                //john.LastName = "Paul";
                prop.Goods.Add(monitor);
                prop2.Goods.Add(monitor);
                //prop.Goods.Add(battery);

                db.DbProperties.Add(prop);
                db.DbProperties.Add(prop2);
                db.SaveChanges();
                var goods = db.DbGoods.Include(p => p.Properties).ToList();
                Console.Write(goods.ToString());
                Console.ReadKey();
            }
        }
    }
}
