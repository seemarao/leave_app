using System;
using System.Collections.Generic;
using System.Net.Http;
using Xamarin.Forms;

namespace Leave_appz
{
    public partial class sickLeaveRequestPage : ContentPage
    {
        void Handle_Clicked(object sender, System.EventArgs e)
        {
            var viewModel = new ViewModels();
            if(viewModel.sickLeaveDateLabelValidater(DateLabel.Text) ){
                DisplayAlert("ALERT", "Please select a valid Date.", "OK");
            }
            else if(viewModel.sickLeaveEntryLabelValidater(MyEditor.Text)){
                DisplayAlert("ALERT", "Please enter the reason.", "OK");
            }
            else{
                if (Application.Current.Properties.ContainsKey("email"))
                {
                    var email = Application.Current.Properties["email"] as String;
                    RequestLeave(AppConstant.URL,email,DateLabel.Text,"0",MyEditor.Text);
                }else{
                    //callLogoutFunction
                }
            }
        }

        public sickLeaveRequestPage()
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
                MyEditor.TextColor = Color.Black;
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

        async void RequestLeave(string URL, string userName, string date, string typeofleave, string description)
        {
            //year/Month/day
            var formContent = new FormUrlEncodedContent(new[]
                {
                new KeyValuePair<string, string>("id", "7"),
                new KeyValuePair<string, string>("useremail", userName),
                new KeyValuePair<string, string>("date", date),
                new KeyValuePair<string, string>("type_of_leave", typeofleave),
                new KeyValuePair<string, string>("description", description),
            });

            var myHttpClient = new HttpClient();
            var response = await myHttpClient.PostAsync(URL, formContent);

            var json = await response.Content.ReadAsStringAsync();
            System.Diagnostics.Debug.WriteLine(json);
            if (json.Trim().Equals("723"))
            {
                await DisplayAlert("ALERT", "Request succcessfull.", "OK");
            }
            else
            {
                await DisplayAlert("ALERT", "Request failed.", "OK");
            }

        }

    }

        

    }

