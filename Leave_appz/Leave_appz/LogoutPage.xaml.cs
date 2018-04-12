using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Leave_appz
{
    public partial class LogoutPage : ContentPage
    {
        public LogoutPage()
        {
            InitializeComponent();
            AppConstant.mastr.IsGestureEnabled = false;
            if (Application.Current.Properties.ContainsKey("email") && Application.Current.Properties.ContainsKey("password"))
            {
                Application.Current.Properties.Remove("email");  
                Application.Current.Properties.Remove("password");  
            }
            Navigation.PushAsync(new Leave_appzPage());
        }
        public static void logout(){
            if (Application.Current.Properties.ContainsKey("email") && Application.Current.Properties.ContainsKey("password"))
            {
                Application.Current.Properties.Remove("email");
                Application.Current.Properties.Remove("password");
            }
        }
    }
}
