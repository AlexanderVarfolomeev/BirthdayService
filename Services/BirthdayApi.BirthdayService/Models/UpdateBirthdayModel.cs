using BirthdayApi.Domain;
using AutoMapper;
using FluentValidation;

namespace BirthdayApi.BirthdayService
{
    public class UpdateBirthdayModel
    {
        public string Name { get; set; }
        public string BirthdayDate { get; set; }
        public string Description { get; set; }
    }

    public class UpdateBirthdayModelValidator : AbstractValidator<UpdateBirthdayModel>
    {
        public UpdateBirthdayModelValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.");
            RuleFor(x => x.BirthdayDate)
                .NotEmpty().WithMessage("Date is required.");
            RuleFor(x => x.BirthdayDate)
                .Matches(@"\d{2}[.]\d{2}").WithMessage("The date must be entered in the format (dd-mm)");

            RuleFor(x => int.Parse(x.BirthdayDate.Split(new char[] { '.' })[0]))
                .InclusiveBetween(1, 31)
                .WithMessage("Day must include in 1-31");

            RuleFor(x => int.Parse(x.BirthdayDate.Split(new char[] { '.' })[1]))
               .InclusiveBetween(1, 12)
               .WithMessage("Day must include in 1-12");
        }
    }

    public class UpdateBirthdayModelProfile : Profile
    {
        public UpdateBirthdayModelProfile()
        {
            CreateMap<UpdateBirthdayModel, Birthday>()
                .ForPath(d => d.Time.Month, a => a.MapFrom(s => int.Parse(s.BirthdayDate.Split(new char[] { '.' })[1])))
                .ForPath(d => d.Time.Day, a => a.MapFrom(s => int.Parse(s.BirthdayDate.Split(new char[] { '.' })[0])));
        }
    }
}
