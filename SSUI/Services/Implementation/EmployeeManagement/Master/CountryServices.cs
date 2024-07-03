using SSUI.Services.Interface.EmployeeManagement.Master;

namespace SSUI.Services.Implementation.EmployeeManagement.Master
{
    public class CountryServices : ICountry
    {
        private readonly HttpClient client;
        private readonly ILogger<DepartmentService> logger;

        public CountryServices(HttpClient client, ILogger<DepartmentService> logger)
        {
            this.client = client;
            this.logger = logger;
        }

        public async Task<vmMasterData?> EditCountry(string Id)
        {
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Get, $"getcountry/{Id}");

                var response = await client.SendAsync(request);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var stringContent = await response.Content.ReadAsStringAsync();
                    var departments = JsonConvert.DeserializeObject<vmMasterData>(stringContent);
                    return departments;
                }

                return null;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                return null;
            }
        }


        public async Task<List<vmMasterData>?> ListCountries()
        {
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Get, "getcountries");

                var response = await client.SendAsync(request);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var stringContent = await response.Content.ReadAsStringAsync();
                    var departments = JsonConvert.DeserializeObject<List<vmMasterData>>(stringContent);
                    return departments;
                }

                return null;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                return null;
            }
        }
        public async Task<vmMasterData?> ModifyCountry(vmMasterData UserInput)
        {
            try
            {
                HttpRequestMessage request;

                if (UserInput.Id == "00000000-0000-0000-0000-000000000000")
                {
                    request = new HttpRequestMessage(HttpMethod.Post, "addcountry");

                }
                else
                {
                    request = new HttpRequestMessage(HttpMethod.Post, "updatecountry");
                }

                var stringUser = JsonConvert.SerializeObject(UserInput);
                request.Content = new StringContent(stringUser);
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

        public async Task<bool?> RemoveCountry(string Id)
        {
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Delete, $"deletecountry/{Id}");

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

    }
}

