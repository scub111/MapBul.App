﻿using Android.App;
using Android.Content.PM;
using Android.OS;
using Xamarin.Forms.Platform.Android;

namespace TK.CustomMap.Sample.Droid
{
    [Activity(Label = "TK.CustomMap.Sample", Theme="@style/MyTheme", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);


            ToolbarResource = Resource.Layout.toolbar;
            TabLayoutResource = Resource.Layout.tabs;

            Xamarin.FormsMaps.Init(this, bundle);
            LoadApplication(new App());
        }
    }
}

