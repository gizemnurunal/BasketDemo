using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Catalog.Infrastructure.Data
{
	public interface ICatalogContext : IDisposable
	{
		void AddCommand(Func<Task> func);
		Task<int> SaveChanges();
		IMongoCollection<T> GetCollection<T>(string name);
	}
}
