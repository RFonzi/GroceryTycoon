using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace tycoon
{
    public class Player : MonoBehaviour
    {

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        double money;
        int capacity = 100; // default
        List<Item> inventory = new List<Item>();
        
        void addItem(Item item)
        {
            if (inventory.Count >= capacity)
                return;
            inventory.Add(item);
        }

        void deleteItem(Item item)
        {
            if (!inventory.Contains(item))
                return;
            inventory.Remove(item);
            
        }

        void addItems(Item[] items)
        {
            if ((inventory.Count + items.Length) < capacity)
                return;
            for (int i = 0; i < items.Length; i++)
            {
                inventory.Add(items[i]);
            }
        }
    }
}
