using SSUI.Services.Interface;

namespace SSUI.Services.Implementation.EmployeeManagement
{
    public class EmpAttachmentService : IEmpAttachment, IDropdownEmployee
    {
        private readonly HttpClient client;
        private readonly ILogger<EmpAttachmentService> logger;

        public EmpAttachmentService(HttpClient client, ILogger<EmpAttachmentService> logger)
        {
            this.client = client;
            this.logger = logger;
        }

        public async Task<vmEmpAttachment?> EditEmpAttachment(string Id)
        {
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Get, $"getempattachment/{Id}");

                var response = await client.SendAsync(request);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var stringContent = await response.Content.ReadAsStringAsync();
                    var entities = JsonConvert.DeserializeObject<vmEmpAttachment>(stringContent);
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
        public async Task<List<vmEmpAttachment>?> ListEmpAttachments()
        {
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Get, "getempattachments");

                var response = await client.SendAsync(request);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var stringContent = await response.Content.ReadAsStringAsync();
                    var entities = JsonConvert.DeserializeObject<List<vmEmpAttachment>>(stringContent);

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
        public async Task<vmEmpAttachment?> ModifyEmpAttachment(vmEmpAttachment UserInput)
        {
            try
            {
                HttpRequestMessage request;

                if (UserInput.Id == "00000000-0000-0000-0000-000000000000")
                {
                    request = new HttpRequestMessage(HttpMethod.Post, "addempattachment");

                }
                else
                {
                    request = new HttpRequestMessage(HttpMethod.Post, "updateempattachment");
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
        public async Task<bool?> RemoveEmpAttachment(string Id)
        {
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Delete, $"deleteempattachment/{Id}");

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
