using Services.Catalog.Grpc.Protos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Basket.Application.Services
{
	public class ProductGrpcService
	{
		private readonly ProductProtoService.ProductProtoServiceClient _productProtoService;

		public ProductGrpcService(ProductProtoService.ProductProtoServiceClient productprotoservice)
		{
			_productProtoService = productprotoservice;
		}

		public ProductResponse CheckStockAsync(List<BasketItemDto> basketItems)
		{
			try
			{
				var productrequest = new BasketItemRequest();
				productrequest.BasketItems.AddRange(basketItems);
				var a = _productProtoService.CheckStock(productrequest);
			}
			catch (Exception ex)
			{

				throw;
			}

			return new ProductResponse();
		}
	}
}
