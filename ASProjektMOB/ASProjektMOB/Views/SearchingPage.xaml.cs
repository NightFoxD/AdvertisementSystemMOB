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
                if ((string.IsNullOrEmpty(Etr_Name.Text) || item.Name.ToLower().StartsWith(Etr_Name.Text.ToLower())) &&
                    (Pck_Category.SelectedIndex < 0 || item.CategoryID == Pck_Category.Items[Pck_Category.SelectedIndex]) &&
                    (Pck_PositionLevel.SelectedIndex < 0 || item.PositionLevel == Pck_PositionLevel.Items[Pck_PositionLevel.SelectedIndex]) &&
                    (Pck_ContractType.SelectedIndex < 0 || item.ContractType == Pck_ContractType.Items[Pck_ContractType.SelectedIndex]) &&
                    (Pck_WorkingTime.SelectedIndex < 0 || (item.WorkingTime != null && item.WorkingTime.ToLower() == Pck_WorkingTime.Items[Pck_WorkingTime.SelectedIndex].ToString().ToLower())) &&
                    (Pck_WorkType.SelectedIndex < 0 || (item.WorkType != null && item.WorkType.ToLower() == Pck_WorkType.Items[Pck_WorkType.SelectedIndex].ToString().ToLower())) &&
                    (string.IsNullOrEmpty(Etr_City.Text) || item.City.ToLower().StartsWith(Etr_City.Text.ToLower()))
                )
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
            Initialize();
        }

        private void Btn_Filters_Click(object sender, EventArgs e)
        {
            Fr_Filters.IsVisible = !Fr_Filters.IsVisible;
        }
    }
}