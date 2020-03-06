using Dapper;
using Emart.DataLayer.Database;
using Emart.DataLayer.Interfaces;
using Emart.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Emart.DataLayer.Repositories
{
  public  class ProductRepository : IProductRepository
    {
        private readonly IDbConnectionFactory _dbConnectionFactory;
       

        public ProductRepository(IDbConnectionFactory dbConnectionFactory)
        {
            _dbConnectionFactory = dbConnectionFactory;
        }


        public async Task<Product> CreateProductAsync(Product product)
        {
            try
            {

              
                //SqLiteConnectionFactory sql = new SqLiteConnectionFactory(string dbLocation);
                var connection = await _dbConnectionFactory.CreateConnectionAsync();
                await _dbConnectionFactory.SetupAsync();
                await connection.ExecuteAsync("Insert into Products (Id, Name) VALUES (@id, @name)", new { id = product.Id, name = product.Name });
                return product;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            try
            {
                var connection = await _dbConnectionFactory.CreateConnectionAsync();
                return await connection.QuerySingleOrDefaultAsync<Product>("select * from Products where Id=@id", new { id = id });
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            try
            {
                var connection = await _dbConnectionFactory.CreateConnectionAsync();
                return await connection.QueryAsync<Product>("select * from Products");
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

       
    }
}
