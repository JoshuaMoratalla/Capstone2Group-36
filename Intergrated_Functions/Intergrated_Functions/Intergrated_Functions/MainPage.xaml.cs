﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Intergrated_Functions {
    public partial class MainPage : ContentPage {
        public MainPage() {
            InitializeComponent();
        }
        private void ToCalculationsPage(object sender, EventArgs e) {
            App.Current.MainPage = new Calculations();
        }
    }
}