using Xamarin.Forms;

namespace Leave_appz
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new Leave_appzPage();
            //MainPage = new MainPage();

            //MainPage = new EarnedLeaveRequestPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
