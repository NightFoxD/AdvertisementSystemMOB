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
    public partial class ProfilePage : ContentPage
    {
        User User;
        public ProfilePage(User user)
        {
            InitializeComponent();
            User = user;
        }

        private void Btn_Edit_UserData_Clicked(object sender, EventArgs e)
        {

        }
        private void Btn_Cancel_UserData_Clicked(object sender, EventArgs e)
        {

        }
        private void Btn_Save_UserData_Clicked(object sender, EventArgs e)
        {

        }

        

        private void Btn_Cancel_ContactData_Clicked(object sender, EventArgs e)
        {

        }

        private void Btn_Save_ContactData_Clicked(object sender, EventArgs e)
        {

        }

        private void Btn_AddFrom_Education_Clicked(object sender, EventArgs e)
        {

        }

        private void Btn_Edit_ContactData_Clicked(object sender, EventArgs e)
        {

        }

        private void Btn_Cancel_Education_Clicked(object sender, EventArgs e)
        {

        }

        private void Btn_Add_Education_Clicked(object sender, EventArgs e)
        {

        }

        private void Btn_Cancel_ExperienceWork_Clicked(object sender, EventArgs e)
        {

        }

        private void Btn_Add_ExperienceWork_Clicked(object sender, EventArgs e)
        {

        }

        private void Btn_AddFrom_ExperienceWork_Clicked(object sender, EventArgs e)
        {

        }

        private void Btn_AddFrom_Language_Clicked(object sender, EventArgs e)
        {

        }

        private void Btn_Cancel_Language_Clicked(object sender, EventArgs e)
        {

        }

        private void Btn_Add_Language_Clicked(object sender, EventArgs e)
        {

        }

        private void Btn_AddFrom_Skills_Clicked(object sender, EventArgs e)
        {

        }

        private void Btn_Cancel_Skills_Clicked(object sender, EventArgs e)
        {

        }

        private void Btn_Add_Skills_Clicked(object sender, EventArgs e)
        {

        }

        private void Btn_Cancel_Link_Clicked(object sender, EventArgs e)
        {

        }

        private void Btn_Add_Link_Clicked(object sender, EventArgs e)
        {

        }
    }
}