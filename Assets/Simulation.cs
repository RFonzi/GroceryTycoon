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

        public SimplePriorityQueue<int> pqueue = new SimplePriorityQueue<int>();
        public const int COLS = 50;
        public const int ROWS = 50;
        int customerCount = 0;
        int shelfCount = 0;

        string[,] Map = new string[50,50];



        List<Shelf> shelvesList = new List<Shelf>();
        List<Customer> customerList = new List<Customer>();
        

        // Use this for initialization
        void Start()
        {
           
        }

        // Update is called once per frame
        void Update()
        {

        }

        void addShelf(Shelf shelf, int row, int col)
        {
            //just resets the ID numbers if no shelves
            if(shelvesList.Count == 0)
            {
                shelfCount = 0;
            }

            //sets coordinates for shelves
            shelf.row = row;
            shelf.col = col;

            shelf.ID = shelfCount;
            shelfCount++;

            shelvesList.Add(shelf);
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
        //finds the specific shelf and returns it
        Shelf checkShelf(int row, int col)
        {
            Shelf tmp;
            for(int i = 0; i < shelvesList.Count; i++)
            {
                tmp = shelvesList[i];

                if(tmp.row == row && tmp.col == col)
                {
                    return tmp;
                }
            }

            return null;
        }

        //find a shelf based on type [NOTE] SHOULD IT FIND THE CLOSEST SHELF RELATIVE TO A CUSTOMER'S POSITION???????????
        Shelf findShelf(string type)
        {
            Shelf tmp;
            for (int i = 0; i < shelvesList.Count; i++)
            {
                tmp = shelvesList[i];

                if (string.Compare(tmp.getShelfType(), type) == 0)
                {
                    return tmp;
                }
            }
            return null;
        }
        //find shelf based on number of items of a type
        Shelf findShelf(string type, int numberItems)
        {
            Shelf tmp;
            for (int i = 0; i < shelvesList.Count; i++)
            {
                tmp = shelvesList[i];

                if (string.Compare(tmp.getShelfType(), type) == 0 && numberItems <= tmp.count)
                {
                    return tmp;
                }
            }
            return null;
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

        //find a customer a path round down customers coordinates for the actual
        //pathfinding algorithm
        void pathFinding(Customer customer)
        {

        }

        void addEmptySpace()
        {

        }

        //find/remove shelf from shelves list
        void removeShelf(Shelf shelf)
        {
            int id = shelf.ID;
            
            for(int i = 0; i < shelvesList.Count;i++)
            {
                Shelf compareShelf = shelvesList[i];

                if(compareShelf.ID == id)
                {
                    removeShelfMap(compareShelf.row, compareShelf.col);
                    shelvesList.RemoveAt(i);
                }
            }
        }

        //adds a shelf to the internal map,
        //represented by a string of "S" followed by its ID 
        void addShelfMap(int row, int col, Shelf shelf)
        {
            Map[row,col] = ("S" + shelf.ID);
        }
        void removeShelfMap(int row, int col)
        {
            Map[row,col] = null;
        }
         //returns an array of ints with all shelf coordinates
        //each row is a different shelf, col 0 is x coord, col 1 is y coord
        public int[,] getShelfCoordinates()
        {
            int[,] shelfCoordinatesArray = new int[shelvesList.Count, 2];

            for (int i = 0; i < shelvesList.Count; i++)
            {
                Shelf tmp = shelvesList[i];
                shelfCoordinatesArray[i, 0] = tmp.row;
                shelfCoordinatesArray[i, 1] = tmp.col;
            }
            return shelfCoordinatesArray;
        }

        //returns an array of floats with all customer coordinates
        //each row is a different customer, col 0 is x coord, col 1 is y coord
        public float[,] getCustomerCoordinates()
        {
            float[,] customerCoordinatesArray = new float[customerList.Count, 2];

            for (int i = 0; i < customerList.Count; i++)
            {
                Customer tmp = customerList[i];
                customerCoordinatesArray[i, 0] = tmp.x;
                customerCoordinatesArray[i, 1] = tmp.y;
            }
            return customerCoordinatesArray;
        }

    }
}

