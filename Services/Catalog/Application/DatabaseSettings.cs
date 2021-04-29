using Services.Catalog.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Catalog.Application
{
	public class DatabaseSettings : IDatabaseSettings
	{
		public string CategoryCollectionName { get; set; }
		public string ProductCollectionName { get; set; }
		public string ConnectionString { get; set; }
		public string Database { get; set; }
	}
}
