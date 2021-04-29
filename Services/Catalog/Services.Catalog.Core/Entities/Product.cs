using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Catalog.Core.Entities
{
	public class Product : BaseEntity
	{
		public string Name { get; set; }
		public string Description { get; set; }
		[BsonRepresentation(MongoDB.Bson.BsonType.Decimal128)]
		public decimal Price { get; set; }
		[BsonRepresentation(MongoDB.Bson.BsonType.Int32)]
		public int UnitsInStock { get; set; }
	}
}
