using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

using Foundation;
using UIKit;
using CoreGraphics;
using CoreFoundation;

/* Leftover tasks: 
 * Pass all the results data to the total calculation controller 
 * Fix the bug with the alert controller

*/

namespace FinanceCalculator
{
	public partial class IncomeBudgetController : UITableViewController
	{
		double calculatedExpenses;
		public IncomeBudgetController(IntPtr handle) : base(handle)
		{
		}

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
		double healthRef;
		double gardeningRef;
		double cleaningRef;
		double utilitiesRef;
		double otherRef;
		double totalExpensesHandler;

		string symbolCurrency_2;
		public IncomeBudgetController(double rent, double housing, double mortgage, double insurance, double taxes, double carPayments, double education, double electronics, double entertainment, double clothing, double pets, double charity, double food, double health, double gardening, double cleaning, double utilities, double other, string symbol, double totalExpensesRef)
		{
			totalExpensesHandler = totalExpensesRef;
			rentRef = rent;
			housingRef = housing;
			mortgageRef = mortgage;
			insuranceRef = insurance;
			taxesRef = taxes;
			carPaymentsRef = carPayments;
			educationRef = education;
			electronicsRef = electronics;

			entertainmentRef = entertainment;
			clothingRef = clothing;
			petsRef = pets;
			charityRef = charity;
			foodRef = food;
			healthRef = health;
			gardeningRef = gardening;
			cleaningRef = cleaning;
			utilitiesRef = utilities;
			otherRef = other;
			symbolCurrency_2 = symbol;
		}

		//list of descriptions
		public List<string> wagesName = new List<string>() { };
		public List<string> realestateName = new List<string>() { };
		public List<string> salesHouseName = new List<string>() { };
		public List<string> smallBusinessName = new List<string>() { };
		public List<string> gamblingName = new List<string>() { };
		public List<string> salesTradesName = new List<string>() { };
		public List<string> intellectualPropertyName = new List<string>() { };
		public List<string> appRoyaltiesName = new List<string>() { };
		public List<string> bookPublishingName = new List<string>() { };
		public List<string> tradeDividendsName = new List<string>() { };
		public List<string> bankInterestName = new List<string>() { };
		public List<string> taxReturnName = new List<string>() { };
		public List<string> studentLoadName = new List<string>() { };
		public List<string> inheritanceName = new List<string>() { };
		public List<string> prizeName = new List<string>() { };
		public List<string> otherIncomeName = new List<string>() { };

		public List<double> wagesIncome = new List<double>() { };
		public List<double> realestateIncome = new List<double>() { };
		public List<double> salesHouseIncome = new List<double>() { };
		public List<double> smallBusinessIncome = new List<double>() { };
		public List<double> gamblingIncome = new List<double>() { };
		public List<double> salesTradesIncome = new List<double>() { };
		public List<double> intellectualPropertyIncome = new List<double>() { };
		public List<double> appRoyaltiesIncome = new List<double>() { };
		public List<double> bookPublishingIncome = new List<double>() { };
		public List<double> tradeDividendsIncome = new List<double>() { };
		public List<double> bankInterestIncome = new List<double>() { };
		public List<double> taxReturnIncome = new List<double>() { };
		public List<double> studentLoadIncome = new List<double>() { };
		public List<double> inheritanceIncome = new List<double>() { };
		public List<double> prizeIncome = new List<double>() { };
		public List<double> otherIncome = new List<double>() { };

		public IncomeBudgetController(){

			//income lists
			wagesIncome = incomeCarrier.wages;
			this.realestateIncome = incomeCarrier.realestate;
			this.salesHouseIncome = incomeCarrier.salesHouseStock;
			this.smallBusinessIncome = incomeCarrier.smallBusiness;
			this.gamblingIncome = incomeCarrier.gamblingWinnings;
			this.salesTradesIncome = incomeCarrier.salesOfTrades;
			this.intellectualPropertyIncome = incomeCarrier.intellectualProperty;
			this.appRoyaltiesIncome = incomeCarrier.appRoyalties;
			this.bookPublishingIncome = incomeCarrier.bookPublishing;
			this.tradeDividendsIncome = incomeCarrier.tradeDividends;
			this.bankInterestIncome = incomeCarrier.bankInterest;
			this.taxReturnIncome = incomeCarrier.taxReturn;
			this.studentLoadIncome = incomeCarrier.studentLoan;
			this.inheritanceIncome = incomeCarrier.inheritance;
			this.prizeIncome = incomeCarrier.prizeMoney;
			this.otherIncome = incomeCarrier.otherIncome;

			//expenses lists 
			this.wagesName = incomeCarrier.wages_Description;
			this.realestateName = incomeCarrier.realestate_Description;
			this.salesHouseName = incomeCarrier.salesHouseStock_Description;
			this.smallBusinessName = incomeCarrier.smallBusiness_Description;
			this.gamblingName = incomeCarrier.gamblingWinnings_Description;
			this.salesTradesName = incomeCarrier.salesOfTrades_Description;
			this.intellectualPropertyName = incomeCarrier.intellectualProperty_Description;
			this.appRoyaltiesName = incomeCarrier.appRoyalties_Description;
			this.bookPublishingName = incomeCarrier.bookPublishing_Description;
			this.tradeDividendsName = incomeCarrier.tradeDividends_Description;
			this.bankInterestName = incomeCarrier.bankInterest_Description;
			this.taxReturnName = incomeCarrier.taxReturn_Description;
			this.studentLoadName = incomeCarrier.studentLoan_Description;
			this.inheritanceName = incomeCarrier.inheritance_Description;
			this.prizeName = incomeCarrier.prizeMoney_Description;
			this.otherIncomeName = incomeCarrier.otherIncome_Description;

		}

		//category table object. This must be global and public so I can refer to it via the UITableViewSource type class
		public TableController controlView = new TableController();
		//user interface properties 
		public UIBarButtonItem addExpense = new UIBarButtonItem(); //adds an expense to the list
		public UIBarButtonItem removeExpense = new UIBarButtonItem(); //removes an expense from the list

		private UIBarButtonItem deleteCell = new UIBarButtonItem(UIBarButtonSystemItem.Edit, null);
		//data structures to store the expenses information
		public List<string> name = new List<string>() { };

		public List<double> expenseAmount = new List<double>() { };

		public List<string> category = new List<string>(){
		{""}, {"\ud83d\udcb0 Wages/Salaries"},{"\ud83c\udfe1 Realestate"},{"\ud83d\udcb5 Sales of Owned Stock/House Products"},{"\ud83d\udcd6 Small Business"},{"\ud83c\udfb0 Gambling winnings"},{"\ud83d\udcc8 Sales of Trades/Stocks"},{"\ud83d\udcd3 Intellectual Property"},{"\ud83c\udf7e App Royalties"},
			{"\ud83d\udce6 Book Publishing"},{"\ud83d\udcca Trade Dividends"},{"\ud83d\udcb3 Bank interest/Term Deposit"},{"\ud83d\udcdc Tax Return"},{"\ud83c\udfc5 Student Loan/Grant"},{"\ud83d\udc8e Inheritance"},{"\ud83c\udfc6 Prize Money"},{"\ud83d\udcf0 Other"}
		};

		public List<string> symbolCurrencyList = new List<string>() { };

		public string symbolCurrency;

		public IncomeBudgetController(string expensesList)
		{
			symbolCurrency = expensesList;
		}


		public List<string> categoryChosen = new List<string>() { };

		Utility AI = new Utility();

		private void addCell()
		{
			UIAlertController addExpensePrompt = UIAlertController.Create("Add an expense?", "", UIAlertControllerStyle.Alert);
			//disable landscape modes on iPhone and iPad

			UIAlertAction Update = UIAlertAction.Create("Add", UIAlertActionStyle.Default, (Action) =>
			{
				if (String.IsNullOrEmpty(addExpensePrompt.TextFields[0].Text) == false)
				{
					categoryAdd("Choose your category", "Choose a category for your expense");
				}
			});

			UIAlertAction cancel = UIAlertAction.Create("Cancel", UIAlertActionStyle.Cancel, (Action) =>
			{
				addExpensePrompt.Dispose();
			});

			addExpensePrompt.AddTextField((UITextField obj) =>
			{
				obj.AdjustsFontSizeToFitWidth = true;
				obj.ClearButtonMode = UITextFieldViewMode.WhileEditing;
				obj.Placeholder = "Enter an expense amount";
				obj.KeyboardAppearance = UIKeyboardAppearance.Alert;
				obj.KeyboardType = UIKeyboardType.DecimalPad;
				obj.BorderStyle = UITextBorderStyle.RoundedRect;
				obj.AutocorrectionType = UITextAutocorrectionType.Yes;


				obj.EditingDidBegin += (object sender_4, EventArgs e_4) =>
				{
					cancel.Enabled = false;
				};
			//enable and disable the 'Add' button based on whether text exists inside the text labels
			Update = UIAlertAction.Create("Add a source of income?", UIAlertActionStyle.Default, (Action) =>
	{
				if (addExpensePrompt.IsBeingDismissed == true)
				{
					if (String.IsNullOrEmpty(obj.Text) == true)
					{
						this.PresentViewController(addExpensePrompt, true, () =>
						{
							AI.AIEnglish("Error. You must enter a value for your income", "en-US", 2.5f, 1.0f, 1.0f);
						});
					}
					else if (String.IsNullOrEmpty(obj.Text) == false)
					{
						this.expenseAmount.Add(Convert.ToDouble(obj.Text));
						this.TableView.ReloadData();



						Console.WriteLine("Name List Count: " + this.name.Count);
						Console.WriteLine("Expense Amount Count: " + this.expenseAmount.Count);
					}
				}
				if (String.IsNullOrEmpty(obj.Text) == false)
				{
					categoryAdd("Choose your category", "Choose a category for your expense");
				}
			});

				obj.EditingDidEnd += (object sender_3, EventArgs e_3) =>
				{

					if (addExpensePrompt.IsBeingDismissed == true)
					{
						if (String.IsNullOrEmpty(obj.Text) == true)
						{
							this.PresentViewController(addExpensePrompt, true, () =>
							{
								AI.AIEnglish("Error. You must enter a value for your expense", "en-US", 2.5f, 1.0f, 1.0f);
							});
						}

						else if (String.IsNullOrEmpty(obj.Text) == false)
						{
							this.expenseAmount.Add(System.Convert.ToDouble(obj.Text));
							this.name.Add(addExpensePrompt.TextFields[1].Text);

							this.TableView.ReloadData();
						}
					}
				};
			});

			addExpensePrompt.AddTextField((UITextField obj_2) =>
			{
				obj_2.AdjustsFontSizeToFitWidth = true;
				obj_2.ClearButtonMode = UITextFieldViewMode.WhileEditing;
				obj_2.Placeholder = "Enter an optional description";
				obj_2.KeyboardAppearance = UIKeyboardAppearance.Alert;
				obj_2.KeyboardType = UIKeyboardType.Default;
				obj_2.ReturnKeyType = UIReturnKeyType.Done;
				obj_2.BorderStyle = UITextBorderStyle.RoundedRect;
				obj_2.AutocorrectionType = UITextAutocorrectionType.Yes;

				obj_2.EditingDidBegin += (object sender_5, EventArgs e_5) =>
				{
					cancel.Enabled = true;
				};

				obj_2.EditingDidEnd += (object sender_4, EventArgs e_4) =>
				{
					if (addExpensePrompt.IsBeingDismissed == true)
					{
						if (String.IsNullOrEmpty(addExpensePrompt.TextFields[0].Text) == true)
						{
							this.PresentViewController(addExpensePrompt, true, () =>
							{
								AI.AIEnglish("Error. You must enter a value for your expense", "en-US", 2.5f, 1.0f, 1.0f);
							});
							obj_2.ResignFirstResponder();
						}
						else if (String.IsNullOrEmpty(addExpensePrompt.TextFields[0].Text) == false)
						{
							this.expenseAmount.Add(System.Convert.ToDouble(addExpensePrompt.TextFields[0].Text));
							this.name.Add(obj_2.Text);
							this.TableView.ReloadData();


							Console.WriteLine("Name List: " + this.name.Count);
							Console.WriteLine("Expense list: " + this.expenseAmount.Count);
							obj_2.ResignFirstResponder();
						}

						if (String.IsNullOrEmpty(obj_2.Text) == true)
						{
							this.TableView.ReloadData();
							this.name.Add("");
							Console.WriteLine("Name is added to the list.");
							obj_2.ResignFirstResponder();
						}
					}
					if (String.IsNullOrEmpty(obj_2.Text) == false)
					{
						categoryAdd("Choose your category", "Choose a category for your expense");
					}

				};
			});


			addExpensePrompt.AddAction(Update);
			addExpensePrompt.AddAction(cancel);

			if (this.PresentedViewController == null)
			{
				this.PresentViewController(addExpensePrompt, true, null);
			}
			else if (this.PresentedViewController != null)
			{
				this.PresentedViewController.DismissViewController(true, () =>
				{
					this.PresentedViewController.Dispose();
					this.PresentViewController(addExpensePrompt, true, null);
				});
			}

		}


		List<string> incomeCategory = new List<string>() { };
		List<double> incomeAmount = new List<double>() { };
		List<string> incomeName = new List<string>() { };

		public IncomeBudgetController(List<string> incomeCat, List<double> incomeAmo, List<string> incomeNameRef)
		{
			incomeCategory = incomeCat;
			incomeAmount = incomeAmo;
			incomeName = incomeNameRef;
		}

		private void expensesInstructions(string title, string message)
		{
			UIAlertController instructionsControl = UIAlertController.Create(title, message, UIAlertControllerStyle.Alert);

			UIAlertAction confirmed = UIAlertAction.Create("Ok", UIAlertActionStyle.Default, (Action) =>
			{
				instructionsControl.Dispose();
			});



			instructionsControl.AddAction(confirmed);

			if (this.PresentedViewController == null)
			{
				this.PresentViewController(instructionsControl, true, null);
			}
			else if (this.PresentedViewController != null)
			{
				this.PresentedViewController.DismissViewController(true, () =>
				{
					this.PresentedViewController.Dispose();
					this.PresentViewController(instructionsControl, true, null);
				});
			}
		}

		public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
		{
			tableView.DeselectRow(indexPath, true);
		}

		//alert controller that asks the category of choice
		private void categoryAdd(string title, string message)
		{

			//custom controller


			controlView.View.Frame = this.View.Frame;
			controlView.View.BackgroundColor = UIColor.Gray;

			UITableView tableCategory = new UITableView();
			tableCategory.SeparatorColor = UIColor.Black;

			tableCategory.ShowsVerticalScrollIndicator = true;
			tableCategory.AlwaysBounceVertical = true;

			tableCategory.IndicatorStyle = UIScrollViewIndicatorStyle.Default;
			tableCategory.SeparatorStyle = UITableViewCellSeparatorStyle.SingleLine;
			tableCategory.Source = new CategoryTableDescriptionIncome(controlView, this, expensesCell, this.TableView.IndexPathForCell(expensesCell));

			controlView.TableView = tableCategory;
			UINavigationBar customBar = new UINavigationBar();

			if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone)
			{
				switch (UIApplication.SharedApplication.StatusBarOrientation)
				{
					case UIInterfaceOrientation.Portrait:
						//tableCategory.Frame = new CGRect(-130.0f, 50.0f, this., 1500.0f);
						tableCategory.ContentSize = new CGSize(controlView.View.Bounds.Width, controlView.View.Bounds.Height);


						tableCategory.ReloadData();
						break;
					case UIInterfaceOrientation.PortraitUpsideDown:
						tableCategory.Frame = new CGRect(-130.0f, 50.0f, 1000.0f, 1500.0f);
						tableCategory.ContentSize = new CGSize(controlView.View.Bounds.Width, controlView.View.Bounds.Height);


						tableCategory.ReloadData();
						break;
					default:

						break;
				}
			}

			else if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
			{
				switch (UIApplication.SharedApplication.StatusBarOrientation)
				{
					case UIInterfaceOrientation.Portrait:
						UIApplication.SharedApplication.StatusBarHidden = false;

						tableCategory.Frame = new CGRect(0, 50, controlView.View.Frame.Width, controlView.View.Frame.Height);
						customBar.Frame = new CGRect(0, 0, this.View.Frame.Size.Width - 50.0f, 50.0f);

						tableCategory.ContentOffset = new CGPoint(0, 50);

						tableCategory.ReloadData();

						break;
					case UIInterfaceOrientation.PortraitUpsideDown:
						UIApplication.SharedApplication.StatusBarHidden = false;

						tableCategory.Frame = new CGRect(0, 50, controlView.View.Frame.Width, controlView.View.Frame.Height);
						customBar.Frame = new CGRect(0, 0, this.View.Frame.Size.Width, 50.0f);


						tableCategory.ContentOffset = new CGPoint(0, 50);
						tableCategory.ReloadData();
						break;
					default:
						UIApplication.SharedApplication.StatusBarHidden = true;
						customBar.Frame = new CGRect(0, 0, this.View.Frame.Size.Width, 50.0f);



						tableCategory.Frame = new CGRect(0, 50, controlView.View.Frame.Width, controlView.View.Frame.Height + 200.0f);
						tableCategory.ContentOffset = new CGPoint(0, 50);
						tableCategory.ReloadData();


						break;
				}
			}

			tableCategory.MultipleTouchEnabled = true;
			tableCategory.AllowsMultipleSelectionDuringEditing = true;
			tableCategory.AllowsMultipleSelection = true;


			UIBarButtonItem cancel = new UIBarButtonItem("  Cancel", UIBarButtonItemStyle.Bordered, (sender, e) =>
			{
				controlView.DismissViewController(true, () =>
				{
				//I need to pop the final value of each of these lists 
				//Another problem here!
				try
					{
						if (this.name.Count == 0 || this.categoryChosen.Count == 0)
						{
							throw new NullReferenceException();
						}

					//fix 
					this.name.RemoveAt(this.name.Count - 1);
						this.expenseAmount.RemoveAt(this.expenseAmount.Count - 1);

						this.TableView.ReloadData();
					}
					catch (NullReferenceException)
					{
						Console.WriteLine(":)");
					}
				});

			});

			cancel.TintColor = UIColor.Red;

			customBar.Alpha = 1.0f;
			customBar.Hidden = false;
			customBar.TintColor = UIColor.White;
			customBar.BarStyle = UIBarStyle.Default;


			UINavigationItem navItem = new UINavigationItem();
			navItem.LeftBarButtonItem = cancel;

			customBar.SetItems(new UINavigationItem[] { navItem }, true);

			customBar.TintColor = UIColor.White;
			customBar.BarStyle = UIBarStyle.Default;


			controlView.View.AddSubview(customBar);

			if (this.PresentedViewController == null)
			{
				this.PresentViewController(controlView, true, () =>
				{
					controlView.PrefersStatusBarHidden();
				});

			}
			else if (this.PresentedViewController != null)
			{
				this.PresentedViewController.DismissViewController(true, () =>
				{
					this.PresentViewController(controlView, true, () =>
					{
						controlView.PrefersStatusBarHidden();
					});
				});
			}
		}


