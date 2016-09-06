using System;
using System.Collections.Generic;
using System.Collections; 

using Foundation;
using UIKit;
using CoreGraphics;
using MessageUI;

/*
 * Leftover tasks: 
 * Settings Controller 
 * Scientific calculator 
 * 

*/

//to control the AI monitor and Battery monitor simply pass the boolean ciontrol value to each class that implements them

namespace FinanceCalculator
{
	partial class SettingsController : UITableViewController
	{
		public SettingsController(IntPtr handle) : base(handle)
		{
		}

		Utility AI = new Utility();

		//section 1 items
		List<string> backgroundOptions = new List<string>() {
			{"\ud83d\udd0b Battery Monitor"}, {"\ud83d\udcf1 Artificial Intelligence"}
		};
		//section 1 items (Front view)
		List<string> springboardOptions = new List<string>() { 
			{"\ud83d\udcd3 About"}, {"♥️ Share"}, {"\ud83d\udc4d Rate on App Store"},{"⚠️ Report an Issue"}
		};

		/* 
		 * 
		 * Section Items: 
		 * 
		 	 Section 1:
		 * Battery monitor control 
		 * Enable or disable AI 
		 * 
			 Section 2:
		 * Sharing function *
		 * About *
		 * Rate on App Store*
		 * More Apps (Directs user to the more apps tab, or just directs to some of the more popular apps)*
		 * Disclaimer 
		 * Report an issue *
		*/


		//section 2 alert controllers
		private void aboutAlert(string title, string message) {
			UIAlertController about = UIAlertController.Create(title, message, UIAlertControllerStyle.Alert);

			UIAlertAction confirmed = UIAlertAction.Create("Ok", UIAlertActionStyle.Default, (Action) =>
			{
				about.Dispose();
			});

			about.AddAction(confirmed); 

			if(this.PresentedViewController == null) {
				this.PresentViewController(about, true, null);
			}

			else if(this.PresentedViewController != null) {
				this.PresentedViewController.DismissViewController(true, () =>
				{
					this.PresentedViewController.Dispose();
					this.PresentViewController(about, true, null);
				});
			}
		}


		//sharing options
		private void shareAlert(string title, string message)
		{
			UIAlertController shareController = UIAlertController.Create(title, message, UIAlertControllerStyle.Alert);


			//facebook servers
			UIAlertAction facebookAction = UIAlertAction.Create("Facebook", UIAlertActionStyle.Default, (Action) => {
				NSUrl facebookURL = NSUrl.FromString("");

				if (UIApplication.SharedApplication.CanOpenUrl(facebookURL) == true)
				{
					UIApplication.SharedApplication.OpenUrl(facebookURL);
					shareController.Dispose();
				}
				else if (UIApplication.SharedApplication.CanOpenUrl(facebookURL) == false)
				{
					AI.AIEnglish("Cannot connect you to the facebook servers. Check your internet connection", "en-US", 2.0f, 1.0f, 1.0f);
					shareController.Dispose();
				}
			});

			//twitter servers
			UIAlertAction twitterAction = UIAlertAction.Create("Twitter", UIAlertActionStyle.Default, (Action) =>
			{
				NSUrl twitterURL = NSUrl.FromString("");

				if (UIApplication.SharedApplication.CanOpenUrl(twitterURL) == true)
				{
					UIApplication.SharedApplication.OpenUrl(twitterURL);
					shareController.Dispose();
				}
				else if (UIApplication.SharedApplication.CanOpenUrl(twitterURL) == false)
				{
					AI.AIEnglish("Cannot connect you to the twitter servers. Check your internet connection", "en-US", 2.0f, 1.0f, 1.0f);
					shareController.Dispose();
				}
			});

			//email a friend option
			UIAlertAction emailFriend = UIAlertAction.Create("\ud83d\udc8c Email a Friend", UIAlertActionStyle.Default, (Action) =>
			{
				MFMailComposeViewController mailEmail = new MessageUI.MFMailComposeViewController();

				if (MFMailComposeViewController.CanSendMail == true)
				{
					this.PresentViewController(mailEmail, true, null);
				}

				else {
					if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
					{
						AI.AIEnglish("Error cannot open mail box. Check if the mail box is enabled on your iPad", "en-US", 2.0f, 1.0f, 1.0f);
					}
					else if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone)
					{
						AI.AIEnglish("Error cannot open mail box. Check if the mail box is enabled on your iPhone", "en-US", 2.0f, 1.0f, 1.0f);
					}
				}

				mailEmail.Finished += (sender, e) =>
				{
					//mail closes
					mailEmail.DismissViewController(true, null);
				};
			});

