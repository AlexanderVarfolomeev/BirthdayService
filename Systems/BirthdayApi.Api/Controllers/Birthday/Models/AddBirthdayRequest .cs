using AutoMapper;
using BirthdayApi.BirthdayService;
using FluentValidation;

namespace BirthdayApi.Api.Controllers
{
    public class AddBirthdayRequest
    {
        public string Name { get; set; }
        public string BirthdayDate { get; set; }
        public string Description { get; set; }
        
    }

    public class AddBirthdayRequestValidator : AbstractValidator<AddBirthdayRequest>
    {
        public AddBirthdayRequestValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.");
            RuleFor(x => x.BirthdayDate)
                .NotEmpty().WithMessage("Date is required.");
            RuleFor(x => x.BirthdayDate)
                .Matches(@"\d{2}[.]\d{2}").WithMessage("The date must be entered in the format (dd-mm)");

            RuleFor(x =>int.Parse(x.BirthdayDate.Split(new char[] { '.' })[0]))
                .InclusiveBetween(1, 31)
                .WithMessage("Day must include in 1-31");
            
            RuleFor(x => int.Parse(x.BirthdayDate.Split(new char[] { '.' })[1]))
               .InclusiveBetween(1, 12)
               .WithMessage("Day must include in 1-12");
        }
    }

    public class AddBirthdayRequestProfile : Profile
    {
        public AddBirthdayRequestProfile()
        {
            CreateMap<AddBirthdayRequest, AddBirthdayModel>();
        }
    }

}
