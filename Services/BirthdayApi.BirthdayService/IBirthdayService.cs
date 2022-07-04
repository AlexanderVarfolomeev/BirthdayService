using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthdayApi.BirthdayService
{
    public interface IBirthdayService
    {
        Task<IEnumerable<BirthdayModel>> GetBirthdays();
        Task<IEnumerable<BirthdayModel>> GetBirthdaysToday();
        Task<IEnumerable<BirthdayModel>> GetBirthdaysForPeriod(string start, string end);
        Task<BirthdayModel> GetBirthdayById(int id);
        Task<BirthdayModel> AddBirthday(AddBirthdayModel addBirthdayModel);
        Task UpdateBirthday(int id, UpdateBirthdayModel updateBirthdayModel);
        Task DeleteBithday(int id);
    }
}
