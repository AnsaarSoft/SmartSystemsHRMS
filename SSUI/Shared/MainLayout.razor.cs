
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

namespace SSUI.Shared
{
    public partial class MainLayout
    {
        #region Variable

        bool DrawerToggle = true;
        
        bool PageLoad = false;

        #endregion

        #region Dependency
        [Inject] ILogger<MainLayout> logger { get; set; }
        //[Inject] AuthenticationStateProvider auth {  get; set; }
        [Inject] NavigationManager navigation { get; set; }
        [Inject] ProtectedLocalStorage storage { get; set; }
        #endregion

        #region Function

        
        protected async override Task OnInitializedAsync()
        {
            await Task.Delay(3000);
            try
            {
                //var status = await auth.GetAuthenticationStateAsync();
                //if (status.User.Identity.IsAuthenticated)
                //{
                //    //navigation.NavigateTo("/dashboard");
                //}
                //else
                //{
                //    //navigation.NavigateTo("/login");
                //}
                //navigation.NavigateTo("/login");
                var loginUser = await storage.GetAsync<string>("userinfo");
                if(!loginUser.Success)
                {
                    PageLoad = true;
                    navigation.NavigateTo("/login");
                }
                else 
                {
                    PageLoad = true;
                }

            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
            }
        }

        void DrawerToggler()
        {
            DrawerToggle = !DrawerToggle;
        }


        #endregion
    }
}
