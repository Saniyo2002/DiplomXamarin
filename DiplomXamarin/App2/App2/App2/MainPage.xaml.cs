using App2.Api;
using App2.Connection;
using App2.Model;
using App2.Views;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App2
{
    public partial class MainPage : ContentPage 
    {

        Matheboard matheboard = new Matheboard();
        List<Matheboard> Matheboards { get; set; }
      
       
        public MainPage()
        {
            InitializeComponent();              
            LoadData();
            


        }
        public async void LoadData()
        {
            Matheboards = await RestApi.restApi.GetMatheboards();
       
            listMatheboards.ItemsSource = Matheboards;
            

        }
       
        
        private async void MatheboardSelected(object sender, SelectedItemChangedEventArgs e)
        {
           bool result = await DisplayAlert("Уведомление", "Добавить в сборку?", "Да", "Отмена");
            if(result)
            {
                
                matheboard = listMatheboards.SelectedItem as Matheboard;
                BasketUser.matheboarduser = matheboard;
                await Navigation.PopModalAsync();
               
            }    
            else
            {

            }
        }
        public async void LoadComboBox()
        {
            var sockettypes = await RestApi.restApi.GetSocketType();
            pickerSockets.ItemsSource = sockettypes;
            var manufacture = await RestApi.restApi.GetManufacturers();
            pickerFactory.ItemsSource = manufacture;
            this.BindingContext = this;

        }

        private void GoToMenu(object sender, EventArgs e)
        {
            LoadComboBox();
            frameCb.IsVisible = true;
            menuStackLayout.IsVisible = true;          
            menubt.IsVisible = false;
            menubt.Margin = new Thickness(0, 0, 0, 0);
            
            disablemenubt.IsVisible = true;
        }

        private void DisableMenu(object sender, EventArgs e)
        {
            frameCb.IsVisible = false;
            menuStackLayout.IsVisible =false;
            disablemenubt.IsVisible = false;
           
            disablemenubt.Margin = new Thickness(0, 0, 0, 0);
            menubt.IsVisible = true;
            
        }

        private void PickerSocketsSelected(object sender, EventArgs e)
        {
           
            listMatheboards.ItemsSource = Matheboards.Where(x => x.MatheboardSocket.IdSocketType == pickerSockets.SelectedIndex + 1);

        }

        private void PickerFactorysSelected(object sender, EventArgs e)
        {
         
           
            listMatheboards.ItemsSource = Matheboards.Where(x => x.MatheboardManufacturer.FactoryId == pickerFactory.SelectedIndex + 1);
        }

        private void searchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            pickerFactory.SelectedIndex = -1;
            pickerSockets.SelectedIndex = -1;
            listMatheboards.ItemsSource = Matheboards.Where(x => x.MatheboardName.ToLower().Contains(searchTb.Text.ToLower()));
        }
    }
}
