using FirstFramework.Northwind.DataAcces.Concrete.EntityFramework.Mappings;
using FirstFramework.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstFramework.Northwind.DataAcces.Concrete.EntityFramework
{
    public class NorthwindContext:DbContext
    {
        public NorthwindContext()
        {
            //Böylebir tablo yoksa otamatik oluşturmasın diye 
            Database.SetInitializer<NorthwindContext>(null);
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories{ get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ProductMap());
             modelBuilder.Configurations.Add(new CategoryMap());
        }
    }
}
