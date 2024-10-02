using SharedLibrary.Model.OrganizationManagement;
using SSUI.Services.Interface;

namespace SSUI.Services.Implementation.Administration
{
    public class UnitServices : IUnit, IDropdownCompany
    {
        private readonly HttpClient client;
        private readonly ILogger<UnitServices> logger;

        public UnitServices(HttpClient client, ILogger<UnitServices> logger)
        {
            this.client = client;
            this.logger = logger;
        }

        public async Task<vmUnit?> EditUnit(string Id)
        {
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Get, $"getunit/{Id}");

                var response = await client.SendAsync(request);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var stringContent = await response.Content.ReadAsStringAsync();
                    var entities = JsonConvert.DeserializeObject<vmUnit>(stringContent);
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
        public async Task<List<vmUnit>?> ListUnits()
        {
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Get, "getunits");

                var response = await client.SendAsync(request);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var stringContent = await response.Content.ReadAsStringAsync();
                    var entities = JsonConvert.DeserializeObject<List<vmUnit>>(stringContent);
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
        public async Task<vmUnit?> ModifyUnit(vmUnit UserInput)
        {
            try
            {
                HttpRequestMessage request;

                if (UserInput.Id == "00000000-0000-0000-0000-000000000000")
                {
                    request = new HttpRequestMessage(HttpMethod.Post, "addunit");

                }
                else
                {
                    request = new HttpRequestMessage(HttpMethod.Post, "updateunit");
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
        public async Task<bool?> RemoveUnit(string Id)
        {
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Delete, $"deleteunit/{Id}");

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
        public async Task<List<MstCompany>?> ListCompanies()
        {
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Get, "getcompanies");

                var response = await client.SendAsync(request);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var stringContent = await response.Content.ReadAsStringAsync();
                    var entities = JsonConvert.DeserializeObject<List<MstCompany>>(stringContent);
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
