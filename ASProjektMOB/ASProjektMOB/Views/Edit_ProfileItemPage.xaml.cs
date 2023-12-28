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
	public partial class Edit_ProfileItemPage : ContentPage
	{
        object Item;
        List<string> Level = new List<string>() { "podstawowe", "wyższe" };
        List<string> LanguageLevel = new List<string>() { "podstawowe", "wyższe", "ojczysty" };
        List<string> Links = new List<string>() { "GitHub", "Facebook" };
        public Edit_ProfileItemPage (object updateItem)
		{
			InitializeComponent ();
            if (updateItem.GetType() == typeof(Experience))
            {
                Item = (Experience)updateItem;
                G_ExperienceWorkForm.BindingContext = (Experience)Item;
                G_ExperienceWorkForm.IsVisible = true;
            }
            else if (updateItem.GetType() == typeof(Education))
            {
                Item = (Education)updateItem;
                G_Education.BindingContext = ((Education)Item);
                Pck_Level.ItemsSource = Level;
                Pck_Level.SelectedItem = ((Education)Item).Level;
                G_Education.IsVisible = true;
            }
            else if (updateItem.GetType() == typeof(Language))
            {
                Item = (Language)updateItem;
                G_Language.BindingContext = ((Language)Item);
                Pck_LanguageLevel.ItemsSource = LanguageLevel;
                Pck_LanguageLevel.SelectedItem = ((Language)Item).Level;
                G_Language.IsVisible = true;
            }
            else if (updateItem.GetType() == typeof(Link))
            {
                Item = (Link)updateItem;
                G_Link.BindingContext = ((Link)Item);
                Pck_LinkType.ItemsSource = Links;
                Pck_LinkType.SelectedItem = ((Link)Item).Type;
                G_Link.IsVisible = true;
            }
        }
       
        private void Btn_Cancel_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        private void Btn_Update_Clicked(object sender, EventArgs e)
        {
            if (Item == null)
            {
                Navigation.PopAsync();
                return;
            }
            if (Item.GetType() == typeof(Experience))
            {
                ((Experience)Item).Position = Etr_Position.Text;
                ((Experience)Item).Localization = Etr_Localization.Text;
                ((Experience)Item).Company = Etr_CompanyName.Text;
                ((Experience)Item).StartPayment = DP_StartPeriod.Date;
                ((Experience)Item).EndPayment = DP_EndPeriod.Date;
                ((Experience)Item).Responsibilities = Etr_Responsibilities.Text;
                App.DataAccess.Update_Experience((Experience)Item);
            }
            else if (Item.GetType() == typeof(Education))
            {
                ((Education)Item).ShoolName = Etr_SchoolName.Text;
                ((Education)Item).Level = Pck_Level.Items[Pck_Level.SelectedIndex];
                ((Education)Item).Direction = Etr_Direction.Text;
                ((Education)Item).StartPeriod = DP_StartEducation.Date;
                ((Education)Item).EndPeriod = DP_EndEducation.Date;
                App.DataAccess.Update_Education((Education)Item);
            }
            else if (Item.GetType() == typeof(Language))
            {
                ((Language)Item).Name = Etr_LanguageName.Text;
                ((Language)Item).Level = Pck_LanguageLevel.Items[Pck_LanguageLevel.SelectedIndex];
                App.DataAccess.Update_Language((Language)Item);
            }
            else if (Item.GetType() == typeof(Link))
            {
                ((Link)Item).Name = Etr_URL.Text;
                ((Link)Item).Type = Pck_LinkType.Items[Pck_LinkType.SelectedIndex];
                App.DataAccess.Update_Link((Link)Item);
            }
            Navigation.PopAsync();
        }
    }
}