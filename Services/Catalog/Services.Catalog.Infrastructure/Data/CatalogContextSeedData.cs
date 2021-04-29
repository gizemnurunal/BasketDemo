using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Catalog.Infrastructure.Data
{
	public class CatalogContextSeedData
	{

		public async static void Seed(ICatalogContext context)
		{

			var productCollection = context.GetCollection<Core.Entities.Product>(nameof(Core.Entities.Product));

			productCollection.Database.DropCollection(nameof(Core.Entities.Product));
			#region Products
			context.AddCommand(() => productCollection.InsertOneAsync(new Core.Entities.Product
			{
				Name = "Mutluluk Kutusu",
				Description = "Bazı günler özeldir ve en özel kutlamayı hak eder.",
				Price = 119,
				UnitsInStock = 100
			}));

			context.AddCommand(() => productCollection.InsertOneAsync(new Core.Entities.Product
			{
				Name = "Kütükte Çiçek Bahçesi",
				Description = "İster kendi eviniz için, isterseniz sevdiğiniz birine hediye etmek için doğal görünümlü bir hediye arıyorsanız, Kütükte Çiçek Bahçesi tam size göre.",
				Price = 59.99m,
				UnitsInStock = 80
			}));

			context.AddCommand(() => productCollection.InsertOneAsync(new Core.Entities.Product
			{
				Name = "Papatya Kolye Ve Papatya Buketi Set",
				Description = "Sevdiklerinizi mutlu etmenin, onlara kendilerini özel hissettirmenin yolu zerafet dolu çiçekler ve şık kolyelerden geçer.",
				Price = 39.9m,
				UnitsInStock = 20
			}));

			context.AddCommand(() => productCollection.InsertOneAsync(new Core.Entities.Product
			{
				Name = "Kişiye Özel Fotoğraflı Ayıcık Melek Kolye",
				Description = "Kişiye özel fotoğraflı ayıcık melek kolye, kendiniz ya da sevdikleriniz için tasarlayabileceğiniz bir hediye olarak tercih edilebilir.",
				Price = 49.99m,
				UnitsInStock = 40
			}));

			context.AddCommand(() => productCollection.InsertOneAsync(new Core.Entities.Product
			{
				Name = "Premium Karışık Çikolata Kutusu 310 gr",
				Description = "Özel anların anlamlı tadı karışık çikolata, zarif ambalajı, şık sunumu ve farklı çikolata seçenekleri ile geliyor.",
				Price = 89.99m,
				UnitsInStock = 100
			}));

			context.AddCommand(() => productCollection.InsertOneAsync(new Core.Entities.Product
			{
				Name = "Aşkın Tadı Truf ve Çilek Buketi",
				Description = "Sevdiklerinizi özel günlerinizde mutlu etmek için farklı bir hediye arıyorsanız Aşkın Tadı Truf ve Çilek Buketi tam size göre.",
				Price = 59.99m,
				UnitsInStock = 75
			}));

			#endregion
			await context.SaveChanges();




		}
	}
}
