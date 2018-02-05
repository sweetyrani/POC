using System;
using Xamarin.Forms;

namespace EntryRendererDemo
{
    public class Checkbox : View
    {
		//public static readonly BindableProperty IsCheckedProperty = BindableProperty.Create<CheckBox, bool>(p => p.IsChecked, true, propertyChanged: (s, o, n) => { (s as CheckBox).OnChecked(new EventArgs()); });
		//public static readonly BindableProperty ColorProperty = BindableProperty.Create<CheckBox, Color>(p => p.Color, Color.Default);
		public static readonly BindableProperty IsCheckedProperty =
			BindableProperty.Create("IsChecked", typeof(bool), typeof(Checkbox), true, propertyChanged: (s, o, n) => { (s as Checkbox).OnChecked(new EventArgs()); });
		public bool IsChecked
		{
			get
			{
				return (bool)GetValue(IsCheckedProperty);
			}
			set
			{
				SetValue(IsCheckedProperty, value);
			}
		}


		public static readonly BindableProperty ColorProperty =
			BindableProperty.Create("Color", typeof(Color), typeof(Checkbox), Color.Default);
		public Color Color
		{
			get
			{
				return (Color)GetValue(ColorProperty);
			}
			set
			{
				SetValue(ColorProperty, value);
			}
		}

		public event EventHandler Checked;

		protected virtual void OnChecked(EventArgs e)
		{
			if (Checked != null)
				Checked(this, e);
		}
    }
}
