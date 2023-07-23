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
        public static IQueryable<Product> FilteredByCatgoryId(this IQueryable<Product> products, int? categoryId)
        {
            if (categoryId == null || categoryId==0)
            {
                return products;
            }
            return products.Where(p => p.CategoryId == categoryId);
        }

        public static IQueryable<Product> FilteredBySearchTerm(this IQueryable<Product> products, String? searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                return products;
            }

            return products.Where(p => p.ProductName.ToLower().Contains(searchTerm.ToLower()));
        }

        public static IQueryable<Product> FilteredByPrice(this IQueryable<Product> products, int minPrice, int maxPrice, bool isValidPrice)
        {
            if (isValidPrice == true)
            {
                return products.Where(p => p.Price >= minPrice && p.Price <= maxPrice);
            }

            return products;
        }

        public static IQueryable<Product> ToPaginate(this IQueryable<Product> products, int pageNumber, int pageSize)
        {
            return products.Skip(((pageNumber - 1) * pageSize)).Take(pageSize);
        }
    }
}
