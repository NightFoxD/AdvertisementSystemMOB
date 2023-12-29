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
    public partial class CompanyPage : ContentPage
    {
        User User;
        Company Company;
        string tempImage;
        public CompanyPage(Company company, bool editFlag)
        {
            InitializeComponent();
            Company = company;
            if(Company.CompanyImage != null)
            {
                I_ComapnyImage.Source = ImageSource.FromFile(Company.CompanyImage);
            }
            List<AnnouncmentItem> items = new List<AnnouncmentItem>();
            foreach (var item in App.DataAccess.GetAnnouncmentList().Where(item => item.CompanyID == company.CompanyID))
            {
                items.Add(new AnnouncmentItem(item));
            }
            LV_ComapnyAnnouncments.ItemsSource = items;
            SP_CompanyMenu.IsVisible = editFlag;
            Lbl_Jobs.Text = $"{App.DataAccess.GetAnnouncmentList().Where(item => item.CompanyID == company.CompanyID).ToList().Count} ogłoszeń o pracę";
            Lbl_Company.Text = company.Name;
            Lbl_Adress.Text = company.Adress;
            Lbl_Email.Text = company.Email;
            int count = App.DataAccess.GetAnnouncmentList(company).Count;
            if (count == 1)
            {
                Lbl_Jobs.Text = count + " Oferta pracy";
            }
            else if (count < 4 && count > 1)
            {
                Lbl_Jobs.Text = count + " Oferty pracy";
            }
            else
            {
                Lbl_Jobs.Text = count + " Ofert pracy";
            }
        }

        private void Btn_EditCompany_Clicked(object sender, EventArgs e)
        {
            string content = Btn_EditCompany.Text.ToString();
            if (content == "Anuluj")
            {
                Lbl_Company.IsVisible = true;
                TxtB_CompanyEdit.IsVisible = false;
                Lbl_Adress.IsVisible = true;
                TxtB_Adress_Edit.IsVisible = false;
                Lbl_Email.IsVisible = true;
                TxtB_Email_Edit.IsVisible = false;
                Btn_EditCompanyPfp.IsVisible = false;
                Btn_EditCompany.Text = "Edytuj";
            }
            else
            {
                Lbl_Company.IsVisible = false;
                TxtB_CompanyEdit.IsVisible = true;
                Lbl_Adress.IsVisible = false;
                TxtB_Adress_Edit.IsVisible = true;
                Lbl_Email.IsVisible = false;
                TxtB_Email_Edit.IsVisible = true;
                Btn_EditCompanyPfp.IsVisible = true;
                Btn_EditCompany.Text = "Anuluj";
            }
            Btn_SaveEditedCompany.IsVisible = true;
        }

        private void Btn_SaveEditedCompany_Clicked(object sender, EventArgs e)
        {
            if (Company != null)
            {
                Company.Name = TxtB_CompanyEdit.Text;
                Company.Adress = TxtB_Adress_Edit.Text;
                Company.Email = TxtB_Email_Edit.Text;
                Company.CompanyImage = tempImage;
                App.DataAccess.Update_Company(Company);
                Company = App.DataAccess.GetCompanyFromID(Company.CompanyID);
                Lbl_Company.Text = Company.Name;
                Lbl_Adress.Text = Company.Adress;
                Lbl_Email.Text = Company.Email;
                Lbl_Company.IsVisible = true;
                TxtB_CompanyEdit.IsVisible = false;
                Lbl_Adress.IsVisible = true;
                TxtB_Adress_Edit.IsVisible = false;
                Lbl_Email.IsVisible = true;
                TxtB_Email_Edit.IsVisible = false;
                Btn_EditCompanyPfp.IsVisible = false;
                Btn_EditCompany.Text = "Edytuj";
            }
        }

        private async void Btn_EditCompanyPfp_Clicked(object sender, EventArgs e)
        {
            var result = await Xamarin.Essentials.MediaPicker.PickPhotoAsync();
            if (result != null)
            {
                tempImage = result.FullPath;
                I_ComapnyImage.Source = ImageSource.FromFile(result.FullPath);
            }
        }

        private void GoToAnnouncment(object sender, EventArgs e)
        {
            AnnouncmentItem tmpItem = ((Button)sender).CommandParameter as AnnouncmentItem;
            if (tmpItem != null)
            {
                Announcment item = tmpItem.Announcment;
                if (item != null && User != null)
                {
                    Navigation.PushAsync(new AnnouncmentPage(User, item));
                }
                else if (item != null)
                {
                    Navigation.PushAsync(new AnnouncmentPage(item));
                }
            }
        }
    }
}