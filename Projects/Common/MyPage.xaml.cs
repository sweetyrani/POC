using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace EntryRendererDemo
{
    public partial class MyPage : ContentPage
    {
        public MyPage()
        {
            InitializeComponent();
            txt.CustomBorderColor = Color.FromHex("#ADB2B7");
        }

        void OnsubmitClicked(object sender, EventArgs args)
        {
            txt.CustomBorderColor = Color.FromHex("#FF0000");
            errorLbl.IsVisible = true;
            txt.ImageName = "";
        }
    }
}
