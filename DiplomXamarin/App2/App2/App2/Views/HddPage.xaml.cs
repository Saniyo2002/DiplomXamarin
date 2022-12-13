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
    public partial class HddPage : ContentPage
    {
        HardDisks hdd = new HardDisks();
        private Clients user;
        List<HardDisks> hdds;
        public HddPage(Clients user, List<HardDisks> hdds)
        {
            InitializeComponent();
            this.user = user;
            this.hdds = hdds;
            LoadData();
        }
        public async void LoadData()
        {            
            listhdds.ItemsSource = hdds;


        }
        public async void LoadComboBox()
        {
            var sockettypes = await RestApi.restApi.GetManufacturers();
            pickerFactory.ItemsSource = sockettypes;

        }
        private async void GoToMenu(object sender, EventArgs e)
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

        private async void HddSelected(object sender, SelectedItemChangedEventArgs e)
        {
            bool result = await DisplayAlert("Уведомление", "Добавить в сборку?", "Да", "Отмена");
            if (result)
            {

                hdd = listhdds.SelectedItem as HardDisks;
                BasketUser.hdduser = hdd;
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