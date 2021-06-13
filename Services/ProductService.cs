using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreDapperPagingSortingFilteringDemo.Domain;
using AspNetCoreDapperPagingSortingFilteringDemo.Models;
using AspNetCoreDapperPagingSortingFilteringDemo.Repositories;

namespace AspNetCoreDapperPagingSortingFilteringDemo.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<DataTableResponse<Product>> GetProductsAsync(DataTableRequest request)
        {
            var req = new ProductListRequest()
            {
                PageNo = request.Start,
                PageSize = request.Length,
                SortColumn = request.Order[0].Column,
                SortDirection = request.Order[0].Dir,
                SearchValue = request.Search != null ? request.Search.Value.Trim() : ""
            };

            var products = await _productRepository.GetProductsAsync(req);

            return new DataTableResponse<Product>()
            {
                Draw = request.Draw,
                RecordsTotal = products[0].TotalCount,
                RecordsFiltered = products[0].FilteredCount,
                Data = products.ToArray(),
                Error = ""
            };

        }
    }
}
