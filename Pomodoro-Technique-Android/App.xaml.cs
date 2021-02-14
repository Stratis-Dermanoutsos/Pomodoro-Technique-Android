using Pomodoro_Technique_Android.Backend;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Pomodoro_Technique_Android
{
    public partial class App : Application
    {
        static TodoItemDatabase database;
        public static TodoItemDatabase Database
        {
            get
            {
                if (database == null)
                    database = new TodoItemDatabase();

                return database;
            }
        }

        public App()
        {
            InitializeComponent();

            NavigationPage navPage = new NavigationPage(new MainPage());
            MainPage = navPage;
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
