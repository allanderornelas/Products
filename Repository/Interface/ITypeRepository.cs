using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Interface
{
    public interface ITypeRepository
    {
        void Add(ProductType type);
        void Save();
        IEnumerable<ProductType> ListAll();
        ProductType Find(int type);
    }
}
