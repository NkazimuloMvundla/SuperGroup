using SuperGroup.Domain.Models;
using SuperGroup.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SuperGroup.Domain.IContractManagers
{
    public interface IProductManager 
    {
        Task<PagedResponseDomainModel<ProductDomainModel>> GetProducts(int itemsToTake, int currentPage);
        Task<int> CreateOrder(OrderDomainModel orderDomainModel);

        Task<List<OrderDetailDomainModel>> GetOrderDetailsAsync();

    }

}
