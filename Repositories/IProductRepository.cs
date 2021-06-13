using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreDapperPagingSortingFilteringDemo.Domain;
using AspNetCoreDapperPagingSortingFilteringDemo.Models;

namespace AspNetCoreDapperPagingSortingFilteringDemo.Repositories
{
    public interface IProductRepository
    {
        Task<List<Product>> GetProductsAsync(ProductListRequest request);
    }
}
