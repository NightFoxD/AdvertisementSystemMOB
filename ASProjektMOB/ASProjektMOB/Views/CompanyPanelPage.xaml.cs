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
	public partial class CompanyPanelPage : ContentPage
	{
        Company Company;
		public CompanyPanelPage (Company company)
		{
			InitializeComponent ();
            Company = company;
		}
        private void Btn_Add_Adnnouncment_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AddEdit_AnnouncmentPage (Company));
        }

        private void Btn_Edit_Adnnouncment_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CompanyAnnouncmentsPage(Company));
        }

        private void Btn_Applications_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CompanyApplicationsPage(Company));
        }
    }
}