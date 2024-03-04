
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using SharedLibrary.Model.EmployeeManagement;
using SharedLibrary.ViewModel;

namespace SSUI.Pages.EmployeeManagement
{
    public partial class LoginPage
    {
        #region Variable
        
        bool PageLoad = false;
        MstUser user = new();
        vmLogin model = new();

        #endregion

        #region Dependency
        [Inject] ILogger<LoginPage> logger { get; set; }
        [Inject] IUser oUserService { get; set; }
        [Inject] ISnackbar oToast { get; set; }
        [Inject] NavigationManager oNavigation {  get; set; }
        [Inject] ProtectedLocalStorage oStorage { get; set; }
        #endregion

        #region Functions

        protected async override Task OnInitializedAsync()
        {
            //return base.OnInitializedAsync();
            try
            {
                await Task.Delay(1000);
                PageLoad = true;
            }
            catch (Exception ex) 
            {
                logger.LogError(ex, ex.Message);
            }
        }
        
        private async Task PostSubmit()
        {
            try
            {
                //await Task.Delay(1000);
                
                var oValidatedUser = await oUserService.ValidateUser(model);
                if (oValidatedUser.ValidatedUser is null)
                {
                    oToast.Add("Check your entered credentials", Severity.Error);
                }
                else
                {
                    await oStorage.SetAsync("accesstoken", oValidatedUser.JwtToken);
                    await oStorage.SetAsync("userinfo", oValidatedUser.ValidatedUser);
                    
                }
            }
            catch(Exception ex)
            {
                logger.LogError(ex, ex.Message);
            }
        }

        #endregion
    }
}
