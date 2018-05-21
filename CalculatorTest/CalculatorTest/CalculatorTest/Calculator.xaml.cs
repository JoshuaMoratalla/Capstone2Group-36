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
                    Output.Text = "Sample Qualifies";
                    Output.BackgroundColor = Color.FromHex("#00853E");
                }
                else
                {
                    Output.Text = "Sample Does Not Qualify";
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

        private void EntryComplete(object sender, EventArgs e)
        {
            FocusEntry(((Entry)sender).AutomationId);
        }

        private void FocusEntry(string ID)
        {
            switch (ID)
            {
                case "0":
                    WholeBlood.Focus();
                    break;
                case "1":
                    PackedCells.Focus();
                    break;
                case "2":
                    OtherBloodProducts.Focus();
                    break;
                case "3":
                    FPPPlasma.Focus();
                    break;
                case "4":
                    Platelets.Focus();
                    break;
                case "5":
                    Cryoprecipitate.Focus();
                    break;
                case "6":
                    Albumin4.Focus();
                    break;
                case "7":
                    Albumin5.Focus();
                    break;
                case "8":
                    Albumin20.Focus();
                    break;
                case "9":
                    Dextran.Focus();
                    break;
                case "10":
                    OtherColloids.Focus();
                    break;
                case "11":
                    NaCl.Focus();
                    break;
                case "12":
                    NS.Focus();
                    break;
                case "13":
                    HartmannsSolution.Focus();
                    break;
                case "14":
                    Dextrose.Focus();
                    break;
                case "15":
                    OtherCrystalloids.Focus();
                    break;
                case "16":
                default:
                    break;
            }
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