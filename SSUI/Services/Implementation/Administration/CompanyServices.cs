namespace SSUI.Services.Implementation.Administration
{
    public class CompanyServices : ICompany
    {
        private readonly HttpClient client;
        private readonly ILogger<CompanyServices> logger;

        public CompanyServices(HttpClient client, ILogger<CompanyServices> logger)
        {
            this.client = client;
            this.logger = logger;
        }

        public async Task<vmCompany?> EditCompany(string Id)
        {
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Get, $"getcompany/{Id}");

                var response = await client.SendAsync(request);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var stringContent = await response.Content.ReadAsStringAsync();
                    var entities = JsonConvert.DeserializeObject<vmCompany>(stringContent);
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
        public async Task<List<vmCompany>?> ListCompanies()
        {
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Get, "getcompanies");

                var response = await client.SendAsync(request);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var stringContent = await response.Content.ReadAsStringAsync();
                    var entities = JsonConvert.DeserializeObject<List<vmCompany>>(stringContent);
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
        public async Task<vmCompany?> ModifyCompany(vmCompany UserInput)
        {
            try
            {
                HttpRequestMessage request;

                if (UserInput.Id == "00000000-0000-0000-0000-000000000000")
                {
                    request = new HttpRequestMessage(HttpMethod.Post, "addcompany");

                }
                else
                {
                    request = new HttpRequestMessage(HttpMethod.Post, "updatecompany");
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
        public async Task<bool?> RemoveCompany(string Id)
        {
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Delete, $"deletecompany/{Id}");

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
