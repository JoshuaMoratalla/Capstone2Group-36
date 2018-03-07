using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;


namespace DefuseBomb
{
	public partial class MainPage : ContentPage
	{
		public MainPage(){
			InitializeComponent();
		}
        //async void ToCalculationsPage(object sender, EventArgs e){
        //   await Navigation.PushAsync(new NavigationPage(new Calculations()));
        //}
        private void ToCalculationsPage(object sender, EventArgs e){
            App.Current.MainPage = new Calculations();
        }
       
    }
}
