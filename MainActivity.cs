using Android.App;
using Android.Widget;
using Android.OS;
using Android.Hardware;
using Android.Content;
using Android.Runtime;
using Android.Content.PM;
using System.Threading;
using Android.Media;
using System;
using Android.Views;
//using Xamarin.Forms;

namespace SpeakToMyDentist
{
    [Activity(Label = "SpeakToMyDentist", MainLauncher = true)]
    public class MainActivity : Activity, ISensorEventListener
    {
        double RotY, RotX = 0.0;
        double OldBumpy, OldBumpx = 0.0;


        public void OnAccuracyChanged(Sensor sensor, [GeneratedEnum] SensorStatus accuracy)
        {
            //hrow new System.NotImplementedException();
        }

        public void OnSensorChanged(SensorEvent e)
        {
            RotX = e.Values[1];
            RotY = e.Values[2];
            if ((((RotX < -30.0) & (OldBumpx > -30.0)) | ((RotX > -30.0) & (OldBumpx < -30.0))))
            {
                Vibrator vibrator = (Vibrator)GetSystemService(VibratorService);
                vibrator.Vibrate(100);
            }
            if ((((RotY < 30.0) & (OldBumpy > 30.0)) | ((RotY > 30.0) & (OldBumpy < 30.0))) | (((RotY < -30.0) & (OldBumpy > -30.0)) | ((RotY > -30.0) & (OldBumpy < -30.0))))
            {
                Vibrator vibrator = (Vibrator)GetSystemService(VibratorService);
                vibrator.Vibrate(100);
            }
            OldBumpx = RotX;
            OldBumpy = RotY;
        }

