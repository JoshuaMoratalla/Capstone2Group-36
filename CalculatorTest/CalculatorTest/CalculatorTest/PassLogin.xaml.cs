using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CalculatorTest
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PassLogin : ContentPage
	{
		public PassLogin ()
		{
			InitializeComponent ();
		}

        private void ReturnToMain(object sender, EventArgs e) {
            App.Current.MainPage = new MainPage();
        }

        protected override bool OnBackButtonPressed()
        {
            App.Current.MainPage = new MainPage();
            base.OnBackButtonPressed();
            return true;
        }
    }
}