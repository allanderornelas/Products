using Domain;
using Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.Data
{
    public static class DbInitializer
    {
        public static void Initialize(appContext context)
        {
            context.Database.EnsureCreated();

            if (context.Product.Any())
            {
                return;
            }

            var ProductType = new ProductType[]
            {
                new ProductType{ Name = "ProdutoTeste" },
                new ProductType{ Name = "Metal" },

            };

            foreach (var pType in ProductType)
            {
                context.ProductType.Add(pType);
            }
            context.SaveChanges();

            var product = new Product[]
            {
                new Product{ Name="Produto Teste", Amount=10, Value=15, ProductType = ProductType[0] },
                new Product{ Name="Produto Teste", Amount=10, Value=15, ProductType = ProductType[1] }
            };

            foreach (var prod in product)
            {
                context.Product.Add(prod);
            }
            context.SaveChanges();


        }
    }
}
