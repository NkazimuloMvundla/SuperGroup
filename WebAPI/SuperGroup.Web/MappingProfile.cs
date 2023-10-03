using AutoMapper;
using SuperGroup.Data.Models;
using SuperGroup.Domain.Models;
using SuperGroup.Models.Models;
using SuperGroup.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperGroup.Web
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            DomainToData();
            DataToDomain();
            DomainToDomain();
            DomainToWeb();
            WebToDomain();
        }

        private void DomainToData()
        {
        }

        private void DataToDomain()
        {
            CreateMap<Product, ProductDomainModel>();
        }

        private void DomainToDomain()
        {
    
        }

        private void DomainToWeb()
        {
            CreateMap<ProductDomainModel, ProductModel>();
            CreateMap<CartLineDomainModel, CartLineModel>();
            CreateMap<OrderDomainModel, OrderModel>();
            CreateMap<OrderDetailDomainModel, OrderDetailModel>();
        }

        private void WebToDomain()
        {
            CreateMap<ProductModel, ProductDomainModel>();
            CreateMap<CartLineModel,CartLineDomainModel>();
            CreateMap<OrderModel, OrderDomainModel>();
            CreateMap<OrderDetailModel, OrderDetailDomainModel>();
        }
    }
}
