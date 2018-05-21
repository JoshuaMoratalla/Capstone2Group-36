using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Content.Res;
using System.IO;
using System.Text;

namespace CalculatorTest.Droid {
    [Activity(Label = "EBAANZ App", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity {
        protected override void OnCreate(Bundle bundle) {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            //Grabs the excel spreadsheet puts it into a string
            #region ExcelLoading
            string Excelfile = "";
            string ACCESS = "";
            AssetManager assets = this.Assets;
            using (StreamReader sr = new StreamReader(assets.Open("ConditionsExcel.xlsx"), System.Text.Encoding.GetEncoding(1252)))
            {
                Excelfile = sr.ReadToEnd();
            }
            using (StreamReader sr = new StreamReader(assets.Open("Access.txt")))
            {
                ACCESS = sr.ReadToEnd();
            }
            #endregion

            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App(Excelfile, ACCESS));
        }
    }
}

