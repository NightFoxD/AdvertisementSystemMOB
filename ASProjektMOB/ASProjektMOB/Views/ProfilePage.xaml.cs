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
using System.Reflection;
using ASProjektMOB.Models;

namespace ASProjektMOB.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfilePage : ContentPage
    {
        User User;
        string tempImage;
        List<string> countries = new List<string>();
        List<string> Level = new List<string>() { "podstawowe", "wyższe" };
        List<string> LanguageLevel = new List<string>() { "podstawowe", "wyższe", "ojczysty" };
        List<string> Links = new List<string>() { "GitHub", "Facebook" };
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
            Pck_Level.ItemsSource = Level;
            Pck_LanguageLevel.ItemsSource = LanguageLevel;
            Pck_LinkType.ItemsSource = Links;
            if (User.Pfp == null)
            {
                I_UserPfp.Source = "icon_default_company";
            }
            else
            {
                I_UserPfp.Source = ImageSource.FromFile(User.Pfp);
            }
            Initialize_UserData();
            UserDataFormVisibility(false);
            Initialize_ContactData();
            ContactDataFormVisibility(false);
            Initialize_ExperienceWork();
            Initialize_Education();
            Initialize_Language();
            Initialize_Skill();
            Initialize_Link();
            Refresh_UserApplication();
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
            if(User.Pfp != null)
            {
                I_UserPfp.Source = ImageSource.FromFile(User.Pfp);
            }
            
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
            Btn_EditPfp.IsVisible = vis;
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
            User.Pfp = tempImage;
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
        private void Btn_AddFrom_Education_Clicked(object sender, EventArgs e)
        {
            G_EducationForm.IsVisible = true;
        }
        private void Btn_Cancel_Education_Clicked(object sender, EventArgs e)
        {
            G_EducationForm.IsVisible = false;
        }
        public void Initialize_Education()
        {
            G_EducationForm.IsVisible = false;
            if (App.DataAccess.GetEducationList(User).Count > 0)
            {
                LV_Education.IsVisible = true;
                LV_Education.ItemsSource = new ObservableCollection<Education>(App.DataAccess.GetEducationList(User));
            }
            else
            {
                LV_Education.IsVisible = false;
            }
        }
        private void Btn_Add_Education_Clicked(object sender, EventArgs e)
        {
            Education item = new Education();
            item.ShoolName = Etr_SchoolName.Text;
            item.Level = Pck_Level.Items[Pck_Level.SelectedIndex];
            item.Direction = Etr_Direction.Text;
            item.StartPeriod = DP_StartEducation.Date;
            item.EndPeriod = DP_EndEducation.Date;
            item.UserID = User.UserID;
            App.DataAccess.Add_Education(item);
            Initialize_Education();
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
                LV_ExperienceWork.IsVisible = true;
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
            Initialize_ExperienceWork();
        }

        private void Btn_AddFrom_ExperienceWork_Clicked(object sender, EventArgs e)
        {
            G_ExperienceWorkForm.IsVisible = true;
        }
        public void Initialize_Language()
        {
            G_LanguageForm.IsVisible = false;
            if (App.DataAccess.GetLanguageList(User).Count > 0)
            {
                LV_Language.IsVisible = true;
                LV_Language.ItemsSource = new ObservableCollection<Language>(App.DataAccess.GetLanguageList(User));
            }
            else
            {
                LV_Language.IsVisible = false;
            }
        }
        private void Btn_AddFrom_Language_Clicked(object sender, EventArgs e)
        {
            G_LanguageForm.IsVisible = true;
        }

        private void Btn_Cancel_Language_Clicked(object sender, EventArgs e)
        {
            G_LanguageForm.IsVisible = false;
        }

        private void Btn_Add_Language_Clicked(object sender, EventArgs e)
        {
            Language item = new Language();
            item.UserID = User.UserID;
            item.Name = Etr_LanguageName.Text;
            item.Level = Pck_LanguageLevel.Items[Pck_LanguageLevel.SelectedIndex];
            App.DataAccess.Add_Language(item);
            Initialize_Language();
        }
        public void Initialize_Skill()
        {
            G_SkillForm.IsVisible = false;
            if (App.DataAccess.GetSkillList(User).Count > 0)
            {
                LV_Skills.IsVisible = true;
                LV_Skills.ItemsSource = new ObservableCollection<Skill>(App.DataAccess.GetSkillList(User));
            }
            else
            {
                LV_Skills.IsVisible = false;
            }
        }
        private void Btn_AddFrom_Skills_Clicked(object sender, EventArgs e)
        {
            G_SkillForm.IsVisible = true;
        }

        private void Btn_Cancel_Skills_Clicked(object sender, EventArgs e)
        {
            G_SkillForm.IsVisible = false;
        }

        private void Btn_Add_Skills_Clicked(object sender, EventArgs e)
        {
            Skill item = new Skill();
            item.UserID = User.UserID;
            item.Name = Etr_SkillName.Text;
            App.DataAccess.Add_Skills(item);
            Initialize_Skill();
        }
        private void Btn_AddForm_Skills_Clicked(object sender, EventArgs e)
        {
            G_SkillForm.IsVisible = true;
        }
        public void Initialize_Link()
        {
            G_LinkForm.IsVisible = false;
            if (App.DataAccess.GetLinkList(User).Count > 0)
            {
                LV_Link.IsVisible = true;
                LV_Link.ItemsSource = new ObservableCollection<Link>(App.DataAccess.GetLinkList(User));
            }
            else
            {
                LV_Link.IsVisible = false;
            }
        }
        private void Btn_Cancel_Link_Clicked(object sender, EventArgs e)
        {
            G_SkillForm.IsVisible = false;
        }

        private void Btn_Add_Link_Clicked(object sender, EventArgs e)
        {
            Link item = new Link();
            item.User = User.UserID;
            item.Name = Etr_URL.Text;
            item.Type = Pck_LinkType.Items[Pck_LinkType.SelectedIndex];
            App.DataAccess.Add_Link(item);
            Initialize_Link();
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

        private void Del_EducationItem_Clicked(object sender, EventArgs e)
        {
            Education item = ((Button)sender).CommandParameter as Education;
            App.DataAccess.Delete_Education(item);
            Initialize_Education();
        }

        private async void Edit_EducationItem_Clicked(object sender, EventArgs e)
        {
            Education item = ((Button)sender).CommandParameter as Education;
            await Navigation.PushAsync(new Edit_ProfileItemPage(item));
            Initialize_Education();
        }

        private void Del_LanguageItem_Clicked(object sender, EventArgs e)
        {
            Language item = ((Button)sender).CommandParameter as Language;
            App.DataAccess.Delete_Language(item);
            Initialize_Language();
        }

        private async void Edit_LanguageItem_Clicked(object sender, EventArgs e)
        {
            Language item = ((Button)sender).CommandParameter as Language;
            await Navigation.PushAsync(new Edit_ProfileItemPage(item));
            Initialize_Language();
        }

        private void Del_SkillItem_Clicked(object sender, EventArgs e)
        {
            Skill item = ((Button)sender).CommandParameter as Skill;
            App.DataAccess.Delete_Skills(item);
            Initialize_Skill();
        }

        private void Del_Link_Clicked(object sender, EventArgs e)
        {
            Link item = ((Button)sender).CommandParameter as Link;
            App.DataAccess.Delete_Link(item);
            Initialize_Link();
        }

        private async void Edit_Link_Clicked(object sender, EventArgs e)
        {
            Link item = ((Button)sender).CommandParameter as Link;
            await Navigation.PushAsync(new Edit_ProfileItemPage(item));
            Initialize_Link();
        }

        private void Btn_Cancel_Skills_Clicked_1(object sender, EventArgs e)
        {
            G_SkillForm.IsVisible = false;
        }

        private void Btn_AddFrom_Link_Clicked(object sender, EventArgs e)
        {
            G_LinkForm.IsVisible = true;
        }
        public void Refresh_UserApplication()
        {
            var list = new ObservableCollection<AnnouncmentItem>();
            foreach (var application in App.DataAccess.GetApplicationList(User))
            {
                foreach (var announcment in App.DataAccess.GetAnnouncmentList())
                {
                    if (application.AnnouncmentID == announcment.AnnouncmentID)
                    {
                        list.Add(new AnnouncmentItem(announcment));
                    }
                }
            }
            if(list.Count > 0)
            {
                LV_UserApplications.IsVisible = true;
                LV_UserApplications.ItemsSource = list;
            }
            else
            {
                LV_UserApplications.IsVisible = false;
            }
        }
        private void Btn_DeleteApplication(object sender, EventArgs e)
        {
            AnnouncmentItem item = ((Button)sender).CommandParameter as AnnouncmentItem;
            if (item != null)
            {
                Announcment itemAnnouncment = item.Announcment;
                if (itemAnnouncment != null && User != null)
                {
                    List<MyApplication> list = App.DataAccess.GetApplicationList();
                    MyApplication application = new MyApplication();
                    foreach (var itemList in list)
                    {
                        if (itemList.UserID == User.UserDataID && itemList.AnnouncmentID == itemAnnouncment.AnnouncmentID)
                        {
                            application = itemList;
                            break;
                        }
                    }
                    App.DataAccess.Delete_Application(application);
                }
            }
            Refresh_UserApplication();
        }

        private async void Btn_EditPfp_Click(object sender, EventArgs e)
        {
            var result = await Xamarin.Essentials.MediaPicker.PickPhotoAsync();
            if (result != null)
            {
                tempImage = result.FullPath;
                I_UserPfp.Source = ImageSource.FromFile(result.FullPath);
            }
        }
    }
}