using System;
using System.Collections; 
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;

using Foundation;
using UIKit;
using AVFoundation; 
using CoreGraphics;
using AudioToolbox;

//top coder = solves problems in programming languages, C++
/* Leftover tasks: 
 
 * Write a privacy policy for the user explaining how their data will be used  
 * Change the category choice of income 
 * Change the start button of the budget calculator
 * Fix the total expenses and total income calculation algorithm 
 * 
 * 
 * 
 * 
 * Features to add: 
 * Encryption security for multiple users
 * AirPlay so users can share their total expenses with each other.
*/

namespace FinanceCalculator
{
	public partial class ExpenseController : UITableViewController
	{
		//category table object. This must be global and public so I can refer to it via the UITableViewSource type class
		public TableController controlView = new TableController();
		//user interface properties 
		public UIBarButtonItem addExpense = new UIBarButtonItem(); //adds an expense to the list
		public UIBarButtonItem removeExpense = new UIBarButtonItem(); //removes an expense from the list

		private UIBarButtonItem deleteCell = new UIBarButtonItem(UIBarButtonSystemItem.Edit, null);
		//data structures to store the expenses information
		public List<string> name = new List<string>() { };

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

		public List<double> expenseAmount = new List<double>() { };

		public List<string> category = new List<string>(){
			{""},{"\ud83d\udecf Rent"},{"\ud83c\udfe1 Housing"},{"\ud83d\udcb3 Mortgage"},{"\ud83d\udc94 Insurance"},{"\ud83d\udcd3 Taxes"},{"\ud83d\ude97 Car Payments"},{"\ud83d\udcda Education"},{"\ud83d\udd0c Electronics"},
			{"\ud83c\udfa5 Entertainment"},{"\ud83d\udc55 Clothing & Footwear"},{"\ud83d\udc08 Pets"},{"\ud83c\udf81 Charity"},{"\ud83c\udf54 Food"},{"\ud83d\udc5f Health & Lifestyle"},{"\ud83c\udf3b Gardening"},
			{"✨ Cleaning & Maintanance"},{"\ud83d\udec1 Utilities"},{"\ud83d\uddde Other"}
		};

		public List<string> symbolCurrencyList = new List<string>() { };

		public string symbolCurrency;

		public ExpenseController(string expensesList)
		{
			symbolCurrency = expensesList;
		}


		public List<string> categoryChosen = new List<string>() { };

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




		Utility AI = new Utility();