		public override void ViewDidAppear(bool animated)
		{
			this.NavigationController.SetNavigationBarHidden(false, true);

			this.NavigationController.ToolbarHidden = false;


			wagesIncome = incomeCarrier.wages;
			realestateIncome = incomeCarrier.realestate;
			this.salesHouseIncome = incomeCarrier.salesHouseStock;
			this.smallBusinessIncome = incomeCarrier.smallBusiness;
			this.gamblingIncome = incomeCarrier.gamblingWinnings;
			this.salesTradesIncome = incomeCarrier.salesOfTrades;
			this.intellectualPropertyIncome = incomeCarrier.intellectualProperty;
			this.appRoyaltiesIncome = incomeCarrier.appRoyalties;
			this.bookPublishingIncome = incomeCarrier.bookPublishing;
			this.tradeDividendsIncome = incomeCarrier.tradeDividends;
			this.bankInterestIncome = incomeCarrier.bankInterest;
			this.taxReturnIncome = incomeCarrier.taxReturn;
			this.studentLoadIncome = incomeCarrier.studentLoan;
			this.inheritanceIncome = incomeCarrier.inheritance;
			this.prizeIncome = incomeCarrier.prizeMoney;
			this.otherIncome = incomeCarrier.otherIncome;

			//expenses lists 

			this.wagesName = incomeCarrier.wages_Description;
			this.realestateName = incomeCarrier.realestate_Description;
			this.salesHouseName = incomeCarrier.salesHouseStock_Description;
			this.smallBusinessName = incomeCarrier.smallBusiness_Description;
			this.gamblingName = incomeCarrier.gamblingWinnings_Description;
			this.salesTradesName = incomeCarrier.salesOfTrades_Description;
			this.intellectualPropertyName = incomeCarrier.intellectualProperty_Description;
			this.appRoyaltiesName = incomeCarrier.appRoyalties_Description;
			this.bookPublishingName = incomeCarrier.bookPublishing_Description;
			this.tradeDividendsName = incomeCarrier.tradeDividends_Description;
			this.bankInterestName = incomeCarrier.bankInterest_Description;
			this.taxReturnName = incomeCarrier.taxReturn_Description;
			this.studentLoadName = incomeCarrier.studentLoan_Description;
			this.inheritanceName = incomeCarrier.inheritance_Description;
			this.prizeName = incomeCarrier.prizeMoney_Description;
			this.otherIncomeName = incomeCarrier.otherIncome_Description;


			//the problem here is that the table views do not refresh  >:(
			this.TableView.ReloadData();

			Console.WriteLine("Wages Income: " + wagesIncome.Count);
			Console.WriteLine("Wages Name: " + wagesName.Count);
		}

		//alert controller that contains the categories 

		AppDelegate incomeCarrier
		{
			get
			{
				return (AppDelegate)UIApplication.SharedApplication.Delegate;
			}
		}

		public override void MotionBegan(UIEventSubtype motion, UIEvent evt)
		{  
			if(evt.Type == UIEventType.Motion) {

				//income list
				incomeCarrier.wages = wagesIncome;
				incomeCarrier.realestate = realestateIncome;
				incomeCarrier.salesHouseStock = this.salesHouseIncome;
				incomeCarrier.smallBusiness = this.smallBusinessIncome;
				incomeCarrier.gamblingWinnings = this.gamblingIncome;
				incomeCarrier.salesOfTrades = this.salesTradesIncome;
				incomeCarrier.intellectualProperty = this.intellectualPropertyIncome;
				incomeCarrier.appRoyalties = this.appRoyaltiesIncome;
				incomeCarrier.bookPublishing = this.bookPublishingIncome;
				incomeCarrier.tradeDividends = this.tradeDividendsIncome;
				incomeCarrier.bankInterest = this.bankInterestIncome;
				incomeCarrier.taxReturn = this.taxReturnIncome;
				incomeCarrier.studentLoan = this.studentLoadIncome;
				incomeCarrier.inheritance = this.inheritanceIncome;
				incomeCarrier.prizeMoney = this.prizeIncome;
				incomeCarrier.otherIncome = this.otherIncome;

				//expenses list 

				incomeCarrier.wages_Description = this.wagesName;
				incomeCarrier.realestate_Description = this.realestateName;
				incomeCarrier.salesHouseStock_Description = this.salesHouseName;
				incomeCarrier.smallBusiness_Description = this.smallBusinessName;
				incomeCarrier.gamblingWinnings_Description = this.gamblingName;
				incomeCarrier.salesOfTrades_Description = this.salesTradesName;
				incomeCarrier.intellectualProperty_Description = this.intellectualPropertyName;
				incomeCarrier.appRoyalties_Description = this.appRoyaltiesName;
				incomeCarrier.bookPublishing_Description = this.bookPublishingName;
				incomeCarrier.tradeDividends_Description = this.tradeDividendsName;
				incomeCarrier.bankInterest_Description = this.bankInterestName;
				incomeCarrier.taxReturn_Description = this.taxReturnName;
				incomeCarrier.studentLoan_Description = this.studentLoadName;
				incomeCarrier.inheritance_Description = this.inheritanceName;
				incomeCarrier.prizeMoney_Description = this.prizeName;
				incomeCarrier.otherIncome_Description = this.otherIncomeName;

				this.NavigationController.PopViewController(true);
			}
		}

		public override void ViewDidLoad()
		{
			this.TableView.AllowsSelection = false;
			this.TableView = new UITableView(new CGRect(0, 0, this.View.Bounds.Width, this.View.Bounds.Height), UITableViewStyle.Grouped);

			this.NavigationItem.Title = "List of Income";
			expensesInstructions("Welcome", "On this page you simply have to list your sources of income");

			//toolbar items 1
			UIBarButtonItem calculateExpense = new UIBarButtonItem("Calculate", UIBarButtonItemStyle.Bordered, (object sender, EventArgs e) =>
			{
			//calculates the total values stored in the list of expenses 

			UIAlertController calculateController = UIAlertController.Create("", "Have you finished listing your sources of income?", UIAlertControllerStyle.Alert);

				UIAlertAction confirmed = UIAlertAction.Create("Yes", UIAlertActionStyle.Default, (Action) =>
				{

				//check if the user has entered any values
				if (this.expenseAmount.Count == 0)
					{
						UIAlertController nullController = UIAlertController.Create("No values entered", "You must list at least one source of income before calculating your total. Simply press the 'Add' button on top to get started", UIAlertControllerStyle.Alert);

						UIAlertAction confirmedButton = UIAlertAction.Create("Ok", UIAlertActionStyle.Default, (Action_2) =>
						{
							nullController.Dispose();
						});

						nullController.AddAction(confirmedButton);

						if (this.PresentedViewController == null)
						{
							this.PresentViewController(nullController, true, null);
						}
						else if (this.PresentedViewController != null)
						{
							this.PresentedViewController.DismissViewController(true, () =>
							{
								this.PresentedViewController.Dispose();
								this.PresentViewController(nullController, true, null);
							});
						}
					}
					else if (this.expenseAmount.Count >= 1)
					{
						double wages = this.wagesIncome.Sum();
						double realestate = this.realestateIncome.Sum();
						double salesHouseStock = this.salesHouseIncome.Sum();
						double smallBusiness = this.smallBusinessIncome.Sum();
						double gamblingWinnings = this.gamblingIncome.Sum();
						double salesTradesMarket = this.salesTradesIncome.Sum();
						double intellectual = this.intellectualPropertyIncome.Sum();
						double appRoyalties = this.appRoyaltiesIncome.Sum();
						double bookPublishing = this.bookPublishingIncome.Sum();
						double tradeDividends = this.tradeDividendsIncome.Sum();
						double bankInterest = this.bankInterestIncome.Sum();
						double taxReturn = this.taxReturnIncome.Sum();
						double studentLoan = this.studentLoadIncome.Sum();
						double inheritance = this.inheritanceIncome.Sum();
						double prizeMoney = this.prizeIncome.Sum();
						double other = this.otherIncome.Sum();

						double totalIncome = this.expenseAmount.Sum();
						double totalExpenses = totalExpensesHandler;
						TotalCalculationController totalCalc = new TotalCalculationController(totalIncome, totalExpenses, rentRef, housingRef, mortgageRef, insuranceRef, taxesRef, carPaymentsRef, educationRef, electronicsRef, entertainmentRef, clothingRef,
																						  petsRef, charityRef, foodRef, healthRef, gardeningRef, cleaningRef, utilitiesRef, otherRef, wages, realestate, salesHouseStock, smallBusiness, gamblingWinnings, salesTradesMarket, intellectual, appRoyalties, bookPublishing, tradeDividends, bankInterest, taxReturn, studentLoan, inheritance,
																						  prizeMoney, other, symbolCurrency_2);
						this.NavigationController.PushViewController(totalCalc, true);
					}
				});
				UIAlertAction denied = UIAlertAction.Create("No", UIAlertActionStyle.Cancel, (Action) =>
				{
					calculateController.Dispose();
				});

				calculateController.AddAction(confirmed);
				calculateController.AddAction(denied);

				if (this.PresentedViewController == null)
				{
					this.PresentViewController(calculateController, true, null);
				}
				else if (this.PresentedViewController != null)
				{
					this.PresentedViewController.DismissViewController(true, () =>
					{
						this.PresentedViewController.Dispose();
						this.PresentViewController(calculateController, true, null);
					});
				}
			});

			UIBarButtonItem flexibleSpace = new UIBarButtonItem(UIBarButtonSystemItem.FlexibleSpace, null);

			//toolbar items 1
			//opens up the instructions window 		 
			UIBarButtonItem info = new UIBarButtonItem();

			info.TintColor = UIColor.Blue;
			info.Enabled = true;



			//info instructions button 
			UIButton infoButton = new UIButton(UIButtonType.InfoDark);
			infoButton.TintColor = UIColor.Blue;

			infoButton.UserInteractionEnabled = true;
			infoButton.ShowsTouchWhenHighlighted = true;
			info.CustomView = infoButton;

			infoButton.TouchDown += (object sender, EventArgs e) =>
			{
				Console.WriteLine("Instructions options have been played");
				expensesInstructions("Need Help?", "On this page you simply have to list your sources of income. Click on 'Add' to get started");
			};

			//toolbar items 2
			//reset button to reset the table dictionaries 
			UIBarButtonItem resetList = new UIBarButtonItem(UIBarButtonSystemItem.Trash, (object sender, EventArgs e) =>
			{
				UIAlertController resetPrompt = UIAlertController.Create("Reset?", "Do you want to clear your list of income?", UIAlertControllerStyle.Alert);

				UIAlertAction confirmed = UIAlertAction.Create("Yes", UIAlertActionStyle.Destructive, (Action) =>
				{
					this.categoryChosen.Clear();
					this.expenseAmount.Clear();
					this.name.Clear();

					this.wagesName.Clear();
					this.realestateName.Clear();
					this.salesHouseName.Clear();
					this.smallBusinessName.Clear();
					this.gamblingName.Clear();
					this.salesTradesName.Clear();
					this.intellectualPropertyName.Clear();
					this.appRoyaltiesName.Clear();
					this.bookPublishingName.Clear();
					this.tradeDividendsName.Clear();
					this.bankInterestName.Clear();
					this.taxReturnName.Clear();
					this.studentLoadName.Clear();
					this.inheritanceName.Clear();
					this.prizeName.Clear();
					this.otherIncomeName.Clear();


					this.wagesIncome.Clear();
					this.realestateIncome.Clear();
					this.salesHouseIncome.Clear();
					this.smallBusinessIncome.Clear();
					this.gamblingIncome.Clear();
					this.salesTradesIncome.Clear();
					this.intellectualPropertyIncome.Clear();
					this.appRoyaltiesIncome.Clear();
					this.bookPublishingIncome.Clear();
					this.tradeDividendsIncome.Clear();
					this.bankInterestIncome.Clear();
					this.taxReturnIncome.Clear();
					this.studentLoadIncome.Clear();
					this.inheritanceIncome.Clear();
					this.prizeIncome.Clear();
					this.otherIncome.Clear();


					this.TableView.ReloadData();
				});

				UIAlertAction denied = UIAlertAction.Create("No", UIAlertActionStyle.Cancel, (Action) =>
				{
					resetPrompt.Dispose();
				});

				resetPrompt.AddAction(confirmed);
				resetPrompt.AddAction(denied);

				if (this.PresentedViewController == null)
				{
					this.PresentViewController(resetPrompt, true, null);
				}
				else if (this.PresentedViewController != null)
				{
					this.PresentedViewController.DismissViewController(true, () =>
					{
						this.PresentedViewController.Dispose();
						this.PresentViewController(resetPrompt, true, null);
					});
				}
			});

			resetList.TintColor = UIColor.Red;

			//return the user to the home page but notifies he will lose his progress if he does

			//create a nice home page icon for this button
			UIBarButtonItem homeButton = new UIBarButtonItem("\ud83c\udfe0", UIBarButtonItemStyle.Bordered, (sender, e) =>
			{
				UIViewController budget = this.NavigationController.ViewControllers[1];

				UIAlertController promptUser = UIAlertController.Create("Return to homepage?", "If you return to the home page you will lose all your work? Are you sure?", UIAlertControllerStyle.Alert);

				UIAlertAction confirmed = UIAlertAction.Create("Yes", UIAlertActionStyle.Destructive, (Action) =>
				{
					this.Dispose();
					this.NavigationController.PopToViewController(budget, true);
				});

				UIAlertAction denied = UIAlertAction.Create("No", UIAlertActionStyle.Cancel, (Action) =>
				{
					promptUser.Dispose();
				});

				promptUser.AddAction(confirmed);
				promptUser.AddAction(denied);

				if (this.PresentedViewController == null)
				{
					this.PresentViewController(promptUser, true, null);
				}
				else if (this.PresentedViewController != null)
				{
					this.PresentedViewController.DismissViewController(true, () =>
					{
						this.PresentViewController(promptUser, true, null);
					});
				}
			});

			//change of currency button 
			if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad || UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone)
			{
				switch (UIApplication.SharedApplication.StatusBarOrientation)
				{
					case UIInterfaceOrientation.Portrait:
						this.ToolbarItems = new UIBarButtonItem[] { info, flexibleSpace, calculateExpense, flexibleSpace, resetList };

						break;
					case UIInterfaceOrientation.PortraitUpsideDown:
						
						this.ToolbarItems = new UIBarButtonItem[] { info, flexibleSpace, calculateExpense, flexibleSpace, resetList };
						break;

					default:
						this.ToolbarItems = new UIBarButtonItem[] { info, flexibleSpace, calculateExpense, flexibleSpace, resetList };
						break;
				}
				if (UIApplication.SharedApplication.StatusBarHidden == true)
				{
					UIDevice.CurrentDevice.BeginGeneratingDeviceOrientationNotifications();
					switch (UIDevice.CurrentDevice.Orientation)
					{
						case UIDeviceOrientation.LandscapeLeft:
							
							this.ToolbarItems = new UIBarButtonItem[] { info, flexibleSpace, calculateExpense, flexibleSpace, resetList };
							break;
						case UIDeviceOrientation.LandscapeRight:
							
							this.ToolbarItems = new UIBarButtonItem[] { info, flexibleSpace, calculateExpense, flexibleSpace, resetList };
							break;

						case UIDeviceOrientation.FaceUp:
							
							this.ToolbarItems = new UIBarButtonItem[] { info, flexibleSpace, calculateExpense, flexibleSpace, resetList };
							break;
						case UIDeviceOrientation.FaceDown:
							
							this.ToolbarItems = new UIBarButtonItem[] { info, flexibleSpace, calculateExpense, flexibleSpace, resetList };
							break;
						case UIDeviceOrientation.Unknown:
							
							this.ToolbarItems = new UIBarButtonItem[] { info, flexibleSpace, calculateExpense, flexibleSpace, resetList };
							break;
						default:
							Console.WriteLine("Orientation: " + UIDevice.CurrentDevice.Orientation);
							break;
					}
				}
			}

			//Navigation items

