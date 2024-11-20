using Bulky.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace Bulky.DataAccess.Data 
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { 

        }

        public DbSet<Category> Categories        {  get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData (
                new Category { Id=1,Name="Action",DisplayOrder=1},
                new Category { Id = 2, Name = "SciFi", DisplayOrder = 2 },
                new Category { Id = 3, Name = "History", DisplayOrder = 3 }
                );
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id= 1,
                    Title="Naruto" ,
                    Author="A",
                    Description="AA",
                    ListPrice=10,
                    CategoryId=1,
                    ImageUrl="a"
                },
                 new Product
                 {
                     Id = 2,
                     Title = "Sasuke",
                     Author = "A",
                     Description = "AA",
                     ListPrice = 15,
                     CategoryId = 1,
                     ImageUrl = "a"
                 },
                  new Product
                  {
                      Id = 3,
                      Title = "Jiraiya",
                      Author = "AS",
                      Description = "AZA",
                      ListPrice = 101,
                      CategoryId = 1,
                      ImageUrl = "a"
                  },
                   new Product
                   {
                       Id = 4,
                       Title = "Madara",
                       Author = "OO",
                       Description = "AXXA",
                       ListPrice = 18,
                       CategoryId = 2,
                       ImageUrl = "a"
                   },
                    new Product
                    {
                        Id = 5,
                        Title = "Obito",
                        Author = "PO",
                        Description = "aaAA",
                        ListPrice = 500,
                        CategoryId = 1,
                        ImageUrl = "a"
                    }
                 );

        }
    }
}
