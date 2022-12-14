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
    public partial class RamsPage : ContentPage
    {
        List<Rams> rams;
        List<Manufacturers> manufacturers;
        List<RamType> ramTypes;
        private Clients user;
        Rams ram = new Rams();
           
        public RamsPage(Clients user, List<Rams> rams)
        {
            InitializeComponent();
            this.user = user;
            this.rams = rams;
            LoadData();
        }
        public async void LoadData()
        {
           
            if (BasketUser.matheboarduser != null)
            {
                rams = rams.Where(x => x.RamTypeId == BasketUser.matheboarduser.MatheboardRamTypeId && x.RamCountSlots <= BasketUser.matheboarduser.MatheboardCountSlotsRam).ToList();               
                listRams.ItemsSource = rams;
            }
            else
            {             
                listRams.ItemsSource = rams;
            }
          
            manufacturers = await RestApi.restApi.GetManufacturers();
            pickerFactory.ItemsSource = manufacturers;
           
            

        }
        public async void LoadComboBox()
        {
            ramTypes = await RestApi.restApi.GetRamTypes();
            pickerType.ItemsSource = ramTypes;
                 
            var manufacture = await RestApi.restApi.GetManufacturers();
            pickerFactory.ItemsSource = manufacture;
            this.BindingContext = this;


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

        private void PickerSocketsSelected(object sender, EventArgs e)
        {
            listRams.ItemsSource = rams.Where(x => x.RamType.RamTypeId == pickerType.SelectedIndex + 1);
        }

        private void PickerFactorysSelected(object sender, EventArgs e)
        {
            listRams.ItemsSource = rams.Where(x => x.RamFactoryId == pickerFactory.SelectedIndex + 1);
        }

        private void PickerCountSelected(object sender, EventArgs e)
        {
            string value = string.Empty;
            value = pickerCount.SelectedItem.ToString();
            listRams.ItemsSource = rams.Where(x => x.RamCountSlots == int.Parse(value));
        }

        private void searchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            listRams.ItemsSource = rams.Where(x => x.RamName.ToLower().Contains(searchTb.Text.ToLower()));
        }

        private async void RamSelected(object sender, SelectedItemChangedEventArgs e)
        {
            bool result = await DisplayAlert("Уведомление", "Добавить в сборку?", "Да", "Отмена");
            if (result)
            {

                ram = listRams.SelectedItem as Rams;
                BasketUser.ramuser = ram;
                await Navigation.PopModalAsync();
            }
            else
            {

            }
        }
    }
}