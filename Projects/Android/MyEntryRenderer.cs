using System;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Graphics.Drawables.Shapes;
using Android.Support.V4.Content;
using EntryRendererDemo;
using EntryRendererDemo.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(MyEntry), typeof(MyEntryRenderer))]
namespace EntryRendererDemo.Droid
{
    public class MyEntryRenderer :EntryRenderer
    {
        MyEntry element;
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Entry> e)
        {
            base.OnElementChanged(e);

			if (e.OldElement != null || e.NewElement == null)
				return;
			if (Control != null)
			{
				// do whatever you want to the UITextField here!
				//Control.BorderStyle = UITextBorderStyle.Line;
				//Control.Layer.BorderWidth = 2;
				//Control.Layer.CornerRadius = 10;
				//Control.Background.SetColorFilter(element.CustomBorderColor.ToAndroid(), PorterDuff.Mode.SrcAtop);
				//Control.
                Control.SetBackgroundResource(Resource.Drawable.EntryStyle);
				
			}
            element = (MyEntry)this.Element;


			var editText = this.Control;
            if (!string.IsNullOrEmpty(element.ImageName))
			{
				switch (element.ImageAlignment)
				{
					case ImageAlignment.Left:
                        editText.SetCompoundDrawablesWithIntrinsicBounds(GetDrawable(element.ImageName), null, null, null);
						break;
					case ImageAlignment.Right:
						editText.SetCompoundDrawablesWithIntrinsicBounds(null, null, GetDrawable(element.ImageName), null);
						break;
				}
			}
			editText.CompoundDrawablePadding = 25;
            //Control.Background.SetColorFilter(element.CustomBorderColor.ToAndroid(), PorterDuff.Mode.SrcAtop);
            GetDesign(element.CustomBorderColor.ToAndroid());
        }

		private BitmapDrawable GetDrawable(string imageEntryImage)
		{
			int resID = Resources.GetIdentifier(imageEntryImage, "drawable", this.Context.PackageName);
			var drawable = ContextCompat.GetDrawable(this.Context, resID);
			var bitmap = ((BitmapDrawable)drawable).Bitmap;

			return new BitmapDrawable(Resources, Bitmap.CreateScaledBitmap(bitmap, element.ImageWidth * 2, element.ImageHeight * 2, true));
		}

        private void GetDesign(Android.Graphics.Color borderColor)
        {
            GradientDrawable gd = new GradientDrawable();
            gd.SetColor(Android.Graphics.Color.White);
			gd.SetCornerRadius(7);
			gd.SetStroke(2, borderColor);
            //Control.SetBackgroundDrawable(gd);
            Control.Background = gd;
        }
        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            element = (MyEntry)this.Element;
            if (e.PropertyName == MyEntry.BorderColorProperty.PropertyName)
            {
                var editText = this.Control;
                //Control.Background.SetColorFilter(element.CustomBorderColor.ToAndroid(), PorterDuff.Mode.SrcAtop);
                GetDesign(element.CustomBorderColor.ToAndroid());
                if (!string.IsNullOrEmpty(element.ErrorImageName))
                {
                    switch (element.ErrorImageAlignment)
                    {
                        case ImageAlignment.Left:
                            editText.SetCompoundDrawablesWithIntrinsicBounds(GetDrawable(element.ErrorImageName), null, null, null);
                            break;
                        case ImageAlignment.Right:
                            editText.SetCompoundDrawablesWithIntrinsicBounds(null, null, GetDrawable(element.ErrorImageName), null);
                            break;
                    }
                }
                //editText.CompoundDrawablePadding = 25;
            }
            if (e.PropertyName == MyEntry.ImageProperty.PropertyName)
            {
                if (string.IsNullOrEmpty(element.ImageName))
                {
					//editText.SetCompoundDrawablesWithIntrinsicBounds(GetDrawable(element.ErrorImageName), null, null, null);
                }
            }
        }
    }
}
