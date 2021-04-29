using AutoMapper;
using Services.Catalog.Application.Dtos;
using Services.Catalog.Application.Interfaces;
using Services.Catalog.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Catalog.Application.Services
{
	public class ProductService : IProductService
	{
		private readonly IGenericRepository<Core.Entities.Product> _productRepository;
		private readonly IMapper _mapper;
		public ProductService(IGenericRepository<Core.Entities.Product> productRepository, IMapper mapper)
		{
			_productRepository = productRepository;
			_mapper = mapper;
		}


		public async Task<List<ProductDto>> GetAllAsync()
		{
			var response = await _productRepository.GetAllAsync();

			return _mapper.Map<List<ProductDto>>(response);
		}
		public async Task<ProductDto> GetByIdAsync(string id)
		{
			var product = await _productRepository.GetByIdAsync(id);
			if (product == null)
			{
				throw new Exception("Product not found");
			}
			return _mapper.Map<ProductDto>(product);
		}
	}
}
