using System;
using System.Collections.Generic;
using System.Collections; 

using Foundation;
using UIKit;
using AudioToolbox;
using CoreGraphics;

//This controller describes the Vault

namespace FinanceCalculator
{
	public partial class ResultsControllerTotal : UITableViewController
	{
		public ResultsControllerTotal (IntPtr handle) : base (handle)
		{
		}

		public AppDelegate VaultPropertyAccess {
			get {
				return (AppDelegate)UIApplication.SharedApplication.Delegate;
			}
		}

		//total income
		double incomeTotal;
		double expensesTotal;

		//expenses total items
		double rentRef;
		double housingRef;
		double mortgageRef;
		double insuranceRef;
		double taxesRef;
		double carPaymentsRef;
		double educationRef;
		double electronicsRef;
		double entertainmentRef;
		double clothingRef;
		double petsRef;
		double charityRef;
		double foodRef;
		double healthLifestyleRef;
		double gardeningRef;
		double cleaningRef;
		double utilitiesRef;
		double otherExpenseRef;



		//income total items
		double wagesRef;
		double realestateRef;
		double salesHouseStockRef;
		double smallBusinessRef;
		double gamblingWinningsRef;
		double salesOfTradesRef;
		double intellectualPropertyRef;
		double appRoyaltiesRef;
		double bookPublishingRef;
		double tradeDividendsRef;
		double bankInterestRef;
		double taxReturnRef;
		double studentLoanRef;
		double inheritanceRef;
		double prizeMoneyRef;
		double otherIncomeRef;

		string symbolCurrencyHandler;  //currency symbol used

		List<double> expensesValues = new List<double>()
		{
		};
		List<double> incomeValues = new List<double>() { };

		// values

		public ResultsControllerTotal() {

			//total 
			incomeTotal = VaultPropertyAccess.incomeTotal;
			expensesTotal = VaultPropertyAccess.expensesTotal;

			//income section
			wagesRef = VaultPropertyAccess.wagesRef;
			realestateRef = VaultPropertyAccess.realestateRef;
			salesHouseStockRef = VaultPropertyAccess.salesHouseStockRef;
			smallBusinessRef = VaultPropertyAccess.smallBusinessRef;
			gamblingWinningsRef = VaultPropertyAccess.gamblingWinningsRef;
			salesOfTradesRef = VaultPropertyAccess.salesOfTradesRef;
			intellectualPropertyRef = VaultPropertyAccess.intellectualPropertyRef;
			appRoyaltiesRef = VaultPropertyAccess.appRoyaltiesRef;
			bookPublishingRef = VaultPropertyAccess.bookPublishingRef;
			tradeDividendsRef = VaultPropertyAccess.tradeDividendsRef;
			bankInterestRef = VaultPropertyAccess.bankInterestRef;
			taxReturnRef = VaultPropertyAccess.taxReturnRef;
			studentLoanRef = VaultPropertyAccess.studentLoanRef;
			inheritanceRef = VaultPropertyAccess.inheritanceRef;
			prizeMoneyRef = VaultPropertyAccess.prizeMoneyRef;
			otherIncomeRef = VaultPropertyAccess.otherIncomeRef;


			//expenses section
			rentRef = VaultPropertyAccess.rentRef;
			housingRef = VaultPropertyAccess.housingRef;
			mortgageRef = VaultPropertyAccess.mortgageRef;
			insuranceRef = VaultPropertyAccess.insuranceRef;
			taxesRef = VaultPropertyAccess.taxesRef;
			carPaymentsRef = VaultPropertyAccess.carPaymentsRef;
			educationRef = VaultPropertyAccess.educationRef;
			electronicsRef = VaultPropertyAccess.electronicsRef;
			entertainmentRef = VaultPropertyAccess.entertainmentRef;
			clothingRef = VaultPropertyAccess.clothingRef;
			petsRef = VaultPropertyAccess.petsRef;
			charityRef = VaultPropertyAccess.charityRef;
			foodRef = VaultPropertyAccess.foodRef;
			healthLifestyleRef = VaultPropertyAccess.healthLifestyleRef;
			gardeningRef = VaultPropertyAccess.gardeningRef;
			cleaningRef = VaultPropertyAccess.cleaningRef;
			utilitiesRef = VaultPropertyAccess.utilitiesRef;
			otherExpenseRef = VaultPropertyAccess.otherExpenseRef;

			expensesValues = new List<Double>(){
				rentRef, housingRef,mortgageRef, insuranceRef, taxesRef, carPaymentsRef, educationRef, electronicsRef, entertainmentRef,
				clothingRef, petsRef, charityRef, foodRef, healthLifestyleRef, gardeningRef, cleaningRef, utilitiesRef, otherExpenseRef
			};

			incomeValues = new List<Double>()
			{
				wagesRef, realestateRef, salesHouseStockRef, smallBusinessRef, gamblingWinningsRef, salesOfTradesRef, intellectualPropertyRef, 
				appRoyaltiesRef, bookPublishingRef, tradeDividendsRef, bankInterestRef, taxReturnRef, studentLoanRef, inheritanceRef, prizeMoneyRef, otherIncomeRef		
			};
		}


		List<string> expensesCategories = new List<string>() {
			{"\ud83d\udecf Rent"},{"\ud83c\udfe1 Housing"},{"\ud83d\udcb3 Mortgage"},{"\ud83d\udc94 Insurance"},{"\ud83d\udcd3 Taxes"},{"\ud83d\ude97 Car Payments"},{"\ud83d\udcda Education"},{"\ud83d\udd0c Electronics"},
			{"\ud83c\udfa5 Entertainment"},{"\ud83d\udc55 Clothing & Footwear"},{"\ud83d\udc08 Pets"},{"\ud83c\udf81 Charity"},{"\ud83c\udf54 Food"},{"\ud83d\udc5f Health & Lifestyle"},{"\ud83c\udf3b Gardening"},
			{"✨ Cleaning & Maintanance"},{"\ud83d\udec1 Utilities"},{"\ud83d\uddde Other"}
		};

		List<string> incomeCategories = new List<string>() {
			{"\ud83d\udcb0 Wages/Salaries"},{"\ud83c\udfe1 Realestate"},{"\ud83d\udcb5 Sales of Owned Stock/House Products"},{"\ud83d\udcd6 Small Business"},{"\ud83c\udfb0 Gambling winnings"},{"\ud83d\udcc8 Sales of Trades/Stocks"},{"\ud83d\udcd3 Intellectual Property"},{"\ud83c\udf7e App Royalties"},
			{"\ud83d\udce6 Book Publishing"},{"\ud83d\udcca Trade Dividends"},{"\ud83d\udcb3 Bank interest/Term Deposit"},{"\ud83d\udcdc Tax Return"},{"\ud83c\udfc5 Student Loan/Grant"},{"\ud83d\udc8e Inheritance"},{"\ud83c\udfc6 Prize Money"},{"\ud83d\udcf0 Other"}
		};


		public override nint NumberOfSections(UITableView tableView)
		{
			return 2;
		}

		public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
		{
			UITableViewCell listOfTable = tableView.DequeueReusableCell("listTable");

			if (listOfTable == null)
			{
				listOfTable = new UITableViewCell(UITableViewCellStyle.Subtitle, "listTable");
			}
			UIProgressView expensesProgress = new UIProgressView();
			expensesProgress.Style = UIProgressViewStyle.Default;

			if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone)
			{
				expensesProgress.Frame = new CGRect(0, 20, 100, 40);
			}
			else if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
			{
				expensesProgress.Frame = new CGRect(0, 20, 300, 50);
			}

