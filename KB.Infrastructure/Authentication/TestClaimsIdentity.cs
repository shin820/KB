using KB.Infrastructure.Runtime.Security;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace KB.Infrastructure.Authentication
{
    public static class TestClaimsIdentity
    {
        public static ClaimsIdentity Create()
        {
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(DefaultAuthenticationTypes.ApplicationCookie, ClaimTypes.NameIdentifier, ClaimTypes.Role);

            claimsIdentity.AddClaim(new Claim(ClaimTypes.NameIdentifier, "1"));
            claimsIdentity.AddClaim(new Claim(ClaimTypes.Name, "test"));
            claimsIdentity.AddClaim(new Claim(ClaimTypes.Email, "abc@123.com"));
            claimsIdentity.AddClaim(new Claim(ClaimTypes.Role, "admin"));
            claimsIdentity.AddClaim(new Claim(Comm100ClaimTypes.SideId, "10000"));
            claimsIdentity.AddClaim(new Claim(Comm100ClaimTypes.Permission, "get_me"));
            claimsIdentity.AddClaim(new Claim(Comm100ClaimTypes.Permission, "create_article"));

            return claimsIdentity;
        }
    }
}