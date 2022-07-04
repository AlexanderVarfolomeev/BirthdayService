using BirthdayApi.Domain;
using AutoMapper;
using BirthdayApi.Domain;
namespace BirthdayApi.BirthdayService
{
    public class BirthdayModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string BirthdayDate { get; set; }
        public string Description { get; set; }
    }

    public class BirthdayModelProfile : Profile
    {
        public BirthdayModelProfile()
        {
            CreateMap<Birthday, BirthdayModel>()
                .ForMember(d => d.BirthdayDate, opt => opt.MapFrom(src => $"{src.Time.Day}.{src.Time.Month}"));
        }
    }
}
