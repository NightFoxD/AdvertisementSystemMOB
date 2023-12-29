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
	public partial class AdminPanelPage : ContentPage
	{
		public AdminPanelPage ()
		{
			InitializeComponent ();
		}

        private void Btn_Add_Category_Clicked(object sender, EventArgs e)
        {
            List<Category> items = App.DataAccess.GetCategoryList();
            Navigation.PushAsync(new Add_CategoryPage(items));
        }

        private void Btn_Add_PositionLevel_Clicked(object sender, EventArgs e)
        {
            List<PositionLevel> items = App.DataAccess.GetPositionLevelList();
            Navigation.PushAsync(new Add_CategoryPage(items));
        }

        private void Btn_Add_ContractType_Clicked(object sender, EventArgs e)
        {
            List<ContractType> items = App.DataAccess.GetContractList();
            Navigation.PushAsync(new Add_CategoryPage(items));
        }

        private void Btn_Add_WorkTime_Clicked(object sender, EventArgs e)
        {
            List<WorkTime> items = App.DataAccess.GetWorkTimeList();
            Navigation.PushAsync(new Add_CategoryPage(items));
        }

        private void Btn_Add_WorkType_Clicked(object sender, EventArgs e)
        {
            List<WorkType> items = App.DataAccess.GetWorkTypeList();
            Navigation.PushAsync(new Add_CategoryPage(items));
        }
    }
}