using System;
using System.Collections.Generic;
using System.Collections; 

using UIKit;
using CoreGraphics;
using Foundation;


namespace FinanceCalculator
{
	partial class BudgetController : UIViewController
	{
		public BudgetController (IntPtr handle) : base (handle) {}

		public BudgetController() {}



		public override void ViewDidAppear (bool animated)
		{
			base.ViewDidAppear (animated);
			UINavigationBar navBar = new UINavigationBar();
			navBar.Frame = new CGRect(0, 0, 100, 50);
			navBar.BarStyle = UIBarStyle.Default;

			this.NavigationController.SetNavigationBarHidden(true, true);

			this.NavigationItem.LeftBarButtonItem = null;
			this.NavigationItem.RightBarButtonItem = null;

			this.NavigationController.ToolbarHidden = true;
		}

		public override void ViewDidLoad ()
		{
			Currency expController = this.Storyboard.InstantiateViewController("Currency") as Currency;
			
			UIButton budgetStart = new UIButton (UIButtonType.InfoLight);

			budgetStart.UserInteractionEnabled = true;
			budgetStart.Frame = new CGRect (40, 40, 200, 200); 
			budgetStart.ShowsTouchWhenHighlighted = true;
			budgetStart.TintColor = UIColor.Blue;
		
			budgetStart.TouchDown += (object sender, EventArgs e) => {
				this.NavigationController.PushViewController(expController, true);
			};

			this.View.AddSubview (budgetStart);
		}
	}
}
