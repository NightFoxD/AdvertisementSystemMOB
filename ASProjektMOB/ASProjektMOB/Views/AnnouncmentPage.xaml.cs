using ASProjektMOB.Models;
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
    public partial class AnnouncmentPage : ContentPage
    {
        AnnouncmentItem item;
        User User;
        public AnnouncmentPage(User user, Announcment announcment)
        {
            InitializeComponent();
            User = user;
            item = new AnnouncmentItem(announcment);
            G_Page.BindingContext = item;
            LV_Responsibilities.ItemsSource = item.Responsibilities;
            LV_Requirements.ItemsSource = item.Requirements;
            LV_Benefits.ItemsSource = item.Benefits;
            Lbl_Adress.Text = item.City;
            DateTime? date = item.EndDate;
            if (date != null)
            {
                Lbl_EndDate.Text = $"Do: {date.Value.Day}.{date.Value.Month}.{date.Value.Year}";
            }
            Lbl_Position.Text = item.PositionName;
            Lbl_WorkTime.Text = item.WorkingTime;
            Lbl_PositionLevel.Text = item.PositionLevel;
            Lbl_WorkType.Text = item.WorkType;

            if (App.DataAccess.GetApplicationList().Where(item => item.AnnouncmentID == announcment.AnnouncmentID).Any())
            {
                int? id = App.DataAccess.GetApplicationList().Where(item => item.AnnouncmentID == announcment.AnnouncmentID).First().UserID;
                if (id != null && id == user.UserID)
                {
                    Btn_Application.IsVisible = false;
                }
                else
                {
                    Btn_Application.IsVisible = true;
                }
            }
            else
            {
                if (user.AccountTypeID == 1)
                {
                    Btn_Application.IsVisible = true;
                }

            }
            if(item.CompanyImage == null)
            {
                I_ComapnyImage.Source = "icon_default_company";
            }
            else
            {
                I_ComapnyImage.Source = ImageSource.FromFile(item.CompanyImage);
            }
            
        }
        public AnnouncmentPage(Announcment announcment)
        {
            InitializeComponent();
            item = new AnnouncmentItem(announcment);
            G_Page.BindingContext = item;
            LV_Responsibilities.ItemsSource = item.Responsibilities;
            LV_Requirements.ItemsSource = item.Requirements;
            LV_Benefits.ItemsSource = item.Benefits;
            Lbl_Adress.Text = item.City;
            DateTime? date = item.EndDate;
            if (date != null)
            {
                Lbl_EndDate.Text = $"Do: {date.Value.Day}.{date.Value.Month}.{date.Value.Year}";
            }
            Lbl_Position.Text = item.PositionName;
            Lbl_WorkTime.Text = item.WorkingTime;
            Lbl_PositionLevel.Text = item.PositionLevel;
            Lbl_WorkType.Text = item.WorkType;
        }
        private void Btn_Application_Clicked(object sender, EventArgs e)
        {
            if (User != null && this.item != null)
            {
                MyApplication item = new MyApplication();
                item.AnnouncmentID = this.item.AnnouncmentID;
                item.UserID = User.UserID;
                App.DataAccess.Add_Application(item);
                DisplayAlert("Powiadomienie","Zaaplikowałeś się do ogłoszenia!","OK");
                Btn_Application.IsVisible = false;
            }
        }
    }
}