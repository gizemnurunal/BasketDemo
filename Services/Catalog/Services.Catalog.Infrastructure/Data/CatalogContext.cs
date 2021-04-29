using MongoDB.Driver;
using Services.Catalog.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Catalog.Infrastructure.Data
{
	public class CatalogContext : ICatalogContext
	{
		private readonly IMongoDatabase _database = null;
		private readonly IMongoClient _client = null;
		private readonly List<Func<Task>> _commands;

		public CatalogContext(IDatabaseSettings databaseSettings)
		{
			_client = new MongoClient(databaseSettings.ConnectionString);
			_database = _client.GetDatabase(databaseSettings.Database);
			_commands = new List<Func<Task>>();

		}
		public async Task<int> SaveChanges()
		{
			var commandTasks = _commands.Select(c => c());
			await Task.WhenAll(commandTasks);
			return _commands.Count;
		}


		public IMongoCollection<T> GetCollection<T>(string name)
		{
			return _database.GetCollection<T>(name);
		}

		public void Dispose()
		{
			GC.SuppressFinalize(this);
		}

		public void AddCommand(Func<Task> func)
		{
			_commands.Add(func);
		}

	}
}