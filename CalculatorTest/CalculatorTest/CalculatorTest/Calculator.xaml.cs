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
	public partial class Calculator : ContentPage
	{
		public Calculator ()
		{
			InitializeComponent ();
        }
        private void Button_Clicked(object sender, EventArgs e) {
            double WeightDouble = double.Parse(DonorWeight.Text);

            double TPV = WeightDouble / 0.025;
            double TBV = WeightDouble / 0.015;

            double BloodDouble = double.Parse(WholeBlood.Text) +
                double.Parse(PackedCells.Text) +
                double.Parse(OtherBloodProducts.Text);
            double ColloidsDouble = double.Parse(FPPPlasma.Text) +
                double.Parse(Platelets.Text) +
                double.Parse(Cryoprecipitate.Text) +
                double.Parse(Albumin4.Text) +
                double.Parse(Albumin5.Text) +
                double.Parse(Albumin20.Text) +
                double.Parse(Dextran.Text) +
                double.Parse(OtherColloids.Text);
            double CrystalDouble = double.Parse(NaCl.Text) +
                double.Parse(NS.Text) +
                double.Parse(HartmannsSolution.Text) +
                double.Parse(Dextrose.Text) +
                double.Parse(OtherCrystalloids.Text);

            if (ColloidsDouble + CrystalDouble<TPV && BloodDouble + 
                ColloidsDouble + CrystalDouble<TBV) {
                Output.Text = "Sample qualifies.";
            } else {
                Output.Text = "Sample does not qualify";
            }
        }

         protected override bool OnBackButtonPressed() {
            App.Current.MainPage = new MainPage();
            base.OnBackButtonPressed();
            return true;
        }

        private void ReturnToMain(object sender, EventArgs e) {
            App.Current.MainPage = new MainPage();
        }
    }

    public class EntryValidateBehaviour : Behavior<Entry>
    {
        protected override void OnAttachedTo(Entry entry)
        {
            entry.TextChanged += OnEntryTextChanged;
            base.OnAttachedTo(entry);
        }

        protected override void OnDetachingFrom(Entry entry)
        {
            entry.TextChanged -= OnEntryTextChanged;
            base.OnDetachingFrom(entry);
        }

        void OnEntryTextChanged(object sender, TextChangedEventArgs args)
        {
            bool isValid = true;
            if (args.NewTextValue == ".")
            {
                ((Entry)sender).Text = "0.";
            }
            else if (args.NewTextValue != "")
            {
                isValid = double.TryParse(args.NewTextValue, out double result);
            }
            ((Entry)sender).BackgroundColor = isValid ? Color.Default : Color.Red;
            
        }
    }
}