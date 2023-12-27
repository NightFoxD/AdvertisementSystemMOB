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
    public partial class LoginRegisterPage : ContentPage
    {
        bool FlagLoginRegister;
        public LoginRegisterPage(bool flagLoginRegister)
        {
            InitializeComponent();
            this.FlagLoginRegister = flagLoginRegister;
            Lbl_CompnayName.IsVisible = false;
            Etr_CompanyName.IsVisible = false;
            Lbl_SecondPassword.IsVisible = flagLoginRegister;
            Etr_Password_2.IsVisible = flagLoginRegister;
            if (flagLoginRegister)
            {
                Btn_LoginRegister.Text = "Zarejetruj się";
            }
            else
            {
                Lbl_Admin.IsVisible = false;
                Stch_Admin.IsVisible = false;

                Btn_LoginRegister.Text = "Zaloguj sie się";
            }
        }

        private void Btn_LoginRegister_Clicked(object sender, EventArgs e)
        {
            if (!CustomValidations.IsCorrectTextAndNumbers(Etr_Login.Text))
            {
                DisplayAlert("Error", "1Login powinien zawierać tylko litery oraz liczby", "OK");
                return;
            }
            if (!CustomValidations.IsCorrectTextAndNumbers(Etr_Password_1.Text))
            {
                DisplayAlert("Error", "2Hasło powinno zawierać tylko litery oraz liczby", "OK");
                return;
            }
            if (!FlagLoginRegister)
            {
                if (!Stch_Company.IsToggled)
                {
                    
                    User User = App.DataAccess.GetUser(Etr_Login.Text, HashPassword.Hash(Etr_Password_1.Text));
                    if (User != null)
                    {
                        Navigation.PushAsync(new MainTabbedPage(User));
                    }
                    else
                    {
                        DisplayAlert("3Error","Niepoprawy login lub hasło","ok");
                    }
                        
                }
                else
                {
                    Company Company = App.DataAccess.GetCompany(Etr_Login.Text,HashPassword.Hash(Etr_Password_1.Text));
                    if (Company != null)
                    {
                        Navigation.PushAsync(new MainTabbedPage(Company));
                    }
                    else
                    {
                        DisplayAlert("4Error", "Niepoprawy login lub hasło", "ok");
                    }
                }
            }
            else
            {
                if (!CustomValidations.IsCorrectTextAndNumbers(Etr_Password_2.Text))
                {
                    DisplayAlert("Error", "5Hasło powinno zawierać tylko litery oraz liczby", "OK");
                    return;
                }
                if(Etr_Password_1.Text != Etr_Password_2.Text)
                {
                    DisplayAlert("Error", "6Hasła są niepoprawne", "OK");
                    return;
                }
                if (!Stch_Company.IsToggled)
                {
                    User User = new User();
                    User.Login = Etr_Login.Text;
                    User.Password = HashPassword.Hash(Etr_Password_1.Text);
                    if (Stch_Admin.IsToggled)
                    {
                        User.AccountTypeID = 2;
                    }
                    else
                    {
                        User.AccountTypeID = 1;
                    }
                    App.DataAccess.InserUser(User);
                    Navigation.PushAsync(new MainTabbedPage(User));
                }
                else
                {
                    if (!CustomValidations.IsCorrectText(Etr_CompanyName.Text))
                    {
                        DisplayAlert("Error", "7Nazwa firmy powinna zawierać tylko litery", "OK");
                        return;
                    }
                    Company Company = new Company();
                    Company.Login = Etr_Login.Text;
                    Company.Name = Etr_CompanyName.Text;
                    Company.Password = HashPassword.Hash(Etr_Password_1.Text);
                    App.DataAccess.Add_Company(Company);
                    Navigation.PushAsync(new MainTabbedPage(Company));
                }
                
            }
            
        }

        private void Stch_Company_Toggled(object sender, ToggledEventArgs e)
        {
            if (!FlagLoginRegister)
            {
                return;
            }
            Stch_Admin.IsToggled = !Stch_Company.IsToggled;
            Lbl_CompnayName.IsVisible = Stch_Company.IsToggled;
            Etr_CompanyName.IsVisible = Stch_Company.IsToggled;
        }

        private void Stch_Admin_Toggled(object sender, ToggledEventArgs e)
        {
            Stch_Company.IsToggled = !Stch_Admin.IsToggled;
        }
    }
}