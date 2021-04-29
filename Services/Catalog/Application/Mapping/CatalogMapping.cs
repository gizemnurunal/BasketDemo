using AutoMapper;
using Services.Catalog.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Catalog.Application.Mapping
{
	public class CatalogMapping : Profile
	{
		public CatalogMapping()
		{
			CreateMap<Core.Entities.Product, ProductDto>().ReverseMap();
		}
	}
}