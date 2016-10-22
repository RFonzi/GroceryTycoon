using UnityEngine;
using System.Collections;
using System.Collections.Generic;


namespace tycoon {
    public class Customer : MonoBehaviour
    {
        Item[] storeItems;
        

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
        public Customer (Item[] items)
        {
            storeItems = items;
        }

        public bool buyItem(Item item)
        {
            double spread = (item.getSellPrice() - item.getStockPrice());
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

        public List<Item> getItemList()
        {
            List<Item> items = new List<Item>();
            for(int i = 0; i < storeItems.Length; i++)
            {
                if (buyItem(storeItems[i]))
                {
                    items.Add(storeItems[i]);
                }
            }
            return items;
        }
    }
}
