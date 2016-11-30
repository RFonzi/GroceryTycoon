    using System;
    using System.Data;
	using System.Collections.Generic;

/*
 *  Contains data for networth (factor in stock, upgrades, cash), each with a timestamp of the in-game time
Networth = cash on hand at end of day + purchase value of upgrades + purchase value of inventory
Data to keep track of: list with 3 pieces of data per entry (array of structs???) with cash difference,
day, and reason (limited reasons e.g. staff, operational costs, etc). Example: If a customer purchased an item that day,
search in this list based on entries matching the current day, search reasons maching the reason we care about (e.g. customer purchases), 
and then add the amount the customer paid for to that list. (THIS IS COMPLICATED BUT I WANT IT)
*/
namespace tycoon
	{

		public class financial
		{
        // creates 3 columns for the data table, can add more if needed

        public void Start()

        {
            data.Columns.Add("Day", typeof(int));
            data.Columns.Add("Value", typeof(double));
            data.Columns.Add("Reason", typeof(string));
        }
        // Update is called once per frame

        void Update()
        {

        }

        double upgradesValue;
        int day;
        string reason;
        double netWorth;


        //creates a data table to store the data
        DataTable data = new DataTable("Financial Data");

        // A list that stores the transaction data 
        List<List<double>> DateList = new List<List<double>>();

        //returns networth which is goods value is number of item * price bought
        // May need to change so that goodsValue is based on base price of goods, or trading could break it if just based on buy price

        public void calculateNetWorth(double money, List<GameItem>[] inventory)

        {
            netWorth = (money + calculateGoodsValue(inventory) + getUpgradesValue());
        }

        public double getNetWorth()
        {
            return netWorth;
        }

        public double getUpgradesValue()
        {
            return upgradesValue;
        }

        //add to the upgrades total
        public void addUpgradesValue(double value)
        {
            upgradesValue += value;
        }

        //This data list is to store the data for the end of each day since the data table stores data per transaction
        void storeEndDayData(double money, List<GameItem>[] inventory)
        {
            calculateNetWorth(money, inventory);

            DateList.Add(new List<double> { getNetWorth(), money, calculateGoodsValue(inventory), getUpgradesValue() });
        }

        //Can add more reasons as needed
        //possible reasons case sensitive CustomerPurchase, UpgradePurchase, StaffWages, ItemsOrdered, OperationalCost, Trade, ItemsExpired, Misc
        //Need to make sure other classes call this function to store data when needed ( ex customer purchases something)
        public void storeTransaction(int day, int value, string reason)
        {
            if (String.Compare(reason, "StaffWages") == 0)
            {
            }
            else if (String.Compare(reason, "CustomerPurchase") == 0)
            {
            }
            else if (String.Compare(reason, "UpgradePurchase") == 0)
            {
            }
            else if (String.Compare(reason, "ItemsOrdered") == 0)
            {
            }
            else if (String.Compare(reason, "OperationalCost") == 0)
            {
            }
            else if (String.Compare(reason, "Trade") == 0)
            {
            }
            else if (String.Compare(reason, "ItemsExpired") == 0)
            {
            }
            else if (String.Compare(reason, "Misc") == 0)
            {
            }
            else
            {
                throw new System.ArgumentException(reason + " Is not a valid reason for storeTransaction()");
            }

            data.Rows.Add(day, value, reason);
        }

        //prints out the transaction table to console
        public void printTransactions()
        {
            // Formats text to be easier to read
            Console.WriteLine("{0,-15}{1,-15}{2,-15}", "Day", "Value", "Reason");
            foreach (DataRow dataRow in data.Rows)
            {
                foreach (var item in dataRow.ItemArray)
                {
                    Console.Write("{0,-15}", item + "      ");
                }
                Console.WriteLine();
            }
        }

        //returns a data table with information from only the day specified
        public DataTable searchDate(int Date)
        {
            int column = 0;
            DataTable dateSearch = data.Clone();

            foreach (DataRow dataRow in data.Rows)
            {

                foreach (var item in dataRow.ItemArray)
                {

                    if (column == 0)
                    {
                        if (item.Equals(Date))
                        {
                            dateSearch.ImportRow(dataRow);
                        }
                    }
                    column++;
                }
                column = 0;
            }

            return dateSearch;

        }

        //returns a table with all data rows based on the reason specified
        public DataTable searchReason(string Reason)
        {
            int column = 0;
            DataTable reasonSearch = data.Clone();

            foreach (DataRow dataRow in data.Rows)
            {

                foreach (var item in dataRow.ItemArray)
                {

                    if (column == 2)
                    {
                        if (item.Equals(Reason))
                        {
                            reasonSearch.ImportRow(dataRow);
                        }
                    }
                    column++;
                }
                column = 0;
            }

            return reasonSearch;

        }
        //returns a table with all data rows based on the exact amount of money specified
        public DataTable searchMoney(double Money)
        {
            int column = 0;
            DataTable moneySearch = data.Clone();

            foreach (DataRow dataRow in data.Rows)
            {

                foreach (var item in dataRow.ItemArray)
                {

                    if (column == 1)
                    {
                        if (item.Equals(Money))
                        {
                            moneySearch.ImportRow(dataRow);
                        }
                    }
                    column++;
                }
                column = 0;
            }

            return moneySearch;

        }

        //prints a data table from one of the searches above
        public void printTable(DataTable table)
        {

            // Formats text to be easier to read
            Console.WriteLine("{0,-15}{1,-15}{2,-15}", "Day", "Value", "Reason");
            foreach (DataRow dataRow in table.Rows)
            {
                foreach (var item in dataRow.ItemArray)
                {
                    Console.Write("{0,-15}", item + "      ");
                }
                Console.WriteLine();
            }
        }

        //need getters for price and expiration or need them to be public
        public double calculateGoodsValue(List<GameItem>[] GoodsList)
        {
            double goodsValue = 0;

            foreach (var Item in GoodsList)
            {
                for(int i = 0; i < Item.Count;i++)
                {
                    if(Item[i].getExpiration() > 0)
                    {
                        goodsValue += Item[i].getBasePrice();
                    }
                }

            }

            return goodsValue;

        }

        //sums up the values columns of the rows of a given table
        //Ex searchReason("StaffWages") then call this with the returned datatable
        //to sum up the amount of money spent on staff wages
        public double sumValuesRows(DataTable table)
        {
            double sum = 0;

            foreach (DataRow dr in table.Rows)
            {
                string value = dr["Value"].ToString();
                sum += Convert.ToDouble(value);
            }

            return sum;
        }


    }
}
