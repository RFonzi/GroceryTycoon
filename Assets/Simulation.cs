using System.Collections;
using System.Collections.Generic;
using System;
using System.Threading;

namespace tycoon
{


    public class Simulation
    {

        int customerCount;

        List<Customer> customerList;

        public Player player;

        public financial fin;

        public double last;

        public double timeBetweenCustomers;

        public Simulation() {
            player = new Player();
            fin = new financial();
            customerList = new List<Customer>();
            timeBetweenCustomers = 5;
            customerCount = 0;

        }


        public void addCustomer(Customer customer)
        {
            //sets ID for customer
            customer.ID = customerCount;
            customerCount++;

            customerList.Add(customer);
        }

        //finds a customer based on id
        Customer checkCustomer(int id)
        {
            for (int i = 0; i < customerList.Count; i++)
            {
                Customer compareCustomer = customerList[i];

                if (compareCustomer.ID == id)
                {
                    return compareCustomer;
                }
            }

            return null;
        }

        //removes a customer from the customer list
        public void removeCustomer(Customer customer)
        {
            int id = customer.ID;

            //goes through the customer list to find the specific customer instance
            for(int i = 0; i < customerList.Count; i++)
            {
                Customer compareCustomer = customerList[i];

                if(compareCustomer.ID == id)
                {
                    customerList.RemoveAt(i);
                }


                //just to reset the customerID counter every once in a while safely
                if(customerList.Count == 0)
                {
                    customerCount = 0;
                }
            }

        }

        //generates customers, right now just based on a 2 second timer
        //deletes items from shopping list from store inventory
        public void generateCustomer()
        {

            Customer newCustomer = new Customer(player.getInventory());

            List<GameItem> shoppingList = newCustomer.getShoppingList();

            for(int i = 0; i < shoppingList.Count; i++)
            {
                player.sellItem(shoppingList[i]);

                //if a customer's prefered item is in the store
                //lowers time between customers, otherwise raises time
                if(newCustomer.hasPrefered)
                {
                    modifyGenerateCustomerTime(-.05f);
                }
                else
                {
                    modifyGenerateCustomerTime(.05f);
                }
            }

            newCustomer = null;

        }

        //simple idea for changing the customer generation speed
        void modifyGenerateCustomerTime(float change)
        {
            //stops the time from going negative or too low
            if(timeBetweenCustomers+change > 1)
            {
                timeBetweenCustomers += change;
            }
        }

        public void inventoryUpgrade()
        {
            if(player.getMoney() >= player.inventoryUpgradeCost)
            {
                player.invCapacity += player.inventoryUpgradeFactor;
                player.subtractMoney(player.inventoryUpgradeCost);

                fin.addUpgradesValue(player.inventoryUpgradeCost);

                player.inventoryUpgradeFactor = (int) (player.inventoryUpgradeFactor * 1.1);
                player.inventoryUpgradeCost *= 1.4;
            }
        }
        public void customerUpgrade()
        {
            if (player.getMoney() >= player.customerUpgradeCost)
            {
                modifyGenerateCustomerTime(player.customerUpgradeFactor);
                player.subtractMoney(player.customerUpgradeCost);
                fin.addUpgradesValue(player.customerUpgradeCost);

                player.customerUpgradeFactor = (float)(player.customerUpgradeFactor * 1.1);
                player.customerUpgradeCost *= 1.4;
            }
        }
        public void operatingCostUpgrade()
        {
            if(player.operatingCost - player.operatingUpgradeFactor > 100)
            {
                if (player.getMoney() >= player.operatingUpgradeCost)
                {
                    player.operatingCost -= player.operatingUpgradeFactor;
                    player.subtractMoney(player.operatingUpgradeCost);
                    fin.addUpgradesValue(player.operatingUpgradeCost);

                    player.operatingUpgradeFactor *= 1.1;
                    player.operatingUpgradeCost *= 1.4;

                }
            }
            else
            {
                return;
            }
        }
        
    }
}

