namespace BirthdayApi.Identity;

using BirthdayApi.Context;
using BirthdayApi.Domain;
using Microsoft.AspNetCore.Identity;
using BirthdayApi.Settings;
using BirthdayApi.Common;
using Microsoft.Extensions.DependencyInjection;
using Duende.IdentityServer.Models;
using Duende.IdentityServer.Test;

public static class AppApiTestUsers
{
    public static List<TestUser> ApiUsers =>
        new List<TestUser>
        {
            new TestUser
            {
                SubjectId = "1",
                Username = "alice@tst.com",
                Password = "password"
            },
            new TestUser
            {
                SubjectId = "2",
                Username = "bob@tst.com",
                Password = "password"
            }
        };
}