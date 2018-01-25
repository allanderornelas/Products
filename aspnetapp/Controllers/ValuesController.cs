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
    public class ValuesController : Controller
    {
        private IProductRepository _productContext;
        private ITypeRepository _productTypeContext;

        public ValuesController(IProductRepository productContext, ITypeRepository productTypeRepository)
        {
            _productContext = productContext;
            _productTypeContext = productTypeRepository;
        }

        // GET api/values
        [HttpGet]
        public IActionResult Get([FromQuery] int page, [FromQuery] int size)
        {
            IEnumerable<Product> product = null;

            if (page == 0 && size == 0)
            {
                product = _productContext.ListAll();
            }
            else
            {
                product = _productContext.ListAll().Skip(page - 1 * size).Take(size);
            }
          
            return new ObjectResult(product);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var resultado = _productContext.Find(id);

            if (resultado != null)
            {
                return new ObjectResult(resultado);
            }
            else
            {
                return NoContent();
            }            
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]Product product)
        {
            if (product == null)           
                return BadRequest();            

            try
            {
                _productContext.Add(product);
                _productContext.Save();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);               
            }           

            return Ok();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Product newProduct)
        {
            var product = _productContext.Find(id);

            if (product == null)
            {
                return BadRequest();
            }

            product.Amount = newProduct.Amount;
            product.Name = newProduct.Name;
            product.ProductTypeId = newProduct.ProductTypeId;
            product.Value = newProduct.Value;

            _productContext.Update(product);
            _productContext.Save();

            return Ok();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var produto = _productContext.Find(id);
            _productContext.Delete(produto);
            _productContext.Save();
        }
    }
}
