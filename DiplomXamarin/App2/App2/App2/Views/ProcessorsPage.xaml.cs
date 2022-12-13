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
    public partial class ProcessorsPage : ContentPage
    {
        List<Processor> processors;
        Processor processor = new Processor();
        private Clients user;
        public ProcessorsPage(Clients user, List<Processor> processors)
        {
            InitializeComponent();
            this.user = user;
            this.processors = processors;

            LoadData();
        }
        public async void LoadData()
        {           
            listProcessors.ItemsSource = processors;
            if(BasketUser.matheboarduser == null)
            {
                listProcessors.ItemsSource = processors;                
            }
            else
            {
                listProcessors.ItemsSource = processors.Where(x=>x.ProcessorSocketId == BasketUser.matheboarduser.MatheboardSocket.IdSocketType);                
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



        private void PickerSocketsSelected(object sender, EventArgs e)
        {


            listProcessors.ItemsSource = processors.Where(x => x.ProcessorSocket.IdSocketType == pickerSockets.SelectedIndex + 1);

        }

        private void PickerFactorysSelected(object sender, EventArgs e)
        {

            listProcessors.ItemsSource = processors.Where(x => x.ProcessorFactoryId == pickerFactory.SelectedIndex + 1);
        }

        private void searchTb_TextChanged(object sender, TextChangedEventArgs e)
        {

            listProcessors.ItemsSource = processors.Where(x => x.ProcessorName.ToLower().Contains(searchTb.Text.ToLower()));
        }

        private async void ProcessorSelected(object sender, SelectedItemChangedEventArgs e)
        {
            bool result = await DisplayAlert("Уведомление", "Добавить в сборку?", "Да", "Отмена");
            if (result)
            {

                processor = listProcessors.SelectedItem as Processor;
                BasketUser.processoruser = processor;
                await Navigation.PopModalAsync();
            }
            else
            {

            }
        }
    }
}