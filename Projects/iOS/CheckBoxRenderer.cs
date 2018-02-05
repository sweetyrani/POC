using System;
using System.ComponentModel;
using EntryRendererDemo;
using EntryRendererDemo.iOS;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(Checkbox), typeof(CheckBoxRenderer))]
namespace EntryRendererDemo.iOS
{
    public class CheckBoxRenderer : ViewRenderer<Checkbox, CheckBoxView>
    {
		protected override void OnElementChanged(ElementChangedEventArgs<Checkbox> e)
		{
			base.OnElementChanged(e);

			if (Element == null)
				return;


			if (e.NewElement != null)
			{
				if (Control == null)
				{
					var checkBox = new CheckBoxView(Bounds);
					checkBox.TouchUpInside += (s, args) => Element.IsChecked = Control.Checked;
					SetNativeControl(checkBox);
				}
				Control.Checked = e.NewElement.IsChecked;
			}

            var frame = Frame;
            frame.Height = 40;
            frame.Width = 40;
			Control.Frame = frame;
			Control.Bounds = Bounds;
            BackgroundColor = Element.BackgroundColor.ToUIColor();
		}

		
		protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged(sender, e);

			if (e.PropertyName.Equals("Checked"))
			{
				Control.Checked = Element.IsChecked;
			}
		}
    }
}
