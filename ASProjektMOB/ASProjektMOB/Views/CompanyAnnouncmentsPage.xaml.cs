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
	public partial class CompanyAnnouncmentsPage : ContentPage
	{
        Company Company;
		public CompanyAnnouncmentsPage (Company company)
		{
			InitializeComponent ();
            Company = company;
            Refresh();
        }
        public void Refresh()
        {
            LV_Announcments.ItemsSource = new ObservableCollection<Announcment>(App.DataAccess.GetAnnouncmentList(Company));
        }
        private void Btn_DelAnnouncment_Clicked(object sender, EventArgs e)
        {
            Announcment item = ((Button)sender).CommandParameter as Announcment;
            App.DataAccess.Delete_Announcment(item);
            Refresh();
        }

        private async void Btn_EditAnnouncment_Clicked(object sender, EventArgs e)
        {
            Announcment item = ((Button)sender).CommandParameter as Announcment;
            await Navigation.PushAsync(new AddEdit_AnnouncmentPage(Company, item));
            Refresh();
        }
    }
}