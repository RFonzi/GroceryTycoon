using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Threading;

namespace tycoon
{


    public class Simulation : MonoBehaviour
    {

        int customerCount = 0;

        List<Customer> customerList = new List<Customer>();

        Player player = new Player();

        float timeElapsed = Time.time + 2;

        float last;

        float timeBetweenCustomers = 2;

        // Use this for initialization
        void Start()
        {
           
        }

        // Update is called once per frame
        void Update()
        {
            //every 2 seconds a new customer, can be changed default to 2
            if(Time.time - last >= timeBetweenCustomers)
            {
                generateCustomer();
                last = Time.time;
            }
        }


        void addCustomer(Customer customer)
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
        void removeCustomer(Customer customer)
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
        void generateCustomer()
        {

            Customer newCustomer = new Customer(player.getInventory());

            List<Item> shoppingList = newCustomer.getShoppingList();

            for(int i = 0; i < shoppingList.Count; i++)
            {
                player.deleteItem(shoppingList[i]);
                player.addMoney(shoppingList[i].getSellPrice());
            }

            Destroy(newCustomer);

        }

        
        
    }
}

