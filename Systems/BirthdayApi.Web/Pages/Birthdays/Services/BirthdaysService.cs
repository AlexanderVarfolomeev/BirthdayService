using System.Text;
using System.Text.Json;

namespace BirthdayApi.Web
{
    public class BirthdaysService : IBirthdaysService
    {
        private readonly HttpClient client;

        public BirthdaysService(HttpClient client)
        {
            this.client = client;
        }

        public async Task<IEnumerable<BirthdayModel>> GetBirthdays()
        {
            string url = $"{Settings.ApiRoot}/Birthday";

            var response = await client.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(content);
            }

            var data = JsonSerializer.Deserialize<IEnumerable<BirthdayModel>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? new List<BirthdayModel>();

            return data;
        }

        public async Task<BirthdayModel> GetBirthday(int id)
        {
            string url = $"{Settings.ApiRoot}/Birthday/{id}";

            var response = await client.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(content);
            }

            var data = JsonSerializer.Deserialize<BirthdayModel>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? new BirthdayModel();

            return data;
        }

        public async Task AddBirthday(BirthdayModel model)
        {
            string url = $"{Settings.ApiRoot}/Birthday";

            
            var body = JsonSerializer.Serialize(model);
            var request = new StringContent(body, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(url, request);

            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(content);
            }
        }

        public async Task EditBirthday(int id, BirthdayModel model)
        {
            string url = $"{Settings.ApiRoot}/Birthday/{id}";

            var body = JsonSerializer.Serialize(model);
            var request = new StringContent(body, Encoding.UTF8, "application/json");

            var response = await client.PutAsync(url, request);

            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(content);
            }
        }

        public async Task DeleteBirthday(int id)
        {
            string url = $"{Settings.ApiRoot}/Birthday/{id}";

            var response = await client.DeleteAsync(url);
            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(content);
            }
        }

        public async Task<IEnumerable<BirthdayModel>> GetBirthdaysToday()
        {
            /* http://localhost:5118/api/Birthday */
            string url = $"{Settings.ApiRoot}/Birthday/get-today";

            var response = await client.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(content);
            }

            var data = JsonSerializer.Deserialize<IEnumerable<BirthdayModel>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? new List<BirthdayModel>();

            return data;
        }

        public async Task<IEnumerable<BirthdayModel>> GetBirthdaysForPeriod(string start, string end)
        {
            string url = $"{Settings.ApiRoot}/Birthday/get-for-period:{start}-{end}";

            var response = await client.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(content);
            }

            var data = JsonSerializer.Deserialize<IEnumerable<BirthdayModel>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? new List<BirthdayModel>();

            return data;
        }
    }
}
