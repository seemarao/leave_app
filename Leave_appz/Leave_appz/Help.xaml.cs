using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Leave_appz
{
    public partial class Help : ContentPage
    {
        public Help()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            var browser = new WebView();
            browser.HorizontalOptions = LayoutOptions.FillAndExpand;
            browser.VerticalOptions = LayoutOptions.FillAndExpand;
            hamburger.Source = ImageSource.FromResource("Leave_appz.Assets.hamburger.png");
            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += (s, e) => {
                AppConstant.mastr.IsPresented = true;
            };
            hamburger.GestureRecognizers.Add(tapGestureRecognizer);

            var source = new HtmlWebViewSource();
            var text = @"<html>" +
                "<head><link href='https://fonts.googleapis.com/css?family=Montserrat'   rel='stylesheet'></head>" +
                "<body background='https://zymolytic-brass.000webhostapp.com/assets/background.png' bgcolor=\"#FB8D00\"  style=\"text-align: justify;color:white;font-family: 'Montserrat';\"><div style=''>" +
                "<div style='font-size: 25px;'><br/<br/> <br/><b>Leave App</b></div>" +

                "<br/><div style='font-size: 20px;'>This app automates and manages employee leave management. No more paper work!! Employees can use this to request different types of leaves. Admin can grant or reject leave to them from the admin app.</div>" +
                "<br/><div style='background-color:white;height:1px;border: 0px;'></div><br/><br/><br/>" +
                "<div style='font-size: 25px;'><b>Contact Us</b></div>" +
                "<br/><div style='font-size: 20px;'>Mobile No : +91 87627837</div>" +
                "<div style='font-size: 20px;'>Email Id : employee@company.io</div>"
                + "<br/><div style='background-color:white;height:1px;border: 0px;'></div> </div>" +
                    "</body>" +
                    "</html>";
            source.Html = text;
            browser.Source = source;
            webViewLayout.Children.Add(browser);
        }
    }
}
