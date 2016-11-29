﻿using System.Collections;
using System.Collections.Generic;

namespace tycoon
{
    public class Player
    {

        public Player() {
            for (int i = 0; i < inventory.Length; i++) // initialize group
            {
                inventory[i] = new List<GameItem>();
            }
            customers = new List<Customer>();

            day = 0;
            hour = 0;
        }

            /*if(Time.time - last >= timePerHour)
            {
                last = Time.time;
                hour++;

                if(hour >= 24)
                {
                    day++;
                    hour = 0;
                }
            } */

        float last;
        float timePerHour = 30;
        double money;
        int invCapacity = 100; // default
        int custCapacity = 100; // default
        List<GameItem>[] inventory = new List<GameItem>[25];
        List<Customer> customers;
        List< List<GameItem>>orderHistory = new List< List<GameItem>>();
        List<GameItem> order = new List<GameItem> ();

        int day { get; set; }
        int hour { get; set; }

        public string storeName;
        //default opening closing hours
        //24 hour clock
        public int openingHour = 7;
        public int closingHour = 23;
        
        // adds a specific item to the correct item list
        public void addItem(GameItem item)
        {
            int itemID = item.getItemID();
            if (getInventorySize() >= invCapacity)
                return;

            if(item.getBasePrice() <= money) {
                inventory[itemID].Add(item);
                money -= item.getBasePrice();
                recordOrder(item);
            }
            
            
        }

        // deletes an item from the correct item list
        public void deleteItem(GameItem item)
        {
            int itemID = item.getItemID();
            if (!inventory[itemID].Contains(item))
                return;
            inventory[itemID].Remove(item);
            
        }

        // adds an array of items, putting them all into the correct list
        //also adds them to a list for the order history
        public void addItems(GameItem[] items)
        {
            if(order.Count >= 0)
            {
                order.Clear();
            }
            

            if ((getInventorySize() + items.Length) > invCapacity)
                return;
            for (int i = 0; i < items.Length; i++)
            {
                int itemID = items[i].getItemID();

                if (items[i].getBasePrice() <= money) {
                    inventory[itemID].Add(items[i]);
                    money -= items[i].getBasePrice();
                }

                order.Add(items[i]);
            }

            recordOrder(order);
        }

        // adds a customer to the store
        void addCustomer()
        {
            if (customers.Count < custCapacity)
                customers.Add(new tycoon.Customer(getInventory()));
        }

        //returns the stores inventory
        public List<GameItem>[] getInventory()
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

        //if 1 item ordered adds to a list then adds to the order history
        public void recordOrder(GameItem item)
        {
            if(order.Count >= 0)
            {
                order.Clear();
            }
            order.Add(item);

            orderHistory.Add(new List<GameItem>(order));
        }
        
        public void recordOrder(List <GameItem> items)
        {
            orderHistory.Add(new List<GameItem>(items));
        }

        public List<List<GameItem>> getOrderHistory()
        {
            return orderHistory;
        }

        public void returnItem(GameItem item)
        {
            //get half of your money back if return item
            money +=  .5 * item.getBasePrice();
            deleteItem(item);
        }

        public void removeExpired(GameItem item)
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

        public void addMoney(double income)
        {
            money += income;
        }
        public void subtractMoney(double loss)
        {
            money -= loss;
        }

        public void sellItem(GameItem item)
        {
            addMoney(item.getSellPrice());
           
            deleteItem(item);

        }
        public int getQuantity(GameItem itemType)
        {
            int id = itemType.getItemID();
            return inventory[id].Count;
        }
    }
}