			//text a friend option
			UIAlertAction textFriend = UIAlertAction.Create("\ud83d\udcf2 Text a friend", UIAlertActionStyle.Default, (Action) => {
				NSUrl textFriendURL = NSUrl.FromString("sms:");

				if(UIApplication.SharedApplication.CanOpenUrl(textFriendURL) == true) {
					UIApplication.SharedApplication.OpenUrl(textFriendURL); 
				}
				else if(UIApplication.SharedApplication.CanOpenUrl(textFriendURL) == false) {
					if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
					{
						AI.AIEnglish("Error cannot open text message box. Check if the text messages are enabled on your iPad", "en-US", 2.0f, 1.0f, 1.0f);
					}
					else if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone)
					{
						AI.AIEnglish("Error cannot open text message box. Check if the text messages are enabled on your iPhone", "en-US", 2.0f, 1.0f, 1.0f);
					}
				}
			});

			UIAlertAction rateOnAppStore = UIAlertAction.Create("\ud83d\udc4d Rate on App Store", UIAlertActionStyle.Default, (Action) =>
			{
				NSUrl urlRateAppURL = NSUrl.FromString(""); //url of application on app store

				if(UIApplication.SharedApplication.CanOpenUrl(urlRateAppURL) == true) {
					UIApplication.SharedApplication.OpenUrl(urlRateAppURL);
				}

				else {
					if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
					{
						AI.AIEnglish("No internet connection detected. Cannot connect to the App Store", "en-US", 2.5f, 1.0f, 1.0f);
					}
					else if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone)
					{
						AI.AIEnglish("No internet connection detected.  Cannot connect to the App Store", "en-US", 2.5f, 1.0f, 1.0f);
					}
					shareController.Dispose();
				}
			});

			UIAlertAction denied = UIAlertAction.Create("Maybe Later", UIAlertActionStyle.Destructive, (Action) =>
			{
				shareController.Dispose();
			});

			shareController.AddAction(facebookAction); 
			shareController.AddAction(twitterAction);
			shareController.AddAction(emailFriend);
			shareController.AddAction(textFriend);
			shareController.AddAction(rateOnAppStore);
			shareController.AddAction(denied);

			if (this.PresentedViewController == null)
			{
				this.PresentViewController(shareController, true, null);
			}

			else if (this.PresentedViewController != null)
			{
				this.PresentedViewController.DismissViewController(true, () =>
				{
					this.PresentedViewController.Dispose();
					this.PresentViewController(shareController, true, null);
				});
			}
		}


		private void rateOnAppStore(string title, string message) {
			UIAlertController rateAppStore = UIAlertController.Create(title, message, UIAlertControllerStyle.Alert);

			UIAlertAction rateAction = UIAlertAction.Create("Rate on the App Store", UIAlertActionStyle.Default, (Action) =>
			{
				NSUrl appStoreURL = NSUrl.FromString(""); //URL of this application on the app store
				if(UIApplication.SharedApplication.CanOpenUrl(appStoreURL) == true) {
					UIApplication.SharedApplication.OpenUrl(appStoreURL); 
				}
				else {
					if(UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad) {
						AI.AIEnglish("No internet connection detected. Cannot connect to the App Store", "en-US", 2.5f, 1.0f, 1.0f);
					}
					else if(UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone) {
						AI.AIEnglish("No internet connection detected. Cannot connect to the App Store", "en-US", 2.5f, 1.0f, 1.0f);
					}
				}
			});

			UIAlertAction denied = UIAlertAction.Create("Maybe Later", UIAlertActionStyle.Destructive, (Action) =>
			{
				rateAppStore.Dispose();
			});

			rateAppStore.AddAction(rateAction);
			rateAppStore.AddAction(denied);


			if (this.PresentedViewController == null)
			{
				this.PresentViewController(rateAppStore, true, null);
			}
			else if (this.PresentedViewController != null)
			{
				this.PresentedViewController.DismissViewController(true, () =>
				{
					rateAppStore.Dispose();
					this.PresentViewController(rateAppStore, true, null);
				});
			}
		}

		private void reportIssue(string title, string message) {
			UIAlertController reportIssueController = UIAlertController.Create(title, message, UIAlertControllerStyle.Alert);

			UIAlertAction reportIssueAction = UIAlertAction.Create("Email Tech Support", UIAlertActionStyle.Default, (Action) =>{
				MFMailComposeViewController mail = new MFMailComposeViewController(); 

				if(MFMailComposeViewController.CanSendMail == true) {
					mail.SetToRecipients(new String[] { "dan.developer789@gmail.com" });
					this.PresentViewController(mail, true, null);
				}
				else {
					if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
					{
						AI.AIEnglish("Mail Box is not enabled on your iPad", "en-US", 2.0f, 1.0f, 1.0f);
					}
					else if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone)
					{
						AI.AIEnglish("Mail Box is not enabled on your iPhone", "en-US", 2.0f, 1.0f, 1.0f);
					}
				}

				mail.Finished += (sender, e) => {
					mail.DismissViewController(true, null);
				};

			});

			UIAlertAction denied = UIAlertAction.Create("Never Mind", UIAlertActionStyle.Cancel, (Action) =>
			{
				reportIssueController.Dispose();
			});

			reportIssueController.AddAction(reportIssueAction);
			reportIssueController.AddAction(denied); 

			if(this.PresentedViewController == null) {
				this.PresentViewController(reportIssueController, true, null); 
			}
			else if(this.PresentedViewController != null) {
				this.PresentedViewController.DismissViewController(true, () =>
				{
					reportIssueController.Dispose();
					this.PresentViewController(reportIssueController, true, null);
				});
			}
		}


		//section 0 alert controllers
		private void batteryMonitorController(string title, string message) {
			UIAlertController batteryController = UIAlertController.Create(title, message, UIAlertControllerStyle.Alert);

			UIAlertAction batteryEnabled = UIAlertAction.Create("Enabled", UIAlertActionStyle.Default, (Action) =>
			{
				//enable the battery monitor (Pass in boolean value that determines if the battery monitor is enabled or not)

				//you can try doing this with objects but we will see

			});

			UIAlertAction batteryDisabled = UIAlertAction.Create("Disabled", UIAlertActionStyle.Cancel, (Action) =>
			{
				batteryController.Dispose();
			});

			batteryController.AddAction(batteryEnabled); 
			batteryController.AddAction(batteryDisabled);

			if (this.PresentedViewController == null)
			{
				this.PresentViewController(batteryController, true, null);
			}

			else if (this.PresentedViewController != null) {
				this.PresentedViewController.DismissViewController(true, () => {
					batteryController.Dispose();
					this.PresentViewController(batteryController, true, null);
				});
			}
		}

		//AI Control. Determines if AI is on or off. AI that will assist the user with any problems
		private void AIFeatures(string title, string message)
		{
			UIAlertController AIController = UIAlertController.Create(title, message, UIAlertControllerStyle.Alert);

			UIAlertAction batteryEnabled = UIAlertAction.Create("Enabled", UIAlertActionStyle.Default, (Action) =>
			{
				//enable the AI (Pass in boolean value that determines if the battery monitor is enabled or not)
				//same thing as the battery monitor
			});

			UIAlertAction batteryDisabled = UIAlertAction.Create("Disabled", UIAlertActionStyle.Cancel, (Action) =>
			{
				AIController.Dispose();
			});


			AIController.AddAction(batteryEnabled);
			AIController.AddAction(batteryDisabled);
			if (this.PresentedViewController == null)
			{
				this.PresentViewController(AIController, true, null);
			}

			else if (this.PresentedViewController != null)
			{
				this.PresentedViewController.DismissViewController(true, () =>
				{
					AIController.Dispose();
					this.PresentViewController(AIController, true, null);
				});
			}
		}

		public override nint NumberOfSections(UITableView tableView)
		{
			return 2; 
		}

		public override void ViewDidAppear(bool animated)
		{
			base.ViewDidAppear(animated);
			this.NavigationController.SetNavigationBarHidden(false, false);

			//custom nav bar 
			UINavigationBar settingsBar = new UINavigationBar();

			UINavigationItem settingsTitle = new UINavigationItem();
			settingsTitle.Title = "Settings";

			settingsBar.Items = new UINavigationItem[] {settingsTitle };

			this.View.AddSubview(settingsBar);
		}

		public override void ViewDidLoad()
		{
			this.NavigationController.NavigationBar.Hidden = false;
			this.View.BackgroundColor = UIColor.White;
			this.TableView.SeparatorColor = UIColor.LightGray;
			this.TableView.Frame = new CGRect(0, 50, this.View.Frame.Width, this.View.Frame.Height);

			UIView cover = new UIView();

			if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
			{
				switch (UIApplication.SharedApplication.StatusBarOrientation)
				{
					case UIInterfaceOrientation.LandscapeLeft: 
			
					cover.Frame = new CGRect(0, 532, this.View.Frame.Size.Width + 700, 600);
					cover.BackgroundColor = UIColor.LightGray;
			

				this.View.AddSubview(cover);
				this.View.BringSubviewToFront(cover);
					break;

					case UIInterfaceOrientation.LandscapeRight:
						
						cover.Frame = new CGRect(0, 532, this.View.Frame.Size.Width + 700, 600);
						cover.BackgroundColor = UIColor.LightGray;

						this.View.AddSubview(cover);
						this.View.BringSubviewToFront(cover);
						break;

					default:
						cover.Frame = new CGRect(0, 532, this.View.Frame.Size.Width + 400, 600);
						cover.BackgroundColor = UIColor.LightGray;

						this.View.AddSubview(cover);
						this.View.BringSubviewToFront(cover);
						break;
				}
			}
			else if(UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone) {
				cover.Frame = new CGRect(0, 532, this.View.Frame.Width, 600);
				cover.BackgroundColor = UIColor.LightGray;
				this.TableView.Frame = new CGRect(0, 0, this.View.Frame.Width, 150);

				this.View.AddSubview(cover);
				this.View.BringSubviewToFront(cover);
			}
		}

		public override nint RowsInSection(UITableView tableView, nint section)
		{

			//section 0
			if(section == 0) {
				return this.backgroundOptions.Count;
			}

			//section 1
			else if(section == 1) {
				return this.springboardOptions.Count; 
			}
			return 0;
		}

		public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
		{
			UITableViewCell settingsCell = tableView.DequeueReusableCell("settingsCell");

			if (settingsCell == null)
			{
				settingsCell = new UITableViewCell(UITableViewCellStyle.Default, "settingsCell");
			}

			switch (indexPath.Section)
			{
				case 0: //background processes
					if (UIApplication.SharedApplication.StatusBarOrientation == UIInterfaceOrientation.LandscapeLeft || UIApplication.SharedApplication.StatusBarOrientation == UIInterfaceOrientation.LandscapeRight)
					{
						settingsCell.TextLabel.Text = this.backgroundOptions[indexPath.Row];
						settingsCell.TextLabel.TextColor = UIColor.Black;
						tableView.RowHeight = 70.0f;
					}
					else if (UIApplication.SharedApplication.StatusBarOrientation == UIInterfaceOrientation.Portrait || UIApplication.SharedApplication.StatusBarOrientation == UIInterfaceOrientation.PortraitUpsideDown || UIApplication.SharedApplication.StatusBarOrientation == UIInterfaceOrientation.Unknown)
					{
						settingsCell.TextLabel.Text = this.backgroundOptions[indexPath.Row];
						settingsCell.TextLabel.TextColor = UIColor.Black;
						tableView.RowHeight = 70.0f;
					}

					return settingsCell;
					break;
				case 1: //view processes
					if (UIApplication.SharedApplication.StatusBarOrientation == UIInterfaceOrientation.LandscapeLeft || UIApplication.SharedApplication.StatusBarOrientation == UIInterfaceOrientation.LandscapeRight)
					{
						settingsCell.TextLabel.Text = this.springboardOptions[indexPath.Row];
						settingsCell.TextLabel.TextColor = UIColor.Black;
						tableView.RowHeight = 70.0f;
					}
					else if (UIApplication.SharedApplication.StatusBarOrientation == UIInterfaceOrientation.Portrait || UIApplication.SharedApplication.StatusBarOrientation == UIInterfaceOrientation.PortraitUpsideDown || UIApplication.SharedApplication.StatusBarOrientation == UIInterfaceOrientation.Unknown)
					{
						settingsCell.TextLabel.Text = this.springboardOptions[indexPath.Row];
						settingsCell.TextLabel.TextColor = UIColor.Black;
						tableView.RowHeight = 70.0f;
					}
					return settingsCell;
					break;
			}

			return settingsCell;
		}

		public override string TitleForHeader(UITableView tableView, nint section)
		{
			switch(section) {
				case 0:
					return "⚙ Background Processes";

					break;
				case 1:
					return "\ud83d\udd27 General";
					break;
			}
			return "";
		}



		public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
		{
			switch (indexPath.Section)
			{
				case 0:
					switch (indexPath.Row)
					{
						case 0:
							batteryMonitorController("", "Would you like to enable or disable the battery monitor");
							break;
						
						case 1:
							AIFeatures("Turn off AI", "The AI helps increase the performance of the application. It assists you with any problems, if any, and notifies you of any bugs");
							break;
					}
					break;
				case 1:
					switch(indexPath.Row) {
						case 0:  // about
							aboutAlert("Welcome to 3-in-1 Calculator", "This smart calculator helps you to manage your finances, perform math calculations via the scientific calculator. And calculate your income tax based on the tax laws of over 10 major countries");
							break;
						case 1: //share
							shareAlert("Share", "");
							break;
						case 2:  //disclaimer
							DisclaimerController disclaimer = new DisclaimerController();
							this.NavigationController.PushViewController(disclaimer, true);
							break;
						case 3: //Rate on App Store
							rateOnAppStore("Would you like to rate this app?", "");
							break;
						case 4: //report an issue
							reportIssue("Any Problems?", "Send me an email so I can address any bugs with the performance of the application. This will help improve you user experience");
							break;
					}
					break;
			}
			tableView.DeselectRow(indexPath, true);

		}
	}
}
