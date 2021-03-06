using System.Net.Http.Headers;
using System.Text.Json;
using System.Text.Json.Serialization;
using BirthdayApi.AccountService.Models;
using BirthdayApi.RabbitMqService;
using BirthdayApi.RabbitMQService;
using Microsoft.AspNetCore.Identity;

namespace BirthdayApi.AccountService;

public class AccountService : IAccountService
{
    private readonly UserManager<IdentityUser<Guid>> userManager;
    private readonly SignInManager<IdentityUser<Guid>> sgInManager;
    private readonly IRabbitMqTask rabbitMqTask;

    public AccountService(UserManager<IdentityUser<Guid>> userManager, SignInManager<IdentityUser<Guid>> sgInManager, IRabbitMqTask rabbitMqTask)
    {
        this.userManager = userManager;
        this.sgInManager = sgInManager;
        this.rabbitMqTask = rabbitMqTask;
    }


    public async Task RegisterAccount(RegisterAccountModel model)
    {
        var user = await userManager.FindByEmailAsync(model.Email);
        if (user != null)
            throw new Exception(""); // исправить на новое исключение

        user = new IdentityUser<Guid>()
        {
            UserName = model.Email,
            Email = model.Email,
            EmailConfirmed = true,
            PhoneNumber = null,
            PhoneNumberConfirmed = false
        };


        await rabbitMqTask.SendEmail(new EmailModel()
        {
            Email = model.Email,
            Subject = "BirthdayService",
            Message = "Your account was registered successful"
        });

        var result = await userManager.CreateAsync(user, model.Password);
        //добавить исключение и тд
    }

    //public async Task<bool> Login(AccountModel model)
    //{
    //    var user = await userManager.FindByEmailAsync(model.Email);
    //    if (user == null)
    //        throw new NotImplementedException();
    //    var result = await sgInManager.PasswordSignInAsync(model.Email, model.Password, false, false);
    //    return result.Succeeded;

    //}

}

