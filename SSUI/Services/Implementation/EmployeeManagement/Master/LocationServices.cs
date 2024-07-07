using SharedLibrary.Model.OrganizationManagement;
using SSUI.Services.Interface;

namespace SSUI.Services.Implementation.EmployeeManagement.Master
{
    public class LocationServices : ILocation, IDropdownCompany, IDropdownUnit
    {
        private readonly HttpClient client;
        private readonly ILogger<LocationServices> logger;

        public LocationServices(HttpClient client, ILogger<LocationServices> logger)
        {
            this.client = client;
            this.logger = logger;
        }

        public async Task<vmMasterDataDD?> EditLocation(string Id)
        {
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Get, $"getlocation/{Id}");

                var response = await client.SendAsync(request);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var stringContent = await response.Content.ReadAsStringAsync();
                    var entities = JsonConvert.DeserializeObject<vmMasterDataDD>(stringContent);
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
        public async Task<List<vmMasterDataDD>?> ListLocations()
        {
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Get, "getlocations");

                var response = await client.SendAsync(request);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var stringContent = await response.Content.ReadAsStringAsync();
                    var entities = JsonConvert.DeserializeObject<List<vmMasterDataDD>>(stringContent);
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
        public async Task<vmMasterDataDD?> ModifyLocation(vmMasterDataDD UserInput)
        {
            try
            {
                HttpRequestMessage request;

                if (UserInput.Id == "00000000-0000-0000-0000-000000000000")
                {
                    request = new HttpRequestMessage(HttpMethod.Post, "addlocation");

                }
                else
                {
                    request = new HttpRequestMessage(HttpMethod.Post, "updatelocation");
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
        public async Task<bool?> RemoveLocation(string Id)
        {
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Delete, $"deletelocation/{Id}");

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
        public async Task<List<MstUnit>?> ListUnits()
        {
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Get, "getunits");

                var response = await client.SendAsync(request);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var stringContent = await response.Content.ReadAsStringAsync();
                    var entities = JsonConvert.DeserializeObject<List<MstUnit>>(stringContent);
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
