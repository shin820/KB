using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KB.Infrastructure.Authentication
{
    public interface IRefreshTokenStore
    {
        void Add(RefreshToken refreshToken);
        void Delete(string refreshTokenId);
        RefreshToken Find(string refreshTokenId);
    }
}
