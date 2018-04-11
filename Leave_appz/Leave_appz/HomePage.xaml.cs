using System;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace Leave_appz
{
    public partial class HomePage : ContentPage
    {
        WebView browser;

        public HomePage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            backgroundImage.Source = ImageSource.FromResource("Leave_appz.Assets.background.png");
            hamburger.Source = ImageSource.FromResource("Leave_appz.Assets.hamburger.png");

            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += (s, e) => {
                AppConstant.mastr.IsPresented = true;
            };
            hamburger.GestureRecognizers.Add(tapGestureRecognizer);

            browser = leaveDetailsWV;
            browser.HorizontalOptions = LayoutOptions.FillAndExpand;
            browser.VerticalOptions = LayoutOptions.FillAndExpand;


            var source = new HtmlWebViewSource();

            var text = @"<html>" +
                "<head><link href='https://fonts.googleapis.com/css?family=Montserrat'   rel='stylesheet'></head>" +
                "<body background='https://zymolytic-brass.000webhostapp.com/assets/background.png' bgcolor=\"#FB8D00\"  style=\"text-align: justify;color:white;font-family: 'Montserrat';\">" +
                    "<div>Loading...!</div>" +
                    "</body>" +
                    "</html>";
            source.Html = text;
            browser.Source = source;
            if (Application.Current.Properties.ContainsKey("email"))
            {
                var email = Application.Current.Properties["email"] as String;
                PostRequest(AppConstant.URL, email);
                setLeaveCount(AppConstant.URL, email, "0");
                setLeaveCount(AppConstant.URL, email, "1");
                setLeaveCount(AppConstant.URL, email, "2");
                userName.Text = email;
            }

        }


        async void PostRequest(string URL, string userNam)
        {
            System.Diagnostics.Debug.WriteLine("asa");
            var formContent = new FormUrlEncodedContent(new[]
                {
               new KeyValuePair<string, string>("id", "13"),
               new KeyValuePair<string, string>("useremail", userNam),

           });

            var myHttpClient = new HttpClient();
            var response = await myHttpClient.PostAsync(URL, formContent);

            var json = await response.Content.ReadAsStringAsync();
            System.Diagnostics.Debug.WriteLine(json);
            int index = json.IndexOf("<img", 0);
            if (index != -1)
            {

                var source = new HtmlWebViewSource();
                System.Diagnostics.Debug.WriteLine(json.Substring(0, index));
                var text = json.Substring(0, index);
                source.Html = text;
                browser.Source = source;
            }
            else
            {
                var source = new HtmlWebViewSource();

                var text = json;
                source.Html = text;
                browser.Source = source;
            }

        }


        async void setLeaveCount(string URL, string userName, string typeOfLeave)
        {
            System.Diagnostics.Debug.WriteLine("asa");
            var formContent = new FormUrlEncodedContent(new[]
                {
                new KeyValuePair<string, string>("id", "6"),
                new KeyValuePair<string, string>("useremail", userName),
                new KeyValuePair<string, string>("type_of_leave", typeOfLeave),
            });

            var myHttpClient = new HttpClient();
            var response = await myHttpClient.PostAsync(URL, formContent);

            var json = await response.Content.ReadAsStringAsync();
            System.Diagnostics.Debug.WriteLine(json);

            try
            {
                var userModel = JsonConvert.DeserializeObject<JsonModelClass.UserLeaveCountModel>(json);
                if (typeOfLeave.Equals("0"))
                {
                    sickButton.Text = "+"  +userModel.leave_count;
                }
                else if (typeOfLeave.Equals("1"))
                {
                    casualButton.Text = "+" + userModel.leave_count;
                }
                else
                {
                    earnedButton.Text = "+" + userModel.leave_count;
                }
            }
            catch (JsonSerializationException ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
                await DisplayAlert("Warning", "Unable to fetch leave details", "OK");
            }


        }
    }
}
