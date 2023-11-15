using System.Collections.Concurrent;
using System.Collections.Generic;
using AuthService.Controllers;
using AuthService.Domain;

namespace AuthService.DataAccess
{
    public class ProductAgentsInMemoryDb : IProductAgents
    {
        private readonly IDictionary<string, ProductAgent> db = new ConcurrentDictionary<string, ProductAgent>();

        public ProductAgentsInMemoryDb()
        {
            Add(new ProductAgent("rohit.solid", "secret", "static/avatars/rohit_solid.png", new List<string>() {"Britania", "Sunfeast", "Tata", "ThreeRoses"}));
            Add(new ProductAgent("surya.solid", "secret", "static/avatars/surya.solid.png", new List<string>() {"Britania", "Sunfeast", "Tata", "ThreeRoses"}));
            Add(new ProductAgent("admin", "admin", "static/avatars/admin.png", new List<string>() {"Britania", "Sunfeast", "Tata", "ThreeRoses"}));
        }

        public void Add(ProductAgent agent)
        {
            db[agent.Login] = agent;
        }

        public ProductAgent FindByLogin(string login) => db[login];
    }
}