			//draw the results sections 
			switch (indexPath.Section)
			{
				case 0: //expenses section

					listOfTable.TextLabel.Text = expensesCategories[indexPath.Row];
					listOfTable.TextLabel.TextColor = UIColor.Black;

					try {
						if(expensesValues.Count == 0) {
							throw new ArgumentOutOfRangeException();
						}
						else if(expensesValues.Count >= 0) {
							listOfTable.DetailTextLabel.Text = symbolCurrencyHandler + expensesValues[indexPath.Row];
							listOfTable.DetailTextLabel.TextColor = UIColor.Gray;
							listOfTable.DetailTextLabel.Font = UIFont.SystemFontOfSize(16.0f);
						}
					}
					catch(ArgumentOutOfRangeException) {
						
					}

					expensesProgress.TrackTintColor = UIColor.LightGray;
					expensesProgress.ProgressTintColor = UIColor.Red;
					tableView.AddSubview(expensesProgress);

					switch (indexPath.Row)
					{
						case 0:
							if (Double.IsNaN(rentRef) == true || Double.IsNaN(expensesTotal) == true)
							{
								rentRef = 0.0f;
								expensesTotal = 0.0f;
								expensesProgress.SetProgress((float)(rentRef / expensesTotal), false);
							}
							else if (rentRef >= 1 && expensesTotal >= 1)
							{
								expensesProgress.SetProgress((float)(rentRef / expensesTotal), false);
							}
							//create a progress image and track image on pixlr.com and assign them to the progress bar for each row 
							listOfTable.AccessoryView = expensesProgress;
							return listOfTable;
							break;

						case 1:
							if (Double.IsNaN(housingRef) || Double.IsNaN(expensesTotal))
							{
								housingRef = 0.0f;
								expensesTotal = 0.0f;
								expensesProgress.SetProgress((float)(housingRef / expensesTotal), false);
							}
							else if (housingRef >= 1 && expensesTotal >= 1)
							{
								expensesProgress.SetProgress((float)(housingRef / expensesTotal), false);
							}
							//create a progress image and track image on pixlr.com and assign them to the progress bar for each row 
							listOfTable.AccessoryView = expensesProgress;
							return listOfTable;
							break;

						case 2:
							if (Double.IsNaN(mortgageRef) || Double.IsNaN(expensesTotal))
							{
								mortgageRef = 0.0f;
								expensesTotal = 0.0f;
								expensesProgress.SetProgress((float)(mortgageRef / expensesTotal), false);
							}
							else if (mortgageRef >= 1 && expensesTotal >= 1)
							{
								expensesProgress.SetProgress((float)(mortgageRef / expensesTotal), false);
							}
							//create a progress image and track image on pixlr.com and assign them to the progress bar for each row 
							listOfTable.AccessoryView = expensesProgress;
							return listOfTable;
							break;

						case 3:
							if (Double.IsNaN(insuranceRef) || Double.IsNaN(expensesTotal))
							{
								insuranceRef = 0.0f;
								expensesTotal = 0.0f;
								expensesProgress.SetProgress((float)(insuranceRef / expensesTotal), false);
							}
							else if (insuranceRef >= 1 && expensesTotal >= 1)
							{
								expensesProgress.SetProgress((float)(insuranceRef / expensesTotal), false);
							}
							//create a progress image and track image on pixlr.com and assign them to the progress bar for each row 
							listOfTable.AccessoryView = expensesProgress;
							return listOfTable;
							break;

						case 4:
							if (Double.IsNaN(taxesRef) || Double.IsNaN(expensesTotal))
							{
								taxesRef = 0.0f;
								expensesTotal = 0.0f;
								expensesProgress.SetProgress((float)(taxesRef / expensesTotal), false);
							}
							else if (taxesRef >= 1 && expensesTotal >= 1)
							{
								expensesProgress.SetProgress((float)(taxesRef / expensesTotal), false);
							}

							//create a progress image and track image on pixlr.com and assign them to the progress bar for each row 
							listOfTable.AccessoryView = expensesProgress;
							return listOfTable;
							break;

						case 5:
							if (Double.IsNaN(carPaymentsRef) || Double.IsNaN(expensesTotal))
							{
								carPaymentsRef = 0.0f;
								expensesTotal = 0.0f;
								expensesProgress.SetProgress((float)(carPaymentsRef / expensesTotal), false);
							}
							else if (carPaymentsRef >= 1 && expensesTotal >= 1)
							{
								expensesProgress.SetProgress((float)(carPaymentsRef / expensesTotal), false);
							}

							//create a progress image and track image on pixlr.com and assign them to the progress bar for each row 
							listOfTable.AccessoryView = expensesProgress;
							return listOfTable;
							break;

						case 6:
							if (Double.IsNaN(educationRef) || Double.IsNaN(expensesTotal))
							{
								educationRef = 0.0f;
								expensesTotal = 0.0f;
								expensesProgress.SetProgress((float)(educationRef / expensesTotal), false);
							}
							else if (educationRef >= 1 && expensesTotal >= 1)
							{
								expensesProgress.SetProgress((float)(educationRef / expensesTotal), false);
							}

							//create a progress image and track image on pixlr.com and assign them to the progress bar for each row 
							listOfTable.AccessoryView = expensesProgress;
							return listOfTable;
							break;
						case 7:
							if (Double.IsNaN(electronicsRef) || Double.IsNaN(expensesTotal))
							{
								electronicsRef = 0.0f;
								expensesTotal = 0.0f;
								expensesProgress.SetProgress((float)(electronicsRef / expensesTotal), false);
							}
							else if (electronicsRef >= 1 && expensesTotal >= 1)
							{
								expensesProgress.SetProgress((float)(electronicsRef / expensesTotal), false);
							}

							//create a progress image and track image on pixlr.com and assign them to the progress bar for each row 
							listOfTable.AccessoryView = expensesProgress;
							return listOfTable;
							break;

						case 8:
							if (Double.IsNaN(entertainmentRef) || Double.IsNaN(expensesTotal))
							{
								entertainmentRef = 0.0f;
								expensesTotal = 0.0f;
								expensesProgress.SetProgress((float)(entertainmentRef / expensesTotal), false);
							}
							else if (entertainmentRef >= 1 && expensesTotal >= 1)
							{
								expensesProgress.SetProgress((float)(entertainmentRef / expensesTotal), false);
							}
							//create a progress image and track image on pixlr.com and assign them to the progress bar for each row 
							listOfTable.AccessoryView = expensesProgress;
							return listOfTable;
							break;

						case 9:
							if (Double.IsNaN(clothingRef) || Double.IsNaN(expensesTotal))
							{
								clothingRef = 0.0f;
								expensesTotal = 0.0f;
								expensesProgress.SetProgress((float)(clothingRef / expensesTotal), false);
							}
							else if (clothingRef >= 1 && expensesTotal >= 1)
							{
								expensesProgress.SetProgress((float)(clothingRef / expensesTotal), false);
							}
							//create a progress image and track image on pixlr.com and assign them to the progress bar for each row 
							listOfTable.AccessoryView = expensesProgress;
							return listOfTable;
							break;

						case 10:
							if (Double.IsNaN(petsRef) || Double.IsNaN(expensesTotal))
							{
								petsRef = 0.0f;
								expensesTotal = 0.0f;
								expensesProgress.SetProgress((float)(petsRef / expensesTotal), false);
							}
							else if (petsRef >= 1 && expensesTotal >= 1)
							{
								expensesProgress.SetProgress((float)(petsRef / expensesTotal), false);
							}
							//create a progress image and track image on pixlr.com and assign them to the progress bar for each row 
							listOfTable.AccessoryView = expensesProgress;
							return listOfTable;
							break;

						case 11:
							if (Double.IsNaN(charityRef) || Double.IsNaN(expensesTotal))
							{
								charityRef = 0.0f;
								expensesTotal = 0.0f;
								expensesProgress.SetProgress((float)(charityRef / expensesTotal), false);
							}
							else if (charityRef >= 1 && expensesTotal >= 1)
							{
								expensesProgress.SetProgress((float)(charityRef / expensesTotal), false);
							}
							//create a progress image and track image on pixlr.com and assign them to the progress bar for each row 
							listOfTable.AccessoryView = expensesProgress;
							return listOfTable;
							break;

						case 12:
							if (Double.IsNaN(foodRef) || Double.IsNaN(expensesTotal))
							{
								foodRef = 0.0f;
								expensesTotal = 0.0f;
								expensesProgress.SetProgress((float)(foodRef / expensesTotal), false);
							}
							else if (foodRef >= 1 && expensesTotal >= 1)
							{
								expensesProgress.SetProgress((float)(foodRef / expensesTotal), false);
							}
							//create a progress image and track image on pixlr.com and assign them to the progress bar for each row 
							listOfTable.AccessoryView = expensesProgress;
							return listOfTable;
							break;

						case 13:
							if (Double.IsNaN(healthLifestyleRef) || Double.IsNaN(expensesTotal))
							{
								healthLifestyleRef = 0.0f;
								expensesTotal = 0.0f;
								expensesProgress.SetProgress((float)(healthLifestyleRef / expensesTotal), false);
							}
							else if (healthLifestyleRef >= 1 && expensesTotal >= 1)
							{
								expensesProgress.SetProgress((float)(healthLifestyleRef / expensesTotal), false);
							}
							//create a progress image and track image on pixlr.com and assign them to the progress bar for each row 
							listOfTable.AccessoryView = expensesProgress;
							return listOfTable;
							break;

						case 14:
							if (Double.IsNaN(gardeningRef) || Double.IsNaN(expensesTotal))
							{
								gardeningRef = 0.0f;
								expensesTotal = 0.0f;
								expensesProgress.SetProgress((float)(gardeningRef / expensesTotal), false);
							}
							else if (gardeningRef >= 1 && expensesTotal >= 1)
							{
								expensesProgress.SetProgress((float)(gardeningRef / expensesTotal), false);
							}
							//create a progress image and track image on pixlr.com and assign them to the progress bar for each row 
							listOfTable.AccessoryView = expensesProgress;
							return listOfTable;
							break;

						case 15:
							if (Double.IsNaN(cleaningRef) || Double.IsNaN(expensesTotal))
							{
								cleaningRef = 0.0f;
								expensesTotal = 0.0f;
								expensesProgress.SetProgress((float)(cleaningRef / expensesTotal), false);
							}
							else if (cleaningRef >= 1 && expensesTotal >= 1)
							{
								expensesProgress.SetProgress((float)(cleaningRef / expensesTotal), false);
							}

							//create a progress image and track image on pixlr.com and assign them to the progress bar for each row 
							listOfTable.AccessoryView = expensesProgress;
							return listOfTable;
							break;

						case 16:
							if (Double.IsNaN(utilitiesRef) || Double.IsNaN(expensesTotal))
							{
								utilitiesRef = 0.0f;
								expensesTotal = 0.0f;
								expensesProgress.SetProgress((float)(utilitiesRef / expensesTotal), false);
							}
							else if (utilitiesRef >= 1 && expensesTotal >= 1)
							{
								expensesProgress.SetProgress((float)(utilitiesRef / expensesTotal), false);
							}

							//create a progress image and track image on pixlr.com and assign them to the progress bar for each row 
							listOfTable.AccessoryView = expensesProgress;
							return listOfTable;
							break;

						case 17:
							if (Double.IsNaN(otherExpenseRef) || Double.IsNaN(expensesTotal))
							{
								otherExpenseRef = 0.0f;
								expensesTotal = 0.0f;
								expensesProgress.SetProgress((float)(otherExpenseRef / expensesTotal), false);
							}
							else if (otherExpenseRef >= 1 && expensesTotal >= 1)
							{
								expensesProgress.SetProgress((float)(otherExpenseRef / expensesTotal), false);
							}
							//create a progress image and track image on pixlr.com and assign them to the progress bar for each row 
							listOfTable.AccessoryView = expensesProgress;
							return listOfTable;
							break;
					}
					break;
				case 1:
					//specify the track and progress image colors here 
					listOfTable.TextLabel.Text = incomeCategories[indexPath.Row];
					listOfTable.TextLabel.TextColor = UIColor.Black;

					try {
						if(incomeValues.Count == 0) {
							throw new ArgumentOutOfRangeException();
						}
						else if(incomeValues.Count >= 0) {
							listOfTable.DetailTextLabel.Text = symbolCurrencyHandler + incomeValues[indexPath.Row];
							listOfTable.DetailTextLabel.TextColor = UIColor.Gray;
							listOfTable.DetailTextLabel.Font = UIFont.SystemFontOfSize(16.0f);
						}	
					}
					catch(ArgumentOutOfRangeException) {
						
					}
					expensesProgress.TrackTintColor = UIColor.LightGray;
					expensesProgress.ProgressTintColor = UIColor.Green;
					tableView.AddSubview(expensesProgress);
					switch (indexPath.Row)
					{
						case 0:
							if (Double.IsNaN(wagesRef) || Double.IsNaN(incomeTotal))
							{
								wagesRef = 0.0f;
								incomeTotal = 0.0f;
								expensesProgress.SetProgress((float)(wagesRef / incomeTotal), false);
							}
							else if (wagesRef >= 1 && incomeTotal >= 1)
							{
								expensesProgress.SetProgress((float)(wagesRef / incomeTotal), false);
							}
							listOfTable.AccessoryView = expensesProgress;
							return listOfTable;
							break;
						case 1:
							if (Double.IsNaN(realestateRef) || Double.IsNaN(incomeTotal))
							{
								realestateRef = 0.0f;
								incomeTotal = 0.0f;
								expensesProgress.SetProgress((float)(realestateRef / incomeTotal), false);
							}
							else if (realestateRef >= 1 && incomeTotal >= 1)
							{
								expensesProgress.SetProgress((float)(realestateRef / incomeTotal), false);
							}

							listOfTable.AccessoryView = expensesProgress;
							return listOfTable;
							break;

						case 2:
							if (Double.IsNaN(salesHouseStockRef) || Double.IsNaN(incomeTotal))
							{
								salesHouseStockRef = 0.0f;
								incomeTotal = 0.0f;
								expensesProgress.SetProgress((float)(salesHouseStockRef / incomeTotal), false);
							}
							else if (salesHouseStockRef >= 1 && incomeTotal >= 1)
							{
								expensesProgress.SetProgress((float)(salesHouseStockRef / incomeTotal), false);
							}

							listOfTable.AccessoryView = expensesProgress;
							return listOfTable;
							break;

						case 3:
							if (Double.IsNaN(smallBusinessRef) || Double.IsNaN(incomeTotal))
							{
								smallBusinessRef = 0.0f;
								incomeTotal = 0.0f;
								expensesProgress.SetProgress((float)(smallBusinessRef / incomeTotal), false);
							}
							else if (smallBusinessRef >= 1 && incomeTotal >= 1)
							{
								expensesProgress.SetProgress((float)(smallBusinessRef / incomeTotal), false);
							}

							listOfTable.AccessoryView = expensesProgress;
							return listOfTable;
							break;

						case 4:
							if (Double.IsNaN(gamblingWinningsRef) || Double.IsNaN(incomeTotal))
							{
								gamblingWinningsRef = 0.0f;
								incomeTotal = 0.0f;
								expensesProgress.SetProgress((float)(gamblingWinningsRef / incomeTotal), false);
							}
							else if (gamblingWinningsRef >= 1 && incomeTotal >= 1)
							{
								expensesProgress.SetProgress((float)(gamblingWinningsRef / incomeTotal), false);
							}

							listOfTable.AccessoryView = expensesProgress;
							return listOfTable;
							break;

						case 5:
							if (Double.IsNaN(salesOfTradesRef) || Double.IsNaN(incomeTotal))
							{
								salesOfTradesRef = 0.0f;
								incomeTotal = 0.0f;
								expensesProgress.SetProgress((float)(salesOfTradesRef / incomeTotal), false);
							}
							else if (salesOfTradesRef >= 1 && incomeTotal >= 1)
							{
								expensesProgress.SetProgress((float)(salesOfTradesRef / incomeTotal), false);
							}

							listOfTable.AccessoryView = expensesProgress;
							return listOfTable;
							break;

						case 6:
							if (Double.IsNaN(intellectualPropertyRef) || Double.IsNaN(incomeTotal))
							{
								intellectualPropertyRef = 0.0f;
								incomeTotal = 0.0f;
								expensesProgress.SetProgress((float)(intellectualPropertyRef / incomeTotal), false);
							}
							else if (intellectualPropertyRef >= 1 && incomeTotal >= 1)
							{
								expensesProgress.SetProgress((float)(intellectualPropertyRef / incomeTotal), false);
							}
							listOfTable.AccessoryView = expensesProgress;
							return listOfTable;
							break;

						case 7:
							if (Double.IsNaN(appRoyaltiesRef) || Double.IsNaN(incomeTotal))
							{
								appRoyaltiesRef = 0.0f;
								incomeTotal = 0.0f;
								expensesProgress.SetProgress((float)(appRoyaltiesRef / incomeTotal), false);
							}
							else if (appRoyaltiesRef >= 1 && incomeTotal >= 1)
							{
								expensesProgress.SetProgress((float)(appRoyaltiesRef / incomeTotal), false);
							}

							listOfTable.AccessoryView = expensesProgress;
							return listOfTable;
							break;

						case 8:
							if (Double.IsNaN(bookPublishingRef) || Double.IsNaN(incomeTotal))
							{
								bookPublishingRef = 0.0f;
								incomeTotal = 0.0f;
								expensesProgress.SetProgress((float)(bookPublishingRef / incomeTotal), false);
							}
							else if (bookPublishingRef >= 1 && incomeTotal >= 1)
							{
								expensesProgress.SetProgress((float)(bookPublishingRef / incomeTotal), false);
							}

							listOfTable.AccessoryView = expensesProgress;
							return listOfTable;
							break;
						case 9:
							if (Double.IsNaN(tradeDividendsRef) || Double.IsNaN(incomeTotal))
							{
								tradeDividendsRef = 0.0f;
								incomeTotal = 0.0f;
								expensesProgress.SetProgress((float)(tradeDividendsRef / incomeTotal), false);
							}
							else if (tradeDividendsRef >= 1 && incomeTotal >= 1)
							{
								expensesProgress.SetProgress((float)(tradeDividendsRef / incomeTotal), false);
							}

							listOfTable.AccessoryView = expensesProgress;
							return listOfTable;
							break;
						case 10:
							if (Double.IsNaN(bankInterestRef) || Double.IsNaN(incomeTotal))
							{
								bankInterestRef = 0.0f;
								incomeTotal = 0.0f;
								expensesProgress.SetProgress((float)(bankInterestRef / incomeTotal), false);
							}
							else if (bankInterestRef >= 1 && incomeTotal >= 1)
							{
								expensesProgress.SetProgress((float)(bankInterestRef / incomeTotal), false);
							}

							listOfTable.AccessoryView = expensesProgress;
							return listOfTable;
							break;
						case 11:
							if (Double.IsNaN(taxReturnRef) || Double.IsNaN(incomeTotal))
							{
								taxReturnRef = 0.0f;
								incomeTotal = 0.0f;
								expensesProgress.SetProgress((float)(taxReturnRef / incomeTotal), false);
							}
							else if (taxReturnRef >= 1 && incomeTotal >= 1)
							{
								expensesProgress.SetProgress((float)(taxReturnRef / incomeTotal), false);
							}

							listOfTable.AccessoryView = expensesProgress;
							return listOfTable;
							break;
						case 12:
							if (Double.IsNaN(studentLoanRef) || Double.IsNaN(incomeTotal))
							{
								studentLoanRef = 0.0f;
								incomeTotal = 0.0f;
								expensesProgress.SetProgress((float)(studentLoanRef / incomeTotal), false);
							}
							else if (studentLoanRef >= 1 && incomeTotal >= 1)
							{
								expensesProgress.SetProgress((float)(studentLoanRef / incomeTotal), false);
							}

							listOfTable.AccessoryView = expensesProgress;
							return listOfTable;
							break;
						case 13:
							if (Double.IsNaN(inheritanceRef) || Double.IsNaN(incomeTotal))
							{
								inheritanceRef = 0.0f;
								incomeTotal = 0.0f;
								expensesProgress.SetProgress((float)(inheritanceRef / incomeTotal), false);
							}
							else if (inheritanceRef >= 1 && incomeTotal >= 1)
							{
								expensesProgress.SetProgress((float)(inheritanceRef / incomeTotal), false);
							}
							listOfTable.AccessoryView = expensesProgress;
							return listOfTable;
							break;
						case 14:
							if (Double.IsNaN(prizeMoneyRef) || Double.IsNaN(incomeTotal))
							{
								prizeMoneyRef = 0.0f;
								incomeTotal = 0.0f;
								expensesProgress.SetProgress((float)(prizeMoneyRef / incomeTotal), false);
							}
							else if (prizeMoneyRef >= 1 && incomeTotal >= 1)
							{
								expensesProgress.SetProgress((float)(prizeMoneyRef / incomeTotal), false);
							}
							listOfTable.AccessoryView = expensesProgress;
							return listOfTable;
							break;
						case 15:
							if (Double.IsNaN(otherIncomeRef) || Double.IsNaN(incomeTotal))
							{
								otherIncomeRef = 0.0f;
								incomeTotal = 0.0f;
								expensesProgress.SetProgress((float)(otherIncomeRef / incomeTotal), false);
							}
							else if (otherIncomeRef >= 1 && incomeTotal >= 1)
							{
								expensesProgress.SetProgress((float)(otherIncomeRef / incomeTotal), false);
							}
							listOfTable.AccessoryView = expensesProgress;
							return listOfTable;
							break;
					}
					break;
			}
			return listOfTable;
		}

