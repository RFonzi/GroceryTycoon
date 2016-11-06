using UnityEngine;
using System.Collections;
using System.Collections.Generic;


namespace tycoon {
    public class Customer : MonoBehaviour
    {
        List<Item>[] storeItems; // where the store inventory is stored
        public int x { get; set; }
        public int y { get; set; }
        public int ID { get; set; }

        List<Item> shoppingList = new List<Item>();
        List<Item> inventory = new List<Item>();

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
        public Customer (List<Item>[] items)
        {
            storeItems = items;
            createShoppingList();
        }

        // determines if the customer wants to buy a specific item
        public bool buyItem(Item item)
        {
            //cant do buy price, since trades will mess it up
            //base price doesnt change and is just what the player can pay from in game market
            double spread = (item.getSellPrice() - item.getBasePrice());
            int factor = (int) (spread * 100);
            System.Random random = new System.Random();
            if (factor < 0) // if we had a negative spread (sell price cheaper than buy price)
            {
                int posFact = factor * -1;
                int toBuy = random.Next(0, posFact);
                if (toBuy >= 5) // lets say spread is 0.20 so fact would be 20, you would have 3/4 chance of buying item
                    return true;
                return false;

            } else // if we had a positive spread (sell price is more expensive than buy price)
            {
                int toBuy = random.Next(0, factor);
                if (toBuy <= (factor/10)) // 1/10 of chance to buy Item if it is overpriced
                    return true;
                return false;   
            }
        }

        // loops through store inventory and figures out what items to buy 
        //stores in shopping list
        private void createShoppingList()
        {
            for(int i = 0; i < storeItems.Length; i++)
            { // [i][0] -- i represents the item type, and 0 is first item in the list, if its null player doesnt have that type of item.
                if (storeItems[i][0] != null && buyItem(storeItems[i][0]))
                {
                    shoppingList.Add(storeItems[i][0]);
                }
            }
        }

        public List<Item> getShoppingList()
        {
            return shoppingList;
        }
        public void move(int X, int Y)
        {
            x = X;
            y = Y;
        }
        public void addToInventory(Item item)
        {
            inventory.Add(item);
        }
        public void removeFromInventory(Item item)
        {
            inventory.Remove(item);
        }
    }
}
