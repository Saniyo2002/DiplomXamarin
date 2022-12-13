using App2.Api;
using App2.Helper;
using App2.Model;
using App2.UserContext;
using App2.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private async void GoToMainComponentsPage(object sender, EventArgs e)
        {
            var response = await RestApi.restApi.Authorization(loginEntry.Text, passwordEntry.Text);
            
            if(response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                XmlManager.WriteToXmlFile(XmlManager.UserPath, response.Content);   
                Preferences.Set("Token", response.Content.Token);
                Currentuser.user = response.Content;
                await Navigation.PushModalAsync(new MainComponentsPage());              
            }

            else
            {
                await DisplayAlert("Ошибка", "Неверный логин или пароль", "OK");
                
            }


        }

        private void GoToRegistrationPage(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new RegistrationPage());
        }

        private void GoToRecoveryPasswordPage(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new RecoveryPasswordPage());
        }

        private void GoToGuest(object sender, EventArgs e)
        {
            Clients clientGuest = new Clients();
            clientGuest.ClientId = 1;
            Currentuser.user = new AuthResponseToken();
            Currentuser.user.User = clientGuest;
            Navigation.PushModalAsync(new MainComponentsPage());
        }
    }
}