using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KB.Infrastructure.Authentication
{
    public class TestRefreshTokenStore : IRefreshTokenStore
    {
        private static List<RefreshToken> RefreshTokens = new List<RefreshToken>();

        public void Add(RefreshToken refreshToken)
        {
            RefreshTokens.Add(refreshToken);
        }

        public RefreshToken Find(string refreshTokenId)
        {
            return RefreshTokens.FirstOrDefault(t => t.Id == refreshTokenId);
        }

        public void Delete(string refreshTokenId)
        {
            RefreshTokens.RemoveAll(t => t.Id == refreshTokenId);
        }
    }
}