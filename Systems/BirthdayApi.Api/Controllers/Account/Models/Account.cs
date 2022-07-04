using AutoMapper;
using BirthdayApi.AccountService.Models;

namespace BirthdayApi.Api.Controllers.Account.Models;

public class Account
{
    public string Email { get; set; }
    public string Password { get; set; }
}

public class AccountProfile : Profile
{
    public AccountProfile()
    {
        CreateMap<Account, AccountModel>();
    }
}