		public override nint RowsInSection(UITableView tableView, nint section)
		{
			if (section == 0)
			{
				return this.expensesCategories.Count;
			}
			else if (section == 1)
			{
				return this.incomeCategories.Count;
			}
			return 0;
		}

		private void rowInformationSelected(string title, string description, double percentage, double total, double amount, string symbolCurrency)
		{
			UIAlertController infoController = UIAlertController.Create(title, description, UIAlertControllerStyle.Alert);

			UIAlertAction confirmed = UIAlertAction.Create("Ok", UIAlertActionStyle.Default, (Action) =>
			{
				infoController.Dispose();
			});

			UIAlertAction extraInfo = UIAlertAction.Create("More", UIAlertActionStyle.Default, (Action) =>
			{
				/*Opens the full list associated with each category along with their values and descriptions*/

				//every symbol used needs to be added to a list contained inside the application's delegate 
				//This list is then run through depending on whether it is added inside the rent category, etc


			});

			//text field: amount
			infoController.AddTextField((UITextField obj) =>
			{
				obj.BorderStyle = UITextBorderStyle.RoundedRect;
				obj.Text = "Amount: " + symbolCurrency + amount; //specify amount
				obj.UserInteractionEnabled = false;
				obj.ClearButtonMode = UITextFieldViewMode.Never;
				obj.Enabled = false;
			});

			//textfield: total
			infoController.AddTextField((UITextField obj_2) =>
			{
				obj_2.BorderStyle = UITextBorderStyle.RoundedRect;
				obj_2.Text = "Total: " + symbolCurrency + total; //specify amount
				obj_2.UserInteractionEnabled = false;
				obj_2.ClearButtonMode = UITextFieldViewMode.Never;
				obj_2.Enabled = false;
			});

			infoController.AddTextField((UITextField obj_3) =>
			{
				if (Double.IsNaN(percentage) == true)
				{
					obj_3.BorderStyle = UITextBorderStyle.RoundedRect;
					obj_3.Text = "Percentage: " + 0 + "%"; //specify amount
					obj_3.UserInteractionEnabled = false;
					obj_3.ClearButtonMode = UITextFieldViewMode.Never;
					obj_3.Enabled = false;
				}
				else if (Double.IsNaN(percentage) == false) {
					obj_3.BorderStyle = UITextBorderStyle.RoundedRect;
					obj_3.Text = "Percentage: " + percentage + "%"; //specify amount
					obj_3.UserInteractionEnabled = false;
					obj_3.ClearButtonMode = UITextFieldViewMode.Never;
					obj_3.Enabled = false;	
				}
			});

			infoController.AddAction(confirmed);
			infoController.AddAction(extraInfo);

			if (this.PresentedViewController == null)
			{
				this.PresentViewController(infoController, true, null);
			}

			else if (this.PresentedViewController != null)
			{
				this.PresentedViewController.DismissViewController(true, () =>
				{
					this.PresentedViewController.Dispose();
					this.PresentViewController(infoController, true, null);
				});
			}
		}