		public ExpenseController(IntPtr handle) : base(handle)
		{
		}

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
				Update = UIAlertAction.Create("Add an expense", UIAlertActionStyle.Default, (Action) =>
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

							Console.WriteLine("Name List Count: " + this.name.Count);
							Console.WriteLine("Expense Amount Count: " + this.expenseAmount.Count);
						}
					}
				};
			});

			addExpensePrompt.AddTextField((UITextField obj_2) =>
			{
				obj_2.AdjustsFontSizeToFitWidth = true;
				obj_2.ClearButtonMode = UITextFieldViewMode.WhileEditing;
				obj_2.Placeholder = "Enter an optional name";
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
					else if (this.name.Count >= 1 && String.IsNullOrEmpty(addExpensePrompt.TextFields[1].Text) == false) {
					this.expenseAmount.RemoveAt(this.expenseAmount.Count - 1);
					this.name.RemoveAt(this.expenseAmount.Count - 1);
				}
			}
						catch(ArgumentOutOfRangeException) {
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

		public ExpenseController(List<string> incomeCat, List<double> incomeAmo, List<string> incomeNameRef)
		{
			incomeCategory = incomeCat;
			incomeAmount = incomeAmo;
			incomeName = incomeNameRef;
		}

		public ExpenseController() { }

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
			tableCategory.Source = new CategoryTableDescription(controlView, this, expensesCell, this.TableView.IndexPathForCell(expensesCell));

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
						if(this.name.Count == 0 || this.categoryChosen.Count == 0) {
							throw new NullReferenceException();
						}

						//fix 
						this.name.RemoveAt(this.name.Count - 1);
						this.expenseAmount.RemoveAt(this.expenseAmount.Count - 1);

						this.TableView.ReloadData();
					}
					catch(NullReferenceException) {
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
		}

		//alert controller that contains the categories 

		public override void MotionBegan(UIKit.UIEventSubtype motion, UIKit.UIEvent evt)
		{
			if(evt.Type == UIEventType.Motion) {

				Utility utilityAI = new Utility();
				utilityAI.AIEnglish("Warning about to pop this controller off the navigation stack. Would you like to proceed?", "en-US", 2.5f, 1.0f, 1.0f);
				UIAlertController chooseAlert = UIAlertController.Create("", "Are you sure you want to return to the previous page? Doing so will delete your progress", UIAlertControllerStyle.Alert);

				UIAlertAction confirmed = UIAlertAction.Create("Yes", UIAlertActionStyle.Default, (Action) =>
				{
					this.NavigationController.PopViewController(true);
					this.Dispose();
				});

				UIAlertAction denied = UIAlertAction.Create("No", UIAlertActionStyle.Default, (Action) =>
				{
					chooseAlert.Dispose();
				});

				chooseAlert.AddAction(confirmed);
				chooseAlert.AddAction(denied);
			
				if(this.PresentedViewController == null) {
					this.PresentViewController(chooseAlert, true, ()=> {
						//SystemSound soundPop = new SystemSound(4095);
						//soundPop.PlaySystemSound();
						utilityAI.AIEnglish("Warning about to pop this controller off the navigation stack. Would you like to proceed?", "en-US", 2.5f, 1.0f, 1.0f);
					});
				}

				else if(this.PresentedViewController != null) {
					this.PresentedViewController.DismissViewController(true, () => {
						this.PresentedViewController.Dispose();

						this.PresentViewController(chooseAlert, true, ()=>{
							//SystemSound soundPop = new SystemSound(4095);
							//soundPop.PlaySystemSound(); 
							utilityAI.AIEnglish("Warning about to pop this controller off the navigation stack. Would you like to proceed?", "en-US", 2.5f, 1.0f, 1.0f);
						});

					});
				}
			}
		}

		public override void ViewDidLoad()
		{
			this.TableView.AllowsSelection = false;
			this.TableView = new UITableView(new CGRect(0, 0, this.View.Bounds.Width, this.View.Bounds.Height), UITableViewStyle.Grouped);

			this.NavigationItem.Title = "Expenses List";
			expensesInstructions("Welcome", "On this page you simply have to list your daily expenses");

			//toolbar items 1
			UIBarButtonItem calculateExpense = new UIBarButtonItem("Calculate", UIBarButtonItemStyle.Bordered, (object sender, EventArgs e) =>
			{
				//calculates the total values stored in the list of expenses 

				UIAlertController calculateController = UIAlertController.Create("", "Have you finished listing your expenses?", UIAlertControllerStyle.Alert);

				UIAlertAction confirmed = UIAlertAction.Create("Yes", UIAlertActionStyle.Default, (Action) =>
				{

				//check if the user has entered any values
				if (this.expenseAmount.Count == 0)
					{
						UIAlertController nullController = UIAlertController.Create("No values entered", "You must list an expense, before calculating your total expenses. Simply press the 'Add' button on top to get started", UIAlertControllerStyle.Alert);

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
						double rent = this.rentExpenses.Sum();
						double housing = this.housingExpenses.Sum();
						double mortgage = this.mortageExpenses.Sum();
						double insurance = this.insuranceExpenses.Sum();
						double taxes = this.taxesExpenses.Sum();
						double carPayments = this.carPaymentsExpenses.Sum();
						double education = this.educationExpenses.Sum();
						double electronics = this.electronicsExpenses.Sum();
						double entertainment = this.entertainmentExpenses.Sum();
						double clothing = this.clothingExpenses.Sum();
						double pets = this.petsExpenses.Sum();
						double charity = this.charityExpenses.Sum();
						double food = this.foodExpenses.Sum();
						double health = this.healthExpenses.Sum();
						double gardening = this.gardeningExpenses.Sum();
						double cleaning = this.cleaningExpenses.Sum();
						double utilities = this.utilitiesExpenses.Sum();
						double other = this.otherExpenses.Sum();

						double totalExpenses = this.expenseAmount.Sum();

						IncomeBudgetController income = new IncomeBudgetController(rent, housing, mortgage, insurance, taxes, carPayments, education,
						                                                           electronics, entertainment, clothing, pets, charity, food, health, gardening, cleaning, utilities, other, symbolCurrency, totalExpenses);
						this.NavigationController.PushViewController(income, true);
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

			UIBarButtonItem spaceFlexible = new UIBarButtonItem(UIBarButtonSystemItem.FlexibleSpace, null);

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
				expensesInstructions("Need Help?", "On this page you simply have to list your daily expenses. Click on 'Add' to get started");
			};

			//toolbar items 2
			//reset button to reset the table dictionaries 
			UIBarButtonItem resetList = new UIBarButtonItem(UIBarButtonSystemItem.Trash, (object sender, EventArgs e) =>
			{
				UIAlertController resetPrompt = UIAlertController.Create("Reset expenses?", "Do you want to clear your list of expenses?", UIAlertControllerStyle.Alert);

				UIAlertAction confirmed = UIAlertAction.Create("Yes", UIAlertActionStyle.Destructive, (Action) =>
				{
					this.categoryChosen.Clear();
					this.expenseAmount.Clear();
					this.name.Clear();

					this.rentName.Clear();
					this.housingName.Clear();
					this.mortageName.Clear();
					this.insuranceName.Clear();
					this.taxesName.Clear();
					this.carPaymentsName.Clear();
					this.educationName.Clear();
					this.electronicsName.Clear();
					this.entertainmentName.Clear();
					this.clothingName.Clear();
					this.petsName.Clear();
					this.charityName.Clear();
					this.foodName.Clear();
					this.healthName.Clear();
					this.gardeningName.Clear();
					this.cleaningName.Clear();
					this.utilitiesName.Clear();
					this.otherName.Clear(); 


					this.rentExpenses.Clear();
					this.housingExpenses.Clear();
					this.mortageExpenses.Clear();
					this.insuranceExpenses.Clear();
					this.taxesExpenses.Clear();
					this.carPaymentsExpenses.Clear();
					this.educationExpenses.Clear();
					this.electronicsExpenses.Clear();
					this.entertainmentExpenses.Clear();
					this.clothingExpenses.Clear();
					this.petsExpenses.Clear();
					this.charityExpenses.Clear();
					this.foodExpenses.Clear();
					this.healthExpenses.Clear();
					this.gardeningExpenses.Clear();
					this.cleaningExpenses.Clear();
					this.utilitiesExpenses.Clear();
					this.otherExpenses.Clear();

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
					this.NavigationController.PopToViewController(budget, true);
					this.Dispose();
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
			if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
			{

				switch (UIApplication.SharedApplication.StatusBarOrientation)
				{
					case UIInterfaceOrientation.Portrait:
						Console.WriteLine("Orientation: " + UIDevice.CurrentDevice.Orientation);
						this.ToolbarItems = new UIBarButtonItem[] { info,spaceFlexible, calculateExpense,spaceFlexible, resetList };

						break;
					case UIInterfaceOrientation.PortraitUpsideDown:
						Console.WriteLine("Orientation: " + UIDevice.CurrentDevice.Orientation);
						this.ToolbarItems = new UIBarButtonItem[] { info, spaceFlexible, calculateExpense, spaceFlexible, resetList };
						break;

					default:
						this.ToolbarItems = new UIBarButtonItem[] { info, spaceFlexible, calculateExpense, spaceFlexible, resetList };
						break;
				}
				if (UIApplication.SharedApplication.StatusBarHidden == true)
				{
					UIDevice.CurrentDevice.BeginGeneratingDeviceOrientationNotifications();
					switch (UIDevice.CurrentDevice.Orientation)
					{
						case UIDeviceOrientation.LandscapeLeft:
							Console.WriteLine("Orientation: " + UIDevice.CurrentDevice.Orientation);
							this.ToolbarItems = new UIBarButtonItem[] { info, spaceFlexible, calculateExpense, spaceFlexible, resetList };


							break;
						case UIDeviceOrientation.LandscapeRight:
							Console.WriteLine("Orientation: " + UIDevice.CurrentDevice.Orientation);
							this.ToolbarItems = new UIBarButtonItem[] { info, spaceFlexible, calculateExpense, spaceFlexible, resetList };
							break;

						case UIDeviceOrientation.FaceUp:
							Console.WriteLine("Orientation: " + UIDevice.CurrentDevice.Orientation);
							this.ToolbarItems = new UIBarButtonItem[] { info, spaceFlexible, calculateExpense, spaceFlexible, resetList };
							break;
						case UIDeviceOrientation.FaceDown:
							Console.WriteLine("Orientation: " + UIDevice.CurrentDevice.Orientation);
							this.ToolbarItems = new UIBarButtonItem[] { info, spaceFlexible, calculateExpense, spaceFlexible, resetList };
							break;
						case UIDeviceOrientation.Unknown:
							Console.WriteLine("Orientation: " + UIDevice.CurrentDevice.Orientation);
							this.ToolbarItems = new UIBarButtonItem[] { info, spaceFlexible, calculateExpense, spaceFlexible, resetList };
							break;
						default:
							Console.WriteLine("Orientation: " + UIDevice.CurrentDevice.Orientation);
							break;

					}
				}

			}

			else if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone)
			{

				switch (UIApplication.SharedApplication.StatusBarOrientation)
				{
					case UIInterfaceOrientation.Portrait:
						Console.WriteLine("Orientation: " + UIDevice.CurrentDevice.Orientation);
						this.ToolbarItems = new UIBarButtonItem[] { info, spaceFlexible, calculateExpense, spaceFlexible, resetList };

						break;
					case UIInterfaceOrientation.PortraitUpsideDown:
						Console.WriteLine("Orientation: " + UIDevice.CurrentDevice.Orientation);
						this.ToolbarItems = new UIBarButtonItem[] { info, spaceFlexible, calculateExpense, spaceFlexible, resetList };
						break;

					default:
						this.ToolbarItems = new UIBarButtonItem[] { info, spaceFlexible, calculateExpense, spaceFlexible, resetList };
						break;
				}
				if (UIApplication.SharedApplication.StatusBarHidden == true)
				{
					UIDevice.CurrentDevice.BeginGeneratingDeviceOrientationNotifications();
					switch (UIDevice.CurrentDevice.Orientation)
					{
						case UIDeviceOrientation.LandscapeLeft:
							Console.WriteLine("Orientation: " + UIDevice.CurrentDevice.Orientation);
							this.ToolbarItems = new UIBarButtonItem[] { info, spaceFlexible, calculateExpense, spaceFlexible, resetList };


							break;
						case UIDeviceOrientation.LandscapeRight:
							Console.WriteLine("Orientation: " + UIDevice.CurrentDevice.Orientation);
							this.ToolbarItems = new UIBarButtonItem[] { info, spaceFlexible, calculateExpense, spaceFlexible, resetList };
							break;

						case UIDeviceOrientation.FaceUp:
							Console.WriteLine("Orientation: " + UIDevice.CurrentDevice.Orientation);
							this.ToolbarItems = new UIBarButtonItem[] { info, spaceFlexible, calculateExpense, spaceFlexible, resetList };
							break;
						case UIDeviceOrientation.FaceDown:
							Console.WriteLine("Orientation: " + UIDevice.CurrentDevice.Orientation);
							this.ToolbarItems = new UIBarButtonItem[] { info, spaceFlexible, calculateExpense, spaceFlexible, resetList };
							break;
						case UIDeviceOrientation.Unknown:
							Console.WriteLine("Orientation: " + UIDevice.CurrentDevice.Orientation);
							this.ToolbarItems = new UIBarButtonItem[] { info, spaceFlexible, calculateExpense, spaceFlexible, resetList };
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
									AI.AIEnglish("Error. You must enter a value for your expense", "en-US", 2.5f, 1.0f, 1.0f);
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

								Console.WriteLine("Name List Count: " + this.name.Count);
								Console.WriteLine("Expense Amount Count: " + this.expenseAmount.Count);
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

					cancel = UIAlertAction.Create("Cancel", UIAlertActionStyle.Cancel, (Action) => {
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

					UIAlertController alertDel = UIAlertController.Create("No values to delete", "You have to enter some values before they can be deleted", UIAlertControllerStyle.Alert);

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
		}

		UITableViewCell expensesCell = new UITableViewCell(UITableViewCellStyle.Subtitle, "Cell");
		NSIndexPath index = new NSIndexPath(); 

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

											textExpenses.Text = symbolCurrency + this.rentExpenses[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.rentName[indexPath.Row];
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

											textExpenses.Text = symbolCurrency + this.housingExpenses[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.housingName[indexPath.Row];
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

											textExpenses.Text = symbolCurrency + this.mortageExpenses[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.mortageName[indexPath.Row];
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

											textExpenses.Text = symbolCurrency + this.insuranceExpenses[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.insuranceName[indexPath.Row];
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

											textExpenses.Text = symbolCurrency + this.taxesExpenses[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.taxesName[indexPath.Row];
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

											textExpenses.Text = symbolCurrency + this.carPaymentsExpenses[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.carPaymentsName[indexPath.Row];
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

											textExpenses.Text = symbolCurrency + this.educationExpenses[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.educationName[indexPath.Row];
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

											textExpenses.Text = symbolCurrency + this.electronicsExpenses[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.electronicsName[indexPath.Row];
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

											textExpenses.Text = symbolCurrency + this.entertainmentExpenses[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.entertainmentName[indexPath.Row];
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

											textExpenses.Text = symbolCurrency + this.clothingExpenses[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.clothingName[indexPath.Row];
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

											textExpenses.Text = symbolCurrency + this.petsExpenses[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.petsName[indexPath.Row];
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

											textExpenses.Text = symbolCurrency + this.charityExpenses[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.charityName[indexPath.Row];
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

											textExpenses.Text = symbolCurrency + this.foodExpenses[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.foodName[indexPath.Row];
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

											textExpenses.Text = symbolCurrency + this.healthExpenses[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.healthName[indexPath.Row];
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

											textExpenses.Text = symbolCurrency + this.gardeningExpenses[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.gardeningName[indexPath.Row];
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

											textExpenses.Text = symbolCurrency + this.cleaningExpenses[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.cleaningName[indexPath.Row];
											expensesCell.DetailTextLabel.TextColor = UIColor.Gray;
											expensesCell.DetailTextLabel.MinimumFontSize = 14.0f;

											expensesCell.DetailTextLabel.AdjustsFontSizeToFitWidth = true;
											expensesCell.DetailTextLabel.AdjustsLetterSpacingToFitWidth = true;

											tableView.SectionIndexBackgroundColor = UIColor.Gray;
											tableView.SectionIndexColor = UIColor.Black;
											return expensesCell;

											break;

										case 16:

											expensesCell.AccessoryView = textExpenses;

											textExpenses.Text = symbolCurrency + this.utilitiesExpenses[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.utilitiesName[indexPath.Row];
											expensesCell.DetailTextLabel.TextColor = UIColor.Gray;
											expensesCell.DetailTextLabel.MinimumFontSize = 14.0f;

											expensesCell.DetailTextLabel.AdjustsFontSizeToFitWidth = true;
											expensesCell.DetailTextLabel.AdjustsLetterSpacingToFitWidth = true;

											tableView.SectionIndexBackgroundColor = UIColor.Gray;
											tableView.SectionIndexColor = UIColor.Black;
											return expensesCell;

											break;

										case 17:

											expensesCell.AccessoryView = textExpenses;

											textExpenses.Text = symbolCurrency + this.otherExpenses[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.otherName[indexPath.Row];
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

											textExpenses.Text = symbolCurrency + this.rentExpenses[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.rentName[indexPath.Row];
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

											textExpenses.Text = symbolCurrency + this.housingExpenses[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.housingName[indexPath.Row];
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

											textExpenses.Text = symbolCurrency + this.mortageExpenses[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.mortageName[indexPath.Row];
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

											textExpenses.Text = symbolCurrency + this.insuranceExpenses[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.insuranceName[indexPath.Row];
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

											textExpenses.Text = symbolCurrency + this.taxesExpenses[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.taxesName[indexPath.Row];
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

											textExpenses.Text = symbolCurrency + this.carPaymentsExpenses[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.carPaymentsName[indexPath.Row];
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

											textExpenses.Text = symbolCurrency + this.educationExpenses[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.educationName[indexPath.Row];
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

											textExpenses.Text = symbolCurrency + this.electronicsExpenses[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.electronicsName[indexPath.Row];
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

											textExpenses.Text = symbolCurrency + this.entertainmentExpenses[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.entertainmentName[indexPath.Row];
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

											textExpenses.Text = symbolCurrency + this.clothingExpenses[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.clothingName[indexPath.Row];
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

											textExpenses.Text = symbolCurrency + this.petsExpenses[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.petsName[indexPath.Row];
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

											textExpenses.Text = symbolCurrency + this.charityExpenses[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.charityName[indexPath.Row];
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

											textExpenses.Text = symbolCurrency + this.foodExpenses[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.foodName[indexPath.Row];
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

											textExpenses.Text = symbolCurrency + this.healthExpenses[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.healthName[indexPath.Row];
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

											textExpenses.Text = symbolCurrency + this.gardeningExpenses[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.gardeningName[indexPath.Row];
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

											textExpenses.Text = symbolCurrency + this.cleaningExpenses[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.cleaningName[indexPath.Row];
											expensesCell.DetailTextLabel.TextColor = UIColor.Gray;
											expensesCell.DetailTextLabel.MinimumFontSize = 14.0f;

											expensesCell.DetailTextLabel.AdjustsFontSizeToFitWidth = true;
											expensesCell.DetailTextLabel.AdjustsLetterSpacingToFitWidth = true;

											tableView.SectionIndexBackgroundColor = UIColor.Gray;
											tableView.SectionIndexColor = UIColor.Black;
											return expensesCell;

											break;

										case 16:

											expensesCell.AccessoryView = textExpenses;

											textExpenses.Text = symbolCurrency + this.utilitiesExpenses[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.utilitiesName[indexPath.Row];
											expensesCell.DetailTextLabel.TextColor = UIColor.Gray;
											expensesCell.DetailTextLabel.MinimumFontSize = 14.0f;

											expensesCell.DetailTextLabel.AdjustsFontSizeToFitWidth = true;
											expensesCell.DetailTextLabel.AdjustsLetterSpacingToFitWidth = true;

											tableView.SectionIndexBackgroundColor = UIColor.Gray;
											tableView.SectionIndexColor = UIColor.Black;
											return expensesCell;

											break;

										case 17:

											expensesCell.AccessoryView = textExpenses;

											textExpenses.Text = symbolCurrency + this.otherExpenses[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.otherName[indexPath.Row];
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

											textExpenses.Text = symbolCurrency + this.rentExpenses[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.rentName[indexPath.Row];
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

											textExpenses.Text = symbolCurrency + this.housingExpenses[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.housingName[indexPath.Row];
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

											textExpenses.Text = symbolCurrency + this.mortageExpenses[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.mortageName[indexPath.Row];
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

											textExpenses.Text = symbolCurrency + this.insuranceExpenses[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.insuranceName[indexPath.Row];
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

											textExpenses.Text = symbolCurrency + this.taxesExpenses[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.taxesName[indexPath.Row];
											expensesCell.DetailTextLabel.TextColor = UIColor.Gray;
											expensesCell.DetailTextLabel.MinimumFontSize = 14.0f;

											expensesCell.DetailTextLabel.AdjustsFontSizeToFitWidth = true;
											expensesCell.DetailTextLabel.AdjustsLetterSpacingToFitWidth = true;
											return expensesCell;

											break;
										case 5:

											expensesCell.AccessoryView = textExpenses;

											textExpenses.Text = symbolCurrency + this.carPaymentsExpenses[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.carPaymentsName[indexPath.Row];
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

											textExpenses.Text = symbolCurrency + this.educationExpenses[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.educationName[indexPath.Row];
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

											textExpenses.Text = symbolCurrency + this.electronicsExpenses[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.electronicsName[indexPath.Row];
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

											textExpenses.Text = symbolCurrency + this.entertainmentExpenses[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.entertainmentName[indexPath.Row];
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

											textExpenses.Text = symbolCurrency + this.clothingExpenses[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.clothingName[indexPath.Row];
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

											textExpenses.Text = symbolCurrency + this.petsExpenses[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.petsName[indexPath.Row];
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

											textExpenses.Text = symbolCurrency + this.charityExpenses[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.charityName[indexPath.Row];
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

											textExpenses.Text = symbolCurrency + this.foodExpenses[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.foodName[indexPath.Row];
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

											textExpenses.Text = symbolCurrency + this.healthExpenses[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.healthName[indexPath.Row];
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

											textExpenses.Text = symbolCurrency + this.gardeningExpenses[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.gardeningName[indexPath.Row];
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

											textExpenses.Text = symbolCurrency + this.cleaningExpenses[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.cleaningName[indexPath.Row];
											expensesCell.DetailTextLabel.TextColor = UIColor.Gray;
											expensesCell.DetailTextLabel.MinimumFontSize = 14.0f;

											expensesCell.DetailTextLabel.AdjustsFontSizeToFitWidth = true;
											expensesCell.DetailTextLabel.AdjustsLetterSpacingToFitWidth = true;

											tableView.SectionIndexBackgroundColor = UIColor.Gray;
											tableView.SectionIndexColor = UIColor.Black;
											return expensesCell;

											break;

										case 16:

											expensesCell.AccessoryView = textExpenses;

											textExpenses.Text = symbolCurrency + this.utilitiesExpenses[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.utilitiesName[indexPath.Row];
											expensesCell.DetailTextLabel.TextColor = UIColor.Gray;
											expensesCell.DetailTextLabel.MinimumFontSize = 14.0f;

											expensesCell.DetailTextLabel.AdjustsFontSizeToFitWidth = true;
											expensesCell.DetailTextLabel.AdjustsLetterSpacingToFitWidth = true;

											tableView.SectionIndexBackgroundColor = UIColor.Gray;
											tableView.SectionIndexColor = UIColor.Black;
											return expensesCell;

											break;

										case 17:

											expensesCell.AccessoryView = textExpenses;

											textExpenses.Text = symbolCurrency + this.otherExpenses[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.otherName[indexPath.Row];
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

											textExpenses.Text = symbolCurrency + this.rentExpenses[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.rentName[indexPath.Row];
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

											textExpenses.Text = symbolCurrency + this.housingExpenses[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.housingName[indexPath.Row];
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

											textExpenses.Text = symbolCurrency + this.mortageExpenses[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.mortageName[indexPath.Row];
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

											textExpenses.Text = symbolCurrency + this.insuranceExpenses[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.insuranceName[indexPath.Row];
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

											textExpenses.Text = symbolCurrency + this.taxesExpenses[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.taxesName[indexPath.Row];
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

											textExpenses.Text = symbolCurrency + this.carPaymentsExpenses[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.carPaymentsName[indexPath.Row];
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

											textExpenses.Text = symbolCurrency + this.educationExpenses[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.educationName[indexPath.Row];
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

											textExpenses.Text = symbolCurrency + this.electronicsExpenses[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.electronicsName[indexPath.Row];
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

											textExpenses.Text = symbolCurrency + this.entertainmentExpenses[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.entertainmentName[indexPath.Row];
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

											textExpenses.Text = symbolCurrency + this.clothingExpenses[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.clothingName[indexPath.Row];
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

											textExpenses.Text = symbolCurrency + this.petsExpenses[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.petsName[indexPath.Row];
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

											textExpenses.Text = symbolCurrency + this.charityExpenses[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.charityName[indexPath.Row];
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

											textExpenses.Text = symbolCurrency + this.foodExpenses[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.foodName[indexPath.Row];
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

											textExpenses.Text = symbolCurrency + this.healthExpenses[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.healthName[indexPath.Row];
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

											textExpenses.Text = symbolCurrency + this.gardeningExpenses[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.gardeningName[indexPath.Row];
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

											textExpenses.Text = symbolCurrency + this.cleaningExpenses[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.cleaningName[indexPath.Row];
											expensesCell.DetailTextLabel.TextColor = UIColor.Gray;
											expensesCell.DetailTextLabel.MinimumFontSize = 14.0f;

											expensesCell.DetailTextLabel.AdjustsFontSizeToFitWidth = true;
											expensesCell.DetailTextLabel.AdjustsLetterSpacingToFitWidth = true;

											tableView.SectionIndexBackgroundColor = UIColor.Gray;
											tableView.SectionIndexColor = UIColor.Black;
											return expensesCell;

											break;

										case 16:

											expensesCell.AccessoryView = textExpenses;

											textExpenses.Text = symbolCurrency + this.utilitiesExpenses[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.utilitiesName[indexPath.Row];
											expensesCell.DetailTextLabel.TextColor = UIColor.Gray;
											expensesCell.DetailTextLabel.MinimumFontSize = 14.0f;

											expensesCell.DetailTextLabel.AdjustsFontSizeToFitWidth = true;
											expensesCell.DetailTextLabel.AdjustsLetterSpacingToFitWidth = true;

											tableView.SectionIndexBackgroundColor = UIColor.Gray;
											tableView.SectionIndexColor = UIColor.Black;
											return expensesCell;

											break;

										case 17:

											expensesCell.AccessoryView = textExpenses;

											textExpenses.Text = symbolCurrency + this.otherExpenses[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.otherName[indexPath.Row];
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

											textExpenses.Text = symbolCurrency + this.rentExpenses[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.rentName[indexPath.Row];
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

											textExpenses.Text = symbolCurrency + this.housingExpenses[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.housingName[indexPath.Row];
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

											textExpenses.Text = symbolCurrency + this.mortageExpenses[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.mortageName[indexPath.Row];
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

											textExpenses.Text = symbolCurrency + this.insuranceExpenses[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.insuranceName[indexPath.Row];
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

											textExpenses.Text = symbolCurrency + this.taxesExpenses[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.taxesName[indexPath.Row];
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

											textExpenses.Text = symbolCurrency + this.carPaymentsExpenses[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.carPaymentsName[indexPath.Row];
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

											textExpenses.Text = symbolCurrency + this.educationExpenses[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.educationName[indexPath.Row];
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

											textExpenses.Text = symbolCurrency + this.electronicsExpenses[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.electronicsName[indexPath.Row];
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

											textExpenses.Text = symbolCurrency + this.entertainmentExpenses[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.entertainmentName[indexPath.Row];
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

											textExpenses.Text = symbolCurrency + this.clothingExpenses[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.clothingName[indexPath.Row];
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

											textExpenses.Text = symbolCurrency + this.petsExpenses[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.petsName[indexPath.Row];
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

											textExpenses.Text = symbolCurrency + this.charityExpenses[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.charityName[indexPath.Row];
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

											textExpenses.Text = symbolCurrency + this.foodExpenses[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.foodName[indexPath.Row];
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

											textExpenses.Text = symbolCurrency + this.healthExpenses[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.healthName[indexPath.Row];
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

											textExpenses.Text = symbolCurrency + this.gardeningExpenses[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.gardeningName[indexPath.Row];
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

											textExpenses.Text = symbolCurrency + this.cleaningExpenses[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.cleaningName[indexPath.Row];
											expensesCell.DetailTextLabel.TextColor = UIColor.Gray;
											expensesCell.DetailTextLabel.MinimumFontSize = 14.0f;

											expensesCell.DetailTextLabel.AdjustsFontSizeToFitWidth = true;
											expensesCell.DetailTextLabel.AdjustsLetterSpacingToFitWidth = true;

											tableView.SectionIndexBackgroundColor = UIColor.Gray;
											tableView.SectionIndexColor = UIColor.Black;
											return expensesCell;

											break;

										case 16:

											expensesCell.AccessoryView = textExpenses;

											textExpenses.Text = symbolCurrency + this.utilitiesExpenses[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.utilitiesName[indexPath.Row];
											expensesCell.DetailTextLabel.TextColor = UIColor.Gray;
											expensesCell.DetailTextLabel.MinimumFontSize = 14.0f;

											expensesCell.DetailTextLabel.AdjustsFontSizeToFitWidth = true;
											expensesCell.DetailTextLabel.AdjustsLetterSpacingToFitWidth = true;

											tableView.SectionIndexBackgroundColor = UIColor.Gray;
											tableView.SectionIndexColor = UIColor.Black;
											return expensesCell;

											break;

										case 17:

											expensesCell.AccessoryView = textExpenses;

											textExpenses.Text = symbolCurrency + this.otherExpenses[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.otherName[indexPath.Row];
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

											textExpenses.Text = symbolCurrency + this.rentExpenses[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.rentName[indexPath.Row];
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

											textExpenses.Text = symbolCurrency + this.housingExpenses[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.housingName[indexPath.Row];
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

											textExpenses.Text = symbolCurrency + this.mortageExpenses[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.mortageName[indexPath.Row];
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

											textExpenses.Text = symbolCurrency + this.insuranceExpenses[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.insuranceName[indexPath.Row];
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

											textExpenses.Text = symbolCurrency + this.taxesExpenses[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.taxesName[indexPath.Row];
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

											textExpenses.Text = symbolCurrency + this.carPaymentsExpenses[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.carPaymentsName[indexPath.Row];
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

											textExpenses.Text = symbolCurrency + this.educationExpenses[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.educationName[indexPath.Row];
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

											textExpenses.Text = symbolCurrency + this.electronicsExpenses[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.electronicsName[indexPath.Row];
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

											textExpenses.Text = symbolCurrency + this.entertainmentExpenses[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.entertainmentName[indexPath.Row];
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

											textExpenses.Text = symbolCurrency + this.clothingExpenses[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.clothingName[indexPath.Row];
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

											textExpenses.Text = symbolCurrency + this.petsExpenses[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.petsName[indexPath.Row];
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

											textExpenses.Text = symbolCurrency + this.charityExpenses[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.charityName[indexPath.Row];
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

											textExpenses.Text = symbolCurrency + this.foodExpenses[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.foodName[indexPath.Row];
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

											textExpenses.Text = symbolCurrency + this.healthExpenses[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.healthName[indexPath.Row];
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

											textExpenses.Text = symbolCurrency + this.gardeningExpenses[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.gardeningName[indexPath.Row];
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

											textExpenses.Text = symbolCurrency + this.cleaningExpenses[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.cleaningName[indexPath.Row];
											expensesCell.DetailTextLabel.TextColor = UIColor.Gray;
											expensesCell.DetailTextLabel.MinimumFontSize = 14.0f;

											expensesCell.DetailTextLabel.AdjustsFontSizeToFitWidth = true;
											expensesCell.DetailTextLabel.AdjustsLetterSpacingToFitWidth = true;

											tableView.SectionIndexBackgroundColor = UIColor.Gray;
											tableView.SectionIndexColor = UIColor.Black;
											return expensesCell;

											break;

										case 16:

											expensesCell.AccessoryView = textExpenses;

											textExpenses.Text = symbolCurrency + this.utilitiesExpenses[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.utilitiesName[indexPath.Row];
											expensesCell.DetailTextLabel.TextColor = UIColor.Gray;
											expensesCell.DetailTextLabel.MinimumFontSize = 14.0f;

											expensesCell.DetailTextLabel.AdjustsFontSizeToFitWidth = true;
											expensesCell.DetailTextLabel.AdjustsLetterSpacingToFitWidth = true;

											tableView.SectionIndexBackgroundColor = UIColor.Gray;
											tableView.SectionIndexColor = UIColor.Black;
											return expensesCell;

											break;

										case 17:

											expensesCell.AccessoryView = textExpenses;

											textExpenses.Text = symbolCurrency + this.otherExpenses[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.otherName[indexPath.Row];
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

											textExpenses.Text = symbolCurrency + this.rentExpenses[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.rentName[indexPath.Row];
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

											textExpenses.Text = symbolCurrency + this.housingExpenses[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.housingName[indexPath.Row];
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

											textExpenses.Text = symbolCurrency + this.mortageExpenses[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.mortageName[indexPath.Row];
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

											textExpenses.Text = symbolCurrency + this.insuranceExpenses[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.insuranceName[indexPath.Row];
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

											textExpenses.Text = symbolCurrency + this.taxesExpenses[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.taxesName[indexPath.Row];
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

											textExpenses.Text = symbolCurrency + this.carPaymentsExpenses[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.carPaymentsName[indexPath.Row];
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

											textExpenses.Text = symbolCurrency + this.educationExpenses[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.educationName[indexPath.Row];
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

											textExpenses.Text = symbolCurrency + this.electronicsExpenses[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.electronicsName[indexPath.Row];
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

											textExpenses.Text = symbolCurrency + this.entertainmentExpenses[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.entertainmentName[indexPath.Row];
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

											textExpenses.Text = symbolCurrency + this.clothingExpenses[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.clothingName[indexPath.Row];
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

											textExpenses.Text = symbolCurrency + this.petsExpenses[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.petsName[indexPath.Row];
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

											textExpenses.Text = symbolCurrency + this.charityExpenses[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.charityName[indexPath.Row];
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

											textExpenses.Text = symbolCurrency + this.foodExpenses[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.foodName[indexPath.Row];
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

											textExpenses.Text = symbolCurrency + this.healthExpenses[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.healthName[indexPath.Row];
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

											textExpenses.Text = symbolCurrency + this.gardeningExpenses[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.gardeningName[indexPath.Row];
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

											textExpenses.Text = symbolCurrency + this.cleaningExpenses[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.cleaningName[indexPath.Row];
											expensesCell.DetailTextLabel.TextColor = UIColor.Gray;
											expensesCell.DetailTextLabel.MinimumFontSize = 14.0f;

											expensesCell.DetailTextLabel.AdjustsFontSizeToFitWidth = true;
											expensesCell.DetailTextLabel.AdjustsLetterSpacingToFitWidth = true;

											tableView.SectionIndexBackgroundColor = UIColor.Gray;
											tableView.SectionIndexColor = UIColor.Black;
											return expensesCell;

											break;

										case 16:

											expensesCell.AccessoryView = textExpenses;

											textExpenses.Text = symbolCurrency + this.utilitiesExpenses[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.utilitiesName[indexPath.Row];
											expensesCell.DetailTextLabel.TextColor = UIColor.Gray;
											expensesCell.DetailTextLabel.MinimumFontSize = 14.0f;

											expensesCell.DetailTextLabel.AdjustsFontSizeToFitWidth = true;
											expensesCell.DetailTextLabel.AdjustsLetterSpacingToFitWidth = true;

											tableView.SectionIndexBackgroundColor = UIColor.Gray;
											tableView.SectionIndexColor = UIColor.Black;
											return expensesCell;

											break;

										case 17:

											expensesCell.AccessoryView = textExpenses;

											textExpenses.Text = symbolCurrency + this.otherExpenses[indexPath.Row];
											tableView.AddSubview(textExpenses);

											expensesCell.DetailTextLabel.Text = "Description: " + this.otherName[indexPath.Row];
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
					return this.categoryChosen.Count((arg) => arg.ToString() == "\ud83d\udecf Rent");
					break;

				case 1:
					//return this.categoryChosen.Count
					return this.categoryChosen.Count((arg) => arg.ToString() == "\ud83c\udfe1 Housing");
					break;

				case 2:

					return this.categoryChosen.Count((arg) => arg.ToString() == "\ud83d\udcb3 Mortgage");
					break;
				case 3:

					return this.categoryChosen.Count((arg) => arg.ToString() == "\ud83d\udc94 Insurance");
					break;

				case 4:

					return this.categoryChosen.Count((arg) => arg.ToString() == "\ud83d\udcd3 Taxes");
					break;

				case 5:

					return this.categoryChosen.Count((arg) => arg.ToString() == "\ud83d\ude97 Car Payments");
					break;

				case 6:

					return this.categoryChosen.Count((arg) => arg.ToString() == "\ud83d\udcda Education");
					break;

				case 7:

					return this.categoryChosen.Count((arg) => arg.ToString() == "\ud83d\udd0c Electronics");
					break;

				case 8:

					return this.categoryChosen.Count((arg) => arg.ToString() == "\ud83c\udfa5 Entertainment");
					break;

				case 9:

					return this.categoryChosen.Count((arg) => arg.ToString() == "\ud83d\udc55 Clothing & Footwear");
					break;

				case 10:

					return this.categoryChosen.Count((arg) => arg.ToString() == "\ud83d\udc08 Pets");
					break;

				case 11:

					return this.categoryChosen.Count((arg) => arg.ToString() == "\ud83c\udf81 Charity");
					break;

				case 12:

					return this.categoryChosen.Count((arg) => arg.ToString() == "\ud83c\udf54 Food");
					break;

				case 13:

					return this.categoryChosen.Count((arg) => arg.ToString() == "\ud83d\udc5f Health & Lifestyle");
					break;

				case 14:

					return this.categoryChosen.Count((arg) => arg.ToString() == "\ud83c\udf3b Gardening");
					break;

				case 15:

					return this.categoryChosen.Count((arg) => arg.ToString() == "✨ Cleaning & Maintanance");
					break;

				case 16:

					return this.categoryChosen.Count((arg) => arg.ToString() == "\ud83d\udec1 Utilities");
					break;

				case 17:

					return this.categoryChosen.Count((arg) => arg.ToString() == "\ud83d\uddde Other");
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
					return "\ud83d\udecf Rent"; //
					break;
				case 1:
					tableView.SectionIndexBackgroundColor = UIColor.Gray;
					tableView.SectionIndexColor = UIColor.Black;
					return "\ud83c\udfe1 Housing";//
					break;
				case 2:
					tableView.SectionIndexBackgroundColor = UIColor.Gray;
					tableView.SectionIndexColor = UIColor.Black;
					return "\ud83d\udcb3 Mortgage"; //
					break;

				case 3:
					tableView.SectionIndexBackgroundColor = UIColor.Gray;
					tableView.SectionIndexColor = UIColor.Black;
					return "\ud83d\udc94 Insurance";//
					break;

				case 4:
					tableView.SectionIndexBackgroundColor = UIColor.Gray;
					tableView.SectionIndexColor = UIColor.Black;
					return "\ud83d\udcd3 Taxes";//
					break;

				case 5:
					tableView.SectionIndexBackgroundColor = UIColor.Gray;
					tableView.SectionIndexColor = UIColor.Black;
					return "\ud83d\ude97 Car Payments";//
					break;
				case 6:
					tableView.SectionIndexBackgroundColor = UIColor.Gray;
					tableView.SectionIndexColor = UIColor.Black;
					return "\ud83d\udcda Education"; //
					break;

				case 7:
					tableView.SectionIndexBackgroundColor = UIColor.Gray;
					tableView.SectionIndexColor = UIColor.Black;
					return "\ud83d\udd0c Electronics";// 
					break;

				case 8:
					tableView.SectionIndexBackgroundColor = UIColor.Gray;
					tableView.SectionIndexColor = UIColor.Black;
					return "\ud83c\udfa5 Entertainment";//
					break;

				case 9:
					tableView.SectionIndexBackgroundColor = UIColor.Gray;
					tableView.SectionIndexColor = UIColor.Black;
					return "\ud83d\udc55 Clothing & Footwear";//
					break;
				case 10:
					tableView.SectionIndexBackgroundColor = UIColor.Gray;
					tableView.SectionIndexColor = UIColor.Black;
					return "\ud83d\udc08 Pets"; //
					break;

				case 11:
					tableView.SectionIndexBackgroundColor = UIColor.Gray;
					tableView.SectionIndexColor = UIColor.Black;
					return "\ud83c\udf81 Charity";//
					break;

				case 12:
					tableView.SectionIndexBackgroundColor = UIColor.Gray;
					tableView.SectionIndexColor = UIColor.Black;
					return "\ud83c\udf54 Food"; //
					break;
				case 13:
					tableView.SectionIndexBackgroundColor = UIColor.Gray;
					tableView.SectionIndexColor = UIColor.Black;
					return "\ud83d\udc5f Health & Lifestyle";
					break;
				case 14:
					tableView.SectionIndexBackgroundColor = UIColor.Gray;
					tableView.SectionIndexColor = UIColor.Black;
					return "\ud83c\udf3b Gardening";
					break;

				case 15:
					tableView.SectionIndexBackgroundColor = UIColor.Gray;
					tableView.SectionIndexColor = UIColor.Black;
					return "✨ Cleaning & Maintanance";
					break;

				case 16:
					tableView.SectionIndexBackgroundColor = UIColor.Gray;
					tableView.SectionIndexColor = UIColor.Black;
					return "\ud83d\udec1 Utilities";  //
					break;

				case 17:
					tableView.SectionIndexBackgroundColor = UIColor.Gray;
					tableView.SectionIndexColor = UIColor.Black;
					return "\ud83d\uddde Other";
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
							if (rentName.Count == 0)
							{
								throw new NullReferenceException();
							}
							else if (rentName.Count >= 1)
							{
								this.rentName.RemoveAt(indexPath.Row);
								this.rentExpenses.RemoveAt(indexPath.Row);
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
							if (housingName.Count == 0)
							{
								throw new NullReferenceException();
							}
							else if (housingName.Count >= 1)
							{
								this.housingName.RemoveAt(indexPath.Row);
								this.housingExpenses.RemoveAt(indexPath.Row);
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
							if (mortageName.Count == 0)
							{
								throw new NullReferenceException();
							}
							else if (mortageName.Count >= 1)
							{
								this.mortageName.RemoveAt(indexPath.Row);
								this.mortageExpenses.RemoveAt(indexPath.Row);
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
							if (insuranceName.Count == 0)
							{
								throw new NullReferenceException();
							}
							else if (insuranceName.Count >= 1)
							{
								this.insuranceName.RemoveAt(indexPath.Row);
								this.insuranceExpenses.RemoveAt(indexPath.Row);
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
							if (taxesName.Count == 0)
							{
								throw new NullReferenceException();
							}
							else if (taxesName.Count >= 1)
							{
								this.taxesName.RemoveAt(indexPath.Row);
								this.taxesExpenses.RemoveAt(indexPath.Row);
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
							if (carPaymentsName.Count == 0)
							{
								throw new NullReferenceException();
							}
							else if (carPaymentsName.Count >= 1)
							{
								this.carPaymentsName.RemoveAt(indexPath.Row);
								this.carPaymentsExpenses.RemoveAt(indexPath.Row);
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
							if (educationName.Count == 0)
							{
								throw new NullReferenceException();
							}
							else if (educationName.Count >= 1)
							{
								this.educationName.RemoveAt(indexPath.Row);
								this.educationExpenses.RemoveAt(indexPath.Row);
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
							if (electronicsName.Count == 0)
							{
								throw new NullReferenceException();
							}
							else if (electronicsName.Count >= 1)
							{
								this.electronicsName.RemoveAt(indexPath.Row);
								this.electronicsExpenses.RemoveAt(indexPath.Row);
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
							if (entertainmentName.Count == 0)
							{
								throw new NullReferenceException();
							}
							else if (entertainmentName.Count >= 1)
							{
								this.entertainmentName.RemoveAt(indexPath.Row);
								this.entertainmentExpenses.RemoveAt(indexPath.Row);
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
							if (clothingName.Count == 0)
							{
								throw new NullReferenceException();
							}
							else if (clothingName.Count >= 1)
							{
								this.clothingName.RemoveAt(indexPath.Row);
								this.clothingExpenses.RemoveAt(indexPath.Row);
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
							if (petsName.Count == 0)
							{
								throw new NullReferenceException();
							}
							else if (petsName.Count >= 1)
							{
								this.petsName.RemoveAt(indexPath.Row);
								this.petsExpenses.RemoveAt(indexPath.Row);
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
							if (charityName.Count == 0)
							{
								throw new NullReferenceException();
							}
							else if (charityName.Count >= 1)
							{
								this.charityName.RemoveAt(indexPath.Row);
								this.charityExpenses.RemoveAt(indexPath.Row);
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
							if (foodName.Count == 0)
							{
								throw new NullReferenceException();
							}
							else if (foodName.Count >= 1)
							{
								this.foodName.RemoveAt(indexPath.Row);
								this.foodExpenses.RemoveAt(indexPath.Row);
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
							if (healthName.Count == 0)
							{
								throw new NullReferenceException();
							}
							else if (healthName.Count >= 1)
							{
								this.healthName.RemoveAt(indexPath.Row);
								this.healthExpenses.RemoveAt(indexPath.Row);
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
							if (gardeningName.Count == 0)
							{
								throw new NullReferenceException();
							}
							else if (gardeningName.Count >= 1)
							{
								this.gardeningName.RemoveAt(indexPath.Row);
								this.gardeningExpenses.RemoveAt(indexPath.Row);
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
							if (cleaningName.Count == 0)
							{
								throw new NullReferenceException();
							}
							else if (cleaningName.Count >= 1)
							{
								this.cleaningName.RemoveAt(indexPath.Row);
								this.cleaningExpenses.RemoveAt(indexPath.Row);
							}

						}
						catch (NullReferenceException)
						{
							Console.WriteLine(":|");
						}

						break;
				
					case 17:
						try
						{
							if (utilitiesName.Count == 0)
							{
								throw new NullReferenceException();
							}
							else if (utilitiesName.Count >= 1)
							{
								this.utilitiesName.RemoveAt(indexPath.Row);
								this.utilitiesExpenses.RemoveAt(indexPath.Row);
							}

						}
						catch (NullReferenceException)
						{
							Console.WriteLine(":|");
						}

						break;
				
					case 18:
						try
						{
							if (otherName.Count == 0)
							{
								throw new NullReferenceException();
							}
							else if (otherName.Count >= 1)
							{
								this.otherName.RemoveAt(indexPath.Row);
								this.otherExpenses.RemoveAt(indexPath.Row);
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
	}

	public class CategoryTableDescription : UITableViewSource
	{
		ExpenseController expController = new ExpenseController();

		List<string> arrow = new List<string>() { "",">",
		">",">",">",">",">",">",">",">",">",">",">",">",">",">",">",">", ">"};

		List<string> categoryChoose = new List<string>(){
			{""},{"\ud83d\udecf Rent"},{"\ud83c\udfe1 Housing"},{"\ud83d\udcb3 Mortgage"},{"\ud83d\udc94 Insurance"},{"\ud83d\udcd3 Taxes"},{"\ud83d\ude97 Car Payments"},{"\ud83d\udcda Education"},{"\ud83d\udd0c Electronics"},
			{"\ud83c\udfa5 Entertainment"},{"\ud83d\udc55 Clothing & Footwear"},{"\ud83d\udc08 Pets"},{"\ud83c\udf81 Charity"},{"\ud83c\udf54 Food"},{"\ud83d\udc5f Health & Lifestyle"},{"\ud83c\udf3b Gardening"},
			{"✨ Cleaning & Maintanance"},{"\ud83d\udec1 Utilities"},{"\ud83d\uddde Other"}
		};

		UIViewController controller = new UIViewController();
		public CategoryTableDescription(UIViewController control, ExpenseController exp, UITableViewCell cell, NSIndexPath indexObject)
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

			if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone)
			{
				categoryCell.TextLabel.Text = categoryChoose[indexPath.Row];
				categoryCell.TextLabel.TextColor = UIColor.Black;

				categoryCell.DetailTextLabel.Text = arrow[indexPath.Row];
				categoryCell.DetailTextLabel.TextColor = UIColor.LightGray; 

				switch (UIApplication.SharedApplication.StatusBarOrientation)
				{
					case UIInterfaceOrientation.Portrait:
						tableView.RowHeight = 60.0f;
						break;
					case UIInterfaceOrientation.PortraitUpsideDown:
						tableView.RowHeight = 60.0f;
						break;
					default:
						tableView.RowHeight = 80.0f;
						break;
				}
			}
			else if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
			{
				categoryCell.TextLabel.Text = categoryChoose[indexPath.Row];
				categoryCell.TextLabel.TextColor = UIColor.Black;

				categoryCell.DetailTextLabel.Text = arrow[indexPath.Row];
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
					expController.name.RemoveAt(expController.name.Count - 1);
					expController.expenseAmount.RemoveAt(expController.expenseAmount.Count - 1); 
					controller.DismissViewController(true, null);
					break;
				case 1:
					expController.categoryChosen.Add(expController.category[1]);
					int index = expController.categoryChosen.FindLastIndex((string obj) => obj.ToString() == "\ud83d\udecf Rent");
					expController.rentExpenses.Add(expController.expenseAmount[index]);
					expController.rentName.Add(expController.name[index]);

					controller.DismissViewController(true, () =>
					{
						expController.TableView.ReloadData();
					});

					break;
				case 2:
					expController.categoryChosen.Add(expController.category[2]);
					int indexHousing = expController.categoryChosen.FindLastIndex((string obj) => obj.ToString() == "\ud83c\udfe1 Housing");
					expController.housingExpenses.Add(expController.expenseAmount[indexHousing]);
					expController.housingName.Add(expController.name[indexHousing]);

					tableView.ScrollToNearestSelected(UITableViewScrollPosition.Top, true);
					controller.DismissViewController(true, () =>
					{
						expController.TableView.ReloadData();
					});

					break;
				case 3:
					expController.categoryChosen.Add(expController.category[3]);
					int indexMortage = expController.categoryChosen.FindLastIndex((string obj) => obj.ToString() == "\ud83d\udcb3 Mortgage");
					expController.mortageExpenses.Add(expController.expenseAmount[indexMortage]);
					expController.mortageName.Add(expController.name[indexMortage]);


					controller.DismissViewController(true, () =>
					{
						expController.TableView.ReloadData();
					});

					break;
				case 4:
					expController.categoryChosen.Add(expController.category[4]);
					int indexInsurance = expController.categoryChosen.FindLastIndex((string obj) => obj.ToString() == "\ud83d\udc94 Insurance");
					expController.insuranceExpenses.Add(expController.expenseAmount[indexInsurance]);
					expController.insuranceName.Add(expController.name[indexInsurance]);

					controller.DismissViewController(true, () =>
					{
						expController.TableView.ReloadData();
					});

					break;
				case 5:
					expController.categoryChosen.Add(expController.category[5]);
					int indexTaxes = expController.categoryChosen.FindLastIndex((string obj) => obj.ToString() == "\ud83d\udcd3 Taxes");
					expController.taxesExpenses.Add(expController.expenseAmount[indexTaxes]);


					expController.taxesName.Add(expController.name[indexTaxes]);
					controller.DismissViewController(true, () =>
					{
						expController.TableView.ReloadData();
					});

					break;
				case 6:
					expController.categoryChosen.Add(expController.category[6]);
					int indexCarPayments = expController.categoryChosen.FindLastIndex((string obj) => obj.ToString() == "\ud83d\ude97 Car Payments");
					expController.carPaymentsExpenses.Add(expController.expenseAmount[indexCarPayments]);
					expController.carPaymentsName.Add(expController.name[indexCarPayments]);

					controller.DismissViewController(true, () =>
					{
						expController.TableView.ReloadData();
					});

					break;
				case 7:
					expController.categoryChosen.Add(expController.category[7]);
					int indexEducation = expController.categoryChosen.FindLastIndex((string obj) => obj.ToString() == "\ud83d\udcda Education");
					expController.educationExpenses.Add(expController.expenseAmount[indexEducation]);
					expController.educationName.Add(expController.name[indexEducation]);


					controller.DismissViewController(true, () =>
					{
						expController.TableView.ReloadData();
					});

					break;
				case 8:
					expController.categoryChosen.Add(expController.category[8]);
					int indexElectronics = expController.categoryChosen.FindLastIndex((string obj) => obj.ToString() == "\ud83d\udd0c Electronics");
					expController.electronicsExpenses.Add(expController.expenseAmount[indexElectronics]);
					expController.electronicsName.Add(expController.name[indexElectronics]);


					controller.DismissViewController(true, () =>
					{
						expController.TableView.ReloadData();
					});

					break;
				case 9:
					expController.categoryChosen.Add(expController.category[9]);
					int indexEntertainment = expController.categoryChosen.FindLastIndex((string obj) => obj.ToString() == "\ud83c\udfa5 Entertainment");
					expController.entertainmentExpenses.Add(expController.expenseAmount[indexEntertainment]);
					expController.entertainmentName.Add(expController.name[indexEntertainment]);


					controller.DismissViewController(true, () =>
					{
						expController.TableView.ReloadData();
					});

					break;
				case 10:
					expController.categoryChosen.Add(expController.category[10]);
					int indexClothing = expController.categoryChosen.FindLastIndex((string obj) => obj.ToString() == "\ud83d\udc55 Clothing & Footwear");
					expController.clothingExpenses.Add(expController.expenseAmount[indexClothing]);
					expController.clothingName.Add(expController.name[indexClothing]);


					controller.DismissViewController(true, () =>
					{
						expController.TableView.ReloadData();
					});

					break;
				case 11:
					expController.categoryChosen.Add(expController.category[11]);
					int indexPets = expController.categoryChosen.FindLastIndex((string obj) => obj.ToString() == "\ud83d\udc08 Pets");
					expController.petsExpenses.Add(expController.expenseAmount[indexPets]);


					expController.petsName.Add(expController.name[indexPets]);
					controller.DismissViewController(true, () =>
					{
						expController.TableView.ReloadData();
					});

					break;
				case 12:
					expController.categoryChosen.Add(expController.category[12]);
					int indexCharity = expController.categoryChosen.FindLastIndex((string obj) => obj.ToString() == "\ud83c\udf81 Charity");
					expController.charityExpenses.Add(expController.expenseAmount[indexCharity]);
					expController.charityName.Add(expController.name[indexCharity]);


					controller.DismissViewController(true, () =>
					{
						expController.TableView.ReloadData();
					});

					break;
				case 13:
					expController.categoryChosen.Add(expController.category[13]);
					int indexFood = expController.categoryChosen.FindLastIndex((string obj) => obj.ToString() == "\ud83c\udf54 Food");
					expController.foodExpenses.Add(expController.expenseAmount[indexFood]);
					expController.foodName.Add(expController.name[indexFood]);


					controller.DismissViewController(true, () =>
					{
						expController.TableView.ReloadData();
					});

					break;
				case 14:
					expController.categoryChosen.Add(expController.category[14]);
					int indexHealth = expController.categoryChosen.FindLastIndex((string obj) => obj.ToString() == "\ud83d\udc5f Health & Lifestyle");
					expController.healthExpenses.Add(expController.expenseAmount[indexHealth]);
					expController.healthName.Add(expController.name[indexHealth]);

					controller.DismissViewController(true, () =>
					{
						expController.TableView.ReloadData();
					});

					break;
				case 15:
					expController.categoryChosen.Add(expController.category[15]);
					int indexGardening = expController.categoryChosen.FindLastIndex((string obj) => obj.ToString() == "\ud83c\udf3b Gardening");
					expController.gardeningExpenses.Add(expController.expenseAmount[indexGardening]);
					expController.gardeningName.Add(expController.name[indexGardening]);


					controller.DismissViewController(true, () =>
					{
						expController.TableView.ReloadData();
					});

					break;
				case 16:
					expController.categoryChosen.Add(expController.category[16]);
					int indexCleaning = expController.categoryChosen.FindLastIndex((string obj) => obj.ToString() == "✨ Cleaning & Maintanance");
					expController.cleaningExpenses.Add(expController.expenseAmount[indexCleaning]);
  					expController.cleaningName.Add(expController.name[indexCleaning]);


					controller.DismissViewController(true, () =>
					{
						expController.TableView.ReloadData();
					});

					break;
				case 17:
					expController.categoryChosen.Add(expController.category[17]);
					int indexUtilities = expController.categoryChosen.FindLastIndex((string obj) => obj.ToString() == "\ud83d\udec1 Utilities");
					expController.utilitiesExpenses.Add(expController.expenseAmount[indexUtilities]);
					expController.utilitiesName.Add(expController.name[indexUtilities]);


					controller.DismissViewController(true, () =>
					{
						expController.TableView.ReloadData();
					});

					break;
				case 18:
					expController.categoryChosen.Add(expController.category[18]);
					int otherIndex = expController.categoryChosen.FindLastIndex((string obj) => obj.ToString() == "\ud83d\uddde Other");
					expController.otherExpenses.Add(expController.expenseAmount[otherIndex]);
					expController.otherName.Add(expController.name[otherIndex]);


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


	public class TableController : UITableViewController
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

		public override void ViewDidAppear(bool animated)
		{
			UIApplication.SharedApplication.SetStatusBarHidden(true, UIStatusBarAnimation.Slide);
		}

		public override void ViewDidLoad()
		{
			UINavigationBar nav = new UINavigationBar();

			UIBarButtonItem cancel = new UIBarButtonItem("Cancel", UIBarButtonItemStyle.Bordered, (object sender, EventArgs e) => {
				this.DismissViewController(true, null);
			});

			cancel.TintColor = UIColor.Red;

			//set up nav item to hold the cancel button and a description of the controller
			UINavigationItem navItem = new UINavigationItem();
			navItem.Title = "Choose your category";

			navItem.LeftBarButtonItem = cancel;

			nav.Items = new UINavigationItem[] {navItem};

			nav.Frame = new CGRect(0, 0, this.View.Bounds.Width, 50);
			nav.TintColor = UIColor.Red;

			this.View.BringSubviewToFront(nav);
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
