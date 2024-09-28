using SharedLibrary.Model.EmployeeManagement.Master;
using SSUI.Services.Interface;

namespace SSUI.Services.Implementation.EmployeeManagement
{
    public class EmpDependentService : IEmpDependents, IDropdownEmployee, IListsDropdown
    {
        private readonly HttpClient client;
        private readonly ILogger<EmpDependentService> logger;

        public EmpDependentService(HttpClient client, ILogger<EmpDependentService> logger)
        {
            this.client = client;
            this.logger = logger;
        }

        public async Task<vmEmpData?> EditEmpDependent(string Id)
        {
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Get, $"getempdependent/{Id}");

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
        public async Task<List<vmEmpData>?> ListEmpDependents()
        {
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Get, "getempdependents");

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
        public async Task<vmEmpData?> ModifyEmpDependent(vmEmpData UserInput)
        {
            try
            {
                HttpRequestMessage request;

                if (UserInput.Id == "00000000-0000-0000-0000-000000000000")
                {
                    request = new HttpRequestMessage(HttpMethod.Post, "addempdependent");

                }
                else
                {
                    request = new HttpRequestMessage(HttpMethod.Post, "updateempdependent");
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
        public async Task<bool?> RemoveEmpDependent(string Id)
        {
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Delete, $"deleteempdependent/{Id}");

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
        public async Task<List<MstList>?> ListLists()
        {
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Get, "getlists");

                var response = await client.SendAsync(request);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var stringContent = await response.Content.ReadAsStringAsync();
                    var entities = JsonConvert.DeserializeObject<List<MstList>>(stringContent);
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
