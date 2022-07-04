namespace BirthdayApi.Web
{
    public interface IBirthdaysService
    {
        Task<IEnumerable<BirthdayModel>> GetBirthdays();
        Task<IEnumerable<BirthdayModel>> GetBirthdaysToday();
        Task<IEnumerable<BirthdayModel>> GetBirthdaysForPeriod(string start, string end);
        Task<BirthdayModel> GetBirthday(int id);
        Task AddBirthday(BirthdayModel model);
        Task EditBirthday(int id, BirthdayModel model);
        Task DeleteBirthday(int id);
    }
}
