using UnityEngine;
using System.Collections;
using System;
using System.Data;
using System.Collections.Generic;

namespace financial
{


    public class financial : MonoBehaviour
    {


        // creates 3 columns for the data table, can add more if needed
        public void Start()
        {
            data.Columns.Add("Day", typeof(int));
            data.Columns.Add("Cash Difference", typeof(double));
            data.Columns.Add("Reason", typeof(string));
        }

        // Update is called once per frame
        void Update()
        {
            //stores the daily data might need to change
            if (endDay)
            {
                net();
                StoreEndDayData();
                day++;
            }
        }

        public int cash;
        public int goodsValue;
        public int upgradesValue;
        int netWorth;
        int day;
        public bool endDay;
        public string reason;

        //creates a data table to store the data
        DataTable data = new DataTable("Financial Data");


        // A list that stores the transaction data 
        List<List<int>> DateList = new List<List<int>>();

        //returns networth which is goods value is number of item * price bought
        void net()
        {
            netWorth = cash + goodsValue + upgradesValue;
        }

        //This data list is to store the data for the end of each day since the data table stores data per transaction
        void StoreEndDayData()
        {
            DateList.Add(new List<int> { netWorth, cash, goodsValue, upgradesValue });
        }

        //possible reasons  CustomerPurchase, UpgradePurchase, StaffWages, ItemsOrdered, OperationalCosts, Trade, ItemsExpired
        //need to be spelled the same everytime
        public void StoreTransaction(int day, int value, string reason)
        {
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
            DataTable dateSearch = data.Clone();

            foreach (DataRow dataRow in data.Rows)
            {

                foreach (var item in dataRow.ItemArray)
                {

                    if (column == 2)
                    {
                        if (item.Equals(Reason))
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
        //returns a table with all data rows based on the exact amount of money specified
        public DataTable searchMoney(double Money)
        {
            int column = 0;
            DataTable dateSearch = data.Clone();

            foreach (DataRow dataRow in data.Rows)
            {

                foreach (var item in dataRow.ItemArray)
                {

                    if (column == 1)
                    {
                        if (item.Equals(Money))
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
    }

}