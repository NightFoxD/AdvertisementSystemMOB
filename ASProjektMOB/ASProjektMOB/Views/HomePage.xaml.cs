using ASProjektWPF.Classes;
using ASProjektWPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ASProjektMOB.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        User User;
        public HomePage(User user)
        {
            InitializeComponent();
            User = user;
            LV_Announcments.ItemsSource = GetAnnouncmentAllInformations();
            CV_Comapnies.ItemsSource = App.DataAccess.GetCompanyList();
        }
        public HomePage()
        {
            InitializeComponent();
            LV_Announcments.ItemsSource = GetAnnouncmentAllInformations();
            CV_Comapnies.ItemsSource = App.DataAccess.GetCompanyList();
        }
        public List<AnnouncmentItem> GetAnnouncmentAllInformations()
        {
            List<AnnouncmentItem> items = new List<AnnouncmentItem>();
            foreach (var item in App.DataAccess.GetAnnouncmentList())
            {
                items.Add(new AnnouncmentItem(item));
            }
            return items;
        }
        private void GoToAnnouncment(object sender, EventArgs e)
        {
            AnnouncmentItem tmpItem = ((Button)sender).CommandParameter as AnnouncmentItem;
            if (tmpItem != null)
            {
                Announcment item = tmpItem.Announcment;
                if (item != null && User != null)
                {
                    Navigation.PushAsync(new AnnouncmentPage(User, item));
                }
                else if (item != null)
                {
                    Navigation.PushAsync(new AnnouncmentPage(item));
                }
            }
        }

        private void Btn_CopanyLook_Clicked(object sender, EventArgs e)
        {
            Company company = ((Button)sender).CommandParameter as Company;
            Navigation.PushAsync(new CompanyPage(company,false));
        }
    }
}