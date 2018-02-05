﻿using System;
using System.ComponentModel;
using Android.Widget;
using EntryRendererDemo;
using EntryRendererDemo.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(Checkbox), typeof(CheckBoxRenderer))]
namespace EntryRendererDemo.Droid
{
    public class CheckBoxRenderer : ViewRenderer<Checkbox, CheckBox>
    {
		private CheckBox checkBox;

		protected override void OnElementChanged(ElementChangedEventArgs<Checkbox> e)
		{
			base.OnElementChanged(e);
			var model = e.NewElement;
			checkBox = new CheckBox(Context);
			checkBox.Tag = this;
			CheckboxPropertyChanged(model, null);
			checkBox.SetOnClickListener(new ClickListener(model));
			SetNativeControl(checkBox);
		}
		private void CheckboxPropertyChanged(Checkbox model, String propertyName)
		{
			if (propertyName == null || Checkbox.IsCheckedProperty.PropertyName == propertyName)
			{
				checkBox.Checked = model.IsChecked;
                //checkBox.ButtonDrawable.SetTint(Color.Blue.ToAndroid());
			}

			if (propertyName == null || Checkbox.ColorProperty.PropertyName == propertyName)
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
				checkBox.ButtonTintList = myList;
			}
		}

		protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			if (checkBox != null)
			{
				base.OnElementPropertyChanged(sender, e);

				CheckboxPropertyChanged((Checkbox)sender, e.PropertyName);
			}
		}

		public class ClickListener : Java.Lang.Object, IOnClickListener
		{
			private Checkbox _myCheckbox;
			public ClickListener(Checkbox myCheckbox)
			{
				this._myCheckbox = myCheckbox;
			}
			public void OnClick(global::Android.Views.View v)
			{
				_myCheckbox.IsChecked = !_myCheckbox.IsChecked;
			}
		}
    }
}
