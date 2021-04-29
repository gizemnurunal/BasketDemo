using Services.Basket.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Basket.Application.Interfaces
{
	public interface IBasketService
	{
		Task<BasketDto> GetBasket(string id);
		Task<bool> SaveOrUpdate(BasketDto basketDto);
		Task<bool> Delete(string id);
	}
}
