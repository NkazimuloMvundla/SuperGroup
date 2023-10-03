using SuperGroup.Core;
using SuperGroup.Data.IContractRepositories;
using SuperGroup.Domain.IContractManagers;
using SuperGroup.Domain.Models;
using SuperGroup.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SuperGroup.Domain.Managers
{
    public class ProductManager : IProductManager
    {
        //  private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IProductRepository _productRepository;

        public ProductManager(IProductRepository productRepository)
        {
            Guard.ArgumentNotNull(productRepository, nameof(productRepository));

            _productRepository = productRepository;

        }

        public async Task<int> CreateOrder(OrderDomainModel orderDomainModel)
        {
            return await _productRepository.CreateOrder(orderDomainModel);
        }

        public ProductDomainModel GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<List<OrderDetailDomainModel>> GetOrderDetailsAsync()
        {
            return await _productRepository.GetOrderDetailsAsync();
        }

        public async Task<PagedResponseDomainModel<ProductDomainModel>> GetProducts(int itemsToTake, int currentPage)
        {
            var currentPageItem = currentPage + 1;
            return await _productRepository.GetProducts(itemsToTake, currentPageItem);
        }
    }
}