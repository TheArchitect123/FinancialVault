using System;
using System.Collections;
using System.Collections.Generic;


namespace FinanceCalculator
{
	public class IncomeCarrierData
	{

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

		public IncomeCarrierData(){}

		public IncomeCarrierData(List<double> wages, List<double> realestate, List<double> salesHouseStock, List<double> smallBusiness, List<double> gamblingWinnings, List<double> salesOfTrades, List<double> intellectualProperty, List<double> appRoyalties, List<double> bookPublishing, List<double> tradeDividends,
										  List<double> bankInterest, List<double> taxReturn, List<double> studentLoan, List<double> inheritance, List<double> prizeMoney, List<double> otherMoney,
		                        List<string> _wagesName, List<string> _realestateName,List<string> _salesHouseStockName, List<string> _smallBusinessName, List<string> _gamblingWinningsName, List<string> _salesOfTradesName, List<string> _intellectualPropertyName, List<string> _appRoyaltiesName, List<string> _bookPublishingName, List<string> _tradeDividendsName,
		                        List<string> _bankInterestName, List<string> _taxReturnName, List<string> _studentLoanName,List<string> _inheritanceName,List<string> _prizeMoneyName, List<string> _otherIncomeName) {
			wagesIncome = wages;
			realestateIncome = realestate;
			salesHouseIncome = salesHouseStock;
			smallBusinessIncome = smallBusiness;
			gamblingIncome = gamblingWinnings;
			salesTradesIncome = salesOfTrades;
			intellectualPropertyIncome = intellectualProperty;
			appRoyaltiesIncome = appRoyalties;
			bookPublishingIncome = bookPublishing;
			tradeDividendsIncome = tradeDividends;
			bankInterestIncome = bankInterest;
			taxReturnIncome = taxReturn;
			studentLoadIncome = studentLoan;
			inheritanceIncome = inheritance;
			prizeIncome = prizeMoney;
			otherIncome = otherMoney;

			wagesName = _wagesName;
			realestateName = _realestateName;
			salesHouseName = _salesHouseStockName;
			smallBusinessName = _smallBusinessName;
			gamblingName = _gamblingWinningsName;
			salesTradesName = _salesOfTradesName;
			intellectualPropertyName = _intellectualPropertyName;
			appRoyaltiesName = _appRoyaltiesName;
			bookPublishingName = _bookPublishingName;
			tradeDividendsName = _tradeDividendsName;
			bankInterestName = _bankInterestName;
			taxReturnName = _taxReturnName;
			studentLoadName = _studentLoanName;
			inheritanceName = _inheritanceName;
			prizeName = _prizeMoneyName;
			otherIncomeName = _otherIncomeName;
		}

		//The income budget controller will access a method which will return these values.  These values will then be rendered across 
		//the income and expenses controllers

		public List<Double> wagesReturn() {
			return wagesIncome;
		}


		public void checkListCount() {
			Console.WriteLine("wages Income Count: " + wagesIncome.Count);
			Console.WriteLine("wages Name Count: " + wagesName.Count);
		}
	}
}

