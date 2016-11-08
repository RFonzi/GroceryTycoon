﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace tycoon
{
    public class Player : MonoBehaviour
    {

        // Use this for initialization
        void Start()
        {
            for (int i = 0; i < inventory.Length; i++) // initialize group
            {
                inventory[i] = new List<Item>();
            }
            customers = new List<Customer>();

        }

        // Update is called once per frame
        void Update()
        {

        }

        double money;
        int invCapacity = 100; // default
        int custCapacity = 100; // default
        List<Item>[] inventory = new List<Item>[25];
        List<Customer> customers;
        List<Item> orderHistory = new List<Item>();

        public string storeName;
        //default opening closing hours
        //24 hour clock
        public int openingHour = 7;
        public int closingHour = 23;
        
        // adds a specific item to the correct item list
        void addItem(Item item)
        {
            int itemID = item.getItemID();
            if (inventory[itemID].Count >= invCapacity)
                return;
            inventory[itemID].Add(item);
            recordOrder(item);
        }

        // deletes an item from the correct item list
        void deleteItem(Item item)
        {
            int itemID = item.getItemID();
            if (!inventory[itemID].Contains(item))
                return;
            inventory[itemID].Remove(item);
            
        }

        // adds an array of items, putting them all into the correct list
        void addItems(Item[] items)
        {
            if ((getInventorySize() + items.Length) < invCapacity)
                return;
            for (int i = 0; i < items.Length; i++)
            {
                int itemID = items[i].getItemID();
                inventory[itemID].Add(items[i]);
            }
        }

        // adds a customer to the store
        void addCustomer()
        {
            if (customers.Count < custCapacity)
                customers.Add(new tycoon.Customer(getInventory()));
        }

        //returns the stores inventory
        public List<Item>[] getInventory()
        {
            return inventory;
        }

        //returns the players money
        public double getMoney()
        {
            return money;
        }

        //returns the size of the players inventory
        public int getInventorySize()
        {
            int tot = 0;
            for (int i = 0; i < inventory.Length; i++)
            {
                tot += inventory[i].Count;
            }
            return tot;
        }

        public void recordOrder(Item item)
        {
            orderHistory.Add(item);
        }

        public List getOrderHistory()
        {
            return orderHistory;
        }

        public void returnItem(Item item)
        {
            //get half of your money back if return item
            money +=  .5 * item.getBasePrice();
            deleteItem(item);
        }

        public void removeExpired(Item item)
        {
            deleteItem(item);
        }
        public void setStoreHours(int opening, int closing)
        {
            openingHour = opening;
            closingHour = closing;
        }

        public void setStorename(string name)
        {
            storeName = name;
        }
    }
}

