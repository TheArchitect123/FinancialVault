using System;

using UIKit;

namespace FinanceCalculator
{
	public partial class DisclaimerController : UIViewController
	{
		public DisclaimerController(IntPtr handler) : base(handler)
		{
		}

		public DisclaimerController() { }

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			this.NavigationItem.Title = "Disclaimer";
			this.NavigationItem.TitleView.TintColor = UIColor.LightGray;
			UIBarButtonItem acceptDisclaimer = new UIBarButtonItem("Ok", UIBarButtonItemStyle.Bordered, (sender, e) =>
			{
				this.DismissViewController(true, () =>
				{
					this.Dispose();
				});
			});
			acceptDisclaimer.TintColor = UIColor.Blue;


			UILabel privacyDescription = new UILabel();
			privacyDescription.Frame = new CoreGraphics.CGRect(0,50,this.View.Frame.Width, this.View.Frame.Height);
			privacyDescription.Text = "Sample Disclaimer description";
			this.View.AddSubview(privacyDescription);
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();

		}
	}
}


