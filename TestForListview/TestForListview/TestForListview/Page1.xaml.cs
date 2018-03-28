using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestForListview {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page1 : ContentPage {
        public Page1() {
            InitializeComponent();
            listview.ItemsSource = ConditionData.ConditionList;
        }
    }
    public class Conditions {

    }
}