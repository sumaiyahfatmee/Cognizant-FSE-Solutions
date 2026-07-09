using Microsoft.EntityFrameworkCore;
using RetailInventory.Data;

using var context = new AppDbContext();

try
{
    var product = await context.Products.FirstAsync();

    product.StockQuantity += 5;

    await context.SaveChangesAsync();

    Console.WriteLine("Stock updated successfully!");
}
catch (DbUpdateConcurrencyException)
{
    Console.WriteLine("Concurrency conflict detected.");
}