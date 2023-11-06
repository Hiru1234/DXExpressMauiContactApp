namespace DXMauiContactApp.Views;

using DXMauiContactApp.Models;
using DXMauiContactApp.ViewModels;

public partial class EditContactPage : ContentPage
{
    private string contact_Id;

    public EditContactPage(string contactId)
    {
        contact_Id = contactId;
        ContactPerson contact = ContactPersonViewModel.GetContactById(contact_Id);
        if (contact != null)
        {
            ContactPersonViewModel.person = contact;
        }
        else
        {
            ContactPersonViewModel.person = new();
        }
        InitializeComponent();
    }

    private async void updateContact_Clicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(firstNameEntry.Text))
        {
            await DisplayAlert("Error", "First Name is Required", "Ok");
            return;
        }
        if (string.IsNullOrWhiteSpace(lastNameEntry.Text))
        {
            await DisplayAlert("Error", "Last Name is Required", "Ok");
            return;
        }
        if (string.IsNullOrWhiteSpace(phoneEntry.Text))
        {
            await DisplayAlert("Error", "Phone number is Required", "Ok");
            return;
        }
        await Navigation.PopAsync();
        ContactPersonViewModel.person = new();
    }

    private async void cancelContact_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

    private async void deleteButton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
        ContactPersonViewModel.person = new();
    }
}