namespace DXMauiContactApp.Views;

using Contact = DXMauiContactApp.ContactPerson;

//[QueryProperty(nameof(ContactId), "Id")]

public partial class EditContactPage : ContentPage
{
    private string contact_Id;

    public EditContactPage(string contactId)
	{
        contact_Id = contactId;
        InitializeComponent();
        ContactPerson contact = ViewModel.GetContactById(contact_Id);
        if (contact != null)
        {
            PersonalInfo test = new PersonalInfo
            {
                FirstName = contact.FirstName,
                LastName = contact.LastName,
                Phone = contact.Phone,
            };
            dataForm.DataObject = test;
        }
        else { 
            dataForm.DataObject = new PersonalInfo(); 
        }
    }

    private async void updateContact_Clicked(object sender, EventArgs e)
    {
        dataForm.Commit();
        ContactPerson contactPerson = ViewModel.MapUserDataToModel((PersonalInfo)dataForm.DataObject);
        contactPerson.ContactId = contact_Id;
        ViewModel.UpdateContact(contact_Id, contactPerson);
        await Navigation.PopAsync();
    }

    private async void cancelContact_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

    private async void deleteButton_Clicked(object sender, EventArgs e)
    {
        ViewModel.DeleteContact(contact_Id);
        await Navigation.PopAsync();
    }
}