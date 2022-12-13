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
    public partial class RegistrationPage : ContentPage
    {
        public RegistrationPage()
        {
            InitializeComponent();
        }

        private async void CreateAccount(object sender, EventArgs e)
        {
            Clients clients = new Clients();
            clients.ClientBirthday = birthDate.Date;
            clients.ClientNick = loginEntry.Text;
            clients.ClientMail = mailEntry.Text;
            clients.ClientPassword = password_1Entry.Text;
            clients.ClientImage = null;
            await RestApi.restApi.Registration(clients);
            var result =  DisplayAlert("Ура!", "Аккаунт зарегистрирован", "ОК");
            await Navigation.PushModalAsync(new LoginPage());
        }
    }
}