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
        public SettingsPage()
        {
            InitializeComponent();
        }

        private void Btn_LogOut_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new LoginRegisterPage(false));
        }
        private void Btn_Register_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new LoginRegisterPage(true));
        }
        private void Btn_Settings_Clicked(object sender, EventArgs e)
        {

        }

        private void Btn_LogIn_Clicked(object sender, EventArgs e)
        {

        }

      
    }
}