        protected override void OnResume()
        {
            base.OnResume();
            View decorView = Window.DecorView;
            var uiOptions = (int)decorView.SystemUiVisibility;
            var newUiOptions = (int)uiOptions;
            newUiOptions |= (int)SystemUiFlags.LowProfile;
            newUiOptions |= (int)SystemUiFlags.Fullscreen;
            newUiOptions |= (int)SystemUiFlags.HideNavigation;
            newUiOptions |= (int)SystemUiFlags.Immersive;
            newUiOptions |= (int)SystemUiFlags.ImmersiveSticky;
            decorView.SystemUiVisibility = (StatusBarVisibility)newUiOptions;

            this.RequestedOrientation = ScreenOrientation.Portrait;
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            View decorView = Window.DecorView;
            var uiOptions = (int)decorView.SystemUiVisibility;
            var newUiOptions = (int)uiOptions;
            newUiOptions |= (int)SystemUiFlags.LowProfile;
            newUiOptions |= (int)SystemUiFlags.Fullscreen;
            newUiOptions |= (int)SystemUiFlags.HideNavigation;
            newUiOptions |= (int)SystemUiFlags.Immersive;
            newUiOptions |= (int)SystemUiFlags.ImmersiveSticky;
            decorView.SystemUiVisibility = (StatusBarVisibility)newUiOptions;

            this.RequestedOrientation = ScreenOrientation.Portrait;
            var _SensorManager = (SensorManager)GetSystemService(Context.SensorService);
            _SensorManager.RegisterListener(this, _SensorManager.GetDefaultSensor(SensorType.Orientation), SensorDelay.Ui);
            string RotDeviceName = _SensorManager.GetDefaultSensor(SensorType.Orientation).Name;

            new Thread(new ThreadStart(() =>
            {
                MediaPlayer _medialPlayer = MediaPlayer.Create(this, Resource.Raw.hello);
                _medialPlayer.Start();
            })).Start();

            Vibrator vibrator = (Vibrator)GetSystemService(VibratorService);


            Button Button1 = FindViewById<Button>(Resource.Id.button1);
            Button Button2 = FindViewById<Button>(Resource.Id.button2);
            Button Button3 = FindViewById<Button>(Resource.Id.button3);
            Button1.Click += Button1_Click;
            Button2.Click += Button2_Click;
            Button3.Click += Button3_Click;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (RotX < -30.0)
            {
                new Thread(new ThreadStart(() =>
                {
                    MediaPlayer _medialPlayer = MediaPlayer.Create(this, Resource.Raw.thatsfealingcold);
                    _medialPlayer.Start();
                    while (_medialPlayer.IsPlaying) { }
                    _medialPlayer.Release();
                })).Start();
            }
            else if (RotY > 30.0)
            {
                new Thread(new ThreadStart(() =>
                {
                    MediaPlayer _medialPlayer = MediaPlayer.Create(this, Resource.Raw.better); //Left
                    _medialPlayer.Start();
                    while (_medialPlayer.IsPlaying) { }
                    _medialPlayer.Release();
                })).Start();
            }
            else if (RotY < -30.0)
            {
                new Thread(new ThreadStart(() =>
                {
                    MediaPlayer _medialPlayer = MediaPlayer.Create(this, Resource.Raw.yes); //Right
                    _medialPlayer.Start();
                    while (_medialPlayer.IsPlaying) { }
                    _medialPlayer.Release();
                })).Start();
            }
            else
            {
                new Thread(new ThreadStart(() =>
                {
                    MediaPlayer _medialPlayer = MediaPlayer.Create(this, Resource.Raw.hahaha); //Center

                    _medialPlayer.Start();
                    while (_medialPlayer.IsPlaying) { }
                    _medialPlayer.Release();
                })).Start();
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (RotX < -30.0)
            {
                new Thread(new ThreadStart(() =>
                {
                    MediaPlayer _medialPlayer = MediaPlayer.Create(this, Resource.Raw.thatsfealinghot);
                    _medialPlayer.Start();
                    while (_medialPlayer.IsPlaying) { }
                    _medialPlayer.Release();
                })).Start();
            }
            else if (RotY > 30.0)
            {
                new Thread(new ThreadStart(() =>
                {
                    MediaPlayer _medialPlayer = MediaPlayer.Create(this, Resource.Raw.worse); //Left
                    _medialPlayer.Start();
                    while (_medialPlayer.IsPlaying) { }
                    _medialPlayer.Release();
                })).Start();
            }
            else if (RotY < -30.0)
            {
                new Thread(new ThreadStart(() =>
                {
                    MediaPlayer _medialPlayer = MediaPlayer.Create(this, Resource.Raw.no); //Right
                    _medialPlayer.Start();
                    while (_medialPlayer.IsPlaying) { }
                    _medialPlayer.Release();
                })).Start();
            }
            else
            {
                new Thread(new ThreadStart(() =>
                {
                    MediaPlayer _medialPlayer = MediaPlayer.Create(this, Resource.Raw.ok); //Center
                    _medialPlayer.Start();
                    while (_medialPlayer.IsPlaying) { }
                    _medialPlayer.Release();
                })).Start();
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            if (RotX < -30.0)
            {
                new Thread(new ThreadStart(() =>
                {
                    MediaPlayer _medialPlayer = MediaPlayer.Create(this, Resource.Raw.imfealingpressure);
                    _medialPlayer.Start();
                    while (_medialPlayer.IsPlaying) { }
                    _medialPlayer.Release();
                })).Start();
            }
            else if (RotY > 30.0)
            {
                new Thread(new ThreadStart(() =>
                {
                    MediaPlayer _medialPlayer = MediaPlayer.Create(this, Resource.Raw.ouch); //Left
                    _medialPlayer.Start();
                    while (_medialPlayer.IsPlaying) { }
                    _medialPlayer.Release();
                })).Start();
            }
            else if (RotY < -30.0)
            {
                new Thread(new ThreadStart(() =>
                {
                    MediaPlayer _medialPlayer = MediaPlayer.Create(this, Resource.Raw.doinggood); //Right
                    _medialPlayer.Start();
                    while (_medialPlayer.IsPlaying) { }
                    _medialPlayer.Release();
                })).Start();
            }
            else
            {
                new Thread(new ThreadStart(() =>
                {
                    MediaPlayer _medialPlayer = MediaPlayer.Create(this, Resource.Raw.imdrowninghere); //Center
                    _medialPlayer.Start();
                    while (_medialPlayer.IsPlaying) { }
                    _medialPlayer.Release();
                })).Start();
            }
        }


    }
}