		//when clicking on one of the cells it gives the end user an option to expand the cell. this is done by pushing a controller to the nav stack
		//which will be split across many different sections. Each section represents a currency, and a time up to a whole year. 
		//every section contains the lists of financial data, that the user adds to the system

		public override void RowSelected(UIKit.UITableView tableView, Foundation.NSIndexPath indexPath)
		{
			switch (indexPath.Section)
			{
				case 0: //expenses list
					switch (indexPath.Row)
					{
						case 0: //rent 
							if(Double.IsNaN(rentRef) == true || Double.IsNaN(expensesTotal) == true) {
								rowInformationSelected(this.expensesCategories[0], "", 0.0f, expensesTotal, rentRef, symbolCurrencyHandler);
								
							}
							else if(Double.IsNaN(rentRef) == false && Double.IsNaN(expensesTotal) == false) {
								rowInformationSelected(this.expensesCategories[0], "", Math.Round(rentRef / expensesTotal * 100), expensesTotal, rentRef, symbolCurrencyHandler);	
							}
							break;

						case 1: //housing 
							if (Double.IsNaN(expensesTotal) == true)
							{
								rowInformationSelected(this.expensesCategories[1], "", Math.Round(housingRef / expensesTotal * 100), expensesTotal, housingRef, symbolCurrencyHandler);

							}
							else if (Double.IsNaN(housingRef) == false || Double.IsNaN(expensesTotal) == false)
							{
								rowInformationSelected(this.expensesCategories[1], "", Math.Round(housingRef / expensesTotal * 100), expensesTotal, housingRef, symbolCurrencyHandler);
							}
							break;

						case 2: //mortgage
							if (Double.IsNaN(expensesTotal) == true)
							{
								rowInformationSelected(this.expensesCategories[2], "", Math.Round(mortgageRef / expensesTotal * 100), expensesTotal, mortgageRef, symbolCurrencyHandler);

							}
							else if (Double.IsNaN(mortgageRef) == false || Double.IsNaN(expensesTotal) == false)
							{
								rowInformationSelected(this.expensesCategories[2], "", Math.Round(mortgageRef / expensesTotal * 100), expensesTotal, mortgageRef, symbolCurrencyHandler);
							}

							break;

						case 3: //insurance 
							if (Double.IsNaN(expensesTotal) == true)
							{
								rowInformationSelected(this.expensesCategories[3], "", Math.Round(insuranceRef / expensesTotal * 100), expensesTotal, insuranceRef, symbolCurrencyHandler);

							}
							else if (Double.IsNaN(insuranceRef) == false || Double.IsNaN(expensesTotal) == false)
							{
								rowInformationSelected(this.expensesCategories[3], "", Math.Round(insuranceRef / expensesTotal * 100), expensesTotal, insuranceRef, symbolCurrencyHandler);
							}

							break;

						case 4: //Taxes 
							if (Double.IsNaN(expensesTotal) == true)
							{
								rowInformationSelected(this.expensesCategories[4], "", Math.Round(taxesRef / expensesTotal * 100), expensesTotal, taxesRef, symbolCurrencyHandler);

							}
							else if (Double.IsNaN(taxesRef) == false || Double.IsNaN(expensesTotal) == false)
							{
								rowInformationSelected(this.expensesCategories[4], "", Math.Round(taxesRef / expensesTotal * 100), expensesTotal, taxesRef, symbolCurrencyHandler);
							}
							break;

						case 5: //car payments
							if (Double.IsNaN(expensesTotal) == true)
							{
								rowInformationSelected(this.expensesCategories[5], "", Math.Round(carPaymentsRef / expensesTotal * 100), expensesTotal, carPaymentsRef, symbolCurrencyHandler);

							}
							else if (Double.IsNaN(carPaymentsRef) == false || Double.IsNaN(expensesTotal) == false)
							{
								rowInformationSelected(this.expensesCategories[5], "", Math.Round(carPaymentsRef / expensesTotal * 100), expensesTotal, carPaymentsRef, symbolCurrencyHandler);
							}
							break;

						case 6: //education

							if (Double.IsNaN(expensesTotal) == true)
							{
								rowInformationSelected(this.expensesCategories[6], "", Math.Round(educationRef / expensesTotal * 100), expensesTotal, educationRef, symbolCurrencyHandler);

							}
							else if (Double.IsNaN(educationRef) == false || Double.IsNaN(expensesTotal) == false)
							{
								rowInformationSelected(this.expensesCategories[6], "", Math.Round(educationRef / expensesTotal * 100), expensesTotal, educationRef, symbolCurrencyHandler);
							}

							break;

						case 7: //Electronics

							if (Double.IsNaN(expensesTotal) == true)
							{
								rowInformationSelected(this.expensesCategories[7], "", Math.Round(electronicsRef / expensesTotal * 100), expensesTotal, electronicsRef, symbolCurrencyHandler);

							}
							else if (Double.IsNaN(electronicsRef) == false || Double.IsNaN(expensesTotal) == false)
							{
								rowInformationSelected(this.expensesCategories[7], "", Math.Round(electronicsRef / expensesTotal * 100), expensesTotal, electronicsRef, symbolCurrencyHandler);
							}
						
							break;

						case 8: //Entertainment

							if (Double.IsNaN(expensesTotal) == true)
							{
								rowInformationSelected(this.expensesCategories[8], "", Math.Round(entertainmentRef / expensesTotal * 100), expensesTotal, entertainmentRef, symbolCurrencyHandler);

							}
							else if (Double.IsNaN(entertainmentRef) == false || Double.IsNaN(expensesTotal) == false)
							{
								rowInformationSelected(this.expensesCategories[8], "", Math.Round(entertainmentRef / expensesTotal * 100), expensesTotal, entertainmentRef, symbolCurrencyHandler);
							}

							break;

						case 9: //Clothing & Footwear
							if (Double.IsNaN(expensesTotal) == true)
							{
								rowInformationSelected(this.expensesCategories[9], "", Math.Round(clothingRef / expensesTotal * 100), expensesTotal, clothingRef, symbolCurrencyHandler);

							}
							else if (Double.IsNaN(clothingRef) == false || Double.IsNaN(expensesTotal) == false)
							{
								rowInformationSelected(this.expensesCategories[9], "", Math.Round(clothingRef / expensesTotal * 100), expensesTotal, clothingRef, symbolCurrencyHandler);
							}
					
							break;

						case 10: //Pets

							if (Double.IsNaN(expensesTotal) == true)
							{
								rowInformationSelected(this.expensesCategories[10], "", Math.Round(petsRef / expensesTotal * 100), expensesTotal, petsRef, symbolCurrencyHandler);

							}
							else if (Double.IsNaN(petsRef) == false || Double.IsNaN(expensesTotal) == false)
							{
								rowInformationSelected(this.expensesCategories[10], "", Math.Round(petsRef / expensesTotal * 100), expensesTotal, petsRef, symbolCurrencyHandler);
							}

							break;

						case 11: //Charity

							if (Double.IsNaN(expensesTotal) == true)
							{
								rowInformationSelected(this.expensesCategories[11], "", Math.Round(charityRef / expensesTotal * 100), expensesTotal, charityRef, symbolCurrencyHandler);
							}
							else if (Double.IsNaN(charityRef) == false || Double.IsNaN(expensesTotal) == false)
							{
								rowInformationSelected(this.expensesCategories[11], "", Math.Round(charityRef / expensesTotal * 100), expensesTotal, charityRef, symbolCurrencyHandler);
							}


							break;

						case 12: //Food
							if (Double.IsNaN(expensesTotal) == true)
							{
								rowInformationSelected(this.expensesCategories[12], "", Math.Round(foodRef / expensesTotal * 100), expensesTotal, foodRef, symbolCurrencyHandler);
							}
							else if (Double.IsNaN(foodRef) == false || Double.IsNaN(expensesTotal) == false)
							{
								rowInformationSelected(this.expensesCategories[12], "", Math.Round(foodRef / expensesTotal * 100), expensesTotal, foodRef, symbolCurrencyHandler);
							}

							break;

						case 13: //Health&Lifestyle
							if (Double.IsNaN(expensesTotal) == true)
							{
								rowInformationSelected(this.expensesCategories[13], "", Math.Round(healthLifestyleRef / expensesTotal * 100), expensesTotal, healthLifestyleRef, symbolCurrencyHandler);
							}
							else if (Double.IsNaN(healthLifestyleRef) == false || Double.IsNaN(expensesTotal) == false)
							{
								rowInformationSelected(this.expensesCategories[13], "", Math.Round(healthLifestyleRef / expensesTotal * 100), expensesTotal, healthLifestyleRef, symbolCurrencyHandler);
							}

							break;

						case 14: //Gardening
							if (Double.IsNaN(expensesTotal) == true)
							{
								rowInformationSelected(this.expensesCategories[14], "", Math.Round(gardeningRef / expensesTotal * 100), expensesTotal, gardeningRef, symbolCurrencyHandler);
							}
							else if (Double.IsNaN(gardeningRef) == false || Double.IsNaN(expensesTotal) == false)
							{
								rowInformationSelected(this.expensesCategories[14], "", Math.Round(gardeningRef / expensesTotal * 100), expensesTotal, gardeningRef, symbolCurrencyHandler);
							}

							break;

						case 15: //Cleaning & Maintainance
							if (Double.IsNaN(expensesTotal) == true)
							{
								rowInformationSelected(this.expensesCategories[15], "", Math.Round(cleaningRef / expensesTotal * 100), expensesTotal, cleaningRef, symbolCurrencyHandler);
							}
							else if (Double.IsNaN(cleaningRef) == false || Double.IsNaN(expensesTotal) == false)
							{
								rowInformationSelected(this.expensesCategories[15], "", Math.Round(cleaningRef / expensesTotal * 100), expensesTotal, cleaningRef, symbolCurrencyHandler);
							}

							break;

						case 16: //Utilities
							if (Double.IsNaN(expensesTotal) == true)
							{
								rowInformationSelected(this.expensesCategories[16], "", Math.Round(utilitiesRef / expensesTotal * 100), expensesTotal, utilitiesRef, symbolCurrencyHandler);
							}
							else if (Double.IsNaN(utilitiesRef) == false || Double.IsNaN(expensesTotal) == false)
							{
								rowInformationSelected(this.expensesCategories[16], "", Math.Round(utilitiesRef / expensesTotal * 100), expensesTotal, utilitiesRef, symbolCurrencyHandler);
							}

							break;

						case 17: //Other 

							if (Double.IsNaN(expensesTotal) == true)
							{
								rowInformationSelected(this.expensesCategories[17], "", Math.Round(otherExpenseRef / expensesTotal * 100), expensesTotal, otherExpenseRef, symbolCurrencyHandler);
							}
							else if (Double.IsNaN(otherExpenseRef) == false || Double.IsNaN(expensesTotal) == false)
							{
								rowInformationSelected(this.expensesCategories[17], "", Math.Round(otherExpenseRef / expensesTotal * 100), expensesTotal, otherExpenseRef, symbolCurrencyHandler);
							}
							break;
					}
					break;
				case 1: //income list
					switch (indexPath.Row)
					{
						case 0://wages 

							if (Double.IsNaN(incomeTotal) == true)
							{
								rowInformationSelected(this.incomeCategories[0], "", Math.Round(wagesRef / expensesTotal * 100), incomeTotal, wagesRef, symbolCurrencyHandler);
							}
							else if (Double.IsNaN(wagesRef) == false || Double.IsNaN(incomeTotal) == false)
							{
								rowInformationSelected(this.incomeCategories[0], "", Math.Round(wagesRef / expensesTotal * 100), incomeTotal, wagesRef, symbolCurrencyHandler);
							}

							break;

						case 1: //realestate
							if (Double.IsNaN(incomeTotal) == true)
							{
								rowInformationSelected(this.incomeCategories[1], "", Math.Round(realestateRef / expensesTotal * 100), incomeTotal, realestateRef, symbolCurrencyHandler);
							}
							else if (Double.IsNaN(realestateRef) == false || Double.IsNaN(incomeTotal) == false)
							{
								rowInformationSelected(this.incomeCategories[1], "", Math.Round(realestateRef / expensesTotal * 100), incomeTotal, realestateRef, symbolCurrencyHandler);
							}

							break;

						case 2: //sales of house stock
							if (Double.IsNaN(incomeTotal) == true)
							{
								rowInformationSelected(this.incomeCategories[2], "", Math.Round(salesHouseStockRef / expensesTotal * 100), incomeTotal, salesHouseStockRef, symbolCurrencyHandler);
							}
							else if (Double.IsNaN(salesHouseStockRef) == false || Double.IsNaN(incomeTotal) == false)
							{
								rowInformationSelected(this.incomeCategories[2], "", Math.Round(salesHouseStockRef / expensesTotal * 100), incomeTotal, salesHouseStockRef, symbolCurrencyHandler);
							}

							break;

						case 3: //small business

							if (Double.IsNaN(incomeTotal) == true)
							{
								rowInformationSelected(this.incomeCategories[3], "", Math.Round(smallBusinessRef / expensesTotal * 100), incomeTotal, smallBusinessRef, symbolCurrencyHandler);
							}
							else if (Double.IsNaN(salesHouseStockRef) == false || Double.IsNaN(incomeTotal) == false)
							{
								rowInformationSelected(this.incomeCategories[3], "", Math.Round(smallBusinessRef / expensesTotal * 100), incomeTotal, smallBusinessRef, symbolCurrencyHandler);
							}
							break;

						case 4: //gambling winnings
							if (Double.IsNaN(incomeTotal) == true)
							{
								rowInformationSelected(this.incomeCategories[4], "", Math.Round(gamblingWinningsRef / expensesTotal * 100), incomeTotal, gamblingWinningsRef, symbolCurrencyHandler);
							}
							else if (Double.IsNaN(gamblingWinningsRef) == false || Double.IsNaN(incomeTotal) == false)
							{
								rowInformationSelected(this.incomeCategories[4], "", Math.Round(gamblingWinningsRef / expensesTotal * 100), incomeTotal, gamblingWinningsRef, symbolCurrencyHandler);
							}
							break;

						case 5: //sales of trades
							if (Double.IsNaN(incomeTotal) == true)
							{
								rowInformationSelected(this.incomeCategories[5], "", Math.Round(salesOfTradesRef / expensesTotal * 100), incomeTotal, salesOfTradesRef, symbolCurrencyHandler);
							}
							else if (Double.IsNaN(salesOfTradesRef) == false || Double.IsNaN(incomeTotal) == false)
							{
								rowInformationSelected(this.incomeCategories[5], "", Math.Round(salesOfTradesRef / expensesTotal * 100), incomeTotal, salesOfTradesRef, symbolCurrencyHandler);
							}
							break;

						case 6: //intellectual property
							if (Double.IsNaN(incomeTotal) == true)
							{
								rowInformationSelected(this.incomeCategories[6], "", Math.Round(intellectualPropertyRef / expensesTotal * 100), incomeTotal, intellectualPropertyRef, symbolCurrencyHandler);
							}
							else if (Double.IsNaN(intellectualPropertyRef) == false || Double.IsNaN(incomeTotal) == false)
							{
								rowInformationSelected(this.incomeCategories[6], "", Math.Round(intellectualPropertyRef / expensesTotal * 100), incomeTotal, intellectualPropertyRef, symbolCurrencyHandler);
							}
							break;

						case 7: //app royalties
							if (Double.IsNaN(incomeTotal) == true)
							{
								rowInformationSelected(this.incomeCategories[7], "", Math.Round(appRoyaltiesRef / expensesTotal * 100), incomeTotal, appRoyaltiesRef, symbolCurrencyHandler);
							}
							else if (Double.IsNaN(appRoyaltiesRef) == false || Double.IsNaN(incomeTotal) == false)
							{
								rowInformationSelected(this.incomeCategories[7], "", Math.Round(appRoyaltiesRef / expensesTotal * 100), incomeTotal, appRoyaltiesRef, symbolCurrencyHandler);
							}
							break;

						case 8: //book publishing
							if (Double.IsNaN(incomeTotal) == true)
							{
								rowInformationSelected(this.incomeCategories[8], "", Math.Round(bookPublishingRef / expensesTotal * 100), incomeTotal, bookPublishingRef, symbolCurrencyHandler);
							}
							else if (Double.IsNaN(bookPublishingRef) == false || Double.IsNaN(incomeTotal) == false)
							{
								rowInformationSelected(this.incomeCategories[8], "", Math.Round(bookPublishingRef / expensesTotal * 100), incomeTotal, bookPublishingRef, symbolCurrencyHandler);
							}
							break;

						case 9: //trade dividends
							if (Double.IsNaN(incomeTotal) == true)
							{
								rowInformationSelected(this.incomeCategories[9], "", Math.Round(tradeDividendsRef / expensesTotal * 100), incomeTotal, tradeDividendsRef, symbolCurrencyHandler);
							}
							else if (Double.IsNaN(bookPublishingRef) == false || Double.IsNaN(incomeTotal) == false)
							{
								rowInformationSelected(this.incomeCategories[9], "", Math.Round(tradeDividendsRef / expensesTotal * 100), incomeTotal, tradeDividendsRef, symbolCurrencyHandler);
							}
							break;

						case 10: //bank interest
							if (Double.IsNaN(incomeTotal) == true)
							{
								rowInformationSelected(this.incomeCategories[10], "", Math.Round(bankInterestRef / expensesTotal * 100), incomeTotal, bankInterestRef, symbolCurrencyHandler);
							}
							else if (Double.IsNaN(bankInterestRef) == false || Double.IsNaN(incomeTotal) == false)
							{
								rowInformationSelected(this.incomeCategories[10], "", Math.Round(bankInterestRef / expensesTotal * 100), incomeTotal, bankInterestRef, symbolCurrencyHandler);
							}
							break;

						case 11: //tax return
							if (Double.IsNaN(incomeTotal) == true)
							{
								rowInformationSelected(this.incomeCategories[11], "", Math.Round(taxReturnRef / expensesTotal * 100), incomeTotal, taxReturnRef, symbolCurrencyHandler);
							}
							else if (Double.IsNaN(taxReturnRef) == false || Double.IsNaN(incomeTotal) == false)
							{
								rowInformationSelected(this.incomeCategories[11], "", Math.Round(taxReturnRef / expensesTotal * 100), incomeTotal, taxReturnRef, symbolCurrencyHandler);
							}
							break;

						case 12: //student loan

							if (Double.IsNaN(incomeTotal) == true)
							{
								rowInformationSelected(this.incomeCategories[12], "", Math.Round(studentLoanRef / expensesTotal * 100), incomeTotal, studentLoanRef, symbolCurrencyHandler);
							}
							else if (Double.IsNaN(studentLoanRef) == false || Double.IsNaN(incomeTotal) == false)
							{
								rowInformationSelected(this.incomeCategories[12], "", Math.Round(studentLoanRef / expensesTotal * 100), incomeTotal, studentLoanRef, symbolCurrencyHandler);
							}
							break;

						case 13: //inheritance
							if (Double.IsNaN(incomeTotal) == true)
							{
								rowInformationSelected(this.incomeCategories[13], "", Math.Round(inheritanceRef / expensesTotal * 100), incomeTotal, inheritanceRef, symbolCurrencyHandler);
							}
							else if (Double.IsNaN(inheritanceRef) == false || Double.IsNaN(incomeTotal) == false)
							{
								rowInformationSelected(this.incomeCategories[13], "", Math.Round(inheritanceRef / expensesTotal * 100), incomeTotal, inheritanceRef, symbolCurrencyHandler);
							}
							break;


						case 14: //prize money
							if (Double.IsNaN(incomeTotal) == true)
							{
								rowInformationSelected(this.incomeCategories[14], "", Math.Round(prizeMoneyRef / expensesTotal * 100), incomeTotal, prizeMoneyRef, symbolCurrencyHandler);
							}
							else if (Double.IsNaN(prizeMoneyRef) == false || Double.IsNaN(incomeTotal) == false)
							{
								rowInformationSelected(this.incomeCategories[14], "", Math.Round(prizeMoneyRef / expensesTotal * 100), incomeTotal, prizeMoneyRef, symbolCurrencyHandler);
							}
							break;

						case 15: // other
							if (Double.IsNaN(incomeTotal) == true)
							{
								rowInformationSelected(this.incomeCategories[15], "", Math.Round(otherIncomeRef / expensesTotal * 100), incomeTotal, otherIncomeRef, symbolCurrencyHandler);
							}
							else if (Double.IsNaN(otherIncomeRef) == false || Double.IsNaN(incomeTotal) == false)
							{
								rowInformationSelected(this.incomeCategories[15], "", Math.Round(otherIncomeRef / expensesTotal * 100), incomeTotal, otherIncomeRef, symbolCurrencyHandler);
							}
							break;
					}
					break;
			}
			tableView.DeselectRow(indexPath, true);
		}

