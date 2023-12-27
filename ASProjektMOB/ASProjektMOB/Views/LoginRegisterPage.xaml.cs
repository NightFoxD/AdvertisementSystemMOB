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
    public partial class LoginRegisterPage : ContentPage
    {
        public LoginRegisterPage(bool flagLoginRegister)
        {
            InitializeComponent();
            if (flagLoginRegister)
            {

            }
            else
            {

            }
        }

        private void Btn_LoginRegister_Clicked(object sender, EventArgs e)
        {

        }
    }
}