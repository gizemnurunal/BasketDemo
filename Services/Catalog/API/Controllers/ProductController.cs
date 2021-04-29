using Microsoft.AspNetCore.Mvc;
using Services.Catalog.Application.Dtos;
using Services.Catalog.Application.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Catalog.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductController : ControllerBase
	{
		public readonly IProductService _productService;
		public ProductController(IProductService productService)
		{
			_productService = productService;
		}
		[HttpGet("{id}")]
		public async Task<ActionResult<ProductDto>> GetById(string id)
		{
			var response = await _productService.GetByIdAsync(id);
			return response;
		}
		[HttpGet]
		public async Task<ActionResult<List<ProductDto>>> GetAll()
		{
			return await _productService.GetAllAsync();
		}
	}
}