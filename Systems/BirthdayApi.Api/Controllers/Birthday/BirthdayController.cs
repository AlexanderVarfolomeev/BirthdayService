using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BirthdayApi.Context;
using AutoMapper;
using BirthdayApi.BirthdayService;
using Microsoft.AspNetCore.Authorization;
namespace BirthdayApi.Api.Controllers.Birthday
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BirthdayController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IBirthdayService birthdayService;

        public BirthdayController(IMapper mapper, IBirthdayService birthdayService)
        {
            this.mapper = mapper;
            this.birthdayService = birthdayService;
        }

        [HttpGet]
        public async Task<IEnumerable<BirthdayResponse>> GetBirthdays()
        {
            var data = await birthdayService.GetBirthdays();
            var result = mapper.Map<IEnumerable<BirthdayResponse>>(data);
            return result;
        }

        [HttpGet("{id}")]
        public async Task<BirthdayResponse> GetBirthdayById([FromRoute] int id)
        {
            var data = await birthdayService.GetBirthdayById(id);
            var result = mapper.Map<BirthdayResponse>(data);
            return result;
        }


        [HttpPost("")]
        public async Task<BirthdayResponse> AddBirthday([FromBody] AddBirthdayRequest model)
        {
            var data = mapper.Map<AddBirthdayModel>(model);
            var brth = await birthdayService.AddBirthday(data);
            return mapper.Map<BirthdayResponse>(brth);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBirthday([FromRoute] int id)
        {
            await birthdayService.DeleteBithday(id);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBirthday([FromRoute] int id, [FromBody] UpdateBirthdayRequest birthdayRequest)
        {
            var model = mapper.Map<UpdateBirthdayModel>(birthdayRequest);
            await birthdayService.UpdateBirthday(id, model);
            return Ok();
        }

        [HttpGet("get-for-period:{str}")]
        public async Task<IEnumerable<BirthdayResponse>> GetBirthdaysForPeriod([FromRoute] string str)
        {
            var date = str.Split('-');
            var data = await birthdayService.GetBirthdaysForPeriod(date[0], date[1]);
            var result = mapper.Map<IEnumerable<BirthdayResponse>>(data);
            return result;
        }

        [HttpGet("get-today")]
        public async Task<IEnumerable<BirthdayResponse>> GetBirthdaysToday()
        {
            var data = await birthdayService.GetBirthdaysToday();
            var result = mapper.Map<IEnumerable<BirthdayResponse>>(data);
            return result;
        }
    }
}
