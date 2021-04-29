using AutoMapper;
using Dtos = Services.Basket.Application.Dtos;
using CatalogDtos = Services.Catalog.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Protos = Services.Catalog.Grpc.Protos;

namespace Services.Basket.Application.Mapping
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<Dtos.BasketItemDto, Protos.BasketItemDto>().ReverseMap();
			CreateMap<CatalogDtos.ProductDto, Protos.ProductDto>().ReverseMap();

		}
	}
}