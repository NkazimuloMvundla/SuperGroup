using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SuperGroup.Core;
using SuperGroup.Data.IContractRepositories;
using SuperGroup.Data.Models;
using SuperGroup.Domain.Models;
using SuperGroup.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperGroup.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly SuperGroupDBContext _superGroupDBContext;
        private readonly IMapper _mapper;

        public ProductRepository(SuperGroupDBContext superGroupDBContext, IMapper mapper)
        {
            Guard.ArgumentNotNull(superGroupDBContext, nameof(superGroupDBContext));
            Guard.ArgumentNotNull(mapper, nameof(mapper));

            _superGroupDBContext = superGroupDBContext;
            _mapper = mapper;
        }

        public async Task<int> CreateOrder(OrderDomainModel orderDomainModel)
        {
            orderDomainModel.Shipped = false;

            var order = new Order
            {
                Created = DateTime.Now,
                Name = orderDomainModel.CustomerName,
                Address = orderDomainModel.Address,
                Shipped = false,
                Products = new List<CartLine>()
            };

            // Add the Order entity to the DbContext and save changes to generate a valid OrderId
            await _superGroupDBContext.Orders.AddAsync(order);
            await _superGroupDBContext.SaveChangesAsync();

            foreach (var cartLine in orderDomainModel.Products)
            {
                var cartLineEntity = new CartLine
                {
                    ProductId = cartLine.ProductId,
                    Quantity = cartLine.Quantity,
                    OrderId = order.OrderId // Use the generated OrderId
                };
                await _superGroupDBContext.CartLines.AddAsync(cartLineEntity);
            }

            // Save changes again to insert CartLine entities with valid OrderId
            await _superGroupDBContext.SaveChangesAsync();

            return (int)order.OrderId;
        }

        public async Task<List<OrderDetailDomainModel>> GetOrderDetailsAsync()
        {
            var orderDetailModel = new OrderDetailDomainModel();

            var query = (from order in _superGroupDBContext.Orders
                        join cartLine in _superGroupDBContext.CartLines on order.OrderId equals cartLine.OrderId
                        join product in _superGroupDBContext.Products on cartLine.ProductId equals product.Id
                        select new OrderDetailDomainModel
                        {
                            Orders = new OrderDomainModel
                            {
                                OrderId = order.OrderId,
                                CustomerName = order.Name,
                                OrderedDate  = order.Created
                            },

                            CartLines = new CartLineDomainModel
                            {
                                ProductId = cartLine.ProductId,
                                Quantity = cartLine.Quantity
                            },

                            Products = new ProductDomainModel
                            {
                                 Name = product.Name,
                                 Id = product.Id
                            },
                        });

            var result = await query.ToListAsync();
            return result;
        }




        private decimal GetPrice(IEnumerable<CartLineDomainModel> lines)
        {
            IEnumerable<long> ids = lines.Select(l => l.ProductId);
            IEnumerable<Product> prods
            = _superGroupDBContext.Products.Where(p => ids.Contains(p.Id));
            return prods.Select(p => lines
            .First(l => l.ProductId == p.Id).Quantity * p.Price)
            .Sum();
        }

        public async Task<PagedResponseDomainModel<ProductDomainModel>> GetProducts(int itemsToTake, int currentPage)
        {
 
            var query = BuildQuery(); // Get the base query

            // Calculate total count before applying pagination
            int totalCount = await query.CountAsync();

            // Apply pagination
            query = query.Skip((currentPage - 1) * itemsToTake).Take(itemsToTake);

            // Execute the query and materialize the results
            var results = await query.ToListAsync();

            return new PagedResponseDomainModel<ProductDomainModel>(totalCount, results);
        }

        private IQueryable<ProductDomainModel> BuildQuery()
        {
            return (from product in _superGroupDBContext.Products

                    select new ProductDomainModel
                    {
                        Id = product.Id,
                        Name = product.Name,
                        Price = product.Price,
                        Description = product.Description
                    });
        }
    }
}