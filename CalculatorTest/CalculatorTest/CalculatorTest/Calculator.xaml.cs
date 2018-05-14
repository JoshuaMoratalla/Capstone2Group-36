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
        public bool isvalid = true;

		public Calculator ()
		{
			InitializeComponent ();
        }

        private void Button_Clicked(object sender, EventArgs e) {

            isvalid = true;
            double WeightDouble = VerifyText(DonorWeight.Text);

            double BloodDouble =
                VerifyText(WholeBlood.Text) +
                VerifyText(PackedCells.Text) +
                VerifyText(OtherBloodProducts.Text);

            double ColloidsDouble =
                VerifyText(FPPPlasma.Text) +
                VerifyText(Platelets.Text) +
                VerifyText(Cryoprecipitate.Text) +
                VerifyText(Albumin4.Text) +
                VerifyText(Albumin5.Text) +
                VerifyText(Albumin20.Text) +
                VerifyText(Dextran.Text) +
                VerifyText(OtherColloids.Text);

            double CrystalDouble =
                VerifyText(NaCl.Text) +
                VerifyText(NS.Text) +
                VerifyText(HartmannsSolution.Text) +
                VerifyText(Dextrose.Text) +
                VerifyText(OtherCrystalloids.Text);

            if (isvalid == false)
            {
                Output.Text = "Invalid Sample Entry";
                Output.BackgroundColor = Color.FromHex("#FEF200");
            }
            else
            {
                double TPV = WeightDouble / 0.025;
                double TBV = WeightDouble / 0.015;

                if (ColloidsDouble + CrystalDouble < TPV &&
                    BloodDouble + ColloidsDouble + CrystalDouble < TBV)
                {
                    Output.Text = "Sample qualifies.";
                    Output.BackgroundColor = Color.FromHex("#00853E");
                }
                else
                {
                    Output.Text = "Sample does not qualify";
                    Output.BackgroundColor = Color.FromHex("#ED3125");
                }
            }
        }

        private double VerifyText(string input)
        {

            isvalid = double.TryParse(input, out double output);
            
            if (isvalid == false)
            {
                output = 0;
            }

            return output;
        }

        protected override bool OnBackButtonPressed()
        {
            App.Current.MainPage = new MainPage();
            base.OnBackButtonPressed();
            return true;
        }

        private void ReturnToMain(object sender, EventArgs e)
        {
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
            ((Entry)sender).BackgroundColor = isValid ? Color.Default : Color.FromHex("#ED3125");
            
        }
    }
}