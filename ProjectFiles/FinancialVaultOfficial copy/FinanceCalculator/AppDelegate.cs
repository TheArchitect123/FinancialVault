using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq; 

using Foundation;
using UIKit;
using AVFoundation;
using CoreVideo;
using CoreMedia;
using CoreGraphics;
using CoreFoundation; 

namespace FinanceCalculator
{
	// The UIApplicationDelegate for the application. This class is responsible for launching the
	// User Interface of the application, as well as listening (and optionally responding) to application events from iOS.
	[Register ("AppDelegate")]
	public class AppDelegate : UIApplicationDelegate
	{
		// class-level declarations

		#region error variable 
		private NSError Error; 
		#endregion

		#region computed properties 
		public override UIWindow Window {get;set;}

		public bool CameraAvailable { get; set;}
		public AVCaptureSession Session { get; set;}
		public AVCaptureDevice CaptureDevice { get; set;}
		public OutputRecorder Recorder { get; set; }
		public DispatchQueue Queue { get; set;}
		public AVCaptureDeviceInput Input { get; set;}
		#endregion

		private NavMasterController navController = new NavMasterController();


		public double incomeTotal;
		public double expensesTotal;

		//expenses total items
		public double rentRef;
		public double housingRef;
		public double mortgageRef;
		public double insuranceRef;
		public double taxesRef;
		public double carPaymentsRef;
		public double educationRef;
		public double electronicsRef;
		public double entertainmentRef;
		public double clothingRef;
		public double petsRef;
		public double charityRef;
		public double foodRef;
		public double healthLifestyleRef;
		public double gardeningRef;
		public double cleaningRef;
		public double utilitiesRef;
		public double otherExpenseRef;



		//income total items
		public double wagesRef;
		public double realestateRef;
		public double salesHouseStockRef;
		public double smallBusinessRef;
		public double gamblingWinningsRef;
		public double salesOfTradesRef;
		public double intellectualPropertyRef;
		public double appRoyaltiesRef;
		public double bookPublishingRef;
		public double tradeDividendsRef;
		public double bankInterestRef;
		public double taxReturnRef;
		public double studentLoanRef;
		public double inheritanceRef;
		public double prizeMoneyRef;
		public double otherIncomeRef;


		//These are the variables to temporarily store the income data when the user pops the income controller off the navigation stack
		public List<double> wages = new List<double>(){};
		public List<double> realestate= new List<double>() { };
		public List<double> salesHouseStock= new List<double>() { };
		public List<double> smallBusiness= new List<double>() { };
		public List<double> gamblingWinnings= new List<double>() { };
		public List<double> salesOfTrades= new List<double>() { };
		public List<double> intellectualProperty= new List<double>() { };
		public List<double> appRoyalties= new List<double>() { };
		public List<double> bookPublishing= new List<double>() { };
		public List<double> tradeDividends= new List<double>() { };
		public List<double> bankInterest= new List<double>() { };
		public List<double> taxReturn= new List<double>() { };
		public List<double> studentLoan= new List<double>() { };
		public List<double> inheritance= new List<double>() { };
		public List<double> prizeMoney= new List<double>() { };
		public List<double> otherIncome= new List<double>() { };

		public List<string> wages_Description= new List<string>() { };
		public List<string> realestate_Description = new List<string>() { };
		public List<string> salesHouseStock_Description = new List<string>() { };
		public List<string> smallBusiness_Description = new List<string>() { };
		public List<string> gamblingWinnings_Description = new List<string>() { };
		public List<string> salesOfTrades_Description = new List<string>() { };
		public List<string> intellectualProperty_Description = new List<string>() { };
		public List<string> appRoyalties_Description = new List<string>() { };
		public List<string> bookPublishing_Description = new List<string>() { };
		public List<string> tradeDividends_Description = new List<string>() { };
		public List<string> bankInterest_Description = new List<string>() { };
		public List<string> taxReturn_Description = new List<string>() { };
		public List<string> studentLoan_Description = new List<string>() { };
		public List<string> inheritance_Description = new List<string>() { };
		public List<string> prizeMoney_Description = new List<string>() { };
		public List<string> otherIncome_Description = new List<string>() { };


