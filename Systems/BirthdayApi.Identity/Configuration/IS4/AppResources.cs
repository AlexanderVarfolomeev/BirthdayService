namespace BirthdayApi.Identity;

using BirthdayApi.Context;
using BirthdayApi.Domain;
using Microsoft.AspNetCore.Identity;
using BirthdayApi.Settings;
using Microsoft.Extensions.DependencyInjection;
using Duende.IdentityServer.Models;

public static class AppResources
{
    public static IEnumerable<ApiResource> Resources => new List<ApiResource>
    {
        new ApiResource("api")
    };
}
