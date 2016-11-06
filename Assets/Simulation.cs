using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Priority_Queue;

// maybe store the customers path in the customer class unless we want to recalculate it several times
//everyframe go through customer list to get coordinates? only do it for shelves when things change?
namespace tycoon
{


    public class Simulation : MonoBehaviour
    {

        int customerCount = 0;

        List<Customer> customerList = new List<Customer>();
        

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }


        void addCustomer(Customer customer)
        {
            //sets ID for customer
            customer.ID = customerCount;
            customerCount++;

            customerList.Add(customer);

            //sets the initial coordinates of new customers (all will start at the same spot)
            //might need to change specific x / y
            customer.x = 0;
            customer.y = (COLS / 2);
            
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

    }
}