		//expenses amounts
		public List<double> rentExpenses = new List<double>() { };
		public List<double> housingExpenses = new List<double>() { };
		public List<double> mortageExpenses = new List<double>() { };
		public List<double> insuranceExpenses = new List<double>() { };
		public List<double> taxesExpenses = new List<double>() { };
		public List<double> carPaymentsExpenses = new List<double>() { };
		public List<double> educationExpenses = new List<double>() { };
		public List<double> electronicsExpenses = new List<double>() { };
		public List<double> entertainmentExpenses = new List<double>() { };
		public List<double> clothingExpenses = new List<double>() { };
		public List<double> petsExpenses = new List<double>() { };
		public List<double> charityExpenses = new List<double>() { };
		public List<double> foodExpenses = new List<double>() { };
		public List<double> gardeningExpenses = new List<double>() { };
		public List<double> healthExpenses = new List<double>() { };
		public List<double> cleaningExpenses = new List<double>() { };
		public List<double> utilitiesExpenses = new List<double>() { };
		public List<double> otherExpenses = new List<double>() { };




		//list of descriptions
		public List<string> rentName = new List<string>() { };
		public List<string> housingName = new List<string>() { };
		public List<string> mortageName = new List<string>() { };
		public List<string> insuranceName = new List<string>() { };
		public List<string> taxesName = new List<string>() { };
		public List<string> carPaymentsName = new List<string>() { };
		public List<string> educationName = new List<string>() { };
		public List<string> electronicsName = new List<string>() { };
		public List<string> entertainmentName = new List<string>() { };
		public List<string> clothingName = new List<string>() { };
		public List<string> petsName = new List<string>() { };
		public List<string> charityName = new List<string>() { };
		public List<string> foodName = new List<string>() { };
		public List<string> gardeningName = new List<string>() { };
		public List<string> healthName = new List<string>() { };
		public List<string> cleaningName = new List<string>() { };
		public List<string> utilitiesName = new List<string>() { };
		public List<string> otherName = new List<string>() { };


		//expenses totals number, and description
		public List<double> expenseAmount = new List<double>() { };
		public List<string> nameExpenses = new List<string>() { };

		private void errorCamera(string title, string message) {
			UIAlertController errorController = UIAlertController.Create(title, message, UIAlertControllerStyle.Alert);

			UIAlertAction confirmed = UIAlertAction.Create("Ok", UIAlertActionStyle.Default, (Action) =>
			{
				errorController.Dispose();
			});

			errorController.AddAction(confirmed); 

			if(navController.PresentedViewController == null) {
				navController.PresentViewController(errorController, true, null);
			}
			else if(navController.PresentedViewController != null) {
				navController.PresentedViewController.DismissViewController(true, () =>
				{
					navController.PresentedViewController.Dispose();
					navController.PresentViewController(errorController, true, null);
				});
			}
		}

