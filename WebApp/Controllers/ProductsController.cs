using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Repository.Services;
using WebApp.Models;

namespace WebApp.Controllers
{    
    public class ProductsController : Controller
    {
        private ProductApiService _productService;
        private ProductTypeApiService _productTypeApiService;

        public ProductsController(ProductApiService productService, ProductTypeApiService productTypeApiService)
        {
            _productService = productService;
            _productTypeApiService = productTypeApiService;
        }

        public IActionResult Index()
        {
            ProductsViewModel model = new ProductsViewModel();            

            model.Report = _productService.GetAllProducts();

            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ProductsViewModel model = new ProductsViewModel();
            model.ProductTypesItens = _productTypeApiService.GetAllProductTypes();

            return View(model);
        }

        [HttpPost]
        public IActionResult Create(ProductsViewModel model)
        {
            var product = new Product();
            product.Amount = model.Amount;
            product.Name = model.Name;
            product.Value = model.Value;
            product.ProductTypeId = model.ProductTypeId;            

            _productService.CreateProduct(product);

            return RedirectToAction("Index","Products");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ProductsViewModel model = new ProductsViewModel();

            var productToEdit = _productService.GetProduct(id);

            model.Amount = productToEdit.Amount;
            model.Name = productToEdit.Name;
            model.Value = productToEdit.Value;
            model.ProductTypeId = productToEdit.ProductTypeId;    
            model.ProductTypesItens = _productTypeApiService.GetAllProductTypes();
            model.ProductId = id;

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(ProductsViewModel model)
        {
            Product product = new Product();

            product.Id = model.ProductId;
            product.Value = model.Value;
            product.Amount = model.Amount;
            product.Name = model.Name;
            product.ProductTypeId = model.ProductTypeId;

            _productService.UpdateProduct(product);

            return RedirectToAction("Index", "Products");
        }

        public IActionResult Delete(int id)
        {
            _productService.DeleteProduct(id);

            return RedirectToAction("Index", "Products");
        }
    }
}
