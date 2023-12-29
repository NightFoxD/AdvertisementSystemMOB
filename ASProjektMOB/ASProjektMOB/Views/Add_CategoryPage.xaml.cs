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
	public partial class Add_CategoryPage : ContentPage
	{
        ObservableCollection<Category> itemsCategory;
        ObservableCollection<PositionLevel> itemsPositionLevel;
        ObservableCollection<ContractType> itemsContractType;
        ObservableCollection<WorkTime> itemsWorkTime;
        ObservableCollection<WorkType> itemsWorkType;
        public Add_CategoryPage (List<Category> list)
		{
			InitializeComponent ();
            if (list == null)
            {
                itemsCategory = new ObservableCollection<Category>() { };
            }
            else
            {
                itemsCategory = new ObservableCollection<Category>(list);
            }
            Title = "Kategorie";
            Lbl_CategoryName.Text = "Nazwa kategori: ";
            Refresh();
        }
        public Add_CategoryPage(List<PositionLevel> list)
        {
            InitializeComponent();
            if (list == null)
            {
                itemsPositionLevel = new ObservableCollection<PositionLevel>() { };
            }
            else
            {
                itemsPositionLevel = new ObservableCollection<PositionLevel>(list);
            }
            Title = "Poziom stanowiska";
            Lbl_CategoryName.Text = "Nazwa poziomu stanowiska: ";
            Refresh();
        }
        public Add_CategoryPage(List<ContractType> list)
        {
            InitializeComponent();
            if (list == null)
            {
                itemsContractType = new ObservableCollection<ContractType>() { };
            }
            else
            {
                itemsContractType = new ObservableCollection<ContractType>(list);
            }
            Title = "Rodzaj umowy";
            Lbl_CategoryName.Text = "Nazwa rodzaju umowy: ";
            Refresh();
        }
        public Add_CategoryPage(List<WorkTime> list)
        {
            InitializeComponent();
            if (list == null)
            {
                itemsWorkTime = new ObservableCollection<WorkTime>() { };
            }
            else
            {
                itemsWorkTime = new ObservableCollection<WorkTime>(list);
            }
            Title = "Wymiar pracy";
            Lbl_CategoryName.Text = "Nazwa wymiaru pracy: ";
            Refresh();
        }
        public Add_CategoryPage(List<WorkType> list)
        {
            InitializeComponent();
            if (list == null)
            {
                itemsWorkType = new ObservableCollection<WorkType>() { };
            }
            else
            {
                itemsWorkType = new ObservableCollection<WorkType>(list);
            }
            Title = "Tryb pracy";
            Lbl_CategoryName.Text = "Nazwa trybu pracy: ";
            Refresh();
        }
        private void Del_Category_Clicked(object sender, EventArgs e)
        {
            Type itemType = ((Button)sender).CommandParameter.GetType();
            if (itemType == typeof(Category))
            {
                Category item = ((Button)sender).CommandParameter as Category;

                App.DataAccess.Delete_Category(item);
            }
            else if (itemType == typeof(PositionLevel))
            {
                PositionLevel item = ((Button)sender).CommandParameter as PositionLevel;
                App.DataAccess.Delete_PositionLevel(item);
            }
            else if (itemType == typeof(ContractType))
            {
                ContractType item = ((Button)sender).CommandParameter as ContractType;
                App.DataAccess.Delete_ContractType(item);
            }
            else if (itemType == typeof(WorkTime))
            {
                WorkTime item = ((Button)sender).CommandParameter as WorkTime;
                App.DataAccess.Delete_WorkTime(item);
            }
            else if (itemType == typeof(WorkType))
            {
                WorkType item = ((Button)sender).CommandParameter as WorkType;
                App.DataAccess.Delete_WorkType(item);
            }
            Refresh();
        }

        private void Btn_AddCategory_Clicked(object sender, EventArgs e)
        {
            if (itemsCategory != null)
            {
                Category newItem = new Category();
                newItem.Name = Text_Item_Content.Text;
                App.DataAccess.Add_Category(newItem);
            }
            else if (itemsContractType != null)
            {
                ContractType newItem = new ContractType();
                newItem.Name = Text_Item_Content.Text;
                App.DataAccess.Add_ContractType(newItem);
            }
            else if (itemsPositionLevel != null)
            {
                PositionLevel newItem = new PositionLevel();
                newItem.Name = Text_Item_Content.Text;
                App.DataAccess.Add_PositionLevel(newItem);
            }
            else if (itemsWorkTime != null)
            {
                WorkTime newItem = new WorkTime();
                newItem.Name = Text_Item_Content.Text;
                App.DataAccess.Add_WorkTime(newItem);
            }
            else if (itemsWorkType != null)
            {
                WorkType newItem = new WorkType();
                newItem.Name = Text_Item_Content.Text;
                App.DataAccess.Add_WorkType(newItem);
            }
            Text_Item_Content.Text = "";
            Refresh();
        }
        public void Refresh()
        {
            if (itemsCategory != null)
            {
                LV_Items.ItemsSource = new ObservableCollection<Category>(App.DataAccess.GetCategoryList());
            }
            else if (itemsContractType != null)
            {
                LV_Items.ItemsSource = new ObservableCollection<ContractType>(App.DataAccess.GetContractList());
            }
            else if (itemsPositionLevel != null)
            {
                LV_Items.ItemsSource = new ObservableCollection<PositionLevel>(App.DataAccess.GetPositionLevelList());
            }
            else if (itemsWorkTime != null)
            {
                LV_Items.ItemsSource = new ObservableCollection<WorkTime>(App.DataAccess.GetWorkTimeList());
            }
            else if (itemsWorkType != null)
            {
                LV_Items.ItemsSource = new ObservableCollection<WorkType>(App.DataAccess.GetWorkTypeList());
            }
        }
    }
}