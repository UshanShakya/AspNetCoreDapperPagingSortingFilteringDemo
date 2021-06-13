using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

using AspNetCoreDapperPagingSortingFilteringDemo.Domain;
using AspNetCoreDapperPagingSortingFilteringDemo.Models;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace AspNetCoreDapperPagingSortingFilteringDemo.Repositories
{
    public class ProductRepository : BaseRepository, IProductRepository
    {
        public ProductRepository(IConfiguration configuration)
            : base(configuration)
        { }

        public async Task<List<Product>> GetProductsAsync(ProductListRequest request)
        {
            try
            {
                var procedure = "spGetProductsList";

                var parameters = new DynamicParameters();
                parameters.Add("SearchValue", request.SearchValue, DbType.String);
                parameters.Add("PageNo", request.PageNo, DbType.Int32);
                parameters.Add("PageSize", request.PageSize, DbType.Int32);
                parameters.Add("SortColumn", request.SortColumn, DbType.Int32);
                parameters.Add("SortDirection", request.SortDirection, DbType.String);
        
                using (var connection = CreateConnection())
                {
                    List<Product> product = (await connection.QueryAsync<Product>(procedure, parameters, commandType: CommandType.StoredProcedure)).ToList();
                    return product;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
