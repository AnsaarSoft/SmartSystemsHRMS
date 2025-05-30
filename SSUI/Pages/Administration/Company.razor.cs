using Microsoft.AspNetCore.Components;

namespace SSUI.Pages.Administration
{
    public partial class Company
    {
        private vmCompany formData = new vmCompany();
        private bool isDeleteDialogVisible = false;
        private string CompanyIdToDelete;
        private string UserSearch = "";
        private vmCompany SelectedEntity;
        private bool isEditMode = false;
        private bool isLoading = false;
        private bool isFormDialogVisible = false;
        private List<vmCompany?> Entities = new List<vmCompany>();

        [Inject]
        public ICompany obj { get; set; }
        public Company() { }
        public Company(ICompany obj)
        {
            this.obj = obj;
        }
        protected override async Task OnInitializedAsync()
        {
            Entities = await obj.ListCompanies();
        }
        private async void HandleSubmit()
        {
            isLoading = true;
            if (string.IsNullOrEmpty(formData.Id))
            {
                formData.Id = "00000000-0000-0000-0000-000000000000";
            }
            var result = await obj.ModifyCompany(formData);
            isLoading = false;
            if (result != null)
            {
                ClearForm();
                Entities = await obj.ListCompanies();
                isFormDialogVisible = false;
                Snackbar.Add(isEditMode ? "Company updated successfully!" : "Company added successfully!", Severity.Success);
                StateHasChanged();
            }
            else
            {
                Snackbar.Add(isEditMode ? "Failed to update company." : "Failed to add company.", Severity.Error);
            }
        }
        private async void EditCompany(string Id)
        {
            var response = await obj.EditCompany(Id);
            if (response != null)
            {
                OpenFormDialog();
                isEditMode = true; // mark as editing mode
                formData.Id = response.Id;
                formData.CompanyName = response.CompanyName;
                formData.flgActive = response.flgActive;
                formData.Region = response.Region;
                formData.Subscription = response.Subscription;
                formData.Email = response.Email;
                formData.Alias = response.Alias;
                await InvokeAsync(StateHasChanged);
            }
        }
        private void ConfirmDelete(string Id)
        {
            CompanyIdToDelete = Id;
            isDeleteDialogVisible = true;
        }
        private async void DeleteCompanyConfirmed()
        {
            isLoading = true;
            isDeleteDialogVisible = false;
            var response = await obj.RemoveCompany(CompanyIdToDelete);
            isLoading = false;
            if (response == true)
            {
                ClearForm();
                var entities = await obj.ListCompanies();
                Entities = entities ?? new List<vmCompany>();
                Snackbar.Add("Company deleted successfully!", Severity.Success);
                StateHasChanged();
            }
            else
            {
                Snackbar.Add("Failed to delete the company.", Severity.Error);
            }
        }
        private void ClearForm()
        {
            formData = new vmCompany();
        }
        private bool SearchFunction(vmCompany element) => Search(element, UserSearch);
        private bool Search(vmCompany element, string searchString)
        {
            if (string.IsNullOrWhiteSpace(searchString))
                return true;
            if (element.CompanyName.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            return false;
        }
        private void OpenFormDialog()
        {
            isEditMode = false;
            ClearForm();
            isFormDialogVisible = true;
        }
        private void CloseFormDialog()
        {
            isFormDialogVisible = false;
        }
    }
}
