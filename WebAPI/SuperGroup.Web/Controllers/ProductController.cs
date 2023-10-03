using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SuperGroup.Core;
using SuperGroup.Domain.IContractManagers;
using SuperGroup.Models.Models;
using SuperGroup.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperGroup.Web.Controllers
{
    [ApiController]
    [Route("api/")]
    public class ProductController: ControllerBase
    {

        private readonly IMapper _mapper;
        private readonly IProductManager _productManager;

        public ProductController(IMapper mapper, IProductManager productController)
        {
            Guard.ArgumentNotNull(mapper, nameof(mapper));
            Guard.ArgumentNotNull(productController, nameof(productController));
            _productManager = productController;
            _mapper = mapper;
        }

        [HttpGet, Route("products")]
        public async Task<IActionResult> GetProducts(int itemsToTake, int currentPage)
        {
     
            try
            {
                var productDomainModel = await _productManager.GetProducts(itemsToTake, currentPage);

                return Ok(new ProductsListModel
                {
                    Products = _mapper.Map<IReadOnlyCollection<ProductModel>>(productDomainModel.Results),
                    TotalRowCount = productDomainModel.Total,
                });
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPost, Route("createorder")]
        public async Task<IActionResult> CreateOrder([FromBody] OrderModel orderModel)
        {

            OrderDomainModel orderModelDomain = _mapper.Map<OrderDomainModel>(orderModel);

            try
            {
                var productDomainModel = await _productManager.CreateOrder(orderModelDomain);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
            return Ok();
        }

        [HttpGet, Route("getordershistory")]
        public async Task<IActionResult> GetOrdersHistory()
        {
            try
            {
                var ordershistoryModel = await _productManager.GetOrderDetailsAsync();

                return Ok(_mapper.Map<List<OrderDetailModel>>(ordershistoryModel));
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }

        }


    }
}
