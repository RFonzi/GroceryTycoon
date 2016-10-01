using UnityEngine;
using System.Collections;
using System;

namespace tycoon {
    public class Item : MonoBehaviour
    {

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        enum Items
        {
            Apples, Bananas, Grapes, Oranges, Tomatoes, Potatoes, Asparagus, Corn, Zukkini,
            Carrots, Water, Orange_Juice, Beer, Wine, Apple_Juice, Chicken, Beef, Pork, Eggs,
            Fish, Pasta, Cereal, Bread, Tortilla, Cookies
        }



        double buyPrice;
        double sellPrice;
        int expiration;
        Items type;

        public Item(int num)
        {
            if (num >= 25) // out of bounds
                return;
            type = (Items)num;
            setDefaults(type);
            sellPrice = buyPrice; // default is same, up to player to set
        }

        public void setSellPrice(double price)
        {
            sellPrice = price;
        }



        void setDefaults(Items itemType)
        {
            switch (itemType) // need to set buyPrice and expiration of each case
            {
                case Items.Apples:
                    buyPrice = 1.50;
                    expiration = 14;
                    break;
                case Items.Apple_Juice:
                    buyPrice = 3.00;
                    expiration = 7;
                    break;
                case Items.Asparagus:
                    buyPrice = 1.25;
                    expiration = 10;
                    break;
                case Items.Bananas:
                    buyPrice = 0.50;
                    expiration = 8;
                    break;
                case Items.Beef:
                    buyPrice = 4.99;
                    expiration = 13;
                    break;
                case Items.Beer:
                    buyPrice = 7.99;
                    expiration = 30;
                    break;
                case Items.Bread:
                    buyPrice = 3.50;
                    expiration = 16;
                    break;
                case Items.Carrots:
                    buyPrice = 2.00;
                    expiration = 10;
                    break;
                case Items.Cereal:
                    buyPrice = 1.50;
                    expiration = 60;
                    break;
                case Items.Chicken:
                    buyPrice = 4.50;
                    expiration = 18;
                    break;
                case Items.Cookies:
                    buyPrice = 2.99;
                    expiration = 20;
                    break;
                case Items.Corn:
                    buyPrice = 1.80;
                    expiration = 15;
                    break;
                case Items.Eggs:
                    buyPrice = 3.20;
                    expiration = 18;
                    break;
                case Items.Fish:
                    buyPrice = 6.00;
                    expiration = 11;
                    break;
                case Items.Grapes:
                    buyPrice = 1.99;
                    expiration = 10;
                    break;
                case Items.Oranges:
                    buyPrice = 1.50;
                    expiration = 20;
                    break;
                case Items.Orange_Juice:
                    buyPrice = 3.99;
                    expiration = 30;
                    break;
                case Items.Pasta:
                    buyPrice = 1.50;
                    expiration = 60;
                    break;
                case Items.Pork:
                    buyPrice = 5.00;
                    expiration = 30;
                    break;
                case Items.Potatoes:
                    buyPrice = 1.00;
                    expiration = 14;
                    break;
                case Items.Tomatoes:
                    buyPrice = 1.40;
                    expiration = 20;
                    break;
                case Items.Tortilla:
                    buyPrice = 3.00;
                    expiration = 18;
                    break;
                case Items.Water:
                    buyPrice = 2.00;
                    expiration = 100;
                    break;
                case Items.Wine:
                    buyPrice = 8.00;
                    expiration = 80;
                    break;
                case Items.Zukkini:
                    buyPrice = 2.00;
                    expiration = 30;
                    break;
            }
        }

        String getName()
        {
            return type.ToString();
        }
    }
}
