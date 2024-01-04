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
    public partial class SettingsPage : ContentPage
    {
        Page page;
        public SettingsPage(Page page)
        {
            InitializeComponent();
            this.page = page;
        }

        private async void Btn_LogOut_Clicked(object sender, EventArgs e)
        {
            await page.Navigation.PopAsync();
        }


      
    }
}