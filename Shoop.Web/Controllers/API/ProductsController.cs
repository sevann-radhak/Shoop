using Microsoft.AspNetCore.Mvc;
using Shoop.Web.Data;
using Shoop.Web.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shoop.Web.Controllers.API
{
    [Route("api/[Controller]")]
    public class ProductsController : Controller
    {
        private readonly IProductRepository productRepository;
        //private readonly IUserHelper userHelper;

        //public ProductsController(IProductRepository productRepository, IUserHelper userHelper)
        public ProductsController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
            //this.userHelper = userHelper;
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            return Ok(this.productRepository.GetAll());
        }
    }
}
