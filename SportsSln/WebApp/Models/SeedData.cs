using Microsoft.EntityFrameworkCore;

namespace WebApp.Models;

public static class SeedData
{
    public static void SeedDatabase(DataContext context)
    {
        context.Database.Migrate();

        if (context.Products.Count() == 0 && context.Suppliers.Count() == 0 && context.Categories.Count() == 0)
        {
            //Seed data for the supplier table
            Supplier s1 = new Supplier
                {Name = "Splash Dudes", City = "San Jose"};
            Supplier s2 = new Supplier
                {Name = "Soccer town", City = "Chicago"};
            Supplier s3 = new Supplier
                {Name = "Chess Co", City = "New York"};


            //Seed data for the Category table
            Category c1 = new Category {Name = "Watesports"};
            Category c2 = new Category {Name = "Soccer"};
            Category c3 = new Category {Name = "Chess"};

            //Seed data for the products table
            context.Products.AddRange(
                new Product {Name = "Kayak", Price = 275, Category = c1, Supplier = s1,},
                new Product {Name = "LifeJacket", Price = 48.95M, Category = c1, Supplier = s1},
                new Product {Name = " Soccer Ball", Price = 19.50M, Category = c2, Supplier = s2},
                new Product {Name = "Corner Flags", Price = 34.95M, Category = c2, Supplier = s2},
                new Product {Name = "Stadium", Price = 79500, Category = c2, Supplier = s2},
                new Product {Name = "Thinking Cap", Price = 16, Category = c3, Supplier = s3},
                new Product {Name = "Unsteady Chair", Price = 29.95M, Category = c3, Supplier = s3},
                new Product {Name = "Human Chess Board", Price = 75, Category = c3, Supplier = s3},
                new Product {Name = "Bling bling king", Price = 1200, Category = c3, Supplier = s3}
            );

            context.SaveChanges();
        }
    }
}