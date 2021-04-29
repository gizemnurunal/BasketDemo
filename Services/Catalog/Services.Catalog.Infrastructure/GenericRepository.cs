using MongoDB.Driver;
using Services.Catalog.Core.Entities;
using Services.Catalog.Core.Interfaces;
using Services.Catalog.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Services.Catalog.Infrastructure
{
	public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
	{
		private readonly ICatalogContext _context;
		private readonly IMongoCollection<T> _collection;
		public GenericRepository(ICatalogContext context)
		{
			_context = context;
			_collection = _context.GetCollection<T>(typeof(T).Name);
		}

		public async Task<T> GetByIdAsync(string id)
		{
			return await _collection.Find<T>(x => x.Id == id).FirstOrDefaultAsync();
		}

		public async Task<IEnumerable<T>> GetAllAsync()
		{
			return await _collection.Find<T>(Builders<T>.Filter.Empty).ToListAsync();
		}
		
	}
}
