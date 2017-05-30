using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace edX.DataApp.CoreConsole
{
    public class ProductAndCategoryQuery
    {
        public async Task RunLogic(ContosoContext context)
        {
            IEnumerable<Product> products = await context.Products
                .Include(p => p.ProductCategory)
                .Where(p => p.ListPrice > 1250m && p.ListPrice < 1450m)
                .Take(20)
                .ToListAsync();
            foreach (Product product in products)
            {
                Console.WriteLine($"[{product.ProductCategory.Name}]\t{product.Name,35}\t{product.ListPrice:C}");
            }
        }
    }
}
