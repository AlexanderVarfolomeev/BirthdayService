namespace BirthdayApi.Identity;

using BirthdayApi.Context;
using BirthdayApi.Domain;
using Microsoft.AspNetCore.Identity;
using BirthdayApi.Settings;
using BirthdayApi.Common;
using Microsoft.Extensions.DependencyInjection;
using Duende.IdentityServer.Models;

public static class AppApiScopes
{
    public static IEnumerable<ApiScope> ApiScopes =>
        new List<ApiScope>
        {
            new ApiScope(AppScopes.BirthdayRead, "Access to books API - Read data"),
            new ApiScope(AppScopes.BirthdayWrite, "Access to books API - Write data")
        };
}