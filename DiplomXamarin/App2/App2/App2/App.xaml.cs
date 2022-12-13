using App2.Api;
using App2.Helper;
using App2.UserContext;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App2
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            RestApi.Init();
            Currentuser.user = XmlManager.ReadFromXmlFile<Model.AuthResponseToken>(XmlManager.UserPath);
            if(Currentuser.user?.User != null)
            {
                MainPage = new MainComponentsPage();
            }
            else
            {
                MainPage = new LoginPage();
            }
            
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
