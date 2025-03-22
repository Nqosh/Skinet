using System.Reflection;
using System.Text.Json;
using Core.Entities;
using Core.Entities.OrderAggregate;
using Infrastructue.Data;

namespace Infrastructure.Data
{
    public class StoreContextSeed
    {
        public static async Task SeedAsync(StoreContext context)
        {
            try
            {
                var path = "C:/Users/nqobilem/source/repos/Ecommerce/Ecommerce/Ecommerce/Infrastructure/Data/SeedData/";

                if (!context.ProductBrands.Any())
                {
                    var brandsData = File.ReadAllText(path + "brands.json");
                    var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);
                    context.ProductBrands.AddRange(brands);
                }

                if (!context.ProductTypes.Any())
                {
                    var typesData = File.ReadAllText(path + "types.json");
                    var types = JsonSerializer.Deserialize<List<ProductType>>(typesData);
                    context.ProductTypes.AddRange(types);
                }

                if (!context.Products.Any())
                {
                    var productsData = File.ReadAllText(path + "products.json");
                    var products = JsonSerializer.Deserialize<List<Product>>(productsData);
                    context.Products.AddRange(products);
                }

                if (!context.DeliveryMethods.Any())
                {
                    var deliveryData = File.ReadAllText(path + "delivery.json");
                    var methods = JsonSerializer.Deserialize<List<DeliveryMethod>>(deliveryData);
                    context.DeliveryMethods.AddRange(methods);
                }

                if (context.ChangeTracker.HasChanges()) await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
           
        }
    }
}