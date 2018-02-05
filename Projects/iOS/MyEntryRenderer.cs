using System;
using System.Drawing;
using CoreAnimation;
using CoreGraphics;
using EntryRendererDemo;
using EntryRendererDemo.iOS;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(MyEntry), typeof(MyEntryRenderer))]
namespace EntryRendererDemo.iOS
{
    public class MyEntryRenderer : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
		{
			base.OnElementChanged(e);

			if (e.OldElement != null || e.NewElement == null)
				return;
            
			if (Control != null)
			{
                // do whatever you want to the UITextField here!
                //Control.BackgroundColor = UIColor.FromRGB(204, 153, 255);
                Control.BorderStyle = UITextBorderStyle.Line;
                //Control.Layer.BorderColor = UIColor.Green.CGColor;
                Control.Layer.BorderColor = (this.Element as MyEntry).CustomBorderColor.ToCGColor();
                Control.Layer.BorderWidth = 2;
                Control.Layer.CornerRadius = 10;
                //Control.LeftViewMode = UITextFieldViewMode.Always;
                //var imageview = new UIImageView();
                //imageview.Image = UIImage.FromBundle("email.png");
                //Control.LeftView = imageview;
			}
            var element = (MyEntry)this.Element;
			var textField = this.Control;
            if (!string.IsNullOrEmpty(element.ImageName))
			{
				switch (element.ImageAlignment)
				{
					case ImageAlignment.Left:
						textField.LeftViewMode = UITextFieldViewMode.Always;
						textField.LeftView = GetImageView(element.ImageName, element.ImageHeight, element.ImageWidth);
						break;
					case ImageAlignment.Right:
						textField.RightViewMode = UITextFieldViewMode.Always;
						textField.RightView = GetImageView(element.ImageName, element.ImageHeight, element.ImageWidth);
						break;
				}
			}

			textField.BorderStyle = UITextBorderStyle.None;
			CALayer bottomBorder = new CALayer
			{
				Frame = new CGRect(0.0f, element.HeightRequest - 1, this.Frame.Width, 1.0f),
				BorderWidth = 2.0f,
				//BorderColor = element.CustomBorderColor.ToCGColor()
			};

			textField.Layer.AddSublayer(bottomBorder);
			textField.Layer.MasksToBounds = true;

		}

		private UIView GetImageView(string imagePath, int height, int width)
		{
			var uiImageView = new UIImageView(UIImage.FromBundle(imagePath))
			{
				Frame = new RectangleF(0, 0, width, height)
			};
			UIView objLeftView = new UIView(new System.Drawing.Rectangle(0, 0, width + 10, height));
			objLeftView.AddSubview(uiImageView);

			return objLeftView;
		}

        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            var element = this.Element as MyEntry;
            if (e.PropertyName == MyEntry.BorderColorProperty.PropertyName)
            {
                
                Control.Layer.BorderColor = element.CustomBorderColor.ToCGColor();
				if (!string.IsNullOrEmpty(element.ErrorImageName))
				{
					switch (element.ErrorImageAlignment)
					{
						case ImageAlignment.Left:
							Control.LeftViewMode = UITextFieldViewMode.Always;
							Control.LeftView = GetImageView(element.ErrorImageName, element.ImageHeight, element.ImageWidth);
							break;
						case ImageAlignment.Right:
							Control.RightViewMode = UITextFieldViewMode.Always;
							Control.RightView = GetImageView(element.ErrorImageName, element.ImageHeight, element.ImageWidth);
							break;
					}
				}

            }
            //if (e.PropertyName == MyEntry.ErrorImageProperty.PropertyName)
            //{
                
				
            //}

            if (e.PropertyName == MyEntry.ImageProperty.PropertyName)
            {
                if (string.IsNullOrEmpty(element.ImageName))
				{
                    Control.LeftViewMode = UITextFieldViewMode.Never;
					
				}
            }
        }
    }
}
