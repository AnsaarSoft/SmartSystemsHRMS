using Microsoft.AspNetCore.Components;

namespace SSUI.Shared
{
    public partial class NavBar
    {
        #region Variable


        #endregion

        #region Dependency

        [Inject] ILogger<MainLayout> logger { get; set; }
        [Inject] NavigationManager navigation { get; set; }
        [Inject] ProtectedLocalStorage storage { get; set; }
        #endregion

        #region Functions

        async Task LogoutUser()
        {
            try
            {
                await storage.DeleteAsync("userinfo");
                await storage.DeleteAsync("accesstoken");
                navigation.NavigateTo("login", true);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
            }
        }

        #endregion
    }
}
