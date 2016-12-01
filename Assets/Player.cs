using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace tycoon
{
    public class Player:MonoBehaviour
    {
        SimState simState; 
        public Player() {
            simState = SimState.Instance;
            for (int i = 0; i < inventory.Length; i++) // initialize group
            {
                inventory[i] = new List<GameItem>();
            }
            customers = new List<Customer>();
            money = 100;

            // set default values for all item types
            //GameItem.Items[] values = (GameItem.Items[])System.Enum.GetValues(typeof(GameItem.Items));
            //for(int i = 0; i < 25; i++)
            //{

            //}
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
        public double operatingCost = 500;
        float last;
        float timePerHour = 30;
        double money;
        public int invCapacity = 100; // default
        int custCapacity = 100; // default
        List<GameItem>[] inventory = new List<GameItem>[25];
        List<Customer> customers;
        List< List<GameItem>>orderHistory = new List< List<GameItem>>();
        List<GameItem> order = new List<GameItem> ();
        public int secondsPerDay = 240;
        public double timeElapsed;
        public double timeLast;
        public double lossFromExpired= 0;

        public double inventoryUpgradeCost = 50;
        public double customerUpgradeCost = 50;
        public double operatingUpgradeCost = 500;

        public int inventoryUpgradeFactor = 10;
        public float customerUpgradeFactor = -.01f;
        public double operatingUpgradeFactor = 50;

        public int day { get; set; }
        public int hour { get; set; }

        public string storeName;
        //default opening closing hours
        //24 hour clock
        public int openingHour = 7;
        public int closingHour = 23;
        
        // adds a specific item to the correct item list
        public void addItem(GameItem item)
        {
            print("add item");
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
        public void addExpiration()
        {
            for(int i = 0; i < inventory.Length;i++)
            {
                if(inventory[i] != null)
                {
                    for(int j = 0; j < inventory[i].Count;j++)
                    {
                        foreach(GameItem item in inventory[i])
                        {
                            item.decrementExpiration();
                        }
                    }
                }
            }
            
        }
        public void removeExpired()
        {
            for (int i = 0; i < inventory.Length; i++)
            {
                if (inventory[i] != null)
                {
                    for (int j = 0; j < inventory[i].Count; j++)
                    {
                        foreach (GameItem item in inventory[i])
                        {
                            if(item.getExpiration() <= 0)
                            {
                                lossFromExpired += item.getBuyPrice();
                                deleteItem(item);
                            }
                        }
                    }
                }
            }
        }

        public void setItemPrice(int id, double price)
        {
            if(inventory[id] != null)
            {
                foreach(GameItem item in inventory[id])
                {
                    item.setSellPrice(price);
                }
            }
        }

    }
}

