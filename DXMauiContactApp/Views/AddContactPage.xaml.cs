//using AndroidX.Lifecycle;
using DevExpress.Maui.Core;
using DXMauiContactApp.Models;
using DXMauiContactApp.ViewModels;
using System.Net.Mail;

namespace DXMauiContactApp.Views;

public partial class AddContactPage : ContentPage
{

    public AddContactPage()
    {
        ContactPersonViewModel.person = new();
        InitializeComponent();
    }

    private async void createNewContact_Clicked(object sender, EventArgs e)
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
}