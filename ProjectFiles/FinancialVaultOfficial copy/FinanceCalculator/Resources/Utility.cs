using System;

using AVFoundation; 
using Foundation; 
using UIKit;


namespace FinanceCalculator
{
	public class Utility
	{
		NavMasterController navMain = new NavMasterController ();

		//AI speech 
		public void AIEnglish(string textToSpeech, string accent, float speechRate, float volume, float pitchMultiplier)
		{

			AVSpeechSynthesizer speech = new AVSpeechSynthesizer();

			AVSpeechUtterance speechUtterance = new AVSpeechUtterance(textToSpeech)
			{
				Rate = AVSpeechUtterance.MaximumSpeechRate / speechRate,
				Voice = AVSpeechSynthesisVoice.FromLanguage(accent),
				Volume = volume,
				PitchMultiplier = pitchMultiplier
			};

			speech.SpeakUtterance(speechUtterance);
		}

	
		//battery monitoring
		public void BatteryLevel() {
			UIDevice.CurrentDevice.BatteryMonitoringEnabled = true; 

			if (UIDevice.CurrentDevice.BatteryLevel >= 0.2f && UIDevice.CurrentDevice.BatteryLevel <= 0.4) {
				AIEnglish ("⚡️ Low battery detected. You should charge your battery", "en-US", 2.5f, 1.0f, 1.0f);

				UIAlertController batteryAlert = UIAlertController.Create ("Low Battery", "Battery is currently measured at " + UIDevice.CurrentDevice.BatteryLevel * 100 + "%", UIAlertControllerStyle.Alert); 

				UIAlertAction confirmed = UIAlertAction.Create ("Thanks for telling me", UIAlertActionStyle.Default, (Action) => {
					batteryAlert.Dispose();
				});

				batteryAlert.AddAction (confirmed); 

				if (navMain.PresentedViewController == null) {
					navMain.PresentViewController (batteryAlert, true, null); 
				} else if (navMain.PresentedViewController != null) {
					navMain.PresentedViewController.DismissViewController (true, () => {
						navMain.PresentViewController(batteryAlert, true, null);
					});
				}
			}
		}
			
		public Utility ()
		{

		}
	}
}

