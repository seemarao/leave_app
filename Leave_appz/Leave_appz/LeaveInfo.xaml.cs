using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Leave_appz
{
    public partial class LeaveInfo : ContentPage
    {
        public LeaveInfo()
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
                "<div style='font-size: 25px;'><br/<br/> <br/><b>Sick Leave</b></div>" +

                "<br/><div style='font-size: 20px;'>Every employee will be granted 5 days of paid sick leave per year. This cannot be carried forward to next year. Sick leaves of more than 1 day and immediatly before/after weekends/public holiday will require a medical certificate as proof. Sick leave cannot be encashed.</div>" +
                "<br/><div style='background-color:white;height:1px;border: 0px;'></div><br/>" +
                "<div style='font-size: 25px;'> <br/><b>Casual Leave</b></div>" +
                "<br/><div style='font-size: 20px;'>Every employee will be granted 10 days of paid casual leave per year. This cannot be carried forward to next year. It should be notified to the manager at least 1 day before taking the leave. Casual leaves can be taken for only 1 day at a stretch.</div>" +
                "<br/><div style='background-color:white;height:1px;border: 0px;'></div><br/>" +
                "<div style='font-size: 25px;'> <br/><b>Annual Leave</b></div>" +
                "<br/><div style='font-size: 20px;'>Every employee will be granted 10 days of paid annual leave per year. This can be carried forward to next year. A maximum of 30 days leave can be accumulated. It should be notified to the manager at least 1 day before taking the leave. Leaves taken on successive days will be considered as annual leave. </div>" +
                 "<br/><div style='background-color:white;height:1px;border: 0px;'></div> </div>" +
                    "</body>" +
                    "</html>";
            source.Html = text;
            browser.Source = source;
            webViewLayout.Children.Add(browser);
        }
    }
}
