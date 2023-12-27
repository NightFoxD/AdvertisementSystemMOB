using AdvertisementSystem.Classes;
using ASProjektMOB.Views;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ASProjektMOB
{
    public partial class App : Application
    {
        static DataAccess Database;

        public static DataAccess DataAccess
        {
            get
            {
                if (Database == null)
                {
                    Database = new DataAccess(Path.Combine(Directory.GetCurrentDirectory(), "AdvertisementSystem_Mob.db3"));
                }
                return Database;
            }
        }
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new MainTabbedPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
