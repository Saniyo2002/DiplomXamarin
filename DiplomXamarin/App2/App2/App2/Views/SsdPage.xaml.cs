using App2.Api;
using App2.Connection;
using App2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SsdPage : ContentPage
    {
        SolidStateDrives ssd = new SolidStateDrives();
        List<SolidStateDrives> ssds;
        private Clients user;
        public SsdPage(Clients user, List<SolidStateDrives> ssds)
        {
            InitializeComponent();
            this.user = user;
            this.ssds = ssds;
            LoadData();
        }
        public async void LoadData()
        {          
            listSsds.ItemsSource = ssds;

        }
        public async void LoadComboBox()
        {
            var sockettypes = await RestApi.restApi.GetManufacturers();
            pickerFactory.ItemsSource = sockettypes;

        }

        private void GoToMenu(object sender, EventArgs e)
        {
            LoadComboBox();
            menuStackLayout.IsVisible = true;
            menubt.IsVisible = false;
           
            disablemenubt.IsVisible = true;
        }

        private void DisableMenu(object sender, EventArgs e)
        {
            menuStackLayout.IsVisible = false;
            disablemenubt.IsVisible = false;
           
            menubt.IsVisible = true;

        }

        private async void SsdSelected(object sender, SelectedItemChangedEventArgs e)
        {
            bool result = await DisplayAlert("Уведомление", "Добавить в сборку?", "Да", "Отмена");
            if (result)
            {

                ssd = listSsds.SelectedItem as SolidStateDrives;
                BasketUser.ssduser = ssd;
                await Navigation.PopModalAsync();

            }
            else
            {

            }
        }

        private void searchTb_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void PickerFactorysSelected(object sender, EventArgs e)
        {

        }
    }
}