		public override void FinishedLaunching(UIApplication application)
		{
			//Create a new capture session 
			Session = new AVCaptureSession();
			Session.SessionPreset = AVCaptureSession.PresetMedium;

			//create a device input 
			CaptureDevice = AVCaptureDevice.DefaultDeviceWithMediaType(AVMediaType.Video);

			if (CaptureDevice == null) {
				//Video capture not supported, abort camera operation
				if(UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad) {
					errorCamera("No Camera detected", "Seems your " + UIDevice.CurrentDevice.UserInterfaceIdiom + " has no camera. You must have a camera installed to use this feature");
					CameraAvailable = false;
					return;
				}

				else if(UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone) {
					errorCamera("No Camera detected", "Seems your " + UIDevice.CurrentDevice.UserInterfaceIdiom + " has no camera. You must have a camera installed to use this feature");
					CameraAvailable = false;
					return;
				}
			}
			else {
				CaptureDevice.LockForConfiguration(out Error); 
				if(Error != null) {
					Console.WriteLine("Error detected in camera configuration: {0} ", Error.LocalizedDescription);
					CaptureDevice.UnlockForConfiguration();
					return;
				}
				else {
					//configure a stream for 40 frames per second fps
					CaptureDevice.ActiveVideoMinFrameDuration = new CMTime(1, 40);

					//unlock configuration 
					CaptureDevice.UnlockForConfiguration();

					//get input from capture device 
					Input = AVCaptureDeviceInput.FromDevice(CaptureDevice);

					if (Input == null) {
						switch(UIDevice.CurrentDevice.UserInterfaceIdiom) {
							case UIUserInterfaceIdiom.Pad:
								errorCamera("No Input", "No input detected from the camera on your: " +  UIUserInterfaceIdiom.Pad);
								CameraAvailable = false;
								return;
								break;
							case UIUserInterfaceIdiom.Phone:
								errorCamera("No Input", "No input detected from the camera on your: " + UIUserInterfaceIdiom.Phone);
								CameraAvailable = false;
								return;
								break;
						}
					}

					else {
						//attach input to session 
						Session.AddInput(Input);

						//create a new output 
						var output = new AVCaptureVideoDataOutput();
						var settings = new AVVideoSettingsUncompressed();
						settings.PixelFormatType = CVPixelFormatType.CV32BGRA;
						output.WeakVideoSettings = settings.Dictionary;

						//configure and attach to the output to the session 
						Queue = new DispatchQueue("ManCamQueue");
						Recorder = new OutputRecorder();
						output.SetSampleBufferDelegate(Recorder, Queue);
						Session.AddOutput(output);

						CameraAvailable = true;
					}
				}
				
			}
		}

		public override bool WillFinishLaunching (UIApplication application, NSDictionary launchOptions)
		{
			Utility utilityRef = new Utility (); 
			if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone) {
				if (UIDevice.CurrentDevice.CheckSystemVersion (8, 0)) {
					//OS is up to date
					utilityRef.AIEnglish("Welcome to Financial Vault made by Dan Gerchcovich", "en-US", 2.2f, 1.0f, 1.0f);
					var settings = UIUserNotificationSettings.GetSettingsForTypes (UIUserNotificationType.Alert & UIUserNotificationType.Sound, null);
					UIApplication.SharedApplication.RegisterUserNotificationSettings (settings);

					UILocalNotification batteryNotification = new UILocalNotification(); 

					NSDate.FromObject (UIDevice.BatteryLevelDidChangeNotification); 

					batteryNotification.SoundName = UILocalNotification.DefaultSoundName; 

					UIApplication.SharedApplication.ScheduleLocalNotification (batteryNotification);
					UIApplication.SharedApplication.StatusBarStyle = UIStatusBarStyle.BlackOpaque; 
					return true; 
				} else {
					//OS is out of date 
					utilityRef.AIEnglish("Your iPhone's OS is out of date. Please update to the latest operating system to use this application", "en-US", 2.5f, 1.0f, 1.0f); 
					return false;
				}
				return true;
			}

