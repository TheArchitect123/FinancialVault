using System;
using System.Collections;
using System.Collections.Generic;

using UIKit;
using CoreGraphics;
using AudioToolbox;
using AVFoundation; 

namespace FinanceCalculator
{
	//this class is used to display extra info the user has about a particular category he selects within the vault 

	public class ExtraInfoOpenController : UITableViewController
	{
		private List<string> currencyCategory = new List<string>() {
			{"\ud83c\uddfa\ud83c\uddf8 US Dollar (USD)"},{"\ud83c\uddea\ud83c\uddfa European Euro (EUR)"},{"\ud83c\uddef\ud83c\uddf5 Japanese Yen (JPY)"},
			{"\ud83c\uddec\ud83c\udde7 British Pound (GBP)"}, {"\ud83c\udde8\ud83c\udded Swiss Franc (CHF)"},{"\ud83c\udde8\ud83c\udde6 Canadian Dollar (CAD)"},{"\ud83c\udde6\ud83c\uddfa Australian Dollar (AUD)"},{"\ud83c\uddff\ud83c\udde6 South African Rand (ZAR)"}, {"\ud83c\uddf3\ud83c\uddff New Zealand Dollar (NZD)"},
			{"\ud83c\uddf2\ud83c\uddfd Mexican Peso (MXN)"},{"\ud83c\udde8\ud83c\uddf3 Chinese Yuan (CNY)"},{"\ud83c\uddf8\ud83c\uddea Swedish Krona (SEK)"},
			{"\ud83c\uddf7\ud83c\uddfa Russian Ruble (RUB)"},{"\ud83c\udded\ud83c\uddf0 Hong Kong Dollar (HKD)"},{"\ud83c\uddf3\ud83c\uddf4 Norwegian Krone (NOK)"},{"\ud83c\uddf8\ud83c\uddec Singapore Dollar (SGD)"}, {"\ud83c\uddf9\ud83c\uddf7 Turkish Lira (TRY)"},
			{"\ud83c\uddf0\ud83c\uddf7 South Korean Won(KRW)"},{"\ud83c\udde7\ud83c\uddf7 Brazilian Real (BRL)"},{"\ud83c\uddee\ud83c\uddf3 Indian Rupee (INR)"}
		};

		private List<string> currencySymbol = new List<string>()
		{
			{"$"},{"€"},{"¥"},{"£"},{"Fr"},{"$"},{"$"}, {"R"},{"$"},{"$"},
			{"¥"},{"kr"},{"₽"},{"$"},{"kr"},{"$"},{"₺"},{"₩"},
			{"R$"},{"₹"}
		};


		public AppDelegate propertiesAccess {
			get {
				return (AppDelegate)UIApplication.SharedApplication.Delegate;
			}
		}

		//from the application's delegate this class accesses the expenses and income lists and simply renders the cells 

		public ExtraInfoOpenController(){}

		public override void ViewDidLoad()
		{
			
		}


		public override UITableViewCell GetCell(UITableView tableView, Foundation.NSIndexPath indexPath)
		{
			UITableViewCell expensesCell = tableView.DequeueReusableCell("VaultCell");

			if(expensesCell == null) {
				expensesCell = new UITableViewCell(UITableViewCellStyle.Subtitle, "VaultCell"); 
			}

			UILabel amountOnCategory = new UILabel(); 


			if(UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone) {
				amountOnCategory.Frame = new CGRect(0, 30, 50, 50);
			}
			else if(UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad) {
				amountOnCategory.Frame = new CGRect(0, 30, 70, 70);
			}

			//currency sections
			switch(indexPath.Section) {
				
			}

			switch(indexPath.Section) {
				//expenses
				case 0:
					switch(indexPath.Row) {
						case 0: //rent category
							expensesCell.TextLabel.Text = "" + propertiesAccess.rentExpenses[indexPath.Row];
							expensesCell.TextLabel.TextColor = UIColor.Black;

							expensesCell.DetailTextLabel.Text = "Description " + propertiesAccess.rentName[indexPath.Row];
							expensesCell.DetailTextLabel.TextColor = UIColor.LightGray;




							return expensesCell;
							break;
						
					}
					break;
				//income 
				case 1:
					
					break;
				
			}	
		}

		public override nint RowsInSection(UITableView tableView, nint section)
		{
			switch(section) {
				case 0:
				return propertiesAccess.rentExpenses.Count;
					break;
				case 1:
			}
		}

		public override nint NumberOfSections(UITableView tableView)
		{
			return currencySymbol.Count 
		}

		public override void RowSelected(UITableView tableView, Foundation.NSIndexPath indexPath)
		{
			tableView.DeselectRow(indexPath, true);
		}


	}
}

