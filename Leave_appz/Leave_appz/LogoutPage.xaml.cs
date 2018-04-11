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
            Navigation.PushAsync(new Leave_appzPage());
        }
    }
}
