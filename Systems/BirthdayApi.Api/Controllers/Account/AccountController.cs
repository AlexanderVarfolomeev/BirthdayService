    using AutoMapper;
using BirthdayApi.AccountService;
using BirthdayApi.AccountService.Models;
using BirthdayApi.Api.Controllers.Account.Models;
using Microsoft.AspNetCore.Mvc;

namespace BirthdayApi.Api.Controllers.Account
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : Controller
    {
        private readonly IAccountService accountService;
        private readonly IMapper mapper;

        public AccountController(IAccountService accountService, IMapper mapper)
        {
            this.accountService = accountService;
            this.mapper = mapper;
        }

        [HttpPost("Register")]
        public async Task Register([FromBody] RegisterAccount model)
        {
            var user = mapper.Map<RegisterAccountModel>(model);
            await accountService.RegisterAccount(user);
        }

    }
}
