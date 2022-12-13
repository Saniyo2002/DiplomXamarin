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
    public partial class CasesPage : ContentPage
    {
        Cases case_ = new Cases();
        private Clients user;
        List<Cases> cases;
        public CasesPage(Clients user, List<Cases> cases)
        {
            InitializeComponent();
            this.user = user; 
            this.cases = cases;
            LoadData();
        }
        public async void LoadData()
        {            
            listCases.ItemsSource = cases;
                     
        }
        public async void LoadComboBox()
        {
            var sockettypes = await RestApi.restApi.GetSocketType();
            

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

        private void searchTb_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void PickerFactorysSelected(object sender, EventArgs e)
        {

        }

        private async void CaseSelected(object sender, SelectedItemChangedEventArgs e)
        {
            bool result = await DisplayAlert("Уведомление", "Добавить в сборку?", "Да", "Отмена");
            if (result)
            {

                case_ = listCases.SelectedItem as Cases;
                BasketUser.casesuser = case_;
                await Navigation.PopModalAsync();

            }
            else
            {

            }
        }
    }
}