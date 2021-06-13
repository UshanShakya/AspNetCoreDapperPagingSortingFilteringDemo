using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreDapperPagingSortingFilteringDemo.Domain;
using AspNetCoreDapperPagingSortingFilteringDemo.Models;
using AspNetCoreDapperPagingSortingFilteringDemo.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreDapperPagingSortingFilteringDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        // GET: api/Products
        [HttpPost]
        public async Task<DataTableResponse<Product>> GetProducts()
        {
            var request = new DataTableRequest();

            request.Draw = Convert.ToInt32(Request.Form["draw"].FirstOrDefault());
            request.Start = Convert.ToInt32(Request.Form["start"].FirstOrDefault());
            request.Length = Convert.ToInt32(Request.Form["length"].FirstOrDefault());
            request.Search = new DataTableSearch()
            {
                Value = Request.Form["search[value]"].FirstOrDefault()
            };
            request.Order = new DataTableOrder[] { 
                new DataTableOrder()
                {
                    Dir = Request.Form["order[0][dir]"].FirstOrDefault(),
                    Column = Convert.ToInt32(Request.Form["order[0][column]"].FirstOrDefault())
                }};

            return await _productService.GetProductsAsync(request);
        } 
    }
}
