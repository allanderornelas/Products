using Domain;
using Repository.Context;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.Concrete
{
    public class ProductTypeRepository : ITypeRepository
    {
        private readonly appContext _context;

        public ProductTypeRepository(appContext context)
        {
            _context = context;
        }

        public void Add(ProductType type)
        {
            _context.ProductType.Add(type);
        }

        public ProductType Find(int type)
        {
            return _context.Find<ProductType>(type);
        }

        public IEnumerable<ProductType> ListAll()
        {
            return _context.ProductType.ToList();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
