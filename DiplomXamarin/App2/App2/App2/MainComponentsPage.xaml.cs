using App2.Api;
using App2.Connection;
using App2.Model;
using App2.Views;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;
using PdfSharp.Xamarin.Forms;
using PdfSharpCore.Pdf;
using App2.UserContext;
using App2.Helper;

namespace App2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainComponentsPage : TabbedPage 
    {
      
        ClientComponent build = new ClientComponent();
        List<ClientComponent> basket;
        public string matheboard1 { get; set; }
        List<StackLayout> stackLayouts = new List<StackLayout>();       
       
        protected override void OnAppearing()
        {
            base.OnAppearing();
            FillBuild();
           
            /////////////////////////////////////////////////////
          
        }

        private Clients user;
        private List<Matheboard> matheboards;
        private List<Processor> processors;
        private List<Videocards> videocards;
        private List<Rams> rams;
        private List<PowerCases> powercases;
        private List<Cases> cases;
        private List<HardDisks> hdds;
        private List<SolidStateDrives> ssds;
        private List<M2> m2s;
        private void FillBuild(ClientComponent editBasket = null)
        {
            if(editBasket != null)
            {
                BasketUser.matheboarduser = editBasket.matheboard;
                BasketUser.processoruser = editBasket.processor;
                BasketUser.videocarduser = editBasket.videocard;
                BasketUser.ramuser = editBasket.ram;
                BasketUser.powercaseuser = editBasket.powerCase;
                BasketUser.casesuser = editBasket.case1;
                BasketUser.hdduser = editBasket.hdd;
                BasketUser.ssduser = editBasket.ssd;
                BasketUser.m2user = editBasket.m2;
            }
          
                if (BasketUser.matheboarduser != null)
                {

                    matheboardImage.Source = "complete.png";
                    matheboardLabel.Text = BasketUser.matheboarduser.MatheboardName;
                }
                if (BasketUser.processoruser != null)
                {

                    processorImage.Source = "complete.png";
                    labelProcessor.Text = BasketUser.processoruser.ProcessorName;
                }
                if (BasketUser.videocarduser != null)
                {

                    videocardImage.Source = "complete.png";
                    labelVideocard.Text = BasketUser.videocarduser.VideocardName;
                }
                if (BasketUser.ramuser != null)
                {

                    ramImage.Source = "complete.png";
                    labelRam.Text = BasketUser.ramuser.RamName;
                }
                if (BasketUser.casesuser != null)
                {

                    caseImage.Source = "complete.png";
                    labelCase.Text = BasketUser.casesuser.CaseName;
                }
                if (BasketUser.powercaseuser != null)
                {

                    powerCaseImage.Source = "complete.png";
                    labelPowerCase.Text = BasketUser.powercaseuser.PowerCaseName;
                }
                if (BasketUser.hdduser != null)
                {

                    hddImage.Source = "complete.png";
                    labelHdd.Text = BasketUser.hdduser.HddName;
                }
                if (BasketUser.ssduser != null)
                {

                    ssdImage.Source = "complete.png";
                    labelSsd.Text = BasketUser.ssduser.SsdName;
                }

                if (BasketUser.m2user != null)
                {

                    ssdm2Image.Source = "complete.png";
                    labelSsdM2.Text = BasketUser.m2user.M2Name;
                }
            
           
           
        }
        public ClientComponent EditBuildd { get; set; }
        public MainComponentsPage(ClientComponent editBuild = null)
        {
            InitializeComponent();
            EditBuildd = editBuild;
            if (editBuild != null)
            {
                FillBuild(editBuild);
                saveButton.IsVisible = false;
                editButton.IsVisible = true;
            }
            this.user = Currentuser.user.User;
            if(user.ClientId == 1)
            {
                accountUserLabel.Text = "Войдите в аккаунт";
                OutButton.IsVisible = false;
                listBasket.IsVisible = false;
                basketGuest.IsVisible = true;
                buttonLogin1.IsVisible = true;
                button2.IsVisible = true;
                

            }
            else
            {
                accountUserLabel.Text = user.ClientMail;
                OutButton.IsVisible = true;
            }
            

            LoadData();
        }       

        public async void LoadData()
        {

            basket = (await RestApi.restApi.GetBasket()).Where(x => x.clientId == user.ClientId).ToList();
            listBasket.ItemsSource = basket;
            var matheboards = await RestApi.restApi.GetMatheboards();
            this.matheboards = matheboards;
            var processors = await RestApi.restApi.GetProcessors();
            this.processors = processors;
            var videocards = await RestApi.restApi.GetVideocards();
            this.videocards = videocards;
            var rams = await RestApi.restApi.GetRams();
            this.rams = rams;
            var powercases = await RestApi.restApi.GetPowerCases();
            this.powercases = powercases;
            var cases = await RestApi.restApi.GetCases();
            this.cases = cases;
            var hdds = await RestApi.restApi.GetHdds();
            this.hdds = hdds;
            var ssds = await RestApi.restApi.GetSsds();
            this.ssds = ssds;   
            var m2s = await RestApi.restApi.GetM2s();
            this.m2s = m2s;

        }

        private async void GoToMainPatge(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new MainPage());
        }

        private async void GoToProcessors(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new ProcessorsPage(user, processors));
        }

        private async void GoToRamsPage(object sender, EventArgs e)
        {
            if(rams == null)
            {

            }
            else
            {
                await Navigation.PushModalAsync(new RamsPage(user, rams));
            }
           
        }

        private void UpdateData(object sender, EventArgs e)
        {

            ;
        }

        private async void GoToVideocards(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new VideocardsPage(user, videocards));
        }

        private async void GoToPowerCases(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new PowerCasesPage(user, powercases));
        }

        private async void GoToCases(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new CasesPage(user, cases));
        }

        private async void GoToHdd(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new HddPage(user, hdds));
        }

        private async void GoToSsd(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new SsdPage(user, ssds));
        }

        private async void GoToM2(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new SsdM2Page(user, m2s));
            
        }

        private async void GoToBasketPage(object sender, EventArgs e)
        {
            ClientComponent clientComponent = new ClientComponent();
            string input = null;
            string result = await DisplayPromptAsync("Название сборки", "Введите название сборки", "ОК", "Отмена", input, -1);
            if (result != null)
            {

                clientComponent.clientId = user.ClientId;
                clientComponent.matheboardId = BasketUser.matheboarduser.MatheboardId;
                clientComponent.processorId = BasketUser.processoruser.ProcessorId;
                clientComponent.ramId = BasketUser.ramuser.RamId;
                clientComponent.videocardId = BasketUser.videocarduser.VideocardId;
                clientComponent.powerCaseId = BasketUser.powercaseuser.PowerCaseId;
                clientComponent.caseId = BasketUser.casesuser.CaseId;
                clientComponent.hddId = BasketUser.hdduser.HddId;
                clientComponent.ssdId = BasketUser.ssduser.SsdId;
                clientComponent.m2id = BasketUser.m2user.M2Id;
                clientComponent.buildName = result;

                string json = JsonConvert.SerializeObject(clientComponent);
                await Api.RestApi.restApi.PostSaveBuild(clientComponent);
                var basket = await RestApi.restApi.GetBasket();
                listBasket.ItemsSource = basket.Where(x => x.clientId == user.ClientId);

                ResetBuild();
            }
           
        }

        private void GoToBasket(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new BasketPage());
            BasketUser.matheboarduser = null;
            BasketUser.videocarduser = null;
            BasketUser.processoruser = null;
            BasketUser.ramuser = null;
            BasketUser.casesuser = null;
            BasketUser.powercaseuser = null;
            BasketUser.ssduser = null;
            BasketUser.m2user = null;
            BasketUser.hdduser = null;
        }

        private async void PublicBuild(object sender, EventArgs e)
        {

            matheboard1 = "Посмотрите на сборку, которую я собрал в приложении Configurator!\n" + build.matheboard.MatheboardName + "\n" + "-------------------------" + "\n" +
                build.processor.ProcessorName + "\n" + "-------------------------" + "\n" +
                build.ram.RamName + "\n" + "-------------------------" + "\n" +
                build.videocard.VideocardName + "\n" + "-------------------------" + "\n" +
                build.powerCase.PowerCaseName + "\n" + "-------------------------" + "\n" +
                build.case1.CaseName + "\n" + "-------------------------" + "\n" +
                build.ssd.SsdName + "\n" + "-------------------------" + "\n" +
                build.m2.M2Name + "\n" + "-------------------------" + "\n" +
                build.hdd.HddName + "\n";
            await Clipboard.SetTextAsync(matheboard1);
            await DisplayAlert("Уведомление", "Сборка скопирована в буфер обмена!", "ОК");
            var result = await DisplayAlert("Уведомление", "Поделиться сборкой?", "Да", "Нет");
            if(result)
            {
                await Share.RequestAsync(new ShareTextRequest
                {
                    Text = matheboard1,
                    Title = "Configurator"
                });
            }

        }
        public interface IPdfSave
        {
            void Save(PdfDocument doc, string fileName);
        }
        private void ImportBuild(object sender, EventArgs e)
        {

            var pdf = PDFManager.GeneratePDFFromView(stackLayouts.First(x=>x.BindingContext == build), size: PdfSharpCore.PageSize.A0, resizeToFit: true);
            DependencyService.Get<IPdfSave>().Save(pdf, Path.GetRandomFileName()+".pdf");
        }

        private void EditBuild(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new MainComponentsPage(build));
            
            BasketUser basketUser = new BasketUser();
        }

        private void BuildSelected(object sender, SelectedItemChangedEventArgs e)
        {          
            build = listBasket.SelectedItem as ClientComponent;
            
        }

        private void BasketChildAdded(object sender, ElementEventArgs e)
        {
            var x = sender as StackLayout;
            
            if (stackLayouts.FirstOrDefault(d => d == x) == null)
            {
                stackLayouts.Add(x);
            }
        }      

        private void GoOut(object sender, EventArgs e)
        {
            Currentuser.user = null;
            File.Delete(XmlManager.UserPath);
            Navigation.PushModalAsync(new LoginPage());
        }

        private void GoToLogin(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new LoginPage());
        }

        private async void RemoveBuild(object sender, EventArgs e)
        {
            var result = await DisplayAlert("Предупреждение", "Вы действительно хотите удалить сборку?", "Да", "Отмена");
            if(result)
            {
                var sborka = (sender as ImageButton).BindingContext as ClientComponent;
                var result1 = await RestApi.restApi.RemoveBuildClient(sborka.clientComponentId);
                if(result1.Content != null)
                {
                    basket.Remove(sborka);
                    listBasket.ItemsSource = null;
                    listBasket.ItemsSource = basket;
                    await DisplayAlert("Ура!", "Сборка успешно удалена", "ОК");
                }
               
                
            }
        }
        private void ResetBuild()
        {
            if (BasketUser.matheboarduser == null)
            {

                matheboardImage.Source = "matheboard.png";
                matheboardLabel.Text = "Материнские платы";
            }
            if (BasketUser.processoruser == null)
            {

                processorImage.Source = "processor.png";
                labelProcessor.Text = "Процессоры";
            }
            if (BasketUser.videocarduser == null)
            {

                videocardImage.Source = "videocard.png";
                labelVideocard.Text = "Видеокарты";
            }
            if (BasketUser.ramuser == null)
            {

                ramImage.Source = "ram.png";
                labelRam.Text = "Оперативная память";
            }
            if (BasketUser.casesuser == null)
            {

                caseImage.Source = "case1.png";
                labelCase.Text = "Материнские платы";
            }
            if (BasketUser.powercaseuser == null)
            {

                powerCaseImage.Source = "powercase.png";
                labelPowerCase.Text = "Блоки питания";
            }
            if (BasketUser.hdduser == null)
            {

                hddImage.Source = "hdd.png";
                labelHdd.Text = "Жесткие диски";
            }
            if (BasketUser.ssduser == null)
            {

                ssdImage.Source = "ssd.png";
                labelSsd.Text = "Твердотельные накопители (SSD)";
            }

            if (BasketUser.m2user == null)
            {

                ssdm2Image.Source = "ssdm2.png";
                labelSsdM2.Text = "Твердотельные накопители (M.2)";
            }
        }

        private async void DeleteAndAddBuild(object sender, EventArgs e)
        {
            ClientComponent clientComponent = new ClientComponent();
            var resultDelte = await RestApi.restApi.RemoveBuildClient(EditBuildd.clientComponentId);
            clientComponent.clientId = user.ClientId;
            clientComponent.matheboardId = BasketUser.matheboarduser.MatheboardId;
            clientComponent.processorId = BasketUser.processoruser.ProcessorId;
            clientComponent.ramId = BasketUser.ramuser.RamId;
            clientComponent.videocardId = BasketUser.videocarduser.VideocardId;
            clientComponent.powerCaseId = BasketUser.powercaseuser.PowerCaseId;
            clientComponent.caseId = BasketUser.casesuser.CaseId;
            clientComponent.hddId = BasketUser.hdduser.HddId;
            clientComponent.ssdId = BasketUser.ssduser.SsdId;
            clientComponent.m2id = BasketUser.m2user.M2Id;
            clientComponent.buildName = EditBuildd.buildName;
            var resultAdd = await RestApi.restApi.PostSaveBuild(clientComponent);
            if(resultAdd.IsSuccessStatusCode)
            {
                basket = (await RestApi.restApi.GetBasket()).Where(x => x.clientId == user.ClientId).ToList();
                listBasket.ItemsSource = null;
                listBasket.ItemsSource = basket;
                BasketUser.matheboarduser = null;
                BasketUser.videocarduser = null;
                BasketUser.processoruser = null;
                BasketUser.ramuser = null;
                BasketUser.casesuser = null;
                BasketUser.powercaseuser = null;
                BasketUser.ssduser = null;
                BasketUser.m2user = null;
                BasketUser.hdduser = null;
                ResetBuild();
                saveButton.IsVisible = true;
                editButton.IsVisible = false;
                await DisplayAlert("Ура!", "Сборка успешно изменена", "OK");
            }
            

        }
    }
}