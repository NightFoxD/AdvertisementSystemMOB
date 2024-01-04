using ASProjektWPF.Classes;
using ASProjektWPF.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ASProjektMOB.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddEdit_AnnouncmentPage : ContentPage
    {
        Company Company;
        Announcment AddEdit_Announcment;
        ObservableCollection<Item> itemsResponsibilities = new ObservableCollection<Item>();
        ObservableCollection<Item> itemsBenefits = new ObservableCollection<Item>();
        ObservableCollection<Item> itemsRequirements = new ObservableCollection<Item>();
        
        public AddEdit_AnnouncmentPage(Company company)
        {
            InitializeComponent();
            Company = company;
            foreach (var item in App.DataAccess.GetPositionLevelList())
            {
                Pck_PositionLevel.Items.Add(item.Name);
            }
            foreach (var item in App.DataAccess.GetContractList())
            {
                Pck_ContractType.Items.Add(item.Name);
            }
            foreach (var item in App.DataAccess.GetWorkTypeList())
            {
                Pck_WorkType.Items.Add(item.Name);
            }
            foreach (var item in App.DataAccess.GetWorkTimeList())
            {
                Pck_WorkTime.Items.Add(item.Name);
            }
            foreach (var item in App.DataAccess.GetCategoryList())
            {
                Pck_Category.Items.Add(item.Name);
            }
            Btn_AddUpdateAnnouncment.Text = "Dodaj ogłoszenie";
            Refresh();
        }
        public AddEdit_AnnouncmentPage(Company company, Announcment edit_Announcment)
        {
            InitializeComponent();
            Company = company;
            AddEdit_Announcment = edit_Announcment;
            Etr_Name.Text = edit_Announcment.Name;
            Etr_PositionName.Text = edit_Announcment.PositionName;
            foreach (var item in App.DataAccess.GetPositionLevelList())
            {
                Pck_PositionLevel.Items.Add(item.Name);
            }
            foreach (var item in App.DataAccess.GetContractList())
            {
                Pck_ContractType.Items.Add(item.Name);
            }
            foreach (var item in App.DataAccess.GetWorkTypeList())
            {
                Pck_WorkType.Items.Add(item.Name);
            }
            foreach (var item in App.DataAccess.GetWorkTimeList())
            {
                Pck_WorkTime.Items.Add(item.Name);
            }
            foreach (var item in App.DataAccess.GetCategoryList())
            {
                Pck_Category.Items.Add(item.Name);
            }
            Pck_PositionLevel.SelectedItem = edit_Announcment.PositionLevel;
            Pck_ContractType.SelectedItem = edit_Announcment.ContractType;
            Pck_WorkType.SelectedItem = edit_Announcment.WorkType;
            Pck_WorkTime.SelectedItem = edit_Announcment.WorkingTime;
            Pck_Category.SelectedItem = edit_Announcment.CategoryID;
            string[] announcmentRequirements = { };
            if (edit_Announcment.Requirements != null && edit_Announcment.Requirements != "")
            {
                announcmentRequirements = edit_Announcment.Requirements.Split(';');
                foreach (var item in announcmentRequirements)
                {
                    itemsRequirements.Add(new Item(item));
                }
            }

            LV_Requirements.ItemsSource = itemsRequirements;
            string[] announcmentResponsibilities = { };
            if (edit_Announcment.Responsibilities != null && edit_Announcment.Responsibilities != "")
            {
                announcmentResponsibilities = edit_Announcment.Responsibilities.Split(';');
                foreach (var item in announcmentResponsibilities)
                {
                    itemsResponsibilities.Add(new Item(item));
                }
            }

            LV_Responsibilities.ItemsSource = itemsResponsibilities;
            string[] announcmentBenefits = { };
            if (edit_Announcment.Benefits != null && edit_Announcment.Benefits != "")
            {
                announcmentBenefits = edit_Announcment.Benefits.Split(';');
                foreach (var item in announcmentBenefits)
                {
                    itemsBenefits.Add(new Item(item));
                }
            }

            LV_Benefits.ItemsSource = itemsBenefits;
            Etr_Description.Text = edit_Announcment.Description;
            Etr_City.Text = edit_Announcment.City;
            DP_EndDate.Date = edit_Announcment.EndDate;
            Btn_AddUpdateAnnouncment.Text = "Edytuj ogłoszenie";
            Refresh();
        }
        public void Refresh()
        {
            LV_Responsibilities.IsVisible = itemsResponsibilities.Any();
            LV_Requirements.IsVisible = itemsRequirements.Any();
            LV_Benefits.IsVisible = itemsBenefits.Any();
            LV_Responsibilities.ItemsSource = itemsResponsibilities;
            LV_Requirements.ItemsSource = itemsRequirements;
            LV_Benefits.ItemsSource = itemsBenefits;
            
        }
        private void Btn_DelResponsibilityItem_Click(object sender, EventArgs e)
        {
            Item item = ((Button)sender).CommandParameter as Item;
            itemsResponsibilities.Remove(item);
            Refresh();
        }

        private void Btn_AddResponsible_Clicked(object sender, EventArgs e)
        {
            Item item = new Item(Etr_Responsibility_Content.Text);
            itemsResponsibilities.Add(item);
            Etr_Responsibility_Content.Text = "";
            Refresh();
        }

        private void Btn_DelRequirementsItem_Click(object sender, EventArgs e)
        {
            Item item = ((Button)sender).CommandParameter as Item;
            itemsRequirements.Remove(item);
            Refresh();
        }

        private void Btn_AddRequriement_Clicked(object sender, EventArgs e)
        {
            Item item = new Item(Etr_Requirement_Content.Text);
            itemsRequirements.Add(item);
            Etr_Requirement_Content.Text = "";
            Refresh();
        }
        private void Btn_DelBenefitItem_Click(object sender, EventArgs e)
        {
            Item item = ((Button)sender).CommandParameter as Item;
            itemsBenefits.Remove(item);
            Refresh();
        }        
        private void Btn_AddBenefit_Clicked(object sender, EventArgs e)
        {
            Item item = new Item(Etr_Benefit_Content.Text);
            itemsBenefits.Add(item);
            Etr_Benefit_Content.Text = "";
            Refresh();
        }        
        private void Btn_AddUpdateAnnouncment_Clicked(object sender, EventArgs e)
        {
            if (AddEdit_Announcment == null)
            {
                AddEdit_Announcment = new Announcment();
                AddEdit_Announcment.CompanyID = Company.CompanyID;
                AddEdit_Announcment.Name = Etr_Name.Text;
                AddEdit_Announcment.Description = Etr_Description.Text;
                AddEdit_Announcment.CategoryID = Pck_Category.Items[Pck_Category.SelectedIndex];
                AddEdit_Announcment.PositionName = Etr_PositionName.Text;
                AddEdit_Announcment.PositionLevel = Pck_PositionLevel.Items[Pck_PositionLevel.SelectedIndex];
                AddEdit_Announcment.ContractType = Pck_ContractType.Items[Pck_ContractType.SelectedIndex];
                AddEdit_Announcment.WorkType = Pck_WorkType.Items[Pck_WorkType.SelectedIndex];
                AddEdit_Announcment.WorkingTime = Pck_WorkTime.Items[Pck_WorkTime.SelectedIndex];
                AddEdit_Announcment.Requirements = string.Join(";", itemsRequirements.Select(item => item.Content));
                AddEdit_Announcment.Benefits = string.Join(";", itemsBenefits.Select(item => item.Content));
                AddEdit_Announcment.Responsibilities = string.Join(";", itemsResponsibilities.Select(item => item.Content));
                AddEdit_Announcment.StartDate = DateTime.Now;
                AddEdit_Announcment.EndDate = DP_EndDate.Date;
                AddEdit_Announcment.City = Etr_City.Text;
                App.DataAccess.Add_Announcment(AddEdit_Announcment);
            }
            else
            {
                AddEdit_Announcment.Name = Etr_Name.Text;
                AddEdit_Announcment.Description = Etr_Description.Text;
                AddEdit_Announcment.CategoryID = Pck_Category.Items[Pck_Category.SelectedIndex];
                AddEdit_Announcment.PositionName = Etr_PositionName.Text;
                AddEdit_Announcment.PositionLevel = Pck_PositionLevel.Items[Pck_PositionLevel.SelectedIndex];
                AddEdit_Announcment.ContractType = Pck_ContractType.Items[Pck_ContractType.SelectedIndex];
                AddEdit_Announcment.WorkType = Pck_WorkType.Items[Pck_WorkType.SelectedIndex];
                AddEdit_Announcment.WorkingTime = Pck_WorkTime.Items[Pck_WorkTime.SelectedIndex];
                AddEdit_Announcment.Benefits = string.Join(";", itemsBenefits.Select(item => item.Content));
                AddEdit_Announcment.Requirements = string.Join(";", itemsRequirements.Select(item => item.Content));
                AddEdit_Announcment.Responsibilities = string.Join(";", itemsResponsibilities.Select(item => item.Content));
                AddEdit_Announcment.StartDate = DateTime.Now;
                AddEdit_Announcment.EndDate = DP_EndDate.Date;
                AddEdit_Announcment.City = Etr_City.Text;
                App.DataAccess.Update_Announcment(AddEdit_Announcment);
            }
            Navigation.PopAsync();
        }
    }
}