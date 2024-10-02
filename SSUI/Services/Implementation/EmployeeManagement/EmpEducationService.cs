using SSUI.Services.Interface;

namespace SSUI.Services.Implementation.EmployeeManagement
{
    public class EmpEducationService : IEmpEducation, IDropdownEmployee
    {
        private readonly HttpClient client;
        private readonly ILogger<EmpEducationService> logger;

        public EmpEducationService(HttpClient client, ILogger<EmpEducationService> logger)
        {
            this.client = client;
            this.logger = logger;
        }

        public async Task<vmEmpData?> EditEmpEducation(string Id)
        {
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Get, $"getempeducation/{Id}");

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
        public async Task<List<vmEmpData>?> ListEmpEducations()
        {
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Get, "getempeducations");

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
        public async Task<vmEmpData?> ModifyEmpEducation(vmEmpData UserInput)
        {
            try
            {
                HttpRequestMessage request;

                if (UserInput.Id == "00000000-0000-0000-0000-000000000000")
                {
                    request = new HttpRequestMessage(HttpMethod.Post, "addempeducation");

                }
                else
                {
                    request = new HttpRequestMessage(HttpMethod.Post, "updateempeducation");
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
        public async Task<bool?> RemoveEmpEducation(string Id)
        {
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Delete, $"deleteempeducation/{Id}");

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
