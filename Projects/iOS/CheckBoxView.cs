﻿using System;
using CoreGraphics;
using Foundation;
using UIKit;

namespace EntryRendererDemo.iOS
{
    [Register("CheckBoxView")]
    public class CheckBoxView : UIButton
    {
        public CheckBoxView()
        {
            Initialize();
        }

		public CheckBoxView(CGRect bounds)
			: base(bounds)
		{
			Initialize();
		}

		public string CheckedTitle
		{
			set
			{
				SetTitle(value, UIControlState.Selected);
			}
		}

		public string UncheckedTitle
		{
			set
			{
				SetTitle(value, UIControlState.Normal);
			}
		}

		public bool Checked
		{
			set { Selected = value; }
			get { return Selected; }
		}

		void Initialize()
		{
			ApplyStyle();

			TouchUpInside += (sender, args) => Selected = !Selected;
			// set default color, because type is not UIButtonType.System 
			SetTitleColor(UIColor.DarkTextColor, UIControlState.Normal);
			SetTitleColor(UIColor.DarkTextColor, UIControlState.Selected);
		}

		void ApplyStyle()
		{
			SetImage(UIImage.FromBundle("checked_checkbox.png"), UIControlState.Selected);
			SetImage(UIImage.FromBundle("unchecked_checkbox.png"), UIControlState.Normal);
		}
    }
}
