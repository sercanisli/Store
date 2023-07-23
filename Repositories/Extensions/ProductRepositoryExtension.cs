using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;

namespace Repositories.Extensions
{
    public static class ProductRepositoryExtension
    {
        public static IQueryable<Product> FilterByCatgoryId(this IQueryable<Product> products, int? categoryId)
        {
            if (categoryId == null || categoryId==0)
            {
                return products;
            }
            return products.Where(p => p.CategoryId == categoryId);
        }
    }
}
