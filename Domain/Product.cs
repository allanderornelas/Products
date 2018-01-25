using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain
{
    public class Product
    {
        public Product()
        {

        }

        public int Id { get; set; }
        public virtual ProductType ProductType { get; set; }        
        public int ProductTypeId { get; set; }
        public decimal Value { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
    }
}
