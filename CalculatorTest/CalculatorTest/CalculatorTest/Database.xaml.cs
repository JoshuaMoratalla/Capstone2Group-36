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
	public partial class Database : ContentPage
	{
		public Database ()
		{
			InitializeComponent ();
            listview.ItemsSource = App.ExcelSheetFinal;
        }

        protected override bool OnBackButtonPressed()
        {
            App.Current.MainPage = new MainPage();
            base.OnBackButtonPressed();
            return true;
        }

        private void ReturnToMain(object sender, EventArgs e) {
            App.Current.MainPage = new MainPage();
        }

        private void listview_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                var selection = e.SelectedItem as App.ConditionTest;
                if (selection.ID != 0)
                {
                    DisplayAlert(selection.Name, "Action\r\n" + selection.Action + "\r\n\r\nExplanation\r\n" + selection.Explanation, "OK");
                }
                listview.SelectedItem = null;
            }
        }
    }
}