using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Basket.Application.Dtos
{
	public class BasketDto
	{
		public string Id { get; set; }
		public List<BasketItemDto> BasketItems { get; set; }
		public decimal TotalPrice { get => BasketItems.Sum(x => x.Price * x.Quantity); }
	}
}
