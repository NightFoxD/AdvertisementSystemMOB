using ASProjektWPF.Classes;
using ASProjektWPF.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ASProjektMOB.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CompanyApplicationsPage : ContentPage
	{
		Company Company;
		public CompanyApplicationsPage (Company company)
		{
			InitializeComponent ();
			Company = company;
            Load_UserApplications();
		}
        public void Load_UserApplications()
        {
            ObservableCollection<ApplicationItem> list = new ObservableCollection<ApplicationItem>();
            if (Company != null)
            {
                foreach (var application in App.DataAccess.GetApplicationList())
                {
                    foreach (var announcment in App.DataAccess.GetAnnouncmentList())
                    {
                        if (application.AnnouncmentID == announcment.AnnouncmentID)
                        {
                            if (new AnnouncmentItem(announcment).CompanyID == Company.CompanyID)
                            {
                                AnnouncmentItem item = new AnnouncmentItem(announcment);
                                User user = App.DataAccess.GetUser(application.UserID);
                                list.Add(new ApplicationItem(item, user));
                            }
                        }
                    }
                }
            }
            if (list.Count == 0)
            {
                TxtB_Application_Info.IsVisible = true;
            }
            else
            {
                TxtB_Application_Info.IsVisible = false;
            }
            LV_CompanyApplications.ItemsSource = list;
        }
        private void GoToAnnouncment(object sender, EventArgs e)
        {
            AnnouncmentItem tmpItem = ((Button)sender).CommandParameter as AnnouncmentItem;
            if (tmpItem != null)
            {
                Announcment item = tmpItem.Announcment;
                Navigation.PushAsync(new AnnouncmentPage(item));
            }
        }
        private void Btn_DeleteApplication(object sender, EventArgs e)
        {
            ApplicationItem applicationItem = ((Button)sender).CommandParameter as ApplicationItem;
            if (applicationItem != null)
            {
                foreach (var item in App.DataAccess.GetApplicationList())
                {
                    if (applicationItem.User != null && applicationItem.Announcment != null)
                    {
                        if (applicationItem.User.UserID == item.UserID && applicationItem.Announcment.AnnouncmentID == item.AnnouncmentID)
                        {
                            App.DataAccess.Delete_Application(item);
                            break;
                        }
                    }

                }
            }
            Load_UserApplications();

        }
    }
}