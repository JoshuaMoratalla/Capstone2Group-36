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
	public partial class Login : ContentPage
	{
		public Login ()
		{
			InitializeComponent ();
		}

        private void LoginButton(object sender, EventArgs e)
        {
            Verify();
        }

        private void PasswordComplete(object sender, EventArgs e)
        {
            Verify();
        }

        private void Verify()
        {
            var Password = PasswordInput.Text;

            if (Password == App.ACCESS)
            {
                App.Current.MainPage = new MainPage();
            }
            else
            {
                DisplayAlert("Incorrect Password", "Incorrect Password. Access Denied.", "OK");
            }
        }
    }
}