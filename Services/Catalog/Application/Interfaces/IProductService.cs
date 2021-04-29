using Services.Catalog.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Catalog.Application.Interfaces
{
	public interface IProductService
	{
		Task<List<ProductDto>> GetAllAsync();
		Task<ProductDto> GetByIdAsync(string id);
	}
}
