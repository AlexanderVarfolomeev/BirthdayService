using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BirthdayApi.Common;
using BirthdayApi.Context;
using BirthdayApi.Domain;
using Microsoft.EntityFrameworkCore;

namespace BirthdayApi.BirthdayService
{
    internal class BirthdayService : IBirthdayService
    {
        private readonly IDbContextFactory<MainDbContext> contextFactory;
        private readonly IMapper mapper;
        private readonly IModelValidator<AddBirthdayModel> addModelValidator;
        private readonly IModelValidator<UpdateBirthdayModel> updateModelValidator;

        public BirthdayService(
            IDbContextFactory<MainDbContext> context,
            IMapper mapper,
            IModelValidator<AddBirthdayModel> addModelValidator,
            IModelValidator<UpdateBirthdayModel> updateModelValidator)
        {
            contextFactory = context;
            this.mapper = mapper;
            this.addModelValidator = addModelValidator;
            this.updateModelValidator = updateModelValidator;
        }

        public async Task<IEnumerable<BirthdayModel>> GetBirthdays()
        {
            using var context = await contextFactory.CreateDbContextAsync();
            var birthdays = context.Birthdays
                .Include(x => x.Time)
                .AsQueryable();
            var data = (await birthdays.ToListAsync()).Select(x => mapper.Map<BirthdayModel>(x));

            return data;
        }

        public async Task<BirthdayModel> GetBirthdayById(int id)
        {
            using var context = await contextFactory.CreateDbContextAsync();
            var birthday = await context.Birthdays
                .Include(x => x.Time)
                .FirstOrDefaultAsync(x => x.Id == id);
            var data = mapper.Map<BirthdayModel>(birthday);

            return data;
        }

        public async Task<BirthdayModel> AddBirthday(AddBirthdayModel addBirthdayModel)
        {
            addModelValidator.Check(addBirthdayModel);
            using var context = await contextFactory.CreateDbContextAsync();
            var model = mapper.Map<Birthday>(addBirthdayModel);
            await context.AddAsync(model);
            await context.SaveChangesAsync();
            return mapper.Map<BirthdayModel>(model);
        }

        public async Task UpdateBirthday(int id, UpdateBirthdayModel updateBirthdayModel)
        {
            updateModelValidator.Check(updateBirthdayModel);
            using var context = await contextFactory.CreateDbContextAsync();

            var birthday = await context.Birthdays
                .Include(x => x.Time)
                .FirstOrDefaultAsync(x => x.Id == id);

            birthday = mapper.Map(updateBirthdayModel, birthday);

            context.Birthdays.Update(birthday);
            await context.SaveChangesAsync();

        }

        public async Task DeleteBithday(int id)
        {
            using var context = await contextFactory.CreateDbContextAsync();

            var birthday = await context.Birthdays
                .Include(x => x.Time)
                .FirstOrDefaultAsync(x => x.Id == id);

            context.Birthdays.Remove(birthday);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<BirthdayModel>> GetBirthdaysForPeriod(string start, string end)
        {
            var first = start.Split(".");
            var second = end.Split(".");

            BirthdayDate firstDate = new BirthdayDate() { Day = int.Parse(first[0]), Month = int.Parse(first[1]) };
            BirthdayDate secondDate = new BirthdayDate() { Day = int.Parse(second[0]), Month = int.Parse(second[1]) };

            using var context = await contextFactory.CreateDbContextAsync();
            var birthdays = context.Birthdays
                .Include(x => x.Time)
                .AsQueryable();

            var result = new List<Birthday>();
            foreach (var item in birthdays)
            {
                if ((item.Time.Month == firstDate.Month && item.Time.Day >= firstDate.Day)
                    || (item.Time.Month == secondDate.Month && item.Time.Day <= secondDate.Day))
                    result.Add(item);
            }
            birthdays = birthdays.Where(x => x.Time.Month > firstDate.Month && x.Time.Month < secondDate.Month);
            foreach (var item in birthdays)
            {
                result.Add(item);
            }
            var data = result.Select(x => mapper.Map<BirthdayModel>(x));


            return data;
        }

        public async Task<IEnumerable<BirthdayModel>> GetBirthdaysToday()
        {

            BirthdayDate Date = new BirthdayDate() { Day = DateTime.Today.Day, Month = DateTime.Today.Month };

            using var context = await contextFactory.CreateDbContextAsync();
            var birthdays = context.Birthdays
                .Include(x => x.Time)
                .AsQueryable();

            birthdays = birthdays.Where(x => x.Time.Day == Date.Day && x.Time.Month == Date.Month);

            var data = (await birthdays.ToListAsync()).Select(x => mapper.Map<BirthdayModel>(x));


            return data;
        }
    }
}
