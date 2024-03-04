namespace SSUI.Services.Implementation.EmployeeManagement
{
    public class UserService : IUser
    {
        private readonly HttpClient client;
        private readonly ILogger<UserService> logger;
        public UserService(HttpClient _client, ILogger<UserService> log)
        {
            client = _client;
            logger = log;
        }
        public async Task<vmLogin?> ValidateUser(vmLogin user)
        {
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Post, "validateuser");
                var stringUser = JsonConvert.SerializeObject(user);
                request.Content = new StringContent(stringUser);
                request.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

                var response = await client.SendAsync(request);
                
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var stringContent = await response.Content.ReadAsStringAsync();
                    var oUser = JsonConvert.DeserializeObject<vmLogin>(stringContent);
                    
                    return oUser;
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
