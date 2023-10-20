using DevExpress.Maui.Core;
using System.Net.Mail;

namespace DXMauiContactApp.Views;

public partial class AddContactPage : ContentPage
{
    public AddContactPage()
	{
		InitializeComponent();
        dataForm.DataObject = new PersonalInfo();

	}

    private async void createNewContact_Clicked(object sender, EventArgs e)
    {
        dataForm.Commit();
        ContactPerson contactPerson = ViewModel.MapUserDataToModel((PersonalInfo)dataForm.DataObject);
        if(contactPerson.FirstName != null && contactPerson.LastName != null && contactPerson.Phone != null)
        {
            contactPerson.ContactId = DateTime.Now.ToString("yyyyMMddHHmmssfff");
            ViewModel.AddContact(contactPerson);
            await Navigation.PopAsync();
        }
    }

    private void ValidateCustomerProperties(object sender, DevExpress.Maui.DataForm.DataFormPropertyValidationEventArgs e)
    {
        if (e.PropertyName == "Email" && e.NewValue != null)
        {
            MailAddress res;
            if (!MailAddress.TryCreate((string)e.NewValue, out res))
            {
                e.HasError = true;
                e.ErrorText = "Invalid email";
            }
        }
    }
}