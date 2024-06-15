using SSUI.Services.Interface.EmployeeManagement.Master;

namespace SSUI.Services.Implementation.EmployeeManagement.Master
{
    public class DepartmentService : IDepartment
    {

        private readonly HttpClient client;
        private readonly ILogger<DepartmentService> logger;
        public DepartmentService(HttpClient _client, ILogger<DepartmentService> log)
        {
            client = _client;
            logger = log;
        }
        public async Task<List<vmMasterData>?> ListDepartments()
        {
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Get, "getdepartments");
                //var stringUser = JsonConvert.SerializeObject(user);
                //request.Content = new StringContent(stringUser);
                //request.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

                //this response returning bad request.....
                var response = await client.SendAsync(request);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var stringContent = await response.Content.ReadAsStringAsync();
                    var departments = JsonConvert.DeserializeObject<List<vmMasterData>>(stringContent);
                    //departments = await client.GetFromJsonAsync<List<vmMasterData>>("api/department/getdepartments");
                    return departments;
                }

                return null;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                return null;
            }
        }
        public async Task<vmMasterData?> AddDepartment(vmMasterData UserInput)
        {
            throw new NotImplementedException();
            //try
            //{
            //    var request = new HttpRequestMessage(HttpMethod.Post, "validateuser");
            //    var stringUser = JsonConvert.SerializeObject(user);
            //    request.Content = new StringContent(stringUser);
            //    request.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            //    //this response returning bad request.....
            //    var response = await client.SendAsync(request);

            //    if (response.StatusCode == System.Net.HttpStatusCode.OK)
            //    {
            //        var stringContent = await response.Content.ReadAsStringAsync();
            //        var oUser = JsonConvert.DeserializeObject<vmMasterData>(stringContent);

            //        return oUser;
            //    }

            //    return null;
            //}
            //catch (Exception ex)
            //{
            //    logger.LogError(ex, ex.Message);
            //    return null;
            //}
        }
    }
}
