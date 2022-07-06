using JewelryShop.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace JewelryShop.Data
{
    public partial class JewelryShopContextDB : DbContext
    {
        public JewelryShopContextDB()
        {
        }

        public JewelryShopContextDB(DbContextOptions<JewelryShopContextDB> options)
            : base(options)
        {

        }

        public virtual DbSet<Material> Materials { get; set; } = null!;
        public virtual DbSet<PhotoURI> PhotoURIs { get; set; } = null!;
        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<CategoryItem> CategoryItems { get; set; } = null!;
        public virtual DbSet<CategoryProduct> CategoryProducts { get; set; } = null!;
        public virtual DbSet<Size> Sizes { get; set; } = null!;
        public virtual DbSet<ProductBase> ProductBases{ get; set; } = null!;
        public virtual DbSet<Supplier> Suppliers { get; set; } = null!;
        public virtual DbSet<SizeItem> SizeItems { get; set; } = null!;
        public virtual DbSet<SizeProduct> SizeProducts { get; set; } = null!;
        public virtual DbSet<Item> Items { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(
                    @"Data Source=(localdb)\JewleryShop;Initial Catalog=JewleryShop;Integrated Security=True",
                    x => x.UseNetTopologySuite());
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Material>().ToTable("Material");
            //modelBuilder.Entity<PhotoURI>().ToTable("PhotoURI");
            //modelBuilder.Entity<Category>().ToTable("Category");
            //modelBuilder.Entity<Size>().ToTable("Size");
            //modelBuilder.Entity<ProductBase>().ToTable("ProductBase");
            //modelBuilder.Entity<Supplier>().ToTable("Supplier");
            //modelBuilder.Entity<SizeItem>().ToTable("SizeItem");
            //modelBuilder.Entity<SizeProduct>().ToTable("SizeProduct");
            //modelBuilder.Entity<Item>().ToTable("Item");
            //modelBuilder.Entity<Product>().ToTable("Product");
        }



    }
}
