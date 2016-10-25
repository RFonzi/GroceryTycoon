using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace tycoon
{

    public class Shelf : MonoBehaviour
    {

        List<Item> CurrentStock = new List<Item>();
        string ShelfType;

        public int row { get; set; }
        public int col { get; set; }
        public int ID { get; set; }
        public int count { get; set; }

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        //make sure only one type of item per shelf
        public void addItem(Item item)
        {
            if (CurrentStock.Count == 0)
            {
                setType(item);
            }
            if (string.Compare(item.getName(), ShelfType) == 0)
            {
                CurrentStock.Add(item);
                count++;
            }
        }

        //maybe sort items in the list so first to expire are first to be removed? 
        public Item removeItem(Item item)
        {
            if (string.Compare(item.getName(), ShelfType) == 0)
            {
                if (CurrentStock.Count > 0)
                {
                    CurrentStock.Remove(item);
                    count--;
                    return item;
                }

            }
            return null;
        }

        //sets the type of items allowed on the shelf
        public void setType(Item item)
        {
            if (CurrentStock.Count == 0)
            {
                ShelfType = item.getName();
            }

        }

        public string getShelfType()
        {
            return ShelfType;
        }

    }
}

