using SharedLibrary.Model.EmployeeManagement.Master;
using SSUI.Services.Interface;

namespace SSUI.Services.Implementation.EmployeeManagement.Master
{
    public class CityServices : ICity, IDropdownCountry
    {
        private readonly HttpClient client;
        private readonly ILogger<CityServices> logger;

        public CityServices(HttpClient client, ILogger<CityServices> logger)
        {
            this.client = client;
            this.logger = logger;
        }

        public async Task<vmCity?> EditCity(string Id)
        {
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Get, $"getcity/{Id}");

                var response = await client.SendAsync(request);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var stringContent = await response.Content.ReadAsStringAsync();
                    var entities = JsonConvert.DeserializeObject<vmCity>(stringContent);
                    return entities;
                }

                return null;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                return null;
            }
        }
        public async Task<List<vmCity>?> ListCities()
        {
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Get, "getcities");

                var response = await client.SendAsync(request);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var stringContent = await response.Content.ReadAsStringAsync();
                    var entities = JsonConvert.DeserializeObject<List<vmCity>>(stringContent);
                    return entities;
                }

                return null;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                return null;
            }
        }
        public async Task<vmCity?> ModifyCity(vmCity UserInput)
        {
            try
            {
                HttpRequestMessage request;

                if (UserInput.Id == "00000000-0000-0000-0000-000000000000")
                {
                    request = new HttpRequestMessage(HttpMethod.Post, "addcity");

                }
                else
                {
                    request = new HttpRequestMessage(HttpMethod.Post, "updatecity");
                }

                var stringContent = JsonConvert.SerializeObject(UserInput);
                request.Content = new StringContent(stringContent);
                request.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

                var response = await client.SendAsync(request);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return UserInput;
                }

                return null;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                return null;
            }
        }
        public async Task<bool?> RemoveCity(string Id)
        {
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Delete, $"deletecity/{Id}");

                var response = await client.SendAsync(request);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return true;
                }

                return null;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                return null;
            }
        }
        public async Task<List<MstCountry>?> ListCountries()
        {
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Get, "getcountries");

                var response = await client.SendAsync(request);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var stringContent = await response.Content.ReadAsStringAsync();
                    var entities = JsonConvert.DeserializeObject<List<MstCountry>>(stringContent);
                    return entities;
                }

                return null;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                return null;
            }
        }

    }
}
