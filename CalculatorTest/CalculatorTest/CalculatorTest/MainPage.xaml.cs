using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CalculatorTest
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void ToCalculator(object sender, EventArgs e)
        {
            App.Current.MainPage = new Calculator();
        }

        private void ToDatabase(object sender, EventArgs e)
        {
            App.Current.MainPage = new Database();
        }

        private void ContactUs(object sender, EventArgs e)
        {
            App.Current.MainPage = new ContactUs();
        }
    }
}
