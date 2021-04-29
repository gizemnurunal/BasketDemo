using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Grpc.Core;
using Services.Catalog.Application.Interfaces;
using Services.Catalog.Core.Entities;
using Services.Catalog.Core.Interfaces;
using Services.Catalog.Grpc.Protos;

namespace Services.Catalog.Grpc.Services
{
	public class ProductService : ProductProtoService.ProductProtoServiceBase
	{
		private readonly IGenericRepository<Product> _productRepository;
		private readonly IMapper _mapper;
		public ProductService(IGenericRepository<Product> productRepository, IMapper mapper)
		{
			_productRepository = productRepository;
			_mapper = mapper;
		}
		public override Task<ProductResponse> CheckStock(BasketItemRequest request, ServerCallContext context)
		{
			return base.CheckStock(request, context);
		}



	}
}
