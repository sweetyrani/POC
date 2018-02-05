using System;
using System.ComponentModel;
using Android.Graphics;
using Android.Widget;
using EntryRendererDemo;
using EntryRendererDemo.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomRadiobutton), typeof(CustomRadioButtonRenderer))]
namespace EntryRendererDemo.Droid
{
    public class CustomRadioButtonRenderer : ViewRenderer<CustomRadiobutton, RadioButton>
    {
        private RadioButton radioButton;
       
        protected override void OnElementChanged(ElementChangedEventArgs<CustomRadiobutton> e)
		{
			base.OnElementChanged(e);


			if (Control == null)
			{
				radioButton = new RadioButton(Context);
                radioButton.SetOnClickListener(new ClickListener(e.NewElement));
				SetNativeControl(radioButton);
                radioButton.LayoutParameters.Height = 100;
                //radioButton.SetWidth(100);
			}
            RadioButtonPropertyChanged(e.NewElement, null);
		}
		
		protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged(sender, e);
            RadioButtonPropertyChanged((CustomRadiobutton)sender, e.PropertyName);
			
		}

        private void RadioButtonPropertyChanged(CustomRadiobutton model, String propertyName)
        {
            if (propertyName == null || CustomRadiobutton.IsCheckedProperty.PropertyName == propertyName)
			{
						int[][] states = {
					new int[] { Android.Resource.Attribute.StateEnabled}, // enabled
                    new int[] {Android.Resource.Attribute.StateEnabled}, // disabled
                    new int[] {Android.Resource.Attribute.StateChecked}, // unchecked
                    new int[] { Android.Resource.Attribute.StatePressed}  // pressed
                };
						var checkBoxColor = (int)model.Color.ToAndroid();
						int[] colors = {
					checkBoxColor,
					checkBoxColor,
					checkBoxColor,
					checkBoxColor
				};
						var myList = new Android.Content.Res.ColorStateList(states, colors);
						Control.ButtonTintList = myList;
						Control.Checked = Element.IsChecked;

                if (propertyName == null || CustomRadiobutton.TextProperty.PropertyName == propertyName)

                {
                    Control.Text = Element.Text;
                }

			}
        }

		public class ClickListener : Java.Lang.Object, IOnClickListener
		{
            private CustomRadiobutton _myRadioButton;
			public ClickListener(CustomRadiobutton myRadioButton)
			{
				this._myRadioButton = myRadioButton;
			}
			public void OnClick(global::Android.Views.View v)
			{
				_myRadioButton.IsChecked = !_myRadioButton.IsChecked;
			}
		}
    }
}
