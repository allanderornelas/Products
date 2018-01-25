using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Repository;
using Repository.Concrete;
using Repository.Interface;

namespace aspnetapp.Controllers
{
    [Route("api/[controller]")]
    public class TypesController : Controller
    {
        private IProductRepository _productContext;
        private ITypeRepository _productTypeContext;

        public TypesController(IProductRepository productContext, ITypeRepository productTypeRepository)
        {
            _productContext = productContext;
            _productTypeContext = productTypeRepository;
        }

        // GET api/types
        [HttpGet]
        public IActionResult Get()
        {
            var types = _productTypeContext.ListAll();
          
            return new ObjectResult(types);
        }       
    }
}
