namespace BirthdayApi.Identity;

using BirthdayApi.Context;
using BirthdayApi.Domain;
using Microsoft.AspNetCore.Identity;
using BirthdayApi.Settings;
using Microsoft.Extensions.DependencyInjection;
using Duende.IdentityServer.Models;
public static class AppIdentityResources
{
    public static IEnumerable<IdentityResource> Resources => new List<IdentityResource>
    {
        new IdentityResources.OpenId(),
        new IdentityResources.Profile()
    };
}
