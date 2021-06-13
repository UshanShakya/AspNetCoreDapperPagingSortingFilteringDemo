using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreDapperPagingSortingFilteringDemo.Domain;
using AspNetCoreDapperPagingSortingFilteringDemo.Models;

namespace AspNetCoreDapperPagingSortingFilteringDemo.Services
{
    public interface IProductService
    {
        public Task<DataTableResponse<Product>> GetProductsAsync(DataTableRequest request);
    }
}
