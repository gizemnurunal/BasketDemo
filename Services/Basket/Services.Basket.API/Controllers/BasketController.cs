using Microsoft.AspNetCore.Mvc;
using Services.Basket.Application.Dtos;
using Services.Basket.Application.Interfaces;
using Services.Basket.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.Basket.API.Controllers
{
	[Route("api/[controller]/[action]")]
	[ApiController]
	public class BasketController : ControllerBase
	{
		private readonly IBasketService _basketService;

		public BasketController(IBasketService basketService, ProductGrpcService productGrpcService)
		{
			_basketService = basketService;
		}
		[HttpGet]
		public async Task<ActionResult<BasketDto>> GetBasket(string id)
		{
			return await _basketService.GetBasket(id);
		}
		[HttpPost]
		public async Task<ActionResult<bool>> SaveOrUpdate(BasketDto basketDto)
		{
			var response = await _basketService.SaveOrUpdate(basketDto);
			return response;
		}
		[HttpDelete]
		public async Task<ActionResult<bool>> Delete(string id)
		{
			var response = await _basketService.Delete(id);
			return response;
		}
	}
}
