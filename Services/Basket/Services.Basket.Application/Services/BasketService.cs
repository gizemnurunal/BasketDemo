using AutoMapper;
using Services.Basket.Application.Dtos;
using Services.Basket.Application.Interfaces;
using Services.Basket.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Services.Basket.Application.Services
{
	public class BasketService : IBasketService
	{
		private readonly RedisService _redisService;
		private readonly ProductGrpcService _productGrpcService;
		private readonly IMapper _mapper;

		public BasketService(RedisService redisService, ProductGrpcService productGrpcService, IMapper mapper)
		{
			_redisService = redisService;
			_productGrpcService = productGrpcService;
			_mapper = mapper;
		}
		public async Task<bool> Delete(string id)
		{
			var status = await _redisService.GetDb().KeyDeleteAsync(id);
			return status;
		}

		public async Task<BasketDto> GetBasket(string id)
		{
			var existBasket = await _redisService.GetDb().StringGetAsync(id);
			if (String.IsNullOrEmpty(existBasket))
			{
				throw new Exception("Basket not found");
			}
			return JsonSerializer.Deserialize<BasketDto>(existBasket);
		}

		public async Task<bool> SaveOrUpdate(BasketDto basketDto)
		{
			var status = await _redisService.GetDb().StringSetAsync(basketDto.Id, JsonSerializer.Serialize(basketDto));
			return status;
		}
	}
}
