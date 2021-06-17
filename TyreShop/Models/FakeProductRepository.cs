using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TyreShop.Models
{
    public class FakeProductRepository
    {
        public IQueryable<Product> Products => new List<Product>
        {
            new Product {Name = "Opona Michelin", Price = 550M},
            new Product {Name = "Opona Kleber", Price = 280M},
            new Product {Name = "Opona Zetex", Price = 120M}
        }.AsQueryable<Product>();
    }
}
