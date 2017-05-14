using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KB.Infrastructure.Authentication
{
    public class TestClientStore : IClientStore
    {
        private static List<Client> _clients = new List<Client>();

        static TestClientStore()
        {
            //just for testing
            _clients.Add(new Client
            {
                Id = "test_client",
                Secret = "123",
                Name = "Test Client",
                Active = true,
                ApplicationType = ApplicationTypes.JavaScript,
                RefreshTokenLifeTime = 7200,
                AllowedOrigin = "*"
            });
        }

        public Client Find(string clientId)
        {
            return _clients.FirstOrDefault(t => t.Id == clientId && t.Active);
        }

        public Client Find(string clientId, string clientSecret)
        {
            return _clients.FirstOrDefault(t => t.Id == clientId && t.Secret == clientSecret && t.Active);
        }
    }
}
