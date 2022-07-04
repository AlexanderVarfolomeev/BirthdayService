namespace BirthdayApi.Web
{
    public class BirthdayModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string BirthdayDate { get; set; }
        public string Description { get; set; } = "";
    }
}
