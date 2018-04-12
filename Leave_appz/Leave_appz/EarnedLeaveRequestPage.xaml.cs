using System;
using System.Collections.Generic;
using System.Net.Http;
using Xamarin.Forms;

namespace Leave_appz
{
    public partial class EarnedLeaveRequestPage : ContentPage
    {
        void Handle_Clicked(object sender, System.EventArgs e)
        {
            if (DateLabel.Text.Trim().Equals("") || DateLabel.Text.Trim().Equals("From Date"))
            {
                DisplayAlert("Warning", "No From Date Selected", "ok");
            }
            else if (DateLabelN.Text.Trim().Equals("") || DateLabelN.Text.Trim().Equals("To Date"))
            {
                DisplayAlert("Warning", "No To Date Selected", "ok");
            }
            else if (MyEditor.Text.Trim().Equals("") || MyEditor.Text.Trim().Equals("Please provide the reason for your leave here !!"))
            {
                DisplayAlert("Warning", "No Description Found", "ok");
            }
            else
            {
                if (Application.Current.Properties.ContainsKey("email"))
                {
                    var email = Application.Current.Properties["email"] as String;
                    RequestEarnedLeave(AppConstant.URL,email,DateLabel.Text,DateLabelN.Text,MyEditor.Text);
                }
                else
                {
                    //callLogoutFunction
                }
            }
        }

        public EarnedLeaveRequestPage()
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

            MyEditor.Text = "Please provide the reason for your leave here !!"; //initialize the Editor.Text and TextColor on the XAML file or on the constructor on the code behind with the PlaceHolder or whatever you want.
            MyEditor.TextColor = Color.FromHex("#BFffffff");
        }

        private void MyEditor_Focused(object sender, FocusEventArgs e) //triggered when the user taps on the Editor to interact with it
        {
            if (MyEditor.Text.Equals("Please provide the reason for your leave here !!")) //if you have the placeholder showing, erase it and set the text color to black
            {
                MyEditor.Text = "";
                MyEditor.TextColor = Color.White;
            }
        }

        private void MyEditor_Unfocused(object sender, FocusEventArgs e) //triggered when the user taps "Done" or outside of the Editor to finish the editing
        {
            if (MyEditor.Text.Equals("")) //if there is text there, leave it, if the user erased everything, put the placeholder Text back and set the TextColor to gray
            {
                MyEditor.Text = "Please provide the reason for your leave here !!";
                MyEditor.TextColor = Color.FromHex("#BFffffff");
            }
        }

        private void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            PickerDate.Focus();
        }

        private void PickerDate_DateSelected(object sender, DateChangedEventArgs e)
        {
            DateLabel.Text = PickerDate.Date.Date.ToString("yyyy-MM-dd");
        }


        private void TapGestureRecognizer_Tapped_2(object senderN, EventArgs f)
        {
            PickerDateN.Focus();
        }

        private void PickerDate_DateSelectedN(object senderN, DateChangedEventArgs f)
        {
            DateLabelN.Text = PickerDateN.Date.Date.ToString("yyyy-MM-dd");
        }
        async void RequestEarnedLeave(string URL, string userName, string from_date, string to_date, string description)
        {
            //year/Month/day
            var formContent = new FormUrlEncodedContent(new[]
                {
                new KeyValuePair<string, string>("id", "8"),
                new KeyValuePair<string, string>("useremail", userName),
                new KeyValuePair<string, string>("from_date", from_date),
                new KeyValuePair<string, string>("to_date", to_date),
                new KeyValuePair<string, string>("description", description),
            });

            var myHttpClient = new HttpClient();
            var response = await myHttpClient.PostAsync(URL, formContent);

            var json = await response.Content.ReadAsStringAsync();
            System.Diagnostics.Debug.WriteLine(json);
            if (json.Trim().Equals("723"))
            {
                await DisplayAlert("Leave Appz", "Request Succcessfull", "ok");
            }
            else if (json.Trim().Equals("726")){
                await DisplayAlert("Warning", "Range Of date Max Allowed Is 10.Remaining is Truncated", "ok");
            }
            else
            {
                await DisplayAlert("Warning", "Request Failed", "ok");
            }

        }



    }
}
