using AutoMapper;
using BirthdayApi.BirthdayService;
namespace BirthdayApi.Api.Controllers
{
    public class BirthdayResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string BirthdayDate { get; set; }
        public string Description { get; set; }
    }

    public class BirthdayResponseProfile : Profile
    {
        public BirthdayResponseProfile()
        {
            CreateMap<BirthdayModel, BirthdayResponse>();
        }
    }
}
