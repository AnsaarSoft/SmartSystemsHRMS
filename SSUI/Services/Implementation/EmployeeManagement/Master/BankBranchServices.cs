using SharedLibrary.Model.EmployeeManagement.Master;
using SharedLibrary.Model.OrganizationManagement;
using SSUI.Services.Interface;

namespace SSUI.Services.Implementation.EmployeeManagement.Master
{
    public class BankBranchServices : IBankBranch, IDropdownCompany, IDropdownUnit, IDropdownBank
    {
        private readonly HttpClient client;
        private readonly ILogger<BankBranchServices> logger;

        public BankBranchServices(HttpClient client, ILogger<BankBranchServices> logger)
        {
            this.client = client;
            this.logger = logger;
        }

        public async Task<vmBankBranch?> EditBankBranch(string Id)
        {
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Get, $"getbankbranch/{Id}");

                var response = await client.SendAsync(request);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var stringContent = await response.Content.ReadAsStringAsync();
                    var entities = JsonConvert.DeserializeObject<vmBankBranch>(stringContent);
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
        public async Task<List<vmBankBranch>?> ListBankBranches()
        {
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Get, "getbankbranches");

                var response = await client.SendAsync(request);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var stringContent = await response.Content.ReadAsStringAsync();
                    var entities = JsonConvert.DeserializeObject<List<vmBankBranch>>(stringContent);
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
        public async Task<vmBankBranch?> ModifyBankBranch(vmBankBranch UserInput)
        {
            try
            {
                HttpRequestMessage request;

                if (UserInput.Id == "00000000-0000-0000-0000-000000000000")
                {
                    request = new HttpRequestMessage(HttpMethod.Post, "addbankbranch");

                }
                else
                {
                    request = new HttpRequestMessage(HttpMethod.Post, "updatebankbranch");
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
        public async Task<bool?> RemoveBankBranch(string Id)
        {
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Delete, $"deletebankbranch/{Id}");

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
        public async Task<List<MstBank>?> ListBanks()
        {
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Get, "getbanks");

                var response = await client.SendAsync(request);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var stringContent = await response.Content.ReadAsStringAsync();
                    var entities = JsonConvert.DeserializeObject<List<MstBank>>(stringContent);
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
