using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KB.Infrastructure.Authentication
{
    public interface IClientStore
    {
        Client Find(string clientId);
    }
}
