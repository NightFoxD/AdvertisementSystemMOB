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
        }
        public HomePage()
        {
            InitializeComponent();
            LV_Announcments.ItemsSource = GetAnnouncmentAllInformations();
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
        private void Btn_More_Announcments_Click(object sender, EventArgs e)
        {

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
    }
}