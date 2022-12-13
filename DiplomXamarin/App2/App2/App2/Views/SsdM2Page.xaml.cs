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
    public partial class SsdM2Page : ContentPage
    {
        M2 m2 = new M2();
        List<M2> m2s;
        private Clients user;
        public SsdM2Page(Clients user, List<M2> m2s)
        {
            InitializeComponent();
            this.user = user;
            this.m2s = m2s;
            LoadData();
        }
        public async void LoadData()
        {
            var m2s = await RestApi.restApi.GetM2s();
            listm2.ItemsSource = m2s;

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

        private async void M2Selected(object sender, SelectedItemChangedEventArgs e)
        {
            bool result = await DisplayAlert("Уведомление", "Добавить в сборку?", "Да", "Отмена");
            if (result)
            {

                m2 = listm2.SelectedItem as M2;
                BasketUser.m2user = m2;
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