using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Data;
using Domain;
using Repository.Context;

namespace Repository.Concrete
{
    public class ProductRepository : IProductRepository
    {
        private readonly appContext _context;

        public ProductRepository(appContext context)
        {
            _context = context;
        }

        public void Add(Product product)
        {
            _context.Product.Add(product);            
        }

        public Product Find(int productId)
        {
            return _context.Product.Include(x => x.ProductType).Where(x => x.Id == productId).SingleOrDefault();
        }

        public IEnumerable<Product> ListAll()
        {
            return _context.Product.Include(x => x.ProductType).ToList();
        }

        public void Update(Product product)
        {
            _context.Update(product);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Delete(Product product)
        {
            _context.Remove(product);
        }
    }
}
