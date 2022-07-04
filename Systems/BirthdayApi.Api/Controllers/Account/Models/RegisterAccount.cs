using AutoMapper;
using BirthdayApi.AccountService.Models;

namespace BirthdayApi.Api.Controllers.Account.Models;

public class RegisterAccount
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}

public class RegisterAccountProfile : Profile
{
    public RegisterAccountProfile()
    {
        CreateMap<RegisterAccount, RegisterAccountModel>();
    }
}
