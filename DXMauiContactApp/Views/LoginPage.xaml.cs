//using static CoreFoundation.DispatchSource;

namespace DXMauiContactApp.Views;

public partial class LoginPage : ContentPage
{
    public LoginPage()
    {
        InitializeComponent();
        loginDataForm.DataObject = new LoginInfo();
    }

    protected override bool OnBackButtonPressed()
    {
        Application.Current.Quit();
        return true;
    }

    private async void LoginButton_Clicked(object sender, EventArgs e)
    {
        loginDataForm.Commit();
        LoginInfo loginInfo = (LoginInfo)loginDataForm.DataObject;

        string username = loginInfo.Username;
        string password = loginInfo.Password;

        if (IsCredentialCorrect(username, password))
        {
            await SecureStorage.SetAsync("hasAuth", "true");
            await Navigation.PushAsync(new MainPage());
        }
        else
        {
            await DisplayAlert("Login failed", "Username or password is invalid", "Try again");
        }
    }


    bool IsCredentialCorrect(string username, string password)
    {
        return username == "admin" && password == "1234";
    }
}