		public override string TitleForHeader(UITableView tableView, nint section)
		{
			if (section == 0)
			{
				return "Expenses";
			}
			else if (section == 1)
			{
				return "Income";
			}
			return "";
		}

		public override void ViewDidAppear(bool animated)
		{

			//total 
			this.incomeTotal = VaultPropertyAccess.incomeTotal;
			this.expensesTotal = VaultPropertyAccess.expensesTotal;
			
			this.wagesRef = VaultPropertyAccess.wagesRef;
			this.realestateRef = VaultPropertyAccess.realestateRef;
			this.salesHouseStockRef = VaultPropertyAccess.salesHouseStockRef;
			this.smallBusinessRef = VaultPropertyAccess.smallBusinessRef;
			this.gamblingWinningsRef = VaultPropertyAccess.gamblingWinningsRef;
			this.salesOfTradesRef = VaultPropertyAccess.salesOfTradesRef;
			this.intellectualPropertyRef = VaultPropertyAccess.intellectualPropertyRef;
			this.appRoyaltiesRef = VaultPropertyAccess.appRoyaltiesRef;
			this.bookPublishingRef = VaultPropertyAccess.bookPublishingRef;
			this.tradeDividendsRef = VaultPropertyAccess.tradeDividendsRef;
			this.bankInterestRef = VaultPropertyAccess.bankInterestRef;
			this.taxReturnRef = VaultPropertyAccess.taxReturnRef;
			this.studentLoanRef = VaultPropertyAccess.studentLoanRef;
			this.inheritanceRef = VaultPropertyAccess.inheritanceRef;
			this.prizeMoneyRef = VaultPropertyAccess.prizeMoneyRef;
			this.otherIncomeRef = VaultPropertyAccess.otherIncomeRef;


			//expenses section
			this.rentRef = VaultPropertyAccess.rentRef;
			this.housingRef = VaultPropertyAccess.housingRef;
			this.mortgageRef = VaultPropertyAccess.mortgageRef;
			this.insuranceRef = VaultPropertyAccess.insuranceRef;
			this.taxesRef = VaultPropertyAccess.taxesRef;
			this.carPaymentsRef = VaultPropertyAccess.carPaymentsRef;
			this.educationRef = VaultPropertyAccess.educationRef;
			this.electronicsRef = VaultPropertyAccess.electronicsRef;
			this.entertainmentRef = VaultPropertyAccess.entertainmentRef;
			this.clothingRef = VaultPropertyAccess.clothingRef;
			this.petsRef = VaultPropertyAccess.petsRef;
			this.charityRef = VaultPropertyAccess.charityRef;
			this.foodRef = VaultPropertyAccess.foodRef;
			this.healthLifestyleRef = VaultPropertyAccess.healthLifestyleRef;
			this.gardeningRef = VaultPropertyAccess.gardeningRef;
			this.cleaningRef = VaultPropertyAccess.cleaningRef;
			this.utilitiesRef = VaultPropertyAccess.utilitiesRef;
			this.otherExpenseRef = VaultPropertyAccess.otherExpenseRef;


			Console.WriteLine("Rent " + this.rentRef);
			Console.WriteLine("Housing " + this.housingRef);
			Console.WriteLine("Wages " + this.wagesRef);
			Console.WriteLine("Realestate " + this.realestateRef);

			Console.WriteLine("Mortgage: " + this.mortgageRef);
			Console.WriteLine("Insurance: " + this.insuranceRef);



			this.TableView.ReloadData();
		}

