using System;
using System.Collections;
using System.Collections.Generic;


namespace tycoon {
    public class Customer
    {
        List<Item>[] storeItems; // where the store inventory is stored
        public int ID { get; set; }

        List<Item> shoppingList = new List<Item>();
        List<Item> inventory = new List<Item>();
        System.Random rnd;

        Item Prefereditem;
        public bool hasPrefered = false;

        public Customer (List<Item>[] items)
        {
            rnd = new System.Random();
            int pref = rnd.Next(0, 25);
            Prefereditem = new Item(pref);

            storeItems = items;
            createShoppingList();
        }

        // determines if the customer wants to buy a specific item
        public bool buyItem(Item item)
        {

            if(item.getItemID() == Prefereditem.getItemID())
            {
                hasPrefered = true;
            }
            //cant do buy price, since trades will mess it up
            //base price doesnt change and is just what the player can pay from in game market
            double spread = (item.getSellPrice() - item.getBasePrice());
            int factor = (int) (spread * 100);
            if (factor < 0) // if we had a negative spread (sell price cheaper than buy price)
            {
                int posFact = factor * -1;
                int toBuy = rnd.Next(0, posFact);
                if (toBuy >= 5) // lets say spread is 0.20 so fact would be 20, you would have 3/4 chance of buying item
                    return true;
                return false;

            }
            else if (factor == 0) 
            {
                if(rnd.Next(0, 2) == 0) {
                    return true;
                }
                return false;
            }
            // if we had a positive spread (sell price is more expensive than buy price)
            else
            {
                int toBuy = rnd.Next(0, factor);
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
                if (storeItems[i].Count > 0)
                {
                    if (buyItem(storeItems[i][0]))
                    {
                        shoppingList.Add(storeItems[i][0]);
                        Console.WriteLine("Item " + i);
                    }
                    
                }
            }

            //if the prefered item is in store inventory
            if(hasPrefered != true)
            {
                hasPrefered = false;
            }
        }

        public List<Item> getShoppingList()
        {
            return shoppingList;
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
