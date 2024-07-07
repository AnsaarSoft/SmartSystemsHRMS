using SharedLibrary.Model.OrganizationManagement;
using SSUI.Services.Interface;

namespace SSUI.Services.Implementation.EmployeeManagement.Master
{
    public class GradeServices : IGrade, IDropdownCompany, IDropdownUnit
    {
        private readonly HttpClient client;
        private readonly ILogger<GradeServices> logger;

        public GradeServices(HttpClient client, ILogger<GradeServices> logger)
        {
            this.client = client;
            this.logger = logger;
        }

        public async Task<vmMasterDataDD?> EditGrade(string Id)
        {
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Get, $"getgrade/{Id}");

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
        public async Task<List<vmMasterDataDD>?> ListGrades()
        {
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Get, "getgrades");

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
        public async Task<vmMasterDataDD?> ModifyGrade(vmMasterDataDD UserInput)
        {
            try
            {
                HttpRequestMessage request;

                if (UserInput.Id == "00000000-0000-0000-0000-000000000000")
                {
                    request = new HttpRequestMessage(HttpMethod.Post, "addgrade");

                }
                else
                {
                    request = new HttpRequestMessage(HttpMethod.Post, "updategrade");
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
        public async Task<bool?> RemoveGrade(string Id)
        {
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Delete, $"deletegrade/{Id}");

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
