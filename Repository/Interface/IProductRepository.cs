using Domain;
using System;
using System.Collections.Generic;

namespace Repository
{
    public interface IProductRepository
    {
        void Add(Product product);
        void Save();
        void Update(Product product);
        IEnumerable<Product> ListAll();
        Product Find(int productId);
        void Delete(Product product);
    }
}
