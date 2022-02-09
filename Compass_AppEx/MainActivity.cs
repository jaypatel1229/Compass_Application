using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Essentials;

namespace Compass_AppEx
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    class MainActivity : Activity
    {
        private Button start;
        private Button stop;
        private TextView textV;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);
            UIReference();
            UIClickEvent();
        }

        private void UIClickEvent()
        {
            start.Click += Start_Click;
            stop.Click += Stop_Click;
        }

        private void Stop_Click(object sender, EventArgs e)
        {
            if (Compass.IsMonitoring)
            {
                Compass.ReadingChanged -= Compass_ReadingChanged;
                Compass.Stop();
            }
        }

        private void Start_Click(object sender, EventArgs e)
        {
            if (!Compass.IsMonitoring)
            {
                Compass.ReadingChanged += Compass_ReadingChanged;
                Compass.Start(SensorSpeed.UI);
            }
        }

        private void Compass_ReadingChanged(object sender, CompassChangedEventArgs e)
        {
            textV.Text = $"Heding:{e.Reading.HeadingMagneticNorth}";
        }

        private void UIReference()
        {
            start = FindViewById<Button>(Resource.Id.buttonStart);
            stop = FindViewById<Button>(Resource.Id.buttonStop);
            textV = FindViewById<TextView>(Resource.Id.textViewCD);

        }
    }
}