			else if(UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad) {
				

				if(UIDevice.CurrentDevice.CheckSystemVersion(8,0)) {
					utilityRef.AIEnglish("Welcome to Financial Vault made by Dan Gerchcovich", "en-US", 2.2f, 1.0f, 1.0f);

					var settings = UIUserNotificationSettings.GetSettingsForTypes(UIUserNotificationType.Alert & UIUserNotificationType.Sound, null);
					UIApplication.SharedApplication.RegisterUserNotificationSettings(settings);

					//local notifications
					UILocalNotification batteryNotification = new UILocalNotification(); 

					NSDate.FromObject(UIDevice.BatteryLevelDidChangeNotification); 

					batteryNotification.SoundName = UILocalNotification.DefaultSoundName; 

					UIApplication.SharedApplication.ScheduleLocalNotification(batteryNotification); 
					UIApplication.SharedApplication.StatusBarStyle = UIStatusBarStyle.BlackOpaque; 
					return true;
				}
			}
			return true;
		}
		public override bool FinishedLaunching (UIApplication application, NSDictionary launchOptions)
		{
			Utility utilityRef = new Utility();
			if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone)
			{
				if (UIDevice.CurrentDevice.CheckSystemVersion(8, 0))
				{
					//OS is up to date
					utilityRef.AIEnglish("Welcome to Financial Vault made by Dan Gerchcovich", "en-US", 2.2f, 1.0f, 1.0f);
					var settings = UIUserNotificationSettings.GetSettingsForTypes(UIUserNotificationType.Alert & UIUserNotificationType.Sound, null);
					UIApplication.SharedApplication.RegisterUserNotificationSettings(settings);

					UILocalNotification batteryNotification = new UILocalNotification();

					NSDate.FromObject(UIDevice.BatteryLevelDidChangeNotification);

					batteryNotification.SoundName = UILocalNotification.DefaultSoundName;

					UIApplication.SharedApplication.ScheduleLocalNotification(batteryNotification);
					UIApplication.SharedApplication.StatusBarStyle = UIStatusBarStyle.BlackOpaque;
					return true;
				}
				else {
					//OS is out of date 
					utilityRef.AIEnglish("Your iPhone's OS is out of date. Please update to the latest operating system to use this application", "en-US", 2.5f, 1.0f, 1.0f);
					return false;
				}
				return true;
			}

			else if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
			{


				if (UIDevice.CurrentDevice.CheckSystemVersion(8, 0))
				{
					utilityRef.AIEnglish("Welcome to Financial Vault made by Dan Gerchcovich", "en-US", 2.2f, 1.0f, 1.0f);

					var settings = UIUserNotificationSettings.GetSettingsForTypes(UIUserNotificationType.Alert & UIUserNotificationType.Sound, null);
					UIApplication.SharedApplication.RegisterUserNotificationSettings(settings);

					//local notifications
					UILocalNotification batteryNotification = new UILocalNotification();

					NSDate.FromObject(UIDevice.BatteryLevelDidChangeNotification);

					batteryNotification.SoundName = UILocalNotification.DefaultSoundName;

					UIApplication.SharedApplication.ScheduleLocalNotification(batteryNotification);
					UIApplication.SharedApplication.StatusBarStyle = UIStatusBarStyle.BlackOpaque;
					return true;
				}
			}
			return true;
		}

		public override void ReceivedLocalNotification (UIApplication application, UILocalNotification notification)
		{
			Utility utility = new Utility (); 
			utility.BatteryLevel (); 
		}

		public override void ReceiveMemoryWarning (UIApplication application)
		{
			System.Console.WriteLine ("Memory warning has been received");
		}

		public override void OnResignActivation (UIApplication application)
		{
			// Invoked when the application is about to move from active to inactive state.
			// This can occur for certain types of temporary interruptions (such as an incoming phone call or SMS message) 
			// or when the user quits the application and it begins the transition to the background state.
			// Games should use this method to pause the game.
		}

		public override void DidEnterBackground (UIApplication application)
		{
			// Use this method to release shared resources, save user data, invalidate timers and store the application state.
			// If your application supports background exection this method is called instead of WillTerminate when the user quits.
		}

		public override void WillEnterForeground (UIApplication application)
		{
			// Called as part of the transiton from background to active state.
			// Here you can undo many of the changes made on entering the background.
		}

		public override void OnActivated (UIApplication application)
		{
			// Restart any tasks that were paused (or not yet started) while the application was inactive. 
			// If the application was previously in the background, optionally refresh the user interface.
		}

		public override void WillTerminate (UIApplication application)
		{
		}
	}
}


