using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CalculatorTest {
    public partial class MainPage : ContentPage {
        public MainPage() {
            InitializeComponent();
        }

        

        private void Button_Clicked(object sender, EventArgs e) {
            var Weight = WeightInput.Text;
            double WeightDouble = double.Parse(Weight);

            double TPV = WeightDouble / 0.025;
            double TBV = WeightDouble / 0.015;

            var Blood = BloodInput.Text;
            var Colloids = ColloidInput.Text;
            var Crystal = CrystalInput.Text;

            double BloodDouble = double.Parse(Blood);
            double ColloidsDouble = double.Parse(Colloids);
            double CrystalDouble = double.Parse(Crystal);

            if (ColloidsDouble + CrystalDouble < TPV && BloodDouble + 
                ColloidsDouble + CrystalDouble < TBV) {
                Output.Text = "Donor successful to qualify for suitability";
            } else {
                Output.Text = "Donor failed to qualify for suitability";
            }
        }
    }
}
