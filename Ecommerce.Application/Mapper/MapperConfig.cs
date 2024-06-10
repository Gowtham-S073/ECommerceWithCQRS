using AutoMapper;
using Ecommerce.Application.RequestModels;
using Ecommerce.Application.ResponseModels;
using Ecommerce.Domain.Models.CoreModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Mapper
{
    public class MapperConfig: Profile
    {
        public MapperConfig()
        {
            CreateMap<Order, AddOrderRequestModel>().ReverseMap();
            CreateMap<Order, GetAllOrderResponseModel>().ReverseMap();
        }   
    }
}
