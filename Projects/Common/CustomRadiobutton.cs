using System;
using Xamarin.Forms;

namespace EntryRendererDemo
{
    public class CustomRadiobutton : View
    {
		
		//public static readonly BindableProperty IsCheckedProperty =
		//BindableProperty.Create("IsChecked", typeof(bool), typeof(CustomRadiobutton), true, propertyChanged: (s, o, n) => { (s as CustomRadiobutton).OnChecked(new EventArgs()); });
		public static readonly BindableProperty IsCheckedProperty =
			BindableProperty.Create("IsChecked", typeof(bool), typeof(CustomRadiobutton), true);

		
		public bool IsChecked
		{
			get
			{
				return (bool)GetValue(IsCheckedProperty);
			}
			set
			{
				this.SetValue(IsCheckedProperty, value);
                var eventHandler = Checked;

				if (eventHandler != null)
				{
					eventHandler.Invoke(this, value);
				}
			}
		}

		public static readonly BindableProperty TextProperty =
            BindableProperty.Create("Text", typeof(string), typeof(CustomRadiobutton), string.Empty);
		public string Text
		{
			get
			{
				return (string)GetValue(TextProperty);
			}

			set
			{
				this.SetValue(TextProperty, value);
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

        public event EventHandler<bool> Checked;
		//protected virtual void OnChecked(EventArgs e)
		//{
		//	if (Checked != null)
		//		Checked(this, e);
		//}
    }
}
