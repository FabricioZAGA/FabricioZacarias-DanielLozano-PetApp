using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZGAF_DELR_EXAMEN_2P.Data;
using ZGAF_DELR_EXAMEN_2P.Views;

namespace ZGAF_DELR_EXAMEN_2P
{
    public partial class App : Application
    {
        static PetDatabase petDatabase;
        public static PetDatabase PetDatabase
        {
            get
            {
                if (petDatabase == null)
                {
                    petDatabase = new PetDatabase();
                }
                return petDatabase;
            }
        }
        public App()
        {
            InitializeComponent();
            var nav = new NavigationPage(new PetListPage());
            MainPage = nav;
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
