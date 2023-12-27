using ASProjektWPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ASProjektWPF.Classes;
using System.Collections.ObjectModel;

namespace ASProjektMOB.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfilePage : ContentPage
    {
        User User;
        List<string> countries = new List<string>();
        public ProfilePage(User user)
        {
            InitializeComponent();
            User = user;
            countries = GetListOfCountries();
            countries.Sort();
            foreach (string country in countries)
            {
                Pckr_Country.Items.Add(country);
            }
            Initialize_UserData();
            UserDataFormVisibility(false);
            Initialize_ContactData();
            ContactDataFormVisibility(false);
            Initialize_ExperienceWork();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            Initialize_ExperienceWork();
        }
        private List<string> GetListOfCountries()
        {
            List<string> countries = new List<string>();

            foreach (CultureInfo ci in CultureInfo.GetCultures(CultureTypes.SpecificCultures))
            {
                RegionInfo region = new RegionInfo(ci.Name);
                string countryName = region.DisplayName;

                if (!countries.Contains(countryName))
                {
                    countries.Add(countryName);
                }
            }
            return countries;
        }

        public void Initialize_UserData()
        {
            Lbl_Name.Text = User.Name;
            Lbl_Surname.Text = User.Surname;
            Lbl_CurrentOccupation.Text = User.CurrentOccupation;
            Lbl_Country.Text = User.Country;
            Lbl_City.Text = User.City;
            Etr_Name.Text = User.Name;
            Etr_Surname.Text = User.Surname;
            Etr_CurrentOccupation.Text = User.CurrentOccupation;
            Pckr_Country.SelectedItem = User.Country;
            Etr_City.Text = User.City;
        }
        public void UserDataFormVisibility(bool vis)
        {
            Lbl_Name.IsVisible = !vis;
            Lbl_Surname.IsVisible = !vis;
            Lbl_CurrentOccupation.IsVisible = !vis;
            Lbl_Country.IsVisible = !vis;
            Lbl_City.IsVisible = !vis;
            Etr_Name.IsVisible = vis;
            Etr_Surname.IsVisible = vis;
            Etr_CurrentOccupation.IsVisible = vis;
            Pckr_Country.IsVisible = vis;
            Etr_City.IsVisible = vis;
            Btn_Cancel_UserData.IsVisible = vis;
            Btn_Save_UserData.IsVisible = vis;
        }
        private void Btn_Edit_UserData_Clicked(object sender, EventArgs e)
        {
            UserDataFormVisibility(true);
        }
        private void Btn_Cancel_UserData_Clicked(object sender, EventArgs e)
        {
            Initialize_UserData();
            UserDataFormVisibility(false);
        }
        private void Btn_Save_UserData_Clicked(object sender, EventArgs e)
        {
            if (!CustomValidations.IsCorrectText(Etr_Name.Text) && !CustomValidations.IsCorrectText(Etr_Surname.Text)
                && !CustomValidations.IsCorrectText(Etr_CurrentOccupation.Text) && !CustomValidations.IsCorrectText(Etr_City.Text))
            {
                DisplayAlert("Error", "Nie wolno wpisywać liczb! ", "OK");
                return;
            }
            User.Name = Etr_Name.Text;
            User.Surname = Etr_Surname.Text;
            User.CurrentOccupation = Etr_CurrentOccupation.Text;
            User.Country = Pckr_Country.Items[Pckr_Country.SelectedIndex];
            User.City = Etr_City.Text;
            App.DataAccess.UpdateUser(User);
            User = App.DataAccess.GetUser(User);
            Initialize_UserData();
            UserDataFormVisibility(false);
        }
        public void Initialize_ContactData()
        {
            Lbl_Email.Text = User.Email;
            Lbl_PhoneNumber.Text = User.TelephoneNumber.ToString();
            Lbl_BirthDate.Text = User.BirthDate.ToString("MM/dd/yyyy");
            Etr_Email.Text = User.Email;
            Etr_PhoneNumber.Text = User.TelephoneNumber.ToString();
            Etr_BirthDate.Date = User.BirthDate;
        }
        public void ContactDataFormVisibility(bool vis)
        {
            Lbl_Email.IsVisible = !vis;
            Lbl_PhoneNumber.IsVisible = !vis;
            Lbl_BirthDate.IsVisible = !vis;
            Etr_Email.IsVisible = vis;
            Etr_PhoneNumber.IsVisible = vis;
            Etr_BirthDate.IsVisible = vis;
            Btn_Cancel_ContactData.IsVisible = vis;
            Btn_Save_ContactData.IsVisible = vis;
        }
        private void Btn_Edit_ContactData_Clicked(object sender, EventArgs e)
        {
            ContactDataFormVisibility(true);
        }
        private void Btn_Cancel_ContactData_Clicked(object sender, EventArgs e)
        {
            Initialize_UserData();
            ContactDataFormVisibility(false);
        }
        
        private void Btn_Save_ContactData_Clicked(object sender, EventArgs e)
        {
            if (!CustomValidations.IsCorrectEmail(Etr_Email.Text))
            {
                DisplayAlert("Error", "Niepoprawny email! ", "OK");
                return;
            }
            if (!CustomValidations.IsCorrectNumbers(Etr_PhoneNumber.Text))
            {
                DisplayAlert("Error", "Niepoprawny numer telefonu! ", "OK");
                return;
            }
            if (Etr_BirthDate.Date == null)
            {
                DisplayAlert("Error", "Wybierz date urodzin! ", "OK");
                return;
            }
            User.Email = Etr_Email.Text;
            User.TelephoneNumber = int.Parse(Etr_PhoneNumber.Text);
            User.BirthDate = Etr_BirthDate.Date;
            App.DataAccess.UpdateUser(User);
            User = App.DataAccess.GetUser(User);
            Initialize_ContactData();
            ContactDataFormVisibility(false);
        }

        public void EducationFormVisibility(bool vis)
        {

        }
        private void Btn_AddFrom_Education_Clicked(object sender, EventArgs e)
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
            G_ExperienceWorkForm.IsVisible = false;
        }
        public  void Initialize_ExperienceWork()
        {
            G_ExperienceWorkForm.IsVisible = false;
            if (App.DataAccess.GetExperienceList(User).Count > 0)
            {
                LV_ExperienceWork.ItemsSource = new ObservableCollection<Experience>(App.DataAccess.GetExperienceList(User));
            }
            else
            {
                LV_ExperienceWork.IsVisible = false;
            }
        }
        private void Btn_Add_ExperienceWork_Clicked(object sender, EventArgs e)
        {
            G_ExperienceWorkForm.IsVisible = false;
            Experience item = new Experience();
            item.Position = Etr_Position.Text;
            item.Localization = Etr_Localization.Text;
            item.Company = Etr_CompanyName.Text;
            item.StartPayment = DP_StartPeriod.Date;
            item.EndPayment = DP_EndPeriod.Date;
            item.Responsibilities = Etr_Responsibilities.Text;
            item.UserID = User.UserID;
            App.DataAccess.Add_Experience(item);
            if(App.DataAccess.GetExperienceList(User).Count > 0)
            {
                 LV_ExperienceWork.ItemsSource =  new ObservableCollection<Experience>(App.DataAccess.GetExperienceList(User));
            }
            else
            {
                LV_ExperienceWork.IsVisible = false;
            }
        }

        private void Btn_AddFrom_ExperienceWork_Clicked(object sender, EventArgs e)
        {
            G_ExperienceWorkForm.IsVisible = true;
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

        private void Del_ExperienceWorkItem_Clicked(object sender, EventArgs e)
        {
            Experience item = ((Button)sender).CommandParameter as Experience;
            App.DataAccess.Delete_Experience(item);
            Initialize_ExperienceWork();
        }

        private async void Edit_ExperienceWorkItem_Clicked(object sender, EventArgs e)
        {
            Experience item = ((Button)sender).CommandParameter as Experience;
            await Navigation.PushAsync(new Edit_ProfileItemPage(item));
            Initialize_ExperienceWork();
        }
    }
}