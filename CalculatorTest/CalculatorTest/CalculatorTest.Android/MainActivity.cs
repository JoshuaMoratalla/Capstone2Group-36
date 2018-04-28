using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Content.Res;
using System.IO;

namespace CalculatorTest.Droid {
    [Activity(Label = "CalculatorTest", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity {
        protected override void OnCreate(Bundle bundle) {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            string Excelfile = "";

            AssetManager assets = this.Assets;
            using (StreamReader sr = new StreamReader(assets.Open("ConditionsExcel.xlsx")))
            {
                Excelfile = sr.ReadToEnd();
            }

                global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App(Excelfile));
        }
    }
}

