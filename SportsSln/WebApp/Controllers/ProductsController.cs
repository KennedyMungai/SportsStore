using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers;

//Making the methods asynchronous doesn't make the methods faster,
//it just means that they can be processed at the same time

[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private DataContext context;

    public ProductsController(DataContext ctx)
    {
        context = ctx;
    }

    [HttpGet]
    public IAsyncEnumerable<Product> GetProducts()
    {
        return context.Products.AsAsyncEnumerable();
    }

    [HttpGet("{id}")]
    public async Task<Product> GetProduct(long id)
    {
        return await context.Products.FindAsync(id);
    }

    [HttpPost]
    public async Task SaveProduct([FromBody] ProductBindingTarget target)
    {
        await context.Products.AddAsync(target.ToProduct());
        await context.SaveChangesAsync();
    }

    [HttpPut]
    public async Task UpdateProduct([FromBody]Product product)
    {
        context.Update(product);
        await context.SaveChangesAsync();
    }

    [HttpDelete("[id}")]
    public async Task DeleteProduct(long id)
    {
        context.Products.Remove(new Product(){ProductId = id});
        await context.SaveChangesAsync();
    }

    // [HttpGet]
    // public IEnumerable<Product> GetProducts()
    // {
    //     return context.Products;
    // }

    // [HttpGet("{id}")]
    // public Product? GetProduct(long id, [FromServices] ILogger<ProductsController> logger)
    // {
    //     logger.LogDebug("GetProduct Action Invoked");
    //     return context.Products.Find(id);
    // }

    // [HttpPost]
    // public void SaveProduct([FromBody] Product product)
    // {
    //     context.Products.Add(product);
    //     context.SaveChanges();
    // }

    // [HttpPut]
    // public void UpdateProduct([FromBody] Product product)
    // {
    //     context.Products.Update(product);
    //     context.SaveChanges();
    // }

    // [HttpDelete("{id}")]
    // public void DeleteProduct(long id)
    // {
    //     context.Products.Remove(new Product(){ProductId = id});
    //     context.SaveChanges();
    // }
}