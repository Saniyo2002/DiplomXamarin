using App2.Api;
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
    public partial class RecoveryPasswordPage : ContentPage
    {
        public RecoveryPasswordPage()
        {
            InitializeComponent();
        }
        AuthResponseToken token;

        private async void  RecoveryPassword(object sender, EventArgs e)
        {
            var x = birtdate.Date.ToString("dd.MM.yyyy");
           var response =  await RestApi.restApi.RecoveryPassword(loginen.Text, emailen.Text, birtdate.Date.ToString("dd.MM.yyyy"));
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                restorePasswordSL.IsVisible = false;
                newPasswordSL.IsVisible = true;
                token = response.Content;
            }
            else
            {
                await DisplayAlert("Ошибка", response.Error.Content.ToString(), "OK");
            }
                
            
        }

        private async void NewPassword(object sender, EventArgs e)
        {
            var x = await RestApi.restApi.NewPassword(token.User.ClientNick, token.User.ClientPassword, newPasswordEntry.Text);
            if(x.IsSuccessStatusCode)
            {
                await DisplayAlert("Ура", "Пароль успешно изменен!", "ОК");
                await App.Current.MainPage.Navigation.PopModalAsync();
            }
            
        }
    }
}