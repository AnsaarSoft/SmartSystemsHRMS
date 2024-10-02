using SSUI.Services.Interface;

namespace SSUI.Services.Implementation.EmployeeManagement
{
    public class EmpExperienceService : IEmpExperience, IDropdownEmployee
    {
        private readonly HttpClient client;
        private readonly ILogger<EmpExperienceService> logger;

        public EmpExperienceService(HttpClient client, ILogger<EmpExperienceService> logger)
        {
            this.client = client;
            this.logger = logger;
        }

        public async Task<vmEmpData?> EditEmpExperience(string Id)
        {
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Get, $"getEmpExperience/{Id}");

                var response = await client.SendAsync(request);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var stringContent = await response.Content.ReadAsStringAsync();
                    var entities = JsonConvert.DeserializeObject<vmEmpData>(stringContent);
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
        public async Task<List<vmEmpData>?> ListEmpExperiences()
        {
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Get, "getEmpExperiences");

                var response = await client.SendAsync(request);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var stringContent = await response.Content.ReadAsStringAsync();
                    var entities = JsonConvert.DeserializeObject<List<vmEmpData>>(stringContent);

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
        public async Task<vmEmpData?> ModifyEmpExperience(vmEmpData UserInput)
        {
            try
            {
                HttpRequestMessage request;

                if (UserInput.Id == "00000000-0000-0000-0000-000000000000")
                {
                    request = new HttpRequestMessage(HttpMethod.Post, "addempexperience");

                }
                else
                {
                    request = new HttpRequestMessage(HttpMethod.Post, "updateempexperience");
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
        public async Task<bool?> RemoveEmpExperience(string Id)
        {
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Delete, $"deleteEmpExperience/{Id}");

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

        public async Task<List<MstEmployee>?> ListEmployees()
        {
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Get, "getemployees");

                var response = await client.SendAsync(request);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var stringContent = await response.Content.ReadAsStringAsync();
                    var entities = JsonConvert.DeserializeObject<List<MstEmployee>>(stringContent);
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
