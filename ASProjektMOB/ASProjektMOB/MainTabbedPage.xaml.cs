using ASProjektMOB.Views;
using ASProjektWPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ASProjektMOB
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainTabbedPage : TabbedPage
    {
        User User;
        Company Company;
        public MainTabbedPage()
        {
            InitializeComponent();
            Initialize();
        }
        public MainTabbedPage(User user)
        {
            InitializeComponent();
            User = user;
            Initialize();
            DisplayAlert("",user.Login + ", " + user.Password,"ok");
        }
        public MainTabbedPage(Company company)
        {
            InitializeComponent();
            Company = company;
            Initialize();
            DisplayAlert("", company.Login + ", " + company.Password, "ok");
        }
        public void Initialize()
        {
            NavigationPage HomePage = new NavigationPage(new HomePage());
            HomePage.IconImageSource = "icon_home.png";
            HomePage.Title = "Strona główna";
            this.Children.Add(HomePage);
            if(User != null && User.AccountTypeID == 2 ) 
            {
                NavigationPage AdminPanelPage = new NavigationPage(new AdminPanelPage());
                AdminPanelPage.IconImageSource = "icon_home.png";
                AdminPanelPage.Title = "Panel";
                this.Children.Add(AdminPanelPage);
            }
            if (Company != null)
            {
                NavigationPage CompanyPanelPage = new NavigationPage(new CompanyPanelPage());
                CompanyPanelPage.IconImageSource = "icon_home.png";
                CompanyPanelPage.Title = "Panel";
                this.Children.Add(CompanyPanelPage);
            }
            
            if(User != null && User.AccountTypeID == 1)
            {
                NavigationPage ProfiePage = new NavigationPage(new ProfilePage());
                ProfiePage.IconImageSource = "icon_user.png";
                ProfiePage.Title = "Profil";
                this.Children.Add(ProfiePage);
            }
            if(Company != null)
            {
                NavigationPage CompanyPage = new NavigationPage(new CompanyPage());
                CompanyPage.IconImageSource = "icon_home.png";
                CompanyPage.Title = "Firma";
                this.Children.Add(CompanyPage);
            }
            NavigationPage SettingsPage = new NavigationPage(new SettingsPage(this));
            SettingsPage.IconImageSource = "icon_settings.png";
            SettingsPage.Title = "Ustawienia";
            this.Children.Add(SettingsPage);
        }
    }
}