using ASProjektWPF.Classes;
using ASProjektWPF.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ASProjektMOB.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SearchingPage : ContentPage
	{
		User User;
		public SearchingPage ()
		{
			InitializeComponent ();
            Initialize();
        }
        public SearchingPage(User user)
        {
            InitializeComponent();
			User = user;
            Initialize();
        }
        public List<AnnouncmentItem> GetAnnouncmentAllInformations()
        {
            List<AnnouncmentItem> items = new List<AnnouncmentItem>();
            foreach (var item in App.DataAccess.GetAnnouncmentList())
            {
                bool nameCondition = string.IsNullOrEmpty(Etr_Name.Text) || item.Name.ToLower().StartsWith(Etr_Name.Text.ToLower());
                bool nameCity = string.IsNullOrEmpty(Etr_City.Text) || item.City.ToLower().StartsWith(Etr_City.Text.ToLower());
                bool categoryCondition = Pck_Category.SelectedIndex < 0 || item.CategoryID == Pck_Category.Items[Pck_Category.SelectedIndex];
                bool positionLevelCondition = Pck_PositionLevel.SelectedIndex < 0 || item.PositionLevel == Pck_PositionLevel.Items[Pck_PositionLevel.SelectedIndex];
                bool contractTypeCondition = Pck_ContractType.SelectedIndex < 0 || item.ContractType == Pck_ContractType.Items[Pck_ContractType.SelectedIndex];
                bool workingTimeCondition = Pck_WorkingTime.SelectedIndex < 0 || item.ContractType == Pck_WorkingTime.Items[Pck_WorkingTime.SelectedIndex];
                bool workTypeCondition = Pck_WorkType.SelectedIndex < 0 || item.ContractType == Pck_WorkType.Items[Pck_WorkType.SelectedIndex];

                if (nameCondition && categoryCondition && positionLevelCondition && contractTypeCondition && workingTimeCondition && workTypeCondition && nameCity)
                {
                    items.Add(new AnnouncmentItem(item));
                }
            }
            return items;
        }
        public void Initialize()
        {
            Pck_Category.Items.Clear();
            foreach (var item in App.DataAccess.GetCategoryList())
            {
                Pck_Category.Items.Add(item.Name);
            }
            Pck_PositionLevel.Items.Clear();
            foreach (var item in App.DataAccess.GetPositionLevelList())
            {
                Pck_PositionLevel.Items.Add(item.Name);
            }
            Pck_ContractType.Items.Clear();
            foreach (var item in App.DataAccess.GetContractList())
            {
                Pck_ContractType.Items.Add(item.Name);
            }
            Pck_WorkingTime.Items.Clear();
            foreach (var item in App.DataAccess.GetWorkTimeList())
            {
                Pck_WorkingTime.Items.Add(item.Name);
            }
            Pck_WorkType.Items.Clear();
            foreach (var item in App.DataAccess.GetWorkTypeList())
            {
                Pck_WorkType.Items.Add(item.Name);
            }
            LV_Announcments.ItemsSource = new ObservableCollection<AnnouncmentItem>(GetAnnouncmentAllInformations());
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

        private void Btn_SearchAnnouncment_Click(object sender, EventArgs e)
        {
            LV_Announcments.ItemsSource = new ObservableCollection<AnnouncmentItem>(GetAnnouncmentAllInformations());
            Fr_Filters.IsVisible = false;
        }

        private void Btn_Filters_Click(object sender, EventArgs e)
        {
            Fr_Filters.IsVisible = !Fr_Filters.IsVisible;
        }

        private void IB_ClearCategory_Click(object sender, EventArgs e)
        {
            Pck_Category.SelectedItem = null;
        }

        private void IB_ClearPositionLevel_Click(object sender, EventArgs e)
        {
            Pck_PositionLevel.SelectedItem = null;
        }

        private void IB_ClearContractType_Click(object sender, EventArgs e)
        {
            Pck_ContractType.SelectedItem = null;
        }

        private void IB_ClearWorkingTime_Click(object sender, EventArgs e)
        {
            Pck_WorkingTime.SelectedItem = null;  
        }

        private void IB_ClearWorkType_Click(object sender, EventArgs e)
        {
            Pck_WorkType.SelectedItem = null;
        }

        private void IB_ClearCity_Click(object sender, EventArgs e)
        {
            Etr_City.Text = string.Empty;
        }
    }
}