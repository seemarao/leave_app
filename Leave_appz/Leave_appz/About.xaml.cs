using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Leave_appz
{
    public partial class About : ContentPage
    {
        public About()
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
                "<br/><div style='font-size: 20px;'>Version 1.0</div>" +
                "<div style='font-size: 20px;'>Beta release</div>" +
                "<div style='font-size: 20px;'>Copyright(c) Prueba India Software Pvt. Ltd. 2018 </div>" +
                "<div style='font-size: 20px;'>All rights reserved</div>" +

                "<br/><div style='background-color:white;height:1px;border: 0px;'></div><br/><br/><br/>" +
                "<div style='font-size: 25px;'><b>Thanks To</b></div>" +
                "<br/><div style='font-size: 20px;'>Nikhil I - App designer and Developer</div>" +
                "<div style='font-size: 20px;'>Pratik Kamath - Developer </div>" +
                "<div style='font-size: 20px;'>Seema Rao Kordcal - Quality Analyst </div>" +
                "<div style='font-size: 20px;'>Shambhavi Salian - Developer </div>" +
                "<div style='font-size: 20px;'>Lathika Shetty - Developer </div>" +
                "<div style='font-size: 20px;'>Sharath Kumar - Developer </div>" +
                "<br/><div style='font-size: 20px;'>Made with Love for Prueba</div>"
                + "<br/><div style='background-color:white;height:1px;border: 0px;'></div> </div>" +
                    "</body>" +
                    "</html>";
            source.Html = text;
            browser.Source = source;
            webViewLayout.Children.Add(browser);
        }
    }
}
