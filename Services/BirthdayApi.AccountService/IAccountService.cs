using BirthdayApi.AccountService.Models;

namespace BirthdayApi.AccountService;

public interface IAccountService
{
    Task RegisterAccount(RegisterAccountModel model);
    Task<bool> Login(AccountModel model);
}