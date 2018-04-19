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

            var viewModel = new ViewModels();
             if ( viewModel.earnedLeaveDateLabelValidater(DateLabel.Text))
            {
                DisplayAlert("ALERT", "Please select a valid From Date.", "OK");
            }
            else if (viewModel.earnedLeaveDateNLabelValidater(DateLabelN.Text))
            {
                DisplayAlert("ALERT", "Please select a valid To Date.", "OK");
            }
            else if (viewModel.earnedLeaveMyEditorLabelValidater(MyEditor.Text))
            {
                DisplayAlert("ALERT", "No Description Found", "OK");
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
                await DisplayAlert("Leave Appz", "Request succcessfull", "OK");
            }
            else if (json.Trim().Equals("726")){
                await DisplayAlert("ALERT", "Range of Maximum allowed leave is 10. Remaining is truncated. ", "OK");
            }
            else
            {
                await DisplayAlert("ALERT", "Request Failed", "OK");
            }

        }



    }
}
