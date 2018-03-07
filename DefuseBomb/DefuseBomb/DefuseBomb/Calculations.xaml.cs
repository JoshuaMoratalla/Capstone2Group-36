using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DefuseBomb
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Calculations : ContentPage
	{
		public Calculations ()
		{
			InitializeComponent ();
		}
        protected override bool OnBackButtonPressed()
        {
            App.Current.MainPage = new MainPage();
            return base.OnBackButtonPressed();
        }
    }
}