			this.NavigationItem.SetRightBarButtonItem(new UIBarButtonItem("Add", UIBarButtonItemStyle.Bordered, (object sender, EventArgs e) =>
			{

				UIAlertController addExpensePrompt = UIAlertController.Create("Add a source of income?", "", UIAlertControllerStyle.Alert);
			//disable landscape modes on iPhone and iPad

			UIAlertAction Update = UIAlertAction.Create("Add", UIAlertActionStyle.Default, (Action) =>
		{
					if (String.IsNullOrEmpty(addExpensePrompt.TextFields[0].Text) == false)
					{
						categoryAdd("Choose your category", "Choose a category for your source of income");
					}
				});

				UIAlertAction cancel = UIAlertAction.Create("Cancel", UIAlertActionStyle.Cancel, (Action) =>
				{
					addExpensePrompt.Dispose();
				});

				addExpensePrompt.AddTextField((UITextField obj) =>
				{
					obj.AdjustsFontSizeToFitWidth = true;
					obj.ClearButtonMode = UITextFieldViewMode.WhileEditing;
					obj.Placeholder = "Enter an amount";
					obj.KeyboardAppearance = UIKeyboardAppearance.Alert;
					obj.KeyboardType = UIKeyboardType.NumberPad;
					obj.BorderStyle = UITextBorderStyle.RoundedRect;
					obj.AutocorrectionType = UITextAutocorrectionType.Yes;


					obj.EditingDidBegin += (object sender_4, EventArgs e_4) =>
					{
						cancel.Enabled = false;
					};
				//enable and disable the 'Add' button based on whether text exists inside the text labels
				Update = UIAlertAction.Create("Add", UIAlertActionStyle.Default, (Action) =>
			{
						if (addExpensePrompt.IsBeingDismissed == true)
						{
							if (String.IsNullOrEmpty(obj.Text) == true)
							{
								this.PresentViewController(addExpensePrompt, true, () =>
								{
									AI.AIEnglish("Error. You must enter a value for your income", "en-US", 2.5f, 1.0f, 1.0f);
								});
							}
							else if (String.IsNullOrEmpty(obj.Text) == false)
							{
								this.expenseAmount.Add(Convert.ToDouble(obj.Text));
								this.TableView.ReloadData();
							}
						}
						if (String.IsNullOrEmpty(obj.Text) == false)
						{
							categoryAdd("Choose your category", "Choose a category for your source of income");
						}
					});

					obj.EditingDidEnd += (object sender_3, EventArgs e_3) =>
					{

						if (addExpensePrompt.IsBeingDismissed == true)
						{
							if (String.IsNullOrEmpty(obj.Text) == true)
							{
								this.PresentViewController(addExpensePrompt, true, () =>
								{
									AI.AIEnglish("Error. You must enter a value for your source of income", "en-US", 2.5f, 1.0f, 1.0f);
								});
							}

							else if (String.IsNullOrEmpty(obj.Text) == false)
							{
								this.expenseAmount.Add(System.Convert.ToDouble(obj.Text));
								this.name.Add(addExpensePrompt.TextFields[1].Text);

								this.TableView.ReloadData();
							}
						}
					};
				});

				addExpensePrompt.AddTextField((UITextField obj_2) =>
				{
					obj_2.AdjustsFontSizeToFitWidth = true;
					obj_2.ClearButtonMode = UITextFieldViewMode.WhileEditing;
					obj_2.Placeholder = "Enter an optional description";
					obj_2.KeyboardAppearance = UIKeyboardAppearance.Alert;
					obj_2.KeyboardType = UIKeyboardType.Default;
					obj_2.ReturnKeyType = UIReturnKeyType.Done;
					obj_2.BorderStyle = UITextBorderStyle.RoundedRect;
					obj_2.AutocorrectionType = UITextAutocorrectionType.Yes;

					obj_2.EditingDidBegin += (object sender_5, EventArgs e_5) =>
					{
						cancel.Enabled = true;
					};


					cancel = UIAlertAction.Create("Cancel", UIAlertActionStyle.Cancel, (Action) =>
					{
						try
						{
							if (this.name.Count >= 0 && String.IsNullOrEmpty(addExpensePrompt.TextFields[1].Text) == true)
							{
								this.expenseAmount.RemoveAt(this.expenseAmount.Count - 1);
							}
							else if (this.name.Count >= 1 && String.IsNullOrEmpty(addExpensePrompt.TextFields[1].Text) == false)
							{
								this.expenseAmount.RemoveAt(this.expenseAmount.Count - 1);
								this.name.RemoveAt(this.name.Count - 1);
							}
						}
						catch (ArgumentOutOfRangeException)
						{
							Console.WriteLine("<:)");
						}
					});

					obj_2.EditingDidEnd += (object sender_4, EventArgs e_4) =>
					{
						if (addExpensePrompt.IsBeingDismissed == true)
						{
							if (String.IsNullOrEmpty(addExpensePrompt.TextFields[0].Text) == true)
							{
								this.PresentViewController(addExpensePrompt, true, () =>
								{
									AI.AIEnglish("Error. You must enter a value for your source of income", "en-US", 2.5f, 1.0f, 1.0f);
								});
								obj_2.ResignFirstResponder();
							}
							else if (String.IsNullOrEmpty(addExpensePrompt.TextFields[0].Text) == false)
							{
								this.expenseAmount.Add(System.Convert.ToDouble(addExpensePrompt.TextFields[0].Text));
								this.name.Add(obj_2.Text);
								this.TableView.ReloadData();
								obj_2.ResignFirstResponder();
							}

							if (String.IsNullOrEmpty(obj_2.Text) == true)
							{
								this.TableView.ReloadData();
								this.name.Add("");

								obj_2.ResignFirstResponder();
							}
						}
						if (String.IsNullOrEmpty(obj_2.Text) == false)
						{
							categoryAdd("Choose your category", "Choose a category for your income");
						}

					};
				});


				addExpensePrompt.AddAction(Update);
				addExpensePrompt.AddAction(cancel);

				if (this.PresentedViewController == null)
				{
					this.PresentViewController(addExpensePrompt, true, null);
				}
				else if (this.PresentedViewController != null)
				{
					this.PresentedViewController.DismissViewController(true, () =>
					{
						this.PresentedViewController.Dispose();
						this.PresentViewController(addExpensePrompt, true, null);
					});
				}
			}), true);


			//UITextAttributes textSize = new UITextAttributes();
			//textSize.Font = UIFont.SystemFontOfSize(23.0f);

			//this.NavigationItem.RightBarButtonItem.SetTitleTextAttributes(textSize, UIControlState.Normal);
			//this.NavigationItem.RightBarButtonItem.SetTitleTextAttributes(textSize, UIControlState.Highlighted);

			//deletes a cell of choice by animating the table cell removal 
			deleteCell.Clicked += (sender, e) =>
			{
				if (this.categoryChosen.Count >= 1)
				{
					this.TableView.SetEditing(true, true);

					this.NavigationItem.SetLeftBarButtonItem(new UIBarButtonItem("Cancel", UIBarButtonItemStyle.Bordered, (sender_2, e_2) =>
					{
						this.TableView.SetEditing(false, true);
						this.NavigationItem.SetLeftBarButtonItem(deleteCell, true);
					}), true);
				}

				else if (this.categoryChosen.Count == 0)
				{
					if (this.TableView.Editing == true)
					{
						Console.WriteLine("Editing is true");
						this.TableView.SetEditing(false, true);
						this.NavigationItem.SetLeftBarButtonItem(deleteCell, true);
					}

					UIAlertController alertDel = UIAlertController.Create("No values to delete", "You have to enter at least one source of income before you can delete anything", UIAlertControllerStyle.Alert);

					UIAlertAction confirmed = UIAlertAction.Create("Ok", UIAlertActionStyle.Default, (Action) =>
					{
						alertDel.Dispose();
					});

					alertDel.AddAction(confirmed);

					if (this.PresentedViewController == null)
					{
						this.PresentViewController(alertDel, true, null);
					}

					else if (this.PresentedViewController != null)
					{
						this.PresentedViewController.DismissViewController(true, () =>
						{
							this.PresentViewController(alertDel, true, null);
						});
					}
				}
			};

			deleteCell.TintColor = UIColor.Red;

