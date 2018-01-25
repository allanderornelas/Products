using Domain;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace WebApp.Models
{
    public class ProductsViewModel
    {
        public ProductsViewModel()
        {
            
        }

        public List<Product> Report { get; set; }
        public int ProductId { get; set; }

        [DisplayName("Quantidade")]
        public int Amount { get; set; }

        [DisplayName("Tipo")]
        public int ProductTypeId { get; set; }
        public List<ProductType> ProductTypesItens { get; set; }

        [DisplayName("Nome")]
        public string Name { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:n2}")]
        [DataType(DataType.Currency)]
        [DisplayName("Valor")]
        public decimal Value { get; set; }        

    }
}