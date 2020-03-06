using Emart.BusinessLayer.Interfaces;
using Emart.DataLayer.Interfaces;
using Emart.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Emart.BusinessLayer.Services
{
 public  class ProductServices : IProductServices
    {
        private readonly IProductRepository _productRepository;

        public ProductServices(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Product> CreateProductAsync(Product product)
        {
            try
            {
                var productDto = new Product { Id = product.Id, Name = product.Name };
                return await _productRepository.CreateProductAsync(productDto);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            try
            {
                return await _productRepository.GetProductByIdAsync(id);
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
                return await _productRepository.GetAllProductsAsync();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
}
