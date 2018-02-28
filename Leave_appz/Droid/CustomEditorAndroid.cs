using System;
using Xamarin.Forms;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Xamarin.Forms.Platform.Android;
using Leave_appz;
using Leave_appz.Droid;
using Android.Graphics.Drawables;
[assembly: ExportRenderer(typeof(CustomEditor), typeof(CustomEditorAndroid))]
namespace Leave_appz.Droid
{
    public class CustomEditorAndroid : EditorRenderer
    {

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Editor> e)
        {
            base.OnElementChanged(e);
            if (e.OldElement == null)
            {

                Control.SetBackgroundColor(Android.Graphics.Color.Transparent);

            }
        }

    }
}