		public override void ViewDidLoad()
		{
			//create the nav bar indicator here

			//scrolls to expenses
			UISwipeGestureRecognizer swipeToExpenses = new UISwipeGestureRecognizer();
			swipeToExpenses.Direction = UISwipeGestureRecognizerDirection.Left;
			swipeToExpenses.AddTarget((Action) =>
			{
				//playing a scroll sound
				SystemSound soundExpense = new SystemSound(1004);
				soundExpense.PlaySystemSound();

				//scroll to top of income table
				NSIndexPath indexExpense = NSIndexPath.FromRowSection(0, 0);
				this.TableView.ScrollToRow(indexExpense, UITableViewScrollPosition.Top, true);
			});

			this.View.AddGestureRecognizer(swipeToExpenses);

			//scrolls to income 
			UISwipeGestureRecognizer swipeToIncome = new UISwipeGestureRecognizer();
			swipeToIncome.Direction = UISwipeGestureRecognizerDirection.Right;
			swipeToIncome.AddTarget((Action) =>
			{

				//playing a scroll sound
				SystemSound soundIncome = new SystemSound(1004);
				soundIncome.PlaySystemSound();

				//scroll to top of income table
				NSIndexPath indexIncome = NSIndexPath.FromRowSection(0, 1);
				this.TableView.ScrollToRow(indexIncome, UITableViewScrollPosition.Top, true);
			});

			this.View.AddGestureRecognizer(swipeToIncome);



			this.TableView.AllowsSelection = false;
			this.TableView = new UITableView(new CGRect(0, 0, this.View.Bounds.Width, this.View.Bounds.Height), UITableViewStyle.Grouped);

			this.View.BackgroundColor = UIColor.White;



			//Alert controllers that emerge due to the comparing of the income and the expenses
			//WARN the user to deal with his finances since his income is far less than his expenses


			//budget proposal 

			UIBarButtonItem restartButton = new UIBarButtonItem(UIBarButtonSystemItem.Refresh, (sender, e) =>
			{
				UIAlertController promptRestart = UIAlertController.Create("Start Again?", "Do you want to start with another budget calculation? Doing so will override all your progress", UIAlertControllerStyle.Alert);

				UIAlertAction confirmed = UIAlertAction.Create("Yes", UIAlertActionStyle.Default, (Action) =>
				{
					ExpenseController exp = new ExpenseController();
					IncomeBudgetController income = new IncomeBudgetController();
					BudgetController budgetCurrency = new BudgetController();

					Console.WriteLine("Expenses: " + exp);
					Console.WriteLine("Income: " + income);
					Console.WriteLine("Main Page: " + budgetCurrency);

					//pops to the original controller and disposes any resources that the user has entered 

					//problem here occurs says that BudgetController does not exist within the storyboard

					this.NavigationController.PopToViewController(this.NavigationController.ViewControllers[1], true);
					exp.Dispose();
					income.Dispose();
					this.Dispose();
				});

				UIAlertAction denied = UIAlertAction.Create("No", UIAlertActionStyle.Cancel, (Action) =>
				{
					promptRestart.Dispose();
				});

				promptRestart.AddAction(confirmed);
				promptRestart.AddAction(denied);

				if (this.PresentedViewController == null)
				{
					this.PresentViewController(promptRestart, true, null);
				}
				else if (this.PresentedViewController != null)
				{
					this.PresentedViewController.DismissViewController(true, () =>
					{
						this.PresentedViewController.Dispose();
						this.PresentViewController(promptRestart, true, null);
					});
				}
			});

			this.NavigationItem.SetLeftBarButtonItem(restartButton, true);
		}

	}
}


/*
 * I need someway to seperate the categories. 
 * So I would create a list of symbol currencies for every session. How would I monitor every manual input session?
 * 
 * 
 * 
 * Remaining tasks: 
 * All the input data needs to be stored into a single SQLite database 
 * All the data inside the vault needs to be encrypted (Facial recognition and password )
 * 
*/

