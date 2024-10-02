namespace SSUI.Service.Implementation.EmployeeManagement
{
    public class EmployeeService : IEmployee
    {
        private readonly HttpClient client;
        private readonly ILogger<EmployeeService> logger;

        public EmployeeService(HttpClient client, ILogger<EmployeeService> logger)
        {
            this.client = client;
            this.logger = logger;
        }

        public async Task<vmEmployee?> EditEmployee(string Id)
        {
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Get, $"getEmployee/{Id}");

                var response = await client.SendAsync(request);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var stringContent = await response.Content.ReadAsStringAsync();
                    var entities = JsonConvert.DeserializeObject<vmEmployee>(stringContent);
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
        public async Task<List<vmEmployee>?> ListEmployees()
        {
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Get, "getemployees");

                var response = await client.SendAsync(request);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var stringContent = await response.Content.ReadAsStringAsync();
                    var entities = JsonConvert.DeserializeObject<List<vmEmployee>>(stringContent);
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
        public async Task<vmEmployee?> ModifyEmployee(vmEmployee UserInput)
        {
            try
            {
                HttpRequestMessage request;

                if (UserInput.Id == "00000000-0000-0000-0000-000000000000")
                {
                    request = new HttpRequestMessage(HttpMethod.Post, "addEmployee");

                }
                else
                {
                    request = new HttpRequestMessage(HttpMethod.Post, "updateEmployee");
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
        public async Task<bool?> RemoveEmployee(string Id)
        {
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Delete, $"deleteEmployee/{Id}");

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
