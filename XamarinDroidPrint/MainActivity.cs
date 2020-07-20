using System;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V4.Print;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;

namespace XamarinDroidPrint
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            Android.Support.V7.Widget.Toolbar toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            FloatingActionButton fab = FindViewById<FloatingActionButton>(Resource.Id.fab);
            fab.Click += FabOnClick;

            ImageView img = FindViewById<ImageView>(Resource.Id.imageView1);
            img.SetImageResource(Resource.Drawable.entry_sample);

            CustomImageView customImageView = new CustomImageView(this, null)
            {
                LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent)
            };
            customImageView.SetMinimumWidth(500);
            customImageView.SetMinimumHeight(500);
//            SetContentView(customImageView);

            RelativeLayout relativeLayout = FindViewById<RelativeLayout>(Resource.Id.relativeLayout1);
            relativeLayout.AddView(customImageView);

        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            if (id == Resource.Id.action_settings)
            {
                return true;
            }

            return base.OnOptionsItemSelected(item);
        }

        private void FabOnClick(object sender, EventArgs eventArgs)
        {
            View view = (View) sender;
            /*
            Snackbar.Make(view, "Replace with your own action", Snackbar.LengthLong)
                .SetAction("Action", (Android.Views.View.IOnClickListener)null).Show();
            */

            PrintByHelper(view);
        }

        private void PrintByHelper(View view)
        {
            Bitmap bitmap = null;
            try
            {
                View _view = Window.DecorView;
                bitmap = Bitmap.CreateBitmap(_view.Width, _view.Height, Bitmap.Config.Argb8888);
                Canvas canvas = new Canvas(bitmap);
                //canvas.DrawText("text", 0, 0, new Paint());

                _view.Draw(canvas);

                String jobName = "test print";
                PrintHelper printHelper = new PrintHelper(this);
                printHelper.ScaleMode = PrintHelper.ScaleModeFit;
                printHelper.ColorMode = PrintHelper.ColorModeColor;
                printHelper.Orientation = PrintHelper.OrientationPortrait;
                printHelper.PrintBitmap(jobName, bitmap);
            }
            catch (Exception ex)
            {
                Snackbar.Make(view, ex.Message, Snackbar.LengthLong)
                    .SetAction("Action", (Android.Views.View.IOnClickListener)null).Show();
            }
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
	}
}