			this.NavigationItem.SetLeftBarButtonItem(deleteCell, true);
			this.View.BackgroundColor = UIColor.White;
			this.TableView.ReloadData();
		}


		UITableViewCell expensesCell = new UITableViewCell(UITableViewCellStyle.Subtitle, "Cell");
		NSIndexPath index = new NSIndexPath();

		public override void Transition(UIViewController fromViewController, UIViewController toViewController, double duration, UIViewAnimationOptions options, Action animations, UICompletionHandler completionHandler)
		{
			if(fromViewController is ExpenseController) {
				this.TableView.ReloadData();
			}
		}


		public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
		{
			expensesCell = tableView.DequeueReusableCell("expensesCellID");

			if (expensesCell == null)
			{
				expensesCell = new UITableViewCell(UITableViewCellStyle.Subtitle, "Cell");
			}


			//manual layouts according to device type
			try
			{
				if (this.name[indexPath.Row] == null)
				{
					throw new System.ArgumentOutOfRangeException();
				}

				else if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad || UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone)
				{

					if (this.categoryChosen.Count == 0)
					{

						UITextField textExpenses = new UITextField();
						textExpenses.Frame = new CGRect(0, 0, 60, 20);
						textExpenses.BorderStyle = UITextBorderStyle.None;
						textExpenses.AdjustsFontSizeToFitWidth = true;
						textExpenses.UserInteractionEnabled = false;
						expensesCell.AccessoryView = textExpenses;

						UIDevice.CurrentDevice.BeginGeneratingDeviceOrientationNotifications();
						switch (UIDevice.CurrentDevice.Orientation)
						{
							case UIDeviceOrientation.LandscapeLeft:
								expensesCell.TextLabel.Text = "Category: ";
								expensesCell.TextLabel.TextColor = UIColor.Black;
								textExpenses.Text = "";


								//setup the orientation and create a nice interface

								expensesCell.DetailTextLabel.Text = "Description: " + this.name[indexPath.Row];
								expensesCell.DetailTextLabel.TextColor = UIColor.Gray;

								break;
							case UIDeviceOrientation.LandscapeRight:
								expensesCell.TextLabel.Text = "Category: ";
								expensesCell.TextLabel.TextColor = UIColor.Black;
								textExpenses.Text = "";

								expensesCell.DetailTextLabel.Text = "Description: " + this.name[indexPath.Row];
								expensesCell.DetailTextLabel.TextColor = UIColor.Gray;

								break;
							case UIDeviceOrientation.Portrait:
								expensesCell.TextLabel.Text = "Category: ";
								expensesCell.TextLabel.TextColor = UIColor.Black;
								textExpenses.Text = "";

								expensesCell.DetailTextLabel.Text = "Description: " + this.name[indexPath.Row];
								expensesCell.DetailTextLabel.TextColor = UIColor.Gray;

								break;
							case UIDeviceOrientation.PortraitUpsideDown:
								expensesCell.TextLabel.Text = "Category: ";
								expensesCell.TextLabel.TextColor = UIColor.Black;
								textExpenses.Text = "";

								expensesCell.DetailTextLabel.Text = "Description: " + this.name[indexPath.Row];
								expensesCell.DetailTextLabel.TextColor = UIColor.Gray;

								break;

							default:
								expensesCell.TextLabel.Text = "Category: ";
								expensesCell.TextLabel.TextColor = UIColor.Black;
								textExpenses.Text = "";

								expensesCell.DetailTextLabel.Text = "Description: " + this.name[indexPath.Row];
								expensesCell.DetailTextLabel.TextColor = UIColor.Gray;

								Console.WriteLine("Interface orientation is: " + UIInterfaceOrientation.Unknown);
								break;
						}
					}


					else if (this.categoryChosen.Count >= 1)
					{
						if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad || UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone)
						{

							UITextField textExpenses = new UITextField();
							textExpenses.Frame = new CGRect(0, 0, 60, 20);
							textExpenses.BorderStyle = UITextBorderStyle.None;
							textExpenses.AdjustsFontSizeToFitWidth = true;
							textExpenses.UserInteractionEnabled = false;

							Console.WriteLine("Orientation: " + UIApplication.SharedApplication.StatusBarOrientation);
							UIDevice.CurrentDevice.BeginGeneratingDeviceOrientationNotifications();

							switch (UIDevice.CurrentDevice.Orientation)
							{
								case UIDeviceOrientation.LandscapeLeft:
									//expensesCell.TextLabel.Text = "Category: " + this.categoryChosen[indexPath.Row];
									//expensesCell.TextLabel.TextColor = UIColor.Black;

									switch (indexPath.Section)
									{
										case 0:

											expensesCell.AccessoryView = textExpenses;

											textExpenses.Text = symbolCurrency_2 + this.wagesIncome[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.wagesName[indexPath.Row];
											expensesCell.DetailTextLabel.TextColor = UIColor.Gray;
											expensesCell.DetailTextLabel.MinimumFontSize = 14.0f;

											expensesCell.DetailTextLabel.AdjustsFontSizeToFitWidth = true;
											expensesCell.DetailTextLabel.AdjustsLetterSpacingToFitWidth = true;

											tableView.SectionIndexBackgroundColor = UIColor.Gray;
											tableView.SectionIndexColor = UIColor.Black;
											return expensesCell;
											break;

										case 1:
											expensesCell.AccessoryView = textExpenses;

											textExpenses.Text = symbolCurrency_2 + this.realestateIncome[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.realestateName[indexPath.Row];
											expensesCell.DetailTextLabel.TextColor = UIColor.Gray;
											expensesCell.DetailTextLabel.MinimumFontSize = 14.0f;


											expensesCell.DetailTextLabel.AdjustsFontSizeToFitWidth = true;
											expensesCell.DetailTextLabel.AdjustsLetterSpacingToFitWidth = true;

											tableView.SectionIndexBackgroundColor = UIColor.Gray;
											tableView.SectionIndexColor = UIColor.Black;
											return expensesCell;

											break;

										case 2:
											expensesCell.AccessoryView = textExpenses;

											textExpenses.Text = symbolCurrency_2 + this.salesHouseIncome[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.salesHouseName[indexPath.Row];
											expensesCell.DetailTextLabel.TextColor = UIColor.Gray;
											expensesCell.DetailTextLabel.MinimumFontSize = 14.0f;


											expensesCell.DetailTextLabel.AdjustsFontSizeToFitWidth = true;
											expensesCell.DetailTextLabel.AdjustsLetterSpacingToFitWidth = true;

											tableView.SectionIndexBackgroundColor = UIColor.Gray;
											tableView.SectionIndexColor = UIColor.Black;
											return expensesCell;

											break;

										case 3:
											expensesCell.AccessoryView = textExpenses;

											textExpenses.Text = symbolCurrency_2 + this.smallBusinessIncome[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.smallBusinessName[indexPath.Row];
											expensesCell.DetailTextLabel.TextColor = UIColor.Gray;
											expensesCell.DetailTextLabel.MinimumFontSize = 14.0f;


											expensesCell.DetailTextLabel.AdjustsFontSizeToFitWidth = true;
											expensesCell.DetailTextLabel.AdjustsLetterSpacingToFitWidth = true;

											tableView.SectionIndexBackgroundColor = UIColor.Gray;
											tableView.SectionIndexColor = UIColor.Black;
											return expensesCell;

											break;

										case 4:

											expensesCell.AccessoryView = textExpenses;

											textExpenses.Text = symbolCurrency_2 + this.gamblingIncome[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.gamblingName[indexPath.Row];
											expensesCell.DetailTextLabel.TextColor = UIColor.Gray;
											expensesCell.DetailTextLabel.MinimumFontSize = 14.0f;


											expensesCell.DetailTextLabel.AdjustsFontSizeToFitWidth = true;
											expensesCell.DetailTextLabel.AdjustsLetterSpacingToFitWidth = true;

											tableView.SectionIndexBackgroundColor = UIColor.Gray;
											tableView.SectionIndexColor = UIColor.Black;
											return expensesCell;

											break;
										case 5:
											expensesCell.AccessoryView = textExpenses;

											textExpenses.Text = symbolCurrency_2 + this.salesTradesIncome[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.salesTradesName[indexPath.Row];
											expensesCell.DetailTextLabel.TextColor = UIColor.Gray;
											expensesCell.DetailTextLabel.MinimumFontSize = 14.0f;


											expensesCell.DetailTextLabel.AdjustsFontSizeToFitWidth = true;
											expensesCell.DetailTextLabel.AdjustsLetterSpacingToFitWidth = true;

											tableView.SectionIndexBackgroundColor = UIColor.Gray;
											tableView.SectionIndexColor = UIColor.Black;
											return expensesCell;

											break;

										case 6:
											expensesCell.AccessoryView = textExpenses;

											textExpenses.Text = symbolCurrency_2 + this.intellectualPropertyIncome[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.intellectualPropertyName[indexPath.Row];
											expensesCell.DetailTextLabel.TextColor = UIColor.Gray;
											expensesCell.DetailTextLabel.MinimumFontSize = 14.0f;


											expensesCell.DetailTextLabel.AdjustsFontSizeToFitWidth = true;
											expensesCell.DetailTextLabel.AdjustsLetterSpacingToFitWidth = true;

											tableView.SectionIndexBackgroundColor = UIColor.Gray;
											tableView.SectionIndexColor = UIColor.Black;
											return expensesCell;

											break;

										case 7:
											expensesCell.AccessoryView = textExpenses;

											textExpenses.Text = symbolCurrency_2 + this.appRoyaltiesIncome[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.appRoyaltiesName[indexPath.Row];
											expensesCell.DetailTextLabel.TextColor = UIColor.Gray;
											expensesCell.DetailTextLabel.MinimumFontSize = 14.0f;


											expensesCell.DetailTextLabel.AdjustsFontSizeToFitWidth = true;
											expensesCell.DetailTextLabel.AdjustsLetterSpacingToFitWidth = true;

											tableView.SectionIndexBackgroundColor = UIColor.Gray;
											tableView.SectionIndexColor = UIColor.Black;
											return expensesCell;

											break;

										case 8:

											expensesCell.AccessoryView = textExpenses;

											textExpenses.Text = symbolCurrency_2 + this.bookPublishingIncome[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.bookPublishingName[indexPath.Row];
											expensesCell.DetailTextLabel.TextColor = UIColor.Gray;
											expensesCell.DetailTextLabel.MinimumFontSize = 14.0f;

											expensesCell.DetailTextLabel.AdjustsFontSizeToFitWidth = true;
											expensesCell.DetailTextLabel.AdjustsLetterSpacingToFitWidth = true;

											tableView.SectionIndexBackgroundColor = UIColor.Gray;
											tableView.SectionIndexColor = UIColor.Black;
											return expensesCell;

											break;

										case 9:
											expensesCell.AccessoryView = textExpenses;

											textExpenses.Text = symbolCurrency_2 + this.tradeDividendsIncome[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.tradeDividendsName[indexPath.Row];
											expensesCell.DetailTextLabel.TextColor = UIColor.Gray;
											expensesCell.DetailTextLabel.MinimumFontSize = 14.0f;


											expensesCell.DetailTextLabel.AdjustsFontSizeToFitWidth = true;
											expensesCell.DetailTextLabel.AdjustsLetterSpacingToFitWidth = true;

											tableView.SectionIndexBackgroundColor = UIColor.Gray;
											tableView.SectionIndexColor = UIColor.Black;
											return expensesCell;

											break;

										case 10:
											expensesCell.AccessoryView = textExpenses;

											textExpenses.Text = symbolCurrency_2 + this.bankInterestIncome[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.bankInterestName[indexPath.Row];
											expensesCell.DetailTextLabel.TextColor = UIColor.Gray;
											expensesCell.DetailTextLabel.MinimumFontSize = 14.0f;

											expensesCell.DetailTextLabel.AdjustsFontSizeToFitWidth = true;
											expensesCell.DetailTextLabel.AdjustsLetterSpacingToFitWidth = true;

											tableView.SectionIndexBackgroundColor = UIColor.Gray;
											tableView.SectionIndexColor = UIColor.Black;
											return expensesCell;

											break;

										case 11:

											expensesCell.AccessoryView = textExpenses;

											textExpenses.Text = symbolCurrency_2 + this.taxReturnIncome[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.taxReturnName[indexPath.Row];
											expensesCell.DetailTextLabel.TextColor = UIColor.Gray;
											expensesCell.DetailTextLabel.MinimumFontSize = 14.0f;

											expensesCell.DetailTextLabel.AdjustsFontSizeToFitWidth = true;
											expensesCell.DetailTextLabel.AdjustsLetterSpacingToFitWidth = true;

											tableView.SectionIndexBackgroundColor = UIColor.Gray;
											tableView.SectionIndexColor = UIColor.Black;
											return expensesCell;

											break;

										case 12:

											expensesCell.AccessoryView = textExpenses;

											textExpenses.Text = symbolCurrency_2 + this.studentLoadIncome[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.studentLoadName[indexPath.Row];
											expensesCell.DetailTextLabel.TextColor = UIColor.Gray;
											expensesCell.DetailTextLabel.MinimumFontSize = 14.0f;

											expensesCell.DetailTextLabel.AdjustsFontSizeToFitWidth = true;
											expensesCell.DetailTextLabel.AdjustsLetterSpacingToFitWidth = true;

											tableView.SectionIndexBackgroundColor = UIColor.Gray;
											tableView.SectionIndexColor = UIColor.Black;
											return expensesCell;

											break;

										case 13:

											expensesCell.AccessoryView = textExpenses;

											textExpenses.Text = symbolCurrency_2 + this.inheritanceIncome[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.inheritanceName[indexPath.Row];
											expensesCell.DetailTextLabel.TextColor = UIColor.Gray;
											expensesCell.DetailTextLabel.MinimumFontSize = 14.0f;

											expensesCell.DetailTextLabel.AdjustsFontSizeToFitWidth = true;
											expensesCell.DetailTextLabel.AdjustsLetterSpacingToFitWidth = true;

											tableView.SectionIndexBackgroundColor = UIColor.Gray;
											tableView.SectionIndexColor = UIColor.Black;
											return expensesCell;

											break;

										case 14:

											expensesCell.AccessoryView = textExpenses;

											textExpenses.Text = symbolCurrency_2 + this.prizeIncome[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.prizeName[indexPath.Row];
											expensesCell.DetailTextLabel.TextColor = UIColor.Gray;
											expensesCell.DetailTextLabel.MinimumFontSize = 14.0f;

											expensesCell.DetailTextLabel.AdjustsFontSizeToFitWidth = true;
											expensesCell.DetailTextLabel.AdjustsLetterSpacingToFitWidth = true;

											tableView.SectionIndexBackgroundColor = UIColor.Gray;
											tableView.SectionIndexColor = UIColor.Black;
											return expensesCell;

											break;

										case 15:

											expensesCell.AccessoryView = textExpenses;

											textExpenses.Text = symbolCurrency_2 + this.otherIncome[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.otherIncomeName[indexPath.Row];
											expensesCell.DetailTextLabel.TextColor = UIColor.Gray;
											expensesCell.DetailTextLabel.MinimumFontSize = 14.0f;

											expensesCell.DetailTextLabel.AdjustsFontSizeToFitWidth = true;
											expensesCell.DetailTextLabel.AdjustsLetterSpacingToFitWidth = true;

											tableView.SectionIndexBackgroundColor = UIColor.Gray;
											tableView.SectionIndexColor = UIColor.Black;
											return expensesCell;

											break;
									}
									break;
								case UIDeviceOrientation.LandscapeRight:

									//expensesCell.TextLabel.Text = "Category: " + this.categoryChosen[indexPath.Row];
									//expensesCell.TextLabel.TextColor = UIColor.Black;


									switch (indexPath.Section)
									{
										case 0:

											expensesCell.AccessoryView = textExpenses;

											textExpenses.Text = symbolCurrency_2 + this.wagesIncome[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.wagesName[indexPath.Row];
											expensesCell.DetailTextLabel.TextColor = UIColor.Gray;
											expensesCell.DetailTextLabel.MinimumFontSize = 14.0f;

											expensesCell.DetailTextLabel.AdjustsFontSizeToFitWidth = true;
											expensesCell.DetailTextLabel.AdjustsLetterSpacingToFitWidth = true;

											tableView.SectionIndexBackgroundColor = UIColor.Gray;
											tableView.SectionIndexColor = UIColor.Black;
											return expensesCell;
											break;

										case 1:
											expensesCell.AccessoryView = textExpenses;

											textExpenses.Text = symbolCurrency_2 + this.realestateIncome[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.realestateName[indexPath.Row];
											expensesCell.DetailTextLabel.TextColor = UIColor.Gray;
											expensesCell.DetailTextLabel.MinimumFontSize = 14.0f;


											expensesCell.DetailTextLabel.AdjustsFontSizeToFitWidth = true;
											expensesCell.DetailTextLabel.AdjustsLetterSpacingToFitWidth = true;

											tableView.SectionIndexBackgroundColor = UIColor.Gray;
											tableView.SectionIndexColor = UIColor.Black;
											return expensesCell;

											break;

										case 2:
											expensesCell.AccessoryView = textExpenses;

											textExpenses.Text = symbolCurrency_2 + this.salesHouseIncome[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.salesHouseName[indexPath.Row];
											expensesCell.DetailTextLabel.TextColor = UIColor.Gray;
											expensesCell.DetailTextLabel.MinimumFontSize = 14.0f;


											expensesCell.DetailTextLabel.AdjustsFontSizeToFitWidth = true;
											expensesCell.DetailTextLabel.AdjustsLetterSpacingToFitWidth = true;

											tableView.SectionIndexBackgroundColor = UIColor.Gray;
											tableView.SectionIndexColor = UIColor.Black;
											return expensesCell;

											break;

										case 3:
											expensesCell.AccessoryView = textExpenses;

											textExpenses.Text = symbolCurrency_2 + this.smallBusinessIncome[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.smallBusinessName[indexPath.Row];
											expensesCell.DetailTextLabel.TextColor = UIColor.Gray;
											expensesCell.DetailTextLabel.MinimumFontSize = 14.0f;


											expensesCell.DetailTextLabel.AdjustsFontSizeToFitWidth = true;
											expensesCell.DetailTextLabel.AdjustsLetterSpacingToFitWidth = true;

											tableView.SectionIndexBackgroundColor = UIColor.Gray;
											tableView.SectionIndexColor = UIColor.Black;
											return expensesCell;

											break;

										case 4:

											expensesCell.AccessoryView = textExpenses;

											textExpenses.Text = symbolCurrency_2 + this.gamblingIncome[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.gamblingName[indexPath.Row];
											expensesCell.DetailTextLabel.TextColor = UIColor.Gray;
											expensesCell.DetailTextLabel.MinimumFontSize = 14.0f;


											expensesCell.DetailTextLabel.AdjustsFontSizeToFitWidth = true;
											expensesCell.DetailTextLabel.AdjustsLetterSpacingToFitWidth = true;

											tableView.SectionIndexBackgroundColor = UIColor.Gray;
											tableView.SectionIndexColor = UIColor.Black;
											return expensesCell;

											break;
										case 5:
											expensesCell.AccessoryView = textExpenses;

											textExpenses.Text = symbolCurrency_2 + this.salesTradesIncome[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.salesTradesName[indexPath.Row];
											expensesCell.DetailTextLabel.TextColor = UIColor.Gray;
											expensesCell.DetailTextLabel.MinimumFontSize = 14.0f;


											expensesCell.DetailTextLabel.AdjustsFontSizeToFitWidth = true;
											expensesCell.DetailTextLabel.AdjustsLetterSpacingToFitWidth = true;

											tableView.SectionIndexBackgroundColor = UIColor.Gray;
											tableView.SectionIndexColor = UIColor.Black;
											return expensesCell;

											break;

										case 6:
											expensesCell.AccessoryView = textExpenses;

											textExpenses.Text = symbolCurrency_2 + this.intellectualPropertyIncome[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.intellectualPropertyName[indexPath.Row];
											expensesCell.DetailTextLabel.TextColor = UIColor.Gray;
											expensesCell.DetailTextLabel.MinimumFontSize = 14.0f;


											expensesCell.DetailTextLabel.AdjustsFontSizeToFitWidth = true;
											expensesCell.DetailTextLabel.AdjustsLetterSpacingToFitWidth = true;

											tableView.SectionIndexBackgroundColor = UIColor.Gray;
											tableView.SectionIndexColor = UIColor.Black;
											return expensesCell;

											break;

										case 7:
											expensesCell.AccessoryView = textExpenses;

											textExpenses.Text = symbolCurrency_2 + this.appRoyaltiesIncome[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.appRoyaltiesName[indexPath.Row];
											expensesCell.DetailTextLabel.TextColor = UIColor.Gray;
											expensesCell.DetailTextLabel.MinimumFontSize = 14.0f;


											expensesCell.DetailTextLabel.AdjustsFontSizeToFitWidth = true;
											expensesCell.DetailTextLabel.AdjustsLetterSpacingToFitWidth = true;

											tableView.SectionIndexBackgroundColor = UIColor.Gray;
											tableView.SectionIndexColor = UIColor.Black;
											return expensesCell;

											break;

										case 8:

											expensesCell.AccessoryView = textExpenses;

											textExpenses.Text = symbolCurrency_2 + this.bookPublishingIncome[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.bookPublishingName[indexPath.Row];
											expensesCell.DetailTextLabel.TextColor = UIColor.Gray;
											expensesCell.DetailTextLabel.MinimumFontSize = 14.0f;

											expensesCell.DetailTextLabel.AdjustsFontSizeToFitWidth = true;
											expensesCell.DetailTextLabel.AdjustsLetterSpacingToFitWidth = true;

											tableView.SectionIndexBackgroundColor = UIColor.Gray;
											tableView.SectionIndexColor = UIColor.Black;
											return expensesCell;

											break;

										case 9:
											expensesCell.AccessoryView = textExpenses;

											textExpenses.Text = symbolCurrency_2 + this.tradeDividendsIncome[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.tradeDividendsName[indexPath.Row];
											expensesCell.DetailTextLabel.TextColor = UIColor.Gray;
											expensesCell.DetailTextLabel.MinimumFontSize = 14.0f;


											expensesCell.DetailTextLabel.AdjustsFontSizeToFitWidth = true;
											expensesCell.DetailTextLabel.AdjustsLetterSpacingToFitWidth = true;

											tableView.SectionIndexBackgroundColor = UIColor.Gray;
											tableView.SectionIndexColor = UIColor.Black;
											return expensesCell;

											break;

										case 10:
											expensesCell.AccessoryView = textExpenses;

											textExpenses.Text = symbolCurrency_2 + this.bankInterestIncome[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.bankInterestName[indexPath.Row];
											expensesCell.DetailTextLabel.TextColor = UIColor.Gray;
											expensesCell.DetailTextLabel.MinimumFontSize = 14.0f;

											expensesCell.DetailTextLabel.AdjustsFontSizeToFitWidth = true;
											expensesCell.DetailTextLabel.AdjustsLetterSpacingToFitWidth = true;

											tableView.SectionIndexBackgroundColor = UIColor.Gray;
											tableView.SectionIndexColor = UIColor.Black;
											return expensesCell;

											break;

										case 11:

											expensesCell.AccessoryView = textExpenses;

											textExpenses.Text = symbolCurrency_2 + this.taxReturnIncome[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.taxReturnName[indexPath.Row];
											expensesCell.DetailTextLabel.TextColor = UIColor.Gray;
											expensesCell.DetailTextLabel.MinimumFontSize = 14.0f;

											expensesCell.DetailTextLabel.AdjustsFontSizeToFitWidth = true;
											expensesCell.DetailTextLabel.AdjustsLetterSpacingToFitWidth = true;

											tableView.SectionIndexBackgroundColor = UIColor.Gray;
											tableView.SectionIndexColor = UIColor.Black;
											return expensesCell;

											break;

										case 12:

											expensesCell.AccessoryView = textExpenses;

											textExpenses.Text = symbolCurrency_2 + this.studentLoadIncome[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.studentLoadName[indexPath.Row];
											expensesCell.DetailTextLabel.TextColor = UIColor.Gray;
											expensesCell.DetailTextLabel.MinimumFontSize = 14.0f;

											expensesCell.DetailTextLabel.AdjustsFontSizeToFitWidth = true;
											expensesCell.DetailTextLabel.AdjustsLetterSpacingToFitWidth = true;

											tableView.SectionIndexBackgroundColor = UIColor.Gray;
											tableView.SectionIndexColor = UIColor.Black;
											return expensesCell;

											break;

										case 13:

											expensesCell.AccessoryView = textExpenses;

											textExpenses.Text = symbolCurrency_2 + this.inheritanceIncome[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.inheritanceName[indexPath.Row];
											expensesCell.DetailTextLabel.TextColor = UIColor.Gray;
											expensesCell.DetailTextLabel.MinimumFontSize = 14.0f;

											expensesCell.DetailTextLabel.AdjustsFontSizeToFitWidth = true;
											expensesCell.DetailTextLabel.AdjustsLetterSpacingToFitWidth = true;

											tableView.SectionIndexBackgroundColor = UIColor.Gray;
											tableView.SectionIndexColor = UIColor.Black;
											return expensesCell;

											break;

										case 14:

											expensesCell.AccessoryView = textExpenses;

											textExpenses.Text = symbolCurrency_2 + this.prizeIncome[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.prizeName[indexPath.Row];
											expensesCell.DetailTextLabel.TextColor = UIColor.Gray;
											expensesCell.DetailTextLabel.MinimumFontSize = 14.0f;

											expensesCell.DetailTextLabel.AdjustsFontSizeToFitWidth = true;
											expensesCell.DetailTextLabel.AdjustsLetterSpacingToFitWidth = true;

											tableView.SectionIndexBackgroundColor = UIColor.Gray;
											tableView.SectionIndexColor = UIColor.Black;
											return expensesCell;

											break;

										case 15:

											expensesCell.AccessoryView = textExpenses;

											textExpenses.Text = symbolCurrency_2 + this.otherIncome[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.otherIncomeName[indexPath.Row];
											expensesCell.DetailTextLabel.TextColor = UIColor.Gray;
											expensesCell.DetailTextLabel.MinimumFontSize = 14.0f;

											expensesCell.DetailTextLabel.AdjustsFontSizeToFitWidth = true;
											expensesCell.DetailTextLabel.AdjustsLetterSpacingToFitWidth = true;

											tableView.SectionIndexBackgroundColor = UIColor.Gray;
											tableView.SectionIndexColor = UIColor.Black;
											return expensesCell;

											break;
									}
									break;
								case UIDeviceOrientation.Portrait:
									//expensesCell.TextLabel.Text = "Category: " + this.categoryChosen[indexPath.Row];
									//expensesCell.TextLabel.TextColor = UIColor.Black;

									switch (indexPath.Section)
									{
										case 0:

											expensesCell.AccessoryView = textExpenses;

											textExpenses.Text = symbolCurrency_2 + this.wagesIncome[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.wagesName[indexPath.Row];
											expensesCell.DetailTextLabel.TextColor = UIColor.Gray;
											expensesCell.DetailTextLabel.MinimumFontSize = 14.0f;

											expensesCell.DetailTextLabel.AdjustsFontSizeToFitWidth = true;
											expensesCell.DetailTextLabel.AdjustsLetterSpacingToFitWidth = true;

											tableView.SectionIndexBackgroundColor = UIColor.Gray;
											tableView.SectionIndexColor = UIColor.Black;
											return expensesCell;
											break;

										case 1:
											expensesCell.AccessoryView = textExpenses;

											textExpenses.Text = symbolCurrency_2 + this.realestateIncome[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.realestateName[indexPath.Row];
											expensesCell.DetailTextLabel.TextColor = UIColor.Gray;
											expensesCell.DetailTextLabel.MinimumFontSize = 14.0f;


											expensesCell.DetailTextLabel.AdjustsFontSizeToFitWidth = true;
											expensesCell.DetailTextLabel.AdjustsLetterSpacingToFitWidth = true;

											tableView.SectionIndexBackgroundColor = UIColor.Gray;
											tableView.SectionIndexColor = UIColor.Black;
											return expensesCell;

											break;

										case 2:
											expensesCell.AccessoryView = textExpenses;

											textExpenses.Text = symbolCurrency_2 + this.salesHouseIncome[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.salesHouseName[indexPath.Row];
											expensesCell.DetailTextLabel.TextColor = UIColor.Gray;
											expensesCell.DetailTextLabel.MinimumFontSize = 14.0f;


											expensesCell.DetailTextLabel.AdjustsFontSizeToFitWidth = true;
											expensesCell.DetailTextLabel.AdjustsLetterSpacingToFitWidth = true;

											tableView.SectionIndexBackgroundColor = UIColor.Gray;
											tableView.SectionIndexColor = UIColor.Black;
											return expensesCell;

											break;

										case 3:
											expensesCell.AccessoryView = textExpenses;

											textExpenses.Text = symbolCurrency_2 + this.smallBusinessIncome[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.smallBusinessName[indexPath.Row];
											expensesCell.DetailTextLabel.TextColor = UIColor.Gray;
											expensesCell.DetailTextLabel.MinimumFontSize = 14.0f;


											expensesCell.DetailTextLabel.AdjustsFontSizeToFitWidth = true;
											expensesCell.DetailTextLabel.AdjustsLetterSpacingToFitWidth = true;

											tableView.SectionIndexBackgroundColor = UIColor.Gray;
											tableView.SectionIndexColor = UIColor.Black;
											return expensesCell;

											break;

										case 4:

											expensesCell.AccessoryView = textExpenses;

											textExpenses.Text = symbolCurrency_2 + this.gamblingIncome[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.gamblingName[indexPath.Row];
											expensesCell.DetailTextLabel.TextColor = UIColor.Gray;
											expensesCell.DetailTextLabel.MinimumFontSize = 14.0f;


											expensesCell.DetailTextLabel.AdjustsFontSizeToFitWidth = true;
											expensesCell.DetailTextLabel.AdjustsLetterSpacingToFitWidth = true;

											tableView.SectionIndexBackgroundColor = UIColor.Gray;
											tableView.SectionIndexColor = UIColor.Black;
											return expensesCell;

											break;
										case 5:
											expensesCell.AccessoryView = textExpenses;

											textExpenses.Text = symbolCurrency_2 + this.salesTradesIncome[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.salesTradesName[indexPath.Row];
											expensesCell.DetailTextLabel.TextColor = UIColor.Gray;
											expensesCell.DetailTextLabel.MinimumFontSize = 14.0f;


											expensesCell.DetailTextLabel.AdjustsFontSizeToFitWidth = true;
											expensesCell.DetailTextLabel.AdjustsLetterSpacingToFitWidth = true;

											tableView.SectionIndexBackgroundColor = UIColor.Gray;
											tableView.SectionIndexColor = UIColor.Black;
											return expensesCell;

											break;

										case 6:
											expensesCell.AccessoryView = textExpenses;

											textExpenses.Text = symbolCurrency_2 + this.intellectualPropertyIncome[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.intellectualPropertyName[indexPath.Row];
											expensesCell.DetailTextLabel.TextColor = UIColor.Gray;
											expensesCell.DetailTextLabel.MinimumFontSize = 14.0f;


											expensesCell.DetailTextLabel.AdjustsFontSizeToFitWidth = true;
											expensesCell.DetailTextLabel.AdjustsLetterSpacingToFitWidth = true;

											tableView.SectionIndexBackgroundColor = UIColor.Gray;
											tableView.SectionIndexColor = UIColor.Black;
											return expensesCell;

											break;

										case 7:
											expensesCell.AccessoryView = textExpenses;

											textExpenses.Text = symbolCurrency_2 + this.appRoyaltiesIncome[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.appRoyaltiesName[indexPath.Row];
											expensesCell.DetailTextLabel.TextColor = UIColor.Gray;
											expensesCell.DetailTextLabel.MinimumFontSize = 14.0f;


											expensesCell.DetailTextLabel.AdjustsFontSizeToFitWidth = true;
											expensesCell.DetailTextLabel.AdjustsLetterSpacingToFitWidth = true;

											tableView.SectionIndexBackgroundColor = UIColor.Gray;
											tableView.SectionIndexColor = UIColor.Black;
											return expensesCell;

											break;

										case 8:

											expensesCell.AccessoryView = textExpenses;

											textExpenses.Text = symbolCurrency_2 + this.bookPublishingIncome[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.bookPublishingName[indexPath.Row];
											expensesCell.DetailTextLabel.TextColor = UIColor.Gray;
											expensesCell.DetailTextLabel.MinimumFontSize = 14.0f;

											expensesCell.DetailTextLabel.AdjustsFontSizeToFitWidth = true;
											expensesCell.DetailTextLabel.AdjustsLetterSpacingToFitWidth = true;

											tableView.SectionIndexBackgroundColor = UIColor.Gray;
											tableView.SectionIndexColor = UIColor.Black;
											return expensesCell;

											break;

										case 9:
											expensesCell.AccessoryView = textExpenses;

											textExpenses.Text = symbolCurrency_2 + this.tradeDividendsIncome[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.tradeDividendsName[indexPath.Row];
											expensesCell.DetailTextLabel.TextColor = UIColor.Gray;
											expensesCell.DetailTextLabel.MinimumFontSize = 14.0f;


											expensesCell.DetailTextLabel.AdjustsFontSizeToFitWidth = true;
											expensesCell.DetailTextLabel.AdjustsLetterSpacingToFitWidth = true;

											tableView.SectionIndexBackgroundColor = UIColor.Gray;
											tableView.SectionIndexColor = UIColor.Black;
											return expensesCell;

											break;

										case 10:
											expensesCell.AccessoryView = textExpenses;

											textExpenses.Text = symbolCurrency_2 + this.bankInterestIncome[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.bankInterestName[indexPath.Row];
											expensesCell.DetailTextLabel.TextColor = UIColor.Gray;
											expensesCell.DetailTextLabel.MinimumFontSize = 14.0f;

											expensesCell.DetailTextLabel.AdjustsFontSizeToFitWidth = true;
											expensesCell.DetailTextLabel.AdjustsLetterSpacingToFitWidth = true;

											tableView.SectionIndexBackgroundColor = UIColor.Gray;
											tableView.SectionIndexColor = UIColor.Black;
											return expensesCell;

											break;

										case 11:

											expensesCell.AccessoryView = textExpenses;

											textExpenses.Text = symbolCurrency_2 + this.taxReturnIncome[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.taxReturnName[indexPath.Row];
											expensesCell.DetailTextLabel.TextColor = UIColor.Gray;
											expensesCell.DetailTextLabel.MinimumFontSize = 14.0f;

											expensesCell.DetailTextLabel.AdjustsFontSizeToFitWidth = true;
											expensesCell.DetailTextLabel.AdjustsLetterSpacingToFitWidth = true;

											tableView.SectionIndexBackgroundColor = UIColor.Gray;
											tableView.SectionIndexColor = UIColor.Black;
											return expensesCell;

											break;

										case 12:

											expensesCell.AccessoryView = textExpenses;

											textExpenses.Text = symbolCurrency_2 + this.studentLoadIncome[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.studentLoadName[indexPath.Row];
											expensesCell.DetailTextLabel.TextColor = UIColor.Gray;
											expensesCell.DetailTextLabel.MinimumFontSize = 14.0f;

											expensesCell.DetailTextLabel.AdjustsFontSizeToFitWidth = true;
											expensesCell.DetailTextLabel.AdjustsLetterSpacingToFitWidth = true;

											tableView.SectionIndexBackgroundColor = UIColor.Gray;
											tableView.SectionIndexColor = UIColor.Black;
											return expensesCell;

											break;

										case 13:

											expensesCell.AccessoryView = textExpenses;

											textExpenses.Text = symbolCurrency_2 + this.inheritanceIncome[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.inheritanceName[indexPath.Row];
											expensesCell.DetailTextLabel.TextColor = UIColor.Gray;
											expensesCell.DetailTextLabel.MinimumFontSize = 14.0f;

											expensesCell.DetailTextLabel.AdjustsFontSizeToFitWidth = true;
											expensesCell.DetailTextLabel.AdjustsLetterSpacingToFitWidth = true;

											tableView.SectionIndexBackgroundColor = UIColor.Gray;
											tableView.SectionIndexColor = UIColor.Black;
											return expensesCell;

											break;

										case 14:

											expensesCell.AccessoryView = textExpenses;

											textExpenses.Text = symbolCurrency_2 + this.prizeIncome[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.prizeName[indexPath.Row];
											expensesCell.DetailTextLabel.TextColor = UIColor.Gray;
											expensesCell.DetailTextLabel.MinimumFontSize = 14.0f;

											expensesCell.DetailTextLabel.AdjustsFontSizeToFitWidth = true;
											expensesCell.DetailTextLabel.AdjustsLetterSpacingToFitWidth = true;

											tableView.SectionIndexBackgroundColor = UIColor.Gray;
											tableView.SectionIndexColor = UIColor.Black;
											return expensesCell;

											break;

										case 15:

											expensesCell.AccessoryView = textExpenses;

											textExpenses.Text = symbolCurrency_2 + this.otherIncome[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.otherIncomeName[indexPath.Row];
											expensesCell.DetailTextLabel.TextColor = UIColor.Gray;
											expensesCell.DetailTextLabel.MinimumFontSize = 14.0f;

											expensesCell.DetailTextLabel.AdjustsFontSizeToFitWidth = true;
											expensesCell.DetailTextLabel.AdjustsLetterSpacingToFitWidth = true;

											tableView.SectionIndexBackgroundColor = UIColor.Gray;
											tableView.SectionIndexColor = UIColor.Black;
											return expensesCell;

											break;
									}
									break;
								case UIDeviceOrientation.PortraitUpsideDown:
									//expensesCell.TextLabel.Text = "Category: " + this.categoryChosen[indexPath.Row];
									//expensesCell.TextLabel.TextColor = UIColor.Black;

									switch (indexPath.Section)
									{
										case 0:

											expensesCell.AccessoryView = textExpenses;

											textExpenses.Text = symbolCurrency_2 + this.wagesIncome[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.wagesName[indexPath.Row];
											expensesCell.DetailTextLabel.TextColor = UIColor.Gray;
											expensesCell.DetailTextLabel.MinimumFontSize = 14.0f;

											expensesCell.DetailTextLabel.AdjustsFontSizeToFitWidth = true;
											expensesCell.DetailTextLabel.AdjustsLetterSpacingToFitWidth = true;

											tableView.SectionIndexBackgroundColor = UIColor.Gray;
											tableView.SectionIndexColor = UIColor.Black;
											return expensesCell;
											break;

										case 1:
											expensesCell.AccessoryView = textExpenses;

											textExpenses.Text = symbolCurrency_2 + this.realestateIncome[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.realestateName[indexPath.Row];
											expensesCell.DetailTextLabel.TextColor = UIColor.Gray;
											expensesCell.DetailTextLabel.MinimumFontSize = 14.0f;


											expensesCell.DetailTextLabel.AdjustsFontSizeToFitWidth = true;
											expensesCell.DetailTextLabel.AdjustsLetterSpacingToFitWidth = true;

											tableView.SectionIndexBackgroundColor = UIColor.Gray;
											tableView.SectionIndexColor = UIColor.Black;
											return expensesCell;

											break;

										case 2:
											expensesCell.AccessoryView = textExpenses;

											textExpenses.Text = symbolCurrency_2 + this.salesHouseIncome[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.salesHouseName[indexPath.Row];
											expensesCell.DetailTextLabel.TextColor = UIColor.Gray;
											expensesCell.DetailTextLabel.MinimumFontSize = 14.0f;


											expensesCell.DetailTextLabel.AdjustsFontSizeToFitWidth = true;
											expensesCell.DetailTextLabel.AdjustsLetterSpacingToFitWidth = true;

											tableView.SectionIndexBackgroundColor = UIColor.Gray;
											tableView.SectionIndexColor = UIColor.Black;
											return expensesCell;

											break;

										case 3:
											expensesCell.AccessoryView = textExpenses;

											textExpenses.Text = symbolCurrency_2 + this.smallBusinessIncome[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.smallBusinessName[indexPath.Row];
											expensesCell.DetailTextLabel.TextColor = UIColor.Gray;
											expensesCell.DetailTextLabel.MinimumFontSize = 14.0f;


											expensesCell.DetailTextLabel.AdjustsFontSizeToFitWidth = true;
											expensesCell.DetailTextLabel.AdjustsLetterSpacingToFitWidth = true;

											tableView.SectionIndexBackgroundColor = UIColor.Gray;
											tableView.SectionIndexColor = UIColor.Black;
											return expensesCell;

											break;

										case 4:

											expensesCell.AccessoryView = textExpenses;

											textExpenses.Text = symbolCurrency_2 + this.gamblingIncome[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.gamblingName[indexPath.Row];
											expensesCell.DetailTextLabel.TextColor = UIColor.Gray;
											expensesCell.DetailTextLabel.MinimumFontSize = 14.0f;


											expensesCell.DetailTextLabel.AdjustsFontSizeToFitWidth = true;
											expensesCell.DetailTextLabel.AdjustsLetterSpacingToFitWidth = true;

											tableView.SectionIndexBackgroundColor = UIColor.Gray;
											tableView.SectionIndexColor = UIColor.Black;
											return expensesCell;

											break;
										case 5:
											expensesCell.AccessoryView = textExpenses;

											textExpenses.Text = symbolCurrency_2 + this.salesTradesIncome[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.salesTradesName[indexPath.Row];
											expensesCell.DetailTextLabel.TextColor = UIColor.Gray;
											expensesCell.DetailTextLabel.MinimumFontSize = 14.0f;


											expensesCell.DetailTextLabel.AdjustsFontSizeToFitWidth = true;
											expensesCell.DetailTextLabel.AdjustsLetterSpacingToFitWidth = true;

											tableView.SectionIndexBackgroundColor = UIColor.Gray;
											tableView.SectionIndexColor = UIColor.Black;
											return expensesCell;

											break;

										case 6:
											expensesCell.AccessoryView = textExpenses;

											textExpenses.Text = symbolCurrency_2 + this.intellectualPropertyIncome[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.intellectualPropertyName[indexPath.Row];
											expensesCell.DetailTextLabel.TextColor = UIColor.Gray;
											expensesCell.DetailTextLabel.MinimumFontSize = 14.0f;


											expensesCell.DetailTextLabel.AdjustsFontSizeToFitWidth = true;
											expensesCell.DetailTextLabel.AdjustsLetterSpacingToFitWidth = true;

											tableView.SectionIndexBackgroundColor = UIColor.Gray;
											tableView.SectionIndexColor = UIColor.Black;
											return expensesCell;

											break;

										case 7:
											expensesCell.AccessoryView = textExpenses;

											textExpenses.Text = symbolCurrency_2 + this.appRoyaltiesIncome[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.appRoyaltiesName[indexPath.Row];
											expensesCell.DetailTextLabel.TextColor = UIColor.Gray;
											expensesCell.DetailTextLabel.MinimumFontSize = 14.0f;


											expensesCell.DetailTextLabel.AdjustsFontSizeToFitWidth = true;
											expensesCell.DetailTextLabel.AdjustsLetterSpacingToFitWidth = true;

											tableView.SectionIndexBackgroundColor = UIColor.Gray;
											tableView.SectionIndexColor = UIColor.Black;
											return expensesCell;

											break;

										case 8:

											expensesCell.AccessoryView = textExpenses;

											textExpenses.Text = symbolCurrency_2 + this.bookPublishingIncome[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.bookPublishingName[indexPath.Row];
											expensesCell.DetailTextLabel.TextColor = UIColor.Gray;
											expensesCell.DetailTextLabel.MinimumFontSize = 14.0f;

											expensesCell.DetailTextLabel.AdjustsFontSizeToFitWidth = true;
											expensesCell.DetailTextLabel.AdjustsLetterSpacingToFitWidth = true;

											tableView.SectionIndexBackgroundColor = UIColor.Gray;
											tableView.SectionIndexColor = UIColor.Black;
											return expensesCell;

											break;

										case 9:
											expensesCell.AccessoryView = textExpenses;

											textExpenses.Text = symbolCurrency_2 + this.tradeDividendsIncome[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.tradeDividendsName[indexPath.Row];
											expensesCell.DetailTextLabel.TextColor = UIColor.Gray;
											expensesCell.DetailTextLabel.MinimumFontSize = 14.0f;


											expensesCell.DetailTextLabel.AdjustsFontSizeToFitWidth = true;
											expensesCell.DetailTextLabel.AdjustsLetterSpacingToFitWidth = true;

											tableView.SectionIndexBackgroundColor = UIColor.Gray;
											tableView.SectionIndexColor = UIColor.Black;
											return expensesCell;

											break;

										case 10:
											expensesCell.AccessoryView = textExpenses;

											textExpenses.Text = symbolCurrency_2 + this.bankInterestIncome[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.bankInterestName[indexPath.Row];
											expensesCell.DetailTextLabel.TextColor = UIColor.Gray;
											expensesCell.DetailTextLabel.MinimumFontSize = 14.0f;

											expensesCell.DetailTextLabel.AdjustsFontSizeToFitWidth = true;
											expensesCell.DetailTextLabel.AdjustsLetterSpacingToFitWidth = true;

											tableView.SectionIndexBackgroundColor = UIColor.Gray;
											tableView.SectionIndexColor = UIColor.Black;
											return expensesCell;

											break;

										case 11:

											expensesCell.AccessoryView = textExpenses;

											textExpenses.Text = symbolCurrency_2 + this.taxReturnIncome[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.taxReturnName[indexPath.Row];
											expensesCell.DetailTextLabel.TextColor = UIColor.Gray;
											expensesCell.DetailTextLabel.MinimumFontSize = 14.0f;

											expensesCell.DetailTextLabel.AdjustsFontSizeToFitWidth = true;
											expensesCell.DetailTextLabel.AdjustsLetterSpacingToFitWidth = true;

											tableView.SectionIndexBackgroundColor = UIColor.Gray;
											tableView.SectionIndexColor = UIColor.Black;
											return expensesCell;

											break;

										case 12:

											expensesCell.AccessoryView = textExpenses;

											textExpenses.Text = symbolCurrency_2 + this.studentLoadIncome[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.studentLoadName[indexPath.Row];
											expensesCell.DetailTextLabel.TextColor = UIColor.Gray;
											expensesCell.DetailTextLabel.MinimumFontSize = 14.0f;

											expensesCell.DetailTextLabel.AdjustsFontSizeToFitWidth = true;
											expensesCell.DetailTextLabel.AdjustsLetterSpacingToFitWidth = true;

											tableView.SectionIndexBackgroundColor = UIColor.Gray;
											tableView.SectionIndexColor = UIColor.Black;
											return expensesCell;

											break;

										case 13:

											expensesCell.AccessoryView = textExpenses;

											textExpenses.Text = symbolCurrency_2 + this.inheritanceIncome[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.inheritanceName[indexPath.Row];
											expensesCell.DetailTextLabel.TextColor = UIColor.Gray;
											expensesCell.DetailTextLabel.MinimumFontSize = 14.0f;

											expensesCell.DetailTextLabel.AdjustsFontSizeToFitWidth = true;
											expensesCell.DetailTextLabel.AdjustsLetterSpacingToFitWidth = true;

											tableView.SectionIndexBackgroundColor = UIColor.Gray;
											tableView.SectionIndexColor = UIColor.Black;
											return expensesCell;

											break;

										case 14:

											expensesCell.AccessoryView = textExpenses;

											textExpenses.Text = symbolCurrency_2 + this.prizeIncome[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.prizeName[indexPath.Row];
											expensesCell.DetailTextLabel.TextColor = UIColor.Gray;
											expensesCell.DetailTextLabel.MinimumFontSize = 14.0f;

											expensesCell.DetailTextLabel.AdjustsFontSizeToFitWidth = true;
											expensesCell.DetailTextLabel.AdjustsLetterSpacingToFitWidth = true;

											tableView.SectionIndexBackgroundColor = UIColor.Gray;
											tableView.SectionIndexColor = UIColor.Black;
											return expensesCell;

											break;

										case 15:

											expensesCell.AccessoryView = textExpenses;

											textExpenses.Text = symbolCurrency_2 + this.otherIncome[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.otherIncomeName[indexPath.Row];
											expensesCell.DetailTextLabel.TextColor = UIColor.Gray;
											expensesCell.DetailTextLabel.MinimumFontSize = 14.0f;

											expensesCell.DetailTextLabel.AdjustsFontSizeToFitWidth = true;
											expensesCell.DetailTextLabel.AdjustsLetterSpacingToFitWidth = true;

											tableView.SectionIndexBackgroundColor = UIColor.Gray;
											tableView.SectionIndexColor = UIColor.Black;
											return expensesCell;

											break;
									}
									break;

								case UIDeviceOrientation.FaceUp:
									//expensesCell.TextLabel.Text = "Category: " + this.categoryChosen[indexPath.Row];
									//expensesCell.TextLabel.TextColor = UIColor.Black;

									switch (indexPath.Section)
									{
										case 0:

											expensesCell.AccessoryView = textExpenses;

											textExpenses.Text = symbolCurrency_2 + this.wagesIncome[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.wagesName[indexPath.Row];
											expensesCell.DetailTextLabel.TextColor = UIColor.Gray;
											expensesCell.DetailTextLabel.MinimumFontSize = 14.0f;

											expensesCell.DetailTextLabel.AdjustsFontSizeToFitWidth = true;
											expensesCell.DetailTextLabel.AdjustsLetterSpacingToFitWidth = true;

											tableView.SectionIndexBackgroundColor = UIColor.Gray;
											tableView.SectionIndexColor = UIColor.Black;
											return expensesCell;
											break;

										case 1:
											expensesCell.AccessoryView = textExpenses;

											textExpenses.Text = symbolCurrency_2 + this.realestateIncome[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.realestateName[indexPath.Row];
											expensesCell.DetailTextLabel.TextColor = UIColor.Gray;
											expensesCell.DetailTextLabel.MinimumFontSize = 14.0f;


											expensesCell.DetailTextLabel.AdjustsFontSizeToFitWidth = true;
											expensesCell.DetailTextLabel.AdjustsLetterSpacingToFitWidth = true;

											tableView.SectionIndexBackgroundColor = UIColor.Gray;
											tableView.SectionIndexColor = UIColor.Black;
											return expensesCell;

											break;

										case 2:
											expensesCell.AccessoryView = textExpenses;

											textExpenses.Text = symbolCurrency_2 + this.salesHouseIncome[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.salesHouseName[indexPath.Row];
											expensesCell.DetailTextLabel.TextColor = UIColor.Gray;
											expensesCell.DetailTextLabel.MinimumFontSize = 14.0f;


											expensesCell.DetailTextLabel.AdjustsFontSizeToFitWidth = true;
											expensesCell.DetailTextLabel.AdjustsLetterSpacingToFitWidth = true;

											tableView.SectionIndexBackgroundColor = UIColor.Gray;
											tableView.SectionIndexColor = UIColor.Black;
											return expensesCell;

											break;

										case 3:
											expensesCell.AccessoryView = textExpenses;

											textExpenses.Text = symbolCurrency_2 + this.smallBusinessIncome[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.smallBusinessName[indexPath.Row];
											expensesCell.DetailTextLabel.TextColor = UIColor.Gray;
											expensesCell.DetailTextLabel.MinimumFontSize = 14.0f;


											expensesCell.DetailTextLabel.AdjustsFontSizeToFitWidth = true;
											expensesCell.DetailTextLabel.AdjustsLetterSpacingToFitWidth = true;

											tableView.SectionIndexBackgroundColor = UIColor.Gray;
											tableView.SectionIndexColor = UIColor.Black;
											return expensesCell;

											break;

										case 4:

											expensesCell.AccessoryView = textExpenses;

											textExpenses.Text = symbolCurrency_2 + this.gamblingIncome[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.gamblingName[indexPath.Row];
											expensesCell.DetailTextLabel.TextColor = UIColor.Gray;
											expensesCell.DetailTextLabel.MinimumFontSize = 14.0f;


											expensesCell.DetailTextLabel.AdjustsFontSizeToFitWidth = true;
											expensesCell.DetailTextLabel.AdjustsLetterSpacingToFitWidth = true;

											tableView.SectionIndexBackgroundColor = UIColor.Gray;
											tableView.SectionIndexColor = UIColor.Black;
											return expensesCell;

											break;
										case 5:
											expensesCell.AccessoryView = textExpenses;

											textExpenses.Text = symbolCurrency_2 + this.salesTradesIncome[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.salesTradesName[indexPath.Row];
											expensesCell.DetailTextLabel.TextColor = UIColor.Gray;
											expensesCell.DetailTextLabel.MinimumFontSize = 14.0f;


											expensesCell.DetailTextLabel.AdjustsFontSizeToFitWidth = true;
											expensesCell.DetailTextLabel.AdjustsLetterSpacingToFitWidth = true;

											tableView.SectionIndexBackgroundColor = UIColor.Gray;
											tableView.SectionIndexColor = UIColor.Black;
											return expensesCell;

											break;

										case 6:
											expensesCell.AccessoryView = textExpenses;

											textExpenses.Text = symbolCurrency_2 + this.intellectualPropertyIncome[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.intellectualPropertyName[indexPath.Row];
											expensesCell.DetailTextLabel.TextColor = UIColor.Gray;
											expensesCell.DetailTextLabel.MinimumFontSize = 14.0f;


											expensesCell.DetailTextLabel.AdjustsFontSizeToFitWidth = true;
											expensesCell.DetailTextLabel.AdjustsLetterSpacingToFitWidth = true;

											tableView.SectionIndexBackgroundColor = UIColor.Gray;
											tableView.SectionIndexColor = UIColor.Black;
											return expensesCell;

											break;

										case 7:
											expensesCell.AccessoryView = textExpenses;

											textExpenses.Text = symbolCurrency_2 + this.appRoyaltiesIncome[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.appRoyaltiesName[indexPath.Row];
											expensesCell.DetailTextLabel.TextColor = UIColor.Gray;
											expensesCell.DetailTextLabel.MinimumFontSize = 14.0f;


											expensesCell.DetailTextLabel.AdjustsFontSizeToFitWidth = true;
											expensesCell.DetailTextLabel.AdjustsLetterSpacingToFitWidth = true;

											tableView.SectionIndexBackgroundColor = UIColor.Gray;
											tableView.SectionIndexColor = UIColor.Black;
											return expensesCell;

											break;

										case 8:

											expensesCell.AccessoryView = textExpenses;

											textExpenses.Text = symbolCurrency_2 + this.bookPublishingIncome[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.bookPublishingName[indexPath.Row];
											expensesCell.DetailTextLabel.TextColor = UIColor.Gray;
											expensesCell.DetailTextLabel.MinimumFontSize = 14.0f;

											expensesCell.DetailTextLabel.AdjustsFontSizeToFitWidth = true;
											expensesCell.DetailTextLabel.AdjustsLetterSpacingToFitWidth = true;

											tableView.SectionIndexBackgroundColor = UIColor.Gray;
											tableView.SectionIndexColor = UIColor.Black;
											return expensesCell;

											break;

										case 9:
											expensesCell.AccessoryView = textExpenses;

											textExpenses.Text = symbolCurrency_2 + this.tradeDividendsIncome[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.tradeDividendsName[indexPath.Row];
											expensesCell.DetailTextLabel.TextColor = UIColor.Gray;
											expensesCell.DetailTextLabel.MinimumFontSize = 14.0f;


											expensesCell.DetailTextLabel.AdjustsFontSizeToFitWidth = true;
											expensesCell.DetailTextLabel.AdjustsLetterSpacingToFitWidth = true;

											tableView.SectionIndexBackgroundColor = UIColor.Gray;
											tableView.SectionIndexColor = UIColor.Black;
											return expensesCell;

											break;

										case 10:
											expensesCell.AccessoryView = textExpenses;

											textExpenses.Text = symbolCurrency_2 + this.bankInterestIncome[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.bankInterestName[indexPath.Row];
											expensesCell.DetailTextLabel.TextColor = UIColor.Gray;
											expensesCell.DetailTextLabel.MinimumFontSize = 14.0f;

											expensesCell.DetailTextLabel.AdjustsFontSizeToFitWidth = true;
											expensesCell.DetailTextLabel.AdjustsLetterSpacingToFitWidth = true;

											tableView.SectionIndexBackgroundColor = UIColor.Gray;
											tableView.SectionIndexColor = UIColor.Black;
											return expensesCell;

											break;

										case 11:

											expensesCell.AccessoryView = textExpenses;

											textExpenses.Text = symbolCurrency_2 + this.taxReturnIncome[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.taxReturnName[indexPath.Row];
											expensesCell.DetailTextLabel.TextColor = UIColor.Gray;
											expensesCell.DetailTextLabel.MinimumFontSize = 14.0f;

											expensesCell.DetailTextLabel.AdjustsFontSizeToFitWidth = true;
											expensesCell.DetailTextLabel.AdjustsLetterSpacingToFitWidth = true;

											tableView.SectionIndexBackgroundColor = UIColor.Gray;
											tableView.SectionIndexColor = UIColor.Black;
											return expensesCell;

											break;

										case 12:

											expensesCell.AccessoryView = textExpenses;

											textExpenses.Text = symbolCurrency_2 + this.studentLoadIncome[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.studentLoadName[indexPath.Row];
											expensesCell.DetailTextLabel.TextColor = UIColor.Gray;
											expensesCell.DetailTextLabel.MinimumFontSize = 14.0f;

											expensesCell.DetailTextLabel.AdjustsFontSizeToFitWidth = true;
											expensesCell.DetailTextLabel.AdjustsLetterSpacingToFitWidth = true;

											tableView.SectionIndexBackgroundColor = UIColor.Gray;
											tableView.SectionIndexColor = UIColor.Black;
											return expensesCell;

											break;

										case 13:

											expensesCell.AccessoryView = textExpenses;

											textExpenses.Text = symbolCurrency_2 + this.inheritanceIncome[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.inheritanceName[indexPath.Row];
											expensesCell.DetailTextLabel.TextColor = UIColor.Gray;
											expensesCell.DetailTextLabel.MinimumFontSize = 14.0f;

											expensesCell.DetailTextLabel.AdjustsFontSizeToFitWidth = true;
											expensesCell.DetailTextLabel.AdjustsLetterSpacingToFitWidth = true;

											tableView.SectionIndexBackgroundColor = UIColor.Gray;
											tableView.SectionIndexColor = UIColor.Black;
											return expensesCell;

											break;

										case 14:

											expensesCell.AccessoryView = textExpenses;

											textExpenses.Text = symbolCurrency_2 + this.prizeIncome[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.prizeName[indexPath.Row];
											expensesCell.DetailTextLabel.TextColor = UIColor.Gray;
											expensesCell.DetailTextLabel.MinimumFontSize = 14.0f;

											expensesCell.DetailTextLabel.AdjustsFontSizeToFitWidth = true;
											expensesCell.DetailTextLabel.AdjustsLetterSpacingToFitWidth = true;

											tableView.SectionIndexBackgroundColor = UIColor.Gray;
											tableView.SectionIndexColor = UIColor.Black;
											return expensesCell;

											break;

										case 15:

											expensesCell.AccessoryView = textExpenses;

											textExpenses.Text = symbolCurrency_2 + this.otherIncome[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.otherIncomeName[indexPath.Row];
											expensesCell.DetailTextLabel.TextColor = UIColor.Gray;
											expensesCell.DetailTextLabel.MinimumFontSize = 14.0f;

											expensesCell.DetailTextLabel.AdjustsFontSizeToFitWidth = true;
											expensesCell.DetailTextLabel.AdjustsLetterSpacingToFitWidth = true;

											tableView.SectionIndexBackgroundColor = UIColor.Gray;
											tableView.SectionIndexColor = UIColor.Black;
											return expensesCell;

											break;
									}
									break;

								case UIDeviceOrientation.FaceDown:
									//expensesCell.TextLabel.Text = "Category: " + this.categoryChosen[indexPath.Row];
									//expensesCell.TextLabel.TextColor = UIColor.Black;

									switch (indexPath.Section)
									{
										case 0:

											expensesCell.AccessoryView = textExpenses;

											textExpenses.Text = symbolCurrency_2 + this.wagesIncome[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.wagesName[indexPath.Row];
											expensesCell.DetailTextLabel.TextColor = UIColor.Gray;
											expensesCell.DetailTextLabel.MinimumFontSize = 14.0f;

											expensesCell.DetailTextLabel.AdjustsFontSizeToFitWidth = true;
											expensesCell.DetailTextLabel.AdjustsLetterSpacingToFitWidth = true;

											tableView.SectionIndexBackgroundColor = UIColor.Gray;
											tableView.SectionIndexColor = UIColor.Black;
											return expensesCell;
											break;

										case 1:
											expensesCell.AccessoryView = textExpenses;

											textExpenses.Text = symbolCurrency_2 + this.realestateIncome[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.realestateName[indexPath.Row];
											expensesCell.DetailTextLabel.TextColor = UIColor.Gray;
											expensesCell.DetailTextLabel.MinimumFontSize = 14.0f;


											expensesCell.DetailTextLabel.AdjustsFontSizeToFitWidth = true;
											expensesCell.DetailTextLabel.AdjustsLetterSpacingToFitWidth = true;

											tableView.SectionIndexBackgroundColor = UIColor.Gray;
											tableView.SectionIndexColor = UIColor.Black;
											return expensesCell;

											break;

										case 2:
											expensesCell.AccessoryView = textExpenses;

											textExpenses.Text = symbolCurrency_2 + this.salesHouseIncome[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.salesHouseName[indexPath.Row];
											expensesCell.DetailTextLabel.TextColor = UIColor.Gray;
											expensesCell.DetailTextLabel.MinimumFontSize = 14.0f;


											expensesCell.DetailTextLabel.AdjustsFontSizeToFitWidth = true;
											expensesCell.DetailTextLabel.AdjustsLetterSpacingToFitWidth = true;

											tableView.SectionIndexBackgroundColor = UIColor.Gray;
											tableView.SectionIndexColor = UIColor.Black;
											return expensesCell;

											break;

										case 3:
											expensesCell.AccessoryView = textExpenses;

											textExpenses.Text = symbolCurrency_2 + this.smallBusinessIncome[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.smallBusinessName[indexPath.Row];
											expensesCell.DetailTextLabel.TextColor = UIColor.Gray;
											expensesCell.DetailTextLabel.MinimumFontSize = 14.0f;


											expensesCell.DetailTextLabel.AdjustsFontSizeToFitWidth = true;
											expensesCell.DetailTextLabel.AdjustsLetterSpacingToFitWidth = true;

											tableView.SectionIndexBackgroundColor = UIColor.Gray;
											tableView.SectionIndexColor = UIColor.Black;
											return expensesCell;

											break;

										case 4:

											expensesCell.AccessoryView = textExpenses;

											textExpenses.Text = symbolCurrency_2 + this.gamblingIncome[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.gamblingName[indexPath.Row];
											expensesCell.DetailTextLabel.TextColor = UIColor.Gray;
											expensesCell.DetailTextLabel.MinimumFontSize = 14.0f;


											expensesCell.DetailTextLabel.AdjustsFontSizeToFitWidth = true;
											expensesCell.DetailTextLabel.AdjustsLetterSpacingToFitWidth = true;

											tableView.SectionIndexBackgroundColor = UIColor.Gray;
											tableView.SectionIndexColor = UIColor.Black;
											return expensesCell;

											break;
										case 5:
											expensesCell.AccessoryView = textExpenses;

											textExpenses.Text = symbolCurrency_2 + this.salesTradesIncome[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.salesTradesName[indexPath.Row];
											expensesCell.DetailTextLabel.TextColor = UIColor.Gray;
											expensesCell.DetailTextLabel.MinimumFontSize = 14.0f;


											expensesCell.DetailTextLabel.AdjustsFontSizeToFitWidth = true;
											expensesCell.DetailTextLabel.AdjustsLetterSpacingToFitWidth = true;

											tableView.SectionIndexBackgroundColor = UIColor.Gray;
											tableView.SectionIndexColor = UIColor.Black;
											return expensesCell;

											break;

										case 6:
											expensesCell.AccessoryView = textExpenses;

											textExpenses.Text = symbolCurrency_2 + this.intellectualPropertyIncome[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.intellectualPropertyName[indexPath.Row];
											expensesCell.DetailTextLabel.TextColor = UIColor.Gray;
											expensesCell.DetailTextLabel.MinimumFontSize = 14.0f;


											expensesCell.DetailTextLabel.AdjustsFontSizeToFitWidth = true;
											expensesCell.DetailTextLabel.AdjustsLetterSpacingToFitWidth = true;

											tableView.SectionIndexBackgroundColor = UIColor.Gray;
											tableView.SectionIndexColor = UIColor.Black;
											return expensesCell;

											break;

										case 7:
											expensesCell.AccessoryView = textExpenses;

											textExpenses.Text = symbolCurrency_2 + this.appRoyaltiesIncome[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.appRoyaltiesName[indexPath.Row];
											expensesCell.DetailTextLabel.TextColor = UIColor.Gray;
											expensesCell.DetailTextLabel.MinimumFontSize = 14.0f;


											expensesCell.DetailTextLabel.AdjustsFontSizeToFitWidth = true;
											expensesCell.DetailTextLabel.AdjustsLetterSpacingToFitWidth = true;

											tableView.SectionIndexBackgroundColor = UIColor.Gray;
											tableView.SectionIndexColor = UIColor.Black;
											return expensesCell;

											break;

										case 8:

											expensesCell.AccessoryView = textExpenses;

											textExpenses.Text = symbolCurrency_2 + this.bookPublishingIncome[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.bookPublishingName[indexPath.Row];
											expensesCell.DetailTextLabel.TextColor = UIColor.Gray;
											expensesCell.DetailTextLabel.MinimumFontSize = 14.0f;

											expensesCell.DetailTextLabel.AdjustsFontSizeToFitWidth = true;
											expensesCell.DetailTextLabel.AdjustsLetterSpacingToFitWidth = true;

											tableView.SectionIndexBackgroundColor = UIColor.Gray;
											tableView.SectionIndexColor = UIColor.Black;
											return expensesCell;

											break;

										case 9:
											expensesCell.AccessoryView = textExpenses;

											textExpenses.Text = symbolCurrency_2 + this.tradeDividendsIncome[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.tradeDividendsName[indexPath.Row];
											expensesCell.DetailTextLabel.TextColor = UIColor.Gray;
											expensesCell.DetailTextLabel.MinimumFontSize = 14.0f;


											expensesCell.DetailTextLabel.AdjustsFontSizeToFitWidth = true;
											expensesCell.DetailTextLabel.AdjustsLetterSpacingToFitWidth = true;

											tableView.SectionIndexBackgroundColor = UIColor.Gray;
											tableView.SectionIndexColor = UIColor.Black;
											return expensesCell;

											break;

										case 10:
											expensesCell.AccessoryView = textExpenses;

											textExpenses.Text = symbolCurrency_2 + this.bankInterestIncome[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.bankInterestName[indexPath.Row];
											expensesCell.DetailTextLabel.TextColor = UIColor.Gray;
											expensesCell.DetailTextLabel.MinimumFontSize = 14.0f;

											expensesCell.DetailTextLabel.AdjustsFontSizeToFitWidth = true;
											expensesCell.DetailTextLabel.AdjustsLetterSpacingToFitWidth = true;

											tableView.SectionIndexBackgroundColor = UIColor.Gray;
											tableView.SectionIndexColor = UIColor.Black;
											return expensesCell;

											break;

										case 11:

											expensesCell.AccessoryView = textExpenses;

											textExpenses.Text = symbolCurrency_2 + this.taxReturnIncome[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.taxReturnName[indexPath.Row];
											expensesCell.DetailTextLabel.TextColor = UIColor.Gray;
											expensesCell.DetailTextLabel.MinimumFontSize = 14.0f;

											expensesCell.DetailTextLabel.AdjustsFontSizeToFitWidth = true;
											expensesCell.DetailTextLabel.AdjustsLetterSpacingToFitWidth = true;

											tableView.SectionIndexBackgroundColor = UIColor.Gray;
											tableView.SectionIndexColor = UIColor.Black;
											return expensesCell;

											break;

										case 12:

											expensesCell.AccessoryView = textExpenses;

											textExpenses.Text = symbolCurrency_2 + this.studentLoadIncome[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.studentLoadName[indexPath.Row];
											expensesCell.DetailTextLabel.TextColor = UIColor.Gray;
											expensesCell.DetailTextLabel.MinimumFontSize = 14.0f;

											expensesCell.DetailTextLabel.AdjustsFontSizeToFitWidth = true;
											expensesCell.DetailTextLabel.AdjustsLetterSpacingToFitWidth = true;

											tableView.SectionIndexBackgroundColor = UIColor.Gray;
											tableView.SectionIndexColor = UIColor.Black;
											return expensesCell;

											break;

										case 13:

											expensesCell.AccessoryView = textExpenses;

											textExpenses.Text = symbolCurrency_2 + this.inheritanceIncome[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.inheritanceName[indexPath.Row];
											expensesCell.DetailTextLabel.TextColor = UIColor.Gray;
											expensesCell.DetailTextLabel.MinimumFontSize = 14.0f;

											expensesCell.DetailTextLabel.AdjustsFontSizeToFitWidth = true;
											expensesCell.DetailTextLabel.AdjustsLetterSpacingToFitWidth = true;

											tableView.SectionIndexBackgroundColor = UIColor.Gray;
											tableView.SectionIndexColor = UIColor.Black;
											return expensesCell;

											break;

										case 14:

											expensesCell.AccessoryView = textExpenses;

											textExpenses.Text = symbolCurrency_2 + this.prizeIncome[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.prizeName[indexPath.Row];
											expensesCell.DetailTextLabel.TextColor = UIColor.Gray;
											expensesCell.DetailTextLabel.MinimumFontSize = 14.0f;

											expensesCell.DetailTextLabel.AdjustsFontSizeToFitWidth = true;
											expensesCell.DetailTextLabel.AdjustsLetterSpacingToFitWidth = true;

											tableView.SectionIndexBackgroundColor = UIColor.Gray;
											tableView.SectionIndexColor = UIColor.Black;
											return expensesCell;

											break;

										case 15:

											expensesCell.AccessoryView = textExpenses;

											textExpenses.Text = symbolCurrency_2 + this.otherIncome[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.otherIncomeName[indexPath.Row];
											expensesCell.DetailTextLabel.TextColor = UIColor.Gray;
											expensesCell.DetailTextLabel.MinimumFontSize = 14.0f;

											expensesCell.DetailTextLabel.AdjustsFontSizeToFitWidth = true;
											expensesCell.DetailTextLabel.AdjustsLetterSpacingToFitWidth = true;

											tableView.SectionIndexBackgroundColor = UIColor.Gray;
											tableView.SectionIndexColor = UIColor.Black;
											return expensesCell;

											break;
									}
									break;

								default: //unknown orientation
										 //expensesCell.TextLabel.Text = "Category: " + this.categoryChosen[indexPath.Row];
										 //expensesCell.TextLabel.TextColor = UIColor.Black;

									switch (indexPath.Section)
									{
										case 0:

											expensesCell.AccessoryView = textExpenses;

											textExpenses.Text = symbolCurrency_2 + this.wagesIncome[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.wagesName[indexPath.Row];
											expensesCell.DetailTextLabel.TextColor = UIColor.Gray;
											expensesCell.DetailTextLabel.MinimumFontSize = 14.0f;

											expensesCell.DetailTextLabel.AdjustsFontSizeToFitWidth = true;
											expensesCell.DetailTextLabel.AdjustsLetterSpacingToFitWidth = true;

											tableView.SectionIndexBackgroundColor = UIColor.Gray;
											tableView.SectionIndexColor = UIColor.Black;
											return expensesCell;
											break;

										case 1:
											expensesCell.AccessoryView = textExpenses;

											textExpenses.Text = symbolCurrency_2 + this.realestateIncome[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.realestateName[indexPath.Row];
											expensesCell.DetailTextLabel.TextColor = UIColor.Gray;
											expensesCell.DetailTextLabel.MinimumFontSize = 14.0f;


											expensesCell.DetailTextLabel.AdjustsFontSizeToFitWidth = true;
											expensesCell.DetailTextLabel.AdjustsLetterSpacingToFitWidth = true;

											tableView.SectionIndexBackgroundColor = UIColor.Gray;
											tableView.SectionIndexColor = UIColor.Black;
											return expensesCell;

											break;

										case 2:
											expensesCell.AccessoryView = textExpenses;

											textExpenses.Text = symbolCurrency_2 + this.salesHouseIncome[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.salesHouseName[indexPath.Row];
											expensesCell.DetailTextLabel.TextColor = UIColor.Gray;
											expensesCell.DetailTextLabel.MinimumFontSize = 14.0f;


											expensesCell.DetailTextLabel.AdjustsFontSizeToFitWidth = true;
											expensesCell.DetailTextLabel.AdjustsLetterSpacingToFitWidth = true;

											tableView.SectionIndexBackgroundColor = UIColor.Gray;
											tableView.SectionIndexColor = UIColor.Black;
											return expensesCell;

											break;

										case 3:
											expensesCell.AccessoryView = textExpenses;

											textExpenses.Text = symbolCurrency_2 + this.smallBusinessIncome[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.smallBusinessName[indexPath.Row];
											expensesCell.DetailTextLabel.TextColor = UIColor.Gray;
											expensesCell.DetailTextLabel.MinimumFontSize = 14.0f;


											expensesCell.DetailTextLabel.AdjustsFontSizeToFitWidth = true;
											expensesCell.DetailTextLabel.AdjustsLetterSpacingToFitWidth = true;

											tableView.SectionIndexBackgroundColor = UIColor.Gray;
											tableView.SectionIndexColor = UIColor.Black;
											return expensesCell;

											break;

										case 4:

											expensesCell.AccessoryView = textExpenses;

											textExpenses.Text = symbolCurrency_2 + this.gamblingIncome[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.gamblingName[indexPath.Row];
											expensesCell.DetailTextLabel.TextColor = UIColor.Gray;
											expensesCell.DetailTextLabel.MinimumFontSize = 14.0f;


											expensesCell.DetailTextLabel.AdjustsFontSizeToFitWidth = true;
											expensesCell.DetailTextLabel.AdjustsLetterSpacingToFitWidth = true;

											tableView.SectionIndexBackgroundColor = UIColor.Gray;
											tableView.SectionIndexColor = UIColor.Black;
											return expensesCell;

											break;
										case 5:
											expensesCell.AccessoryView = textExpenses;

											textExpenses.Text = symbolCurrency_2 + this.salesTradesIncome[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.salesTradesName[indexPath.Row];
											expensesCell.DetailTextLabel.TextColor = UIColor.Gray;
											expensesCell.DetailTextLabel.MinimumFontSize = 14.0f;


											expensesCell.DetailTextLabel.AdjustsFontSizeToFitWidth = true;
											expensesCell.DetailTextLabel.AdjustsLetterSpacingToFitWidth = true;

											tableView.SectionIndexBackgroundColor = UIColor.Gray;
											tableView.SectionIndexColor = UIColor.Black;
											return expensesCell;

											break;

										case 6:
											expensesCell.AccessoryView = textExpenses;

											textExpenses.Text = symbolCurrency_2 + this.intellectualPropertyIncome[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.intellectualPropertyName[indexPath.Row];
											expensesCell.DetailTextLabel.TextColor = UIColor.Gray;
											expensesCell.DetailTextLabel.MinimumFontSize = 14.0f;


											expensesCell.DetailTextLabel.AdjustsFontSizeToFitWidth = true;
											expensesCell.DetailTextLabel.AdjustsLetterSpacingToFitWidth = true;

											tableView.SectionIndexBackgroundColor = UIColor.Gray;
											tableView.SectionIndexColor = UIColor.Black;
											return expensesCell;

											break;

										case 7:
											expensesCell.AccessoryView = textExpenses;

											textExpenses.Text = symbolCurrency_2 + this.appRoyaltiesIncome[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.appRoyaltiesName[indexPath.Row];
											expensesCell.DetailTextLabel.TextColor = UIColor.Gray;
											expensesCell.DetailTextLabel.MinimumFontSize = 14.0f;


											expensesCell.DetailTextLabel.AdjustsFontSizeToFitWidth = true;
											expensesCell.DetailTextLabel.AdjustsLetterSpacingToFitWidth = true;

											tableView.SectionIndexBackgroundColor = UIColor.Gray;
											tableView.SectionIndexColor = UIColor.Black;
											return expensesCell;

											break;

										case 8:

											expensesCell.AccessoryView = textExpenses;

											textExpenses.Text = symbolCurrency_2 + this.bookPublishingIncome[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.bookPublishingName[indexPath.Row];
											expensesCell.DetailTextLabel.TextColor = UIColor.Gray;
											expensesCell.DetailTextLabel.MinimumFontSize = 14.0f;

											expensesCell.DetailTextLabel.AdjustsFontSizeToFitWidth = true;
											expensesCell.DetailTextLabel.AdjustsLetterSpacingToFitWidth = true;

											tableView.SectionIndexBackgroundColor = UIColor.Gray;
											tableView.SectionIndexColor = UIColor.Black;
											return expensesCell;

											break;

										case 9:
											expensesCell.AccessoryView = textExpenses;

											textExpenses.Text = symbolCurrency_2 + this.tradeDividendsIncome[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.tradeDividendsName[indexPath.Row];
											expensesCell.DetailTextLabel.TextColor = UIColor.Gray;
											expensesCell.DetailTextLabel.MinimumFontSize = 14.0f;


											expensesCell.DetailTextLabel.AdjustsFontSizeToFitWidth = true;
											expensesCell.DetailTextLabel.AdjustsLetterSpacingToFitWidth = true;

											tableView.SectionIndexBackgroundColor = UIColor.Gray;
											tableView.SectionIndexColor = UIColor.Black;
											return expensesCell;

											break;

										case 10:
											expensesCell.AccessoryView = textExpenses;

											textExpenses.Text = symbolCurrency_2 + this.bankInterestIncome[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.bankInterestName[indexPath.Row];
											expensesCell.DetailTextLabel.TextColor = UIColor.Gray;
											expensesCell.DetailTextLabel.MinimumFontSize = 14.0f;

											expensesCell.DetailTextLabel.AdjustsFontSizeToFitWidth = true;
											expensesCell.DetailTextLabel.AdjustsLetterSpacingToFitWidth = true;

											tableView.SectionIndexBackgroundColor = UIColor.Gray;
											tableView.SectionIndexColor = UIColor.Black;
											return expensesCell;

											break;

										case 11:

											expensesCell.AccessoryView = textExpenses;

											textExpenses.Text = symbolCurrency_2 + this.taxReturnIncome[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.taxReturnName[indexPath.Row];
											expensesCell.DetailTextLabel.TextColor = UIColor.Gray;
											expensesCell.DetailTextLabel.MinimumFontSize = 14.0f;

											expensesCell.DetailTextLabel.AdjustsFontSizeToFitWidth = true;
											expensesCell.DetailTextLabel.AdjustsLetterSpacingToFitWidth = true;

											tableView.SectionIndexBackgroundColor = UIColor.Gray;
											tableView.SectionIndexColor = UIColor.Black;
											return expensesCell;

											break;

										case 12:

											expensesCell.AccessoryView = textExpenses;

											textExpenses.Text = symbolCurrency_2 + this.studentLoadIncome[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.studentLoadName[indexPath.Row];
											expensesCell.DetailTextLabel.TextColor = UIColor.Gray;
											expensesCell.DetailTextLabel.MinimumFontSize = 14.0f;

											expensesCell.DetailTextLabel.AdjustsFontSizeToFitWidth = true;
											expensesCell.DetailTextLabel.AdjustsLetterSpacingToFitWidth = true;

											tableView.SectionIndexBackgroundColor = UIColor.Gray;
											tableView.SectionIndexColor = UIColor.Black;
											return expensesCell;

											break;

										case 13:

											expensesCell.AccessoryView = textExpenses;

											textExpenses.Text = symbolCurrency_2 + this.inheritanceIncome[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.inheritanceName[indexPath.Row];
											expensesCell.DetailTextLabel.TextColor = UIColor.Gray;
											expensesCell.DetailTextLabel.MinimumFontSize = 14.0f;

											expensesCell.DetailTextLabel.AdjustsFontSizeToFitWidth = true;
											expensesCell.DetailTextLabel.AdjustsLetterSpacingToFitWidth = true;

											tableView.SectionIndexBackgroundColor = UIColor.Gray;
											tableView.SectionIndexColor = UIColor.Black;
											return expensesCell;

											break;

										case 14:

											expensesCell.AccessoryView = textExpenses;

											textExpenses.Text = symbolCurrency_2 + this.prizeIncome[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.prizeName[indexPath.Row];
											expensesCell.DetailTextLabel.TextColor = UIColor.Gray;
											expensesCell.DetailTextLabel.MinimumFontSize = 14.0f;

											expensesCell.DetailTextLabel.AdjustsFontSizeToFitWidth = true;
											expensesCell.DetailTextLabel.AdjustsLetterSpacingToFitWidth = true;

											tableView.SectionIndexBackgroundColor = UIColor.Gray;
											tableView.SectionIndexColor = UIColor.Black;
											return expensesCell;

											break;

										case 15:

											expensesCell.AccessoryView = textExpenses;

											textExpenses.Text = symbolCurrency_2 + this.otherIncome[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.otherIncomeName[indexPath.Row];
											expensesCell.DetailTextLabel.TextColor = UIColor.Gray;
											expensesCell.DetailTextLabel.MinimumFontSize = 14.0f;

											expensesCell.DetailTextLabel.AdjustsFontSizeToFitWidth = true;
											expensesCell.DetailTextLabel.AdjustsLetterSpacingToFitWidth = true;

											tableView.SectionIndexBackgroundColor = UIColor.Gray;
											tableView.SectionIndexColor = UIColor.Black;
											return expensesCell;

											break;
									}
									Console.WriteLine("Interface orientation is: " + UIInterfaceOrientation.Unknown);
									break;
							}
						}
					}
				}
			}
			catch (ArgumentOutOfRangeException)
			{
				//add the ipad implementation 
				Console.WriteLine(":)");

			}
			//when a category is written;

			return expensesCell;
		}


		public override nint RowsInSection(UITableView tableView, nint section)
		{

			//The number of rows is determined by the number of values of a particular category
			switch (section)
			{
				case 0:
					return this.categoryChosen.Count((arg) => arg.ToString() == "\ud83d\udcb0 Wages/Salaries");
					break;

				case 1:
					//return this.categoryChosen.Count
					return this.categoryChosen.Count((arg) => arg.ToString() == "\ud83c\udfe1 Realestate");
					break;

				case 2:

					return this.categoryChosen.Count((arg) => arg.ToString() == "\ud83d\udcb5 Sales of Owned Stock/House Products");
					break;
				case 3:

					return this.categoryChosen.Count((arg) => arg.ToString() == "\ud83d\udcd6 Small Business");
					break;

				case 4:

					return this.categoryChosen.Count((arg) => arg.ToString() == "\ud83c\udfb0 Gambling winnings");
					break;

				case 5:

					return this.categoryChosen.Count((arg) => arg.ToString() == "\ud83d\udcc8 Sales of Trades/Stocks");
					break;

				case 6:

					return this.categoryChosen.Count((arg) => arg.ToString() == "\ud83d\udcd3 Intellectual Property");
					break;

				case 7:

					return this.categoryChosen.Count((arg) => arg.ToString() == "\ud83c\udf7e App Royalties");
					break;

				case 8:

					return this.categoryChosen.Count((arg) => arg.ToString() == "\ud83d\udce6 Book Publishing");
					break;

				case 9:

					return this.categoryChosen.Count((arg) => arg.ToString() == "\ud83d\udcca Trade Dividends");
					break;

				case 10:

					return this.categoryChosen.Count((arg) => arg.ToString() == "\ud83d\udcb3 Bank interest/Term Deposit");
					break;

				case 11:

					return this.categoryChosen.Count((arg) => arg.ToString() == "\ud83d\udcdc Tax Return");
					break;

				case 12:

					return this.categoryChosen.Count((arg) => arg.ToString() == "\ud83c\udfc5 Student Loan/Grant");
					break;

				case 13:

					return this.categoryChosen.Count((arg) => arg.ToString() == "\ud83d\udc8e Inheritance");
					break;

				case 14:

					return this.categoryChosen.Count((arg) => arg.ToString() == "\ud83c\udfc6 Prize Money");
					break;

				case 15:

					return this.categoryChosen.Count((arg) => arg.ToString() == "\ud83d\udcf0 Other");
					break;
			}
			return 0;
		}


		public override System.nint NumberOfSections(UIKit.UITableView tableView)
		{
			return this.category.Count;
		}

		public override string TitleForHeader(UIKit.UITableView tableView, System.nint section)
		{
			switch (section)
			{
				case 0:
					tableView.SectionIndexBackgroundColor = UIColor.Gray;
					tableView.SectionIndexColor = UIColor.Black;
					return "\ud83d\udcb0 Wages/Salaries"; //
					break;
				case 1:
					tableView.SectionIndexBackgroundColor = UIColor.Gray;
					tableView.SectionIndexColor = UIColor.Black;
					return "\ud83c\udfe1 Realestate";//
					break;
				case 2:
					tableView.SectionIndexBackgroundColor = UIColor.Gray;
					tableView.SectionIndexColor = UIColor.Black;
					return "\ud83d\udcb5 Sales of Owned Stock/House Products"; //
					break;

				case 3:
					tableView.SectionIndexBackgroundColor = UIColor.Gray;
					tableView.SectionIndexColor = UIColor.Black;
					return "\ud83d\udcd6 Small Business";//
					break;

				case 4:
					tableView.SectionIndexBackgroundColor = UIColor.Gray;
					tableView.SectionIndexColor = UIColor.Black;
					return "\ud83c\udfb0 Gambling winnings";//
					break;

				case 5:
					tableView.SectionIndexBackgroundColor = UIColor.Gray;
					tableView.SectionIndexColor = UIColor.Black;
					return "\ud83d\udcc8 Sales of Trades/Stocks";//
					break;
				case 6:
					tableView.SectionIndexBackgroundColor = UIColor.Gray;
					tableView.SectionIndexColor = UIColor.Black;
					return "\ud83d\udcd3 Intellectual Property"; //
					break;

				case 7:
					tableView.SectionIndexBackgroundColor = UIColor.Gray;
					tableView.SectionIndexColor = UIColor.Black;
					return "\ud83c\udf7e App Royalties";// 
					break;

				case 8:
					tableView.SectionIndexBackgroundColor = UIColor.Gray;
					tableView.SectionIndexColor = UIColor.Black;
					return "\ud83d\udce6 Book Publishing";//
					break;

				case 9:
					tableView.SectionIndexBackgroundColor = UIColor.Gray;
					tableView.SectionIndexColor = UIColor.Black;
					return "\ud83d\udcca Trade Dividends";//
					break;
				case 10:
					tableView.SectionIndexBackgroundColor = UIColor.Gray;
					tableView.SectionIndexColor = UIColor.Black;
					return "\ud83d\udcb3 Bank interest/Term Deposit"; //
					break;

				case 11:
					tableView.SectionIndexBackgroundColor = UIColor.Gray;
					tableView.SectionIndexColor = UIColor.Black;
					return "\ud83d\udcdc Tax Return";//
					break;

				case 12:
					tableView.SectionIndexBackgroundColor = UIColor.Gray;
					tableView.SectionIndexColor = UIColor.Black;
					return "\ud83c\udfc5 Student Loan/Grant"; //
					break;
				case 13:
					tableView.SectionIndexBackgroundColor = UIColor.Gray;
					tableView.SectionIndexColor = UIColor.Black;
					return "\ud83d\udc8e Inheritance";
					break;
				case 14:
					tableView.SectionIndexBackgroundColor = UIColor.Gray;
					tableView.SectionIndexColor = UIColor.Black;
					return "\ud83c\udfc6 Prize Money";
					break;

				case 15:
					tableView.SectionIndexBackgroundColor = UIColor.Gray;
					tableView.SectionIndexColor = UIColor.Black;
					return "\ud83d\udcf0 Other";
					break;
			}
			return "";
		}

		public override void CommitEditingStyle(UIKit.UITableView tableView, UIKit.UITableViewCellEditingStyle editingStyle, Foundation.NSIndexPath indexPath)
		{
			if (editingStyle == UITableViewCellEditingStyle.Delete)
			{

				//probelm with the deletion of the cells exists here. Fix this Fast!

				switch (indexPath.Section)
				{

					case 1: //rent category

						try
						{
							if (wagesName.Count == 0)
							{
								throw new NullReferenceException();
							}
							else if (wagesName.Count >= 1)
							{
								this.wagesIncome.RemoveAt(indexPath.Row);
								this.wagesName.RemoveAt(indexPath.Row);
							}

						}
						catch (NullReferenceException)
						{
							Console.WriteLine(":|");
						}
						break;
					case 2:
						try
						{
							if (realestateName.Count == 0)
							{
								throw new NullReferenceException();
							}
							else if (realestateName.Count >= 1)
							{
								this.realestateName.RemoveAt(indexPath.Row);
								this.realestateIncome.RemoveAt(indexPath.Row);
							}

						}
						catch (NullReferenceException)
						{
							Console.WriteLine(":|");
						}

						break;
					case 3:
						try
						{
							if (salesHouseName.Count == 0)
							{
								throw new NullReferenceException();
							}
							else if (salesHouseName.Count >= 1)
							{
								this.salesHouseName.RemoveAt(indexPath.Row);
								this.salesHouseIncome.RemoveAt(indexPath.Row);
							}

						}
						catch (NullReferenceException)
						{
							Console.WriteLine(":|");
						}

						break;


					case 4:
						try
						{
							if (smallBusinessName.Count == 0)
							{
								throw new NullReferenceException();
							}
							else if (smallBusinessName.Count >= 1)
							{
								this.smallBusinessName.RemoveAt(indexPath.Row);
								this.smallBusinessIncome.RemoveAt(indexPath.Row);
							}

						}
						catch (NullReferenceException)
						{
							Console.WriteLine(":|");
						}

						break;

					case 5:
						try
						{
							if (gamblingName.Count == 0)
							{
								throw new NullReferenceException();
							}
							else if (gamblingName.Count >= 1)
							{
								this.gamblingName.RemoveAt(indexPath.Row);
								this.gamblingIncome.RemoveAt(indexPath.Row);
							}

						}
						catch (NullReferenceException)
						{
							Console.WriteLine(":|");
						}

						break;

					case 6:
						try
						{
							if (salesTradesName.Count == 0)
							{
								throw new NullReferenceException();
							}
							else if (salesTradesName.Count >= 1)
							{
								this.salesTradesName.RemoveAt(indexPath.Row);
								this.salesTradesIncome.RemoveAt(indexPath.Row);
							}

						}
						catch (NullReferenceException)
						{
							Console.WriteLine(":|");
						}

						break;

					case 7:
						try
						{
							if (intellectualPropertyName.Count == 0)
							{
								throw new NullReferenceException();
							}
							else if (intellectualPropertyName.Count >= 1)
							{
								this.intellectualPropertyName.RemoveAt(indexPath.Row);
								this.intellectualPropertyIncome.RemoveAt(indexPath.Row);
							}

						}
						catch (NullReferenceException)
						{
							Console.WriteLine(":|");
						}

						break;

					case 8:
						try
						{
							if (appRoyaltiesName.Count == 0)
							{
								throw new NullReferenceException();
							}
							else if (appRoyaltiesName.Count >= 1)
							{
								this.appRoyaltiesName.RemoveAt(indexPath.Row);
								this.appRoyaltiesIncome.RemoveAt(indexPath.Row);
							}

						}
						catch (NullReferenceException)
						{
							Console.WriteLine(":|");
						}

						break;

					case 9:
						try
						{
							if (bookPublishingName.Count == 0)
							{
								throw new NullReferenceException();
							}
							else if (bookPublishingName.Count >= 1)
							{
								this.bookPublishingName.RemoveAt(indexPath.Row);
								this.bookPublishingIncome.RemoveAt(indexPath.Row);
							}

						}
						catch (NullReferenceException)
						{
							Console.WriteLine(":|");
						}

						break;

					case 10:
						try
						{
							if (tradeDividendsName.Count == 0)
							{
								throw new NullReferenceException();
							}
							else if (tradeDividendsName.Count >= 1)
							{
								this.tradeDividendsName.RemoveAt(indexPath.Row);
								this.tradeDividendsIncome.RemoveAt(indexPath.Row);
							}

						}
						catch (NullReferenceException)
						{
							Console.WriteLine(":|");
						}

						break;

					case 11:
						try
						{
							if (bankInterestName.Count == 0)
							{
								throw new NullReferenceException();
							}
							else if (bankInterestName.Count >= 1)
							{
								this.bankInterestName.RemoveAt(indexPath.Row);
								this.bankInterestIncome.RemoveAt(indexPath.Row);
							}

						}
						catch (NullReferenceException)
						{
							Console.WriteLine(":|");
						}

						break;

					case 12:
						try
						{
							if (taxReturnName.Count == 0)
							{
								throw new NullReferenceException();
							}
							else if (taxReturnName.Count >= 1)
							{
								this.taxReturnName.RemoveAt(indexPath.Row);
								this.taxReturnIncome.RemoveAt(indexPath.Row);
							}

						}
						catch (NullReferenceException)
						{
							Console.WriteLine(":|");
						}

						break;
					case 13:
						try
						{
							if (studentLoadName.Count == 0)
							{
								throw new NullReferenceException();
							}
							else if (studentLoadName.Count >= 1)
							{
								this.studentLoadName.RemoveAt(indexPath.Row);
								this.studentLoadIncome.RemoveAt(indexPath.Row);
							}

						}
						catch (NullReferenceException)
						{
							Console.WriteLine(":|");
						}

						break;

					case 14:
						try
						{
							if (inheritanceName.Count == 0)
							{
								throw new NullReferenceException();
							}
							else if (inheritanceName.Count >= 1)
							{
								this.inheritanceName.RemoveAt(indexPath.Row);
								this.inheritanceIncome.RemoveAt(indexPath.Row);
							}

						}
						catch (NullReferenceException)
						{
							Console.WriteLine(":|");
						}

						break;

					case 15:
						try
						{
							if (prizeName.Count == 0)
							{
								throw new NullReferenceException();
							}
							else if (prizeName.Count >= 1)
							{
								this.prizeName.RemoveAt(indexPath.Row);
								this.prizeIncome.RemoveAt(indexPath.Row);
							}

						}
						catch (NullReferenceException)
						{
							Console.WriteLine(":|");
						}

						break;

					case 16:
						try
						{
							if (otherIncomeName.Count == 0)
							{
								throw new NullReferenceException();
							}
							else if (otherIncomeName.Count >= 1)
							{
								this.otherIncomeName.RemoveAt(indexPath.Row);
								this.otherIncome.RemoveAt(indexPath.Row);
							}

						}
						catch (NullReferenceException)
						{
							Console.WriteLine(":|");
						}

						break;
				}

				this.categoryChosen.RemoveAt(indexPath.Row);
				this.name.RemoveAt(indexPath.Row);
				this.expenseAmount.RemoveAt(indexPath.Row);
				tableView.DeleteRows(new NSIndexPath[] { indexPath }, UITableViewRowAnimation.Automatic);

				if (expenseAmount.Count == 0)
				{
					this.NavigationItem.LeftBarButtonItem = this.deleteCell;
					tableView.SetEditing(false, true);
				}
			}
		}

		//returns height for section
		public override nfloat GetHeightForHeader(UITableView tableView, nint section)
		{
			switch (section)
			{
				case 0:
					return 38.0f;
					break;
				case 1:
					return 38.0f;
					break;
				case 2:
					return 38.0f;
					break;
				case 3:
					return 38.0f;
					break;
				case 4:
					return 38.0f;
					break;
				case 5:
					return 38.0f;
					break;
				case 6:
					return 38.0f;
					break;
				case 7:
					return 38.0f;
					break;
				case 8:
					return 38.0f;
					break;
				case 9:
					return 38.0f;
					break;
				case 10:
					return 38.0f;
					break;
				case 11:
					return 38.0f;
					break;
				case 12:
					return 38.0f;
					break;
				case 13:
					return 38.0f;
					break;
				case 14:
					return 38.0f;
					break;
				case 15:
					return 38.0f;
					break;
			}
			return 0;
		}
	}



	public class CategoryTableDescriptionIncome : UITableViewSource
	{
		IncomeBudgetController expController = new IncomeBudgetController();

		List<string> incomeCategories = new List<string>() { {""}, {"\ud83d\udcb0 Wages/Salaries"},{"\ud83c\udfe1 Realestate"},{"\ud83d\udcb5 Sales of Owned Stock/House Products"},{"\ud83d\udcd6 Small Business"},{"\ud83c\udfb0 Gambling winnings"},{"\ud83d\udcc8 Sales of Trades/Stocks"},{"\ud83d\udcd3 Intellectual Property"},{"\ud83c\udf7e App Royalties"},
			{"\ud83d\udce6 Book Publishing"},{"\ud83d\udcca Trade Dividends"},{"\ud83d\udcb3 Bank interest/Term Deposit"},{"\ud83d\udcdc Tax Return"},{"\ud83c\udfc5 Student Loan/Grant"},{"\ud83d\udc8e Inheritance"},{"\ud83c\udfc6 Prize Money"},{"\ud83d\udcf0 Other"}}; 

		List<string> arrowHeading = new List<string>() { "", ">", ">", ">", ">", ">", ">", ">", ">", ">", ">", ">", ">", ">", ">", ">",">" };
		UIViewController controller = new UIViewController();
		public CategoryTableDescriptionIncome(UIViewController control, IncomeBudgetController exp, UITableViewCell cell, NSIndexPath indexObject)
		{
			controller = control;
			expController = exp;
		}

		public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
		{
			UITableViewCell categoryCell = tableView.DequeueReusableCell("categoryCell");

			if (categoryCell == null)
			{
				categoryCell = new UITableViewCell(UITableViewCellStyle.Value1, "categoryCell");
			}

			if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad || UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone)
			{
				categoryCell.TextLabel.Text = incomeCategories[indexPath.Row];
				categoryCell.TextLabel.TextColor = UIColor.Black;

				categoryCell.DetailTextLabel.Text = arrowHeading[indexPath.Row];
				categoryCell.DetailTextLabel.TextColor = UIColor.LightGray; 

				switch (UIApplication.SharedApplication.StatusBarOrientation)
				{
					case UIInterfaceOrientation.Portrait:
						tableView.RowHeight = 70.0f;

						break;
					case UIInterfaceOrientation.PortraitUpsideDown:
						tableView.RowHeight = 70.0f;

						break;
					default:
						tableView.RowHeight = 50.0f;
						break;
				}
			}

			return categoryCell;
		}


		public override nint RowsInSection(UITableView tableview, nint section)
		{
			return this.expController.category.Count;
		}


		public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
		{
			switch (indexPath.Row)
			{
				case 0:
					expController.expenseAmount.RemoveAt(expController.expenseAmount.Count - 1); 
					expController.name.RemoveAt(expController.name.Count - 1);
					controller.DismissViewController(true, null);
					break;

				case 1:
					expController.categoryChosen.Add(expController.category[1]);
					int index = expController.categoryChosen.FindLastIndex((string obj) => obj.ToString() == "\ud83d\udcb0 Wages/Salaries");
					expController.wagesIncome.Add(expController.expenseAmount[index]);
					expController.wagesName.Add(expController.name[index]);

					controller.DismissViewController(true, () =>
					{
						expController.TableView.ReloadData();
					});

					break;
				case 2:
					expController.categoryChosen.Add(expController.category[2]);
					int indexHousing = expController.categoryChosen.FindLastIndex((string obj) => obj.ToString() == "\ud83c\udfe1 Realestate");
					expController.realestateIncome.Add(expController.expenseAmount[indexHousing]);
					expController.realestateName.Add(expController.name[indexHousing]);

					tableView.ScrollToNearestSelected(UITableViewScrollPosition.Top, true);
					controller.DismissViewController(true, () =>
					{
						expController.TableView.ReloadData();
					});

					break;
				case 3:
					expController.categoryChosen.Add(expController.category[3]);
					int indexMortage = expController.categoryChosen.FindLastIndex((string obj) => obj.ToString() == "\ud83d\udcb5 Sales of Owned Stock/House Products");
					expController.salesHouseIncome.Add(expController.expenseAmount[indexMortage]);
					expController.salesHouseName.Add(expController.name[indexMortage]);


					controller.DismissViewController(true, () =>
					{
						expController.TableView.ReloadData();
					});

					break;
				case 4:
					expController.categoryChosen.Add(expController.category[4]);
					int indexInsurance = expController.categoryChosen.FindLastIndex((string obj) => obj.ToString() == "\ud83d\udcd6 Small Business");
					expController.smallBusinessIncome.Add(expController.expenseAmount[indexInsurance]);
					expController.smallBusinessName.Add(expController.name[indexInsurance]);

					controller.DismissViewController(true, () =>
					{
						expController.TableView.ReloadData();
					});

					break;
				case 5:
					expController.categoryChosen.Add(expController.category[5]);
					int indexTaxes = expController.categoryChosen.FindLastIndex((string obj) => obj.ToString() == "\ud83c\udfb0 Gambling winnings");
					expController.gamblingIncome.Add(expController.expenseAmount[indexTaxes]);


					expController.gamblingName.Add(expController.name[indexTaxes]);
					controller.DismissViewController(true, () =>
					{
						expController.TableView.ReloadData();
					});

					break;
				case 6:
					expController.categoryChosen.Add(expController.category[6]);
					int indexCarPayments = expController.categoryChosen.FindLastIndex((string obj) => obj.ToString() == "\ud83d\udcc8 Sales of Trades/Stocks");
					expController.salesTradesIncome.Add(expController.expenseAmount[indexCarPayments]);
					expController.salesTradesName.Add(expController.name[indexCarPayments]);

					controller.DismissViewController(true, () =>
					{
						expController.TableView.ReloadData();
					});

					break;
				case 7:
					expController.categoryChosen.Add(expController.category[7]);
					int indexEducation = expController.categoryChosen.FindLastIndex((string obj) => obj.ToString() == "\ud83d\udcd3 Intellectual Property");
					expController.intellectualPropertyIncome.Add(expController.expenseAmount[indexEducation]);
					expController.intellectualPropertyName.Add(expController.name[indexEducation]);


					controller.DismissViewController(true, () =>
					{
						expController.TableView.ReloadData();
					});

					break;
				case 8:
					expController.categoryChosen.Add(expController.category[8]);
					int indexElectronics = expController.categoryChosen.FindLastIndex((string obj) => obj.ToString() == "\ud83c\udf7e App Royalties");
					expController.appRoyaltiesIncome.Add(expController.expenseAmount[indexElectronics]);
					expController.appRoyaltiesName.Add(expController.name[indexElectronics]);


					controller.DismissViewController(true, () =>
					{
						expController.TableView.ReloadData();
					});

					break;
				case 9:
					expController.categoryChosen.Add(expController.category[9]);
					int indexEntertainment = expController.categoryChosen.FindLastIndex((string obj) => obj.ToString() == "\ud83d\udce6 Book Publishing");
					expController.bookPublishingIncome.Add(expController.expenseAmount[indexEntertainment]);
					expController.bookPublishingName.Add(expController.name[indexEntertainment]);


					controller.DismissViewController(true, () =>
					{
						expController.TableView.ReloadData();
					});

					break;
				case 10:
					expController.categoryChosen.Add(expController.category[10]);
					int indexClothing = expController.categoryChosen.FindLastIndex((string obj) => obj.ToString() == "\ud83d\udcca Trade Dividends");
					expController.tradeDividendsIncome.Add(expController.expenseAmount[indexClothing]);
					expController.tradeDividendsName.Add(expController.name[indexClothing]);


					controller.DismissViewController(true, () =>
					{
						expController.TableView.ReloadData();
					});

					break;
				case 11:
					expController.categoryChosen.Add(expController.category[11]);
					int indexPets = expController.categoryChosen.FindLastIndex((string obj) => obj.ToString() == "\ud83d\udcb3 Bank interest/Term Deposit");
					expController.bankInterestIncome.Add(expController.expenseAmount[indexPets]);


					expController.bankInterestName.Add(expController.name[indexPets]);
					controller.DismissViewController(true, () =>
					{
						expController.TableView.ReloadData();
					});

					break;
				case 12:
					expController.categoryChosen.Add(expController.category[12]);
					int indexCharity = expController.categoryChosen.FindLastIndex((string obj) => obj.ToString() == "\ud83d\udcdc Tax Return");
					expController.taxReturnIncome.Add(expController.expenseAmount[indexCharity]);
					expController.taxReturnName.Add(expController.name[indexCharity]);


					controller.DismissViewController(true, () =>
					{
						expController.TableView.ReloadData();
					});

					break;
				case 13:
					expController.categoryChosen.Add(expController.category[13]);
					int indexFood = expController.categoryChosen.FindLastIndex((string obj) => obj.ToString() == "\ud83c\udfc5 Student Loan/Grant");
					expController.studentLoadIncome.Add(expController.expenseAmount[indexFood]);
					expController.studentLoadName.Add(expController.name[indexFood]);


					controller.DismissViewController(true, () =>
					{
						expController.TableView.ReloadData();
					});

					break;
				case 14:
					expController.categoryChosen.Add(expController.category[14]);
					int indexHealth = expController.categoryChosen.FindLastIndex((string obj) => obj.ToString() == "\ud83d\udc8e Inheritance");
					expController.inheritanceIncome.Add(expController.expenseAmount[indexHealth]);
					expController.inheritanceName.Add(expController.name[indexHealth]);

					controller.DismissViewController(true, () =>
					{
						expController.TableView.ReloadData();
					});

					break;
				case 15:
					expController.categoryChosen.Add(expController.category[15]);
					int indexGardening = expController.categoryChosen.FindLastIndex((string obj) => obj.ToString() == "\ud83c\udfc6 Prize Money");
					expController.prizeIncome.Add(expController.expenseAmount[indexGardening]);
					expController.prizeName.Add(expController.name[indexGardening]);


					controller.DismissViewController(true, () =>
					{
						expController.TableView.ReloadData();
					});

					break;
				case 16:
					expController.categoryChosen.Add(expController.category[16]);
					int indexGardening_2 = expController.categoryChosen.FindLastIndex((string obj) => obj.ToString() == "\ud83d\udcf0 Other");
					expController.otherIncome.Add(expController.expenseAmount[indexGardening_2]);
					expController.otherIncomeName.Add(expController.name[indexGardening_2]);


					controller.DismissViewController(true, () =>
					{
						expController.TableView.ReloadData();
					});

					break;
				default:
					Console.WriteLine("No category has been chosen");
					break;
			}
			tableView.DeselectRow(indexPath, true);
		}
	}


	public class TableControllerIncome : UITableViewController
	{
		public override UIInterfaceOrientationMask GetSupportedInterfaceOrientations()
		{
			if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
			{
				return UIInterfaceOrientationMask.Landscape;
			}
			else {
				return UIInterfaceOrientationMask.All;
			}
		}



		public override bool ShouldAutorotateToInterfaceOrientation(UIInterfaceOrientation toInterfaceOrientation)
		{
			return false;
		}

		public override bool ShouldAutorotate()
		{
			return false;
		}

		public override bool PrefersStatusBarHidden()
		{
			return true;
		}
	}
}
