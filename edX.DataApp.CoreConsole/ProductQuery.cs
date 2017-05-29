using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace edX.DataApp.CoreConsole
{
    public class ProductQuery
    {
        public void RunLogic(ContosoContext context)
        {
            IEnumerable<Product> products =
                from product in context.Products
                where product.SafetyReviewResult ?? false
                select product;
            foreach (Product product in products)
            {
                Console.WriteLine($"[{product.ProductNumber}]\t{product.Name,35}\tPassed Review: {product.SafetyReviewResult}");
            }
        }
    }
}
