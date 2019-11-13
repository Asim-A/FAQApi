using FAQApi.Model.DatabaseModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JsonNet.PrivateSettersContractResolvers;
using Microsoft.Extensions.DependencyInjection;

namespace FAQApi.Database
{
    public static class Seeder
    {
        public static void Seedit(string jsonData,
                                  IServiceProvider serviceProvider)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                ContractResolver = new PrivateSetterContractResolver()
            };
            var cat1 =
             JsonConvert.DeserializeObject<List<Category>>(
               jsonData, settings);
            using (
             var serviceScope = serviceProvider
               .GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope
                              .ServiceProvider.GetService<FAQContext>();
                if (!context.categories.Any())
                {
                    context.AddRange(cat1);
                    context.SaveChanges();
                }
            }
        }
    }
}
