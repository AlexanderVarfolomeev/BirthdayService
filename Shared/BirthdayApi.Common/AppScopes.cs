using Duende.IdentityServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthdayApi.Common
{
    public class AppScopes
    {
        public const string BirthdayRead = "birthday_read";
        public const string BirthdayWrite = "birthday_write";
    }

    public static class IdentityConfig
    {
        public static IEnumerable<ApiScope> ApiScopes =>
            new List<ApiScope>
            {
                new ApiScope("Birthday", "Access to API")
            };

        public static IEnumerable<Client> Clients =>
            new List<Client>
            {
                new Client
                {
                    ClientId = "swagger",
                    AllowedGrantTypes = new List<string>(){ GrantType.ClientCredentials},// GrantType.ClientCredentials,
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },
                    AllowedScopes = {"Birthday"}
                }   
            };
    }

}
