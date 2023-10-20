using DevExpress.Maui.Core;
using DXMauiContactApp.Views;
using Microsoft.Maui.Controls;
using System.Collections.ObjectModel;

namespace DXMauiContactApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            var contacts = new ObservableCollection<ContactPerson>(ViewModel._data);

            collectionView.ItemsSource = contacts;
        }

        private async void addContact_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddContactPage());
        }


        private async void collectionView_SelectionChanged(object sender, DevExpress.Maui.CollectionView.CollectionViewSelectionChangedEventArgs e)
        {
            if (collectionView.SelectedItem != null)
            {
                await Navigation.PushAsync(new EditContactPage(((ContactPerson)collectionView.SelectedItem).ContactId));
            }

        }
    }
}