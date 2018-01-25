using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class ProductType
    {
        public ProductType()
        {
        }

        public int Id { get; set; }
        public string Name { get; set; }        

    }
}
