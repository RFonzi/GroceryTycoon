using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;

namespace tycoon
{
    public class Item : MonoBehaviour
    {
        public GameObject itemHeader;
        public GameObject buttonText;
        public GameObject prefabItemText;
        public GameObject prefabButton;
        public GameObject playerMoneyText;
        public GameObject netWorthDub;
        public GameObject profitDub;
        public GameObject lossDub;
        public RectTransform ParentPanel;
        SimState simState = SimState.Instance; // returns instance of the SimState simulation that I want.
        public AudioSource audio;

        public GameObject quanText;
        public GameObject quanText1;
        public GameObject quanText2;
        public GameObject quanText3;
        public GameObject quanText4;
        public GameObject quanText5;
        public GameObject quanText6;
        public GameObject quanText7;
        public GameObject quanText8;
        public GameObject quanText9;
        public GameObject quanText10;
        public GameObject quanText11;
        public GameObject quanText12;
        public GameObject quanText13;
        public GameObject quanText14;
        public GameObject quanText15;
        public GameObject quanText16;
        public GameObject quanText17;
        public GameObject quanText18;
        public GameObject quanText19;
        public GameObject quanText20;
        public GameObject quanText21;
        public GameObject quanText22;
        public GameObject quanText23;
        public GameObject quanText24;

        public GameObject order;
        public GameObject order1;
        public GameObject order2;
        public GameObject order3;
        public GameObject order4;
        public GameObject order5;
        public GameObject order6;
        public GameObject order7;
        public GameObject order8;
        public GameObject order9;
        public GameObject order10;
        public GameObject order11;
        public GameObject order12;
        public GameObject order13;
        public GameObject order14;
        public GameObject order15;
        public GameObject order16;
        public GameObject order17;
        public GameObject order18;
        public GameObject order19;
        public GameObject order20;
        public GameObject order21;
        public GameObject order22;
        public GameObject order23;
        public GameObject order24;

        public GameObject cost;
        public GameObject cost1;
        public GameObject cost2;
        public GameObject cost3;
        public GameObject cost4;
        public GameObject cost5;
        public GameObject cost6;
        public GameObject cost7;
        public GameObject cost8;
        public GameObject cost9;
        public GameObject cost10;
        public GameObject cost11;
        public GameObject cost12;
        public GameObject cost13;
        public GameObject cost14;
        public GameObject cost15;
        public GameObject cost16;
        public GameObject cost17;
        public GameObject cost18;
        public GameObject cost19;
        public GameObject cost20;
        public GameObject cost21;
        public GameObject cost22;
        public GameObject cost23;
        public GameObject cost24;


        // Use this for initialization
        void Start()
        {
           
            /*foreach (GameItem Items in GameItem.Items.GetValues(typeof(GameItem.Items)))
            {
                tycoon.GameItem.Items product = Items;
                tycoon.GameItem.setDefaults(product);
            }*/


        }

        // Update is called once per frame
        void Update()
        {
            // show available money in top-right corner of MainPanel
            double money = 100.00;//simState.sim.player.getMoney(); // uses Singleton "SimState" class 
            //playerMoneyText.GetComponent<Text>().text = money.ToString();

            //showFinances();
            showCost();
        }

        public void mute()
        {
            if (audio.mute)
                audio.mute = false;
            else
                audio.mute = true;
        }

        // need to change from .getMoney() to appropriate implemented methods
        public void showFinances()
        {
            double net = simState.sim.player.getMoney(); // uses Singleton "SimState" class 
            netWorthDub.GetComponent<Text>().text = net.ToString();

            double prof = simState.sim.player.getMoney(); // uses Singleton "SimState" class 
            profitDub.GetComponent<Text>().text = prof.ToString();

            double loss = simState.sim.player.getMoney(); // uses Singleton "SimState" class 
            lossDub.GetComponent<Text>().text = loss.ToString();
        }

        // remove an item from inventory
        /*public void remove(tycoon.GameItem itemType)
        {
            //tycoon.Player.deleteItem(itemType);

            // adjust UI

            // if there is no value to display for the item panel, hide it. This makes a "dynamic" list

        }*/


        // display cost on Create Order panel
        public void showCost()
        {

            int total = 0;
            double price = 0.00;
            GameItem.Items item;

            // apples
            var b = order.GetComponent<InputField>().text;
            //print(b.ToString());
            if (b.Length > 0)
            {
                total = int.Parse(b); // convert input text to int
                item = GameItem.Items.Apples;

                // new stuff
                GameItem pro = new GameItem((int)item);
                price = pro.getBuyPrice();
                cost.GetComponent<Text>().text = (total * price).ToString();
            }

            // bananas
            b = order1.GetComponent<InputField>().text;
            //print(b.ToString());
            if (b.Length > 0)
            {
                total = int.Parse(b); // convert input text to int
                item = GameItem.Items.Bananas;

                // new stuff
                GameItem pro = new GameItem((int)item);
                price = pro.getBuyPrice();
                cost1.GetComponent<Text>().text = (total * price).ToString();
            }

            // grapes
            b = order2.GetComponent<InputField>().text;
            //print(b.ToString());
            if (b.Length > 0)
            {
                total = int.Parse(b); // convert input text to int
                item = GameItem.Items.Grapes;

                // new stuff
                GameItem pro = new GameItem((int)item);
                price = pro.getBuyPrice();
                cost2.GetComponent<Text>().text = (total * price).ToString();
            }

            // oranges
            b = order3.GetComponent<InputField>().text;
            //print(b.ToString());
            if (b.Length > 0)
            {
                total = int.Parse(b); // convert input text to int
                item = GameItem.Items.Oranges;

                // new stuff
                GameItem pro = new GameItem((int)item);
                price = pro.getBuyPrice();
                cost3.GetComponent<Text>().text = (total * price).ToString();
            }

            // tomatoes
            b = order4.GetComponent<InputField>().text;
            //print(b.ToString());
            if (b.Length > 0)
            {
                total = int.Parse(b); // convert input text to int
                item = GameItem.Items.Tomatoes;

                // new stuff
                GameItem pro = new GameItem((int)item);
                price = pro.getBuyPrice();
                cost4.GetComponent<Text>().text = (total * price).ToString();
            }

            // potatoes
            b = order5.GetComponent<InputField>().text;
            //print(b.ToString());
            if (b.Length > 0)
            {
                total = int.Parse(b); // convert input text to int
                item = GameItem.Items.Potatoes;

                // new stuff
                GameItem pro = new GameItem((int)item);
                price = pro.getBuyPrice();
                cost5.GetComponent<Text>().text = (total * price).ToString();
            }

            // asparagus
            b = order6.GetComponent<InputField>().text;
            //print(b.ToString());
            if (b.Length > 0)
            {
                total = int.Parse(b); // convert input text to int
                item = GameItem.Items.Asparagus;

                // new stuff
                GameItem pro = new GameItem((int)item);
                price = pro.getBuyPrice();
                cost6.GetComponent<Text>().text = (total * price).ToString();
            }

            // corn
            b = order7.GetComponent<InputField>().text;
            //print(b.ToString());
            if (b.Length > 0)
            {
                total = int.Parse(b); // convert input text to int
                item = GameItem.Items.Corn;

                // new stuff
                GameItem pro = new GameItem((int)item);
                price = pro.getBuyPrice();
                cost7.GetComponent<Text>().text = (total * price).ToString();
            }

            // zucchini
            b = order8.GetComponent<InputField>().text;
            //print(b.ToString());
            if (b.Length > 0)
            {
                total = int.Parse(b); // convert input text to int
                item = GameItem.Items.Zucchini;

                // new stuff
                GameItem pro = new GameItem((int)item);
                price = pro.getBuyPrice();
                cost8.GetComponent<Text>().text = (total * price).ToString();
            }

            // carrots
            b = order9.GetComponent<InputField>().text;
            //print(b.ToString());
            if (b.Length > 0)
            {
                total = int.Parse(b); // convert input text to int
                item = GameItem.Items.Carrots;

                // new stuff
                GameItem pro = new GameItem((int)item);
                price = pro.getBuyPrice();
                cost9.GetComponent<Text>().text = (total * price).ToString();
            }

            // chicken
            b = order10.GetComponent<InputField>().text;
            //print(b.ToString());
            if (b.Length > 0)
            {
                total = int.Parse(b); // convert input text to int
                item = GameItem.Items.Chicken;

                // new stuff
                GameItem pro = new GameItem((int)item);
                price = pro.getBuyPrice();
                cost10.GetComponent<Text>().text = (total * price).ToString();
            }

            // beef
            b = order11.GetComponent<InputField>().text;
            //print(b.ToString());
            if (b.Length > 0)
            {
                total = int.Parse(b); // convert input text to int
                item = GameItem.Items.Beef;

                // new stuff
                GameItem pro = new GameItem((int)item);
                price = pro.getBuyPrice();
                cost11.GetComponent<Text>().text = (total * price).ToString();
            }

            // pork
            b = order12.GetComponent<InputField>().text;
            //print(b.ToString());
            if (b.Length > 0)
            {
                total = int.Parse(b); // convert input text to int
                item = GameItem.Items.Pork;

                // new stuff
                GameItem pro = new GameItem((int)item);
                price = pro.getBuyPrice();
                cost12.GetComponent<Text>().text = (total * price).ToString();
            }

            // eggs
            b = order13.GetComponent<InputField>().text;
            //print(b.ToString());
            if (b.Length > 0)
            {
                total = int.Parse(b); // convert input text to int
                item = GameItem.Items.Eggs;

                // new stuff
                GameItem pro = new GameItem((int)item);
                price = pro.getBuyPrice();
                cost13.GetComponent<Text>().text = (total * price).ToString();
            }

            // fish
            b = order14.GetComponent<InputField>().text;
            //print(b.ToString());
            if (b.Length > 0)
            {
                total = int.Parse(b); // convert input text to int
                item = GameItem.Items.Fish;

                // new stuff
                GameItem pro = new GameItem((int)item);
                price = pro.getBuyPrice();
                cost14.GetComponent<Text>().text = (total * price).ToString();
            }

            // pasta
            b = order15.GetComponent<InputField>().text;
            //print(b.ToString());
            if (b.Length > 0)
            {
                total = int.Parse(b); // convert input text to int
                item = GameItem.Items.Pasta;

                // new stuff
                GameItem pro = new GameItem((int)item);
                price = pro.getBuyPrice();
                cost15.GetComponent<Text>().text = (total * price).ToString();
            }

            // cereal
            b = order16.GetComponent<InputField>().text;
            //print(b.ToString());
            if (b.Length > 0)
            {
                total = int.Parse(b); // convert input text to int
                item = GameItem.Items.Cereal;

                // new stuff
                GameItem pro = new GameItem((int)item);
                price = pro.getBuyPrice();
                cost16.GetComponent<Text>().text = (total * price).ToString();
            }

            // bread
            b = order17.GetComponent<InputField>().text;
            //print(b.ToString());
            if (b.Length > 0)
            {
                total = int.Parse(b); // convert input text to int
                item = GameItem.Items.Bread;

                // new stuff
                GameItem pro = new GameItem((int)item);
                price = pro.getBuyPrice();
                cost17.GetComponent<Text>().text = (total * price).ToString();
            }

            // cookies
            b = order18.GetComponent<InputField>().text;
            //print(b.ToString());
            if (b.Length > 0)
            {
                total = int.Parse(b); // convert input text to int
                item = GameItem.Items.Cookies;

                // new stuff
                GameItem pro = new GameItem((int)item);
                price = pro.getBuyPrice();
                cost18.GetComponent<Text>().text = (total * price).ToString();
            }

            // tortillas
            b = order19.GetComponent<InputField>().text;
            //print(b.ToString());
            if (b.Length > 0)
            {
                total = int.Parse(b); // convert input text to int
                item = GameItem.Items.Tortillas;

                // new stuff
                GameItem pro = new GameItem((int)item);
                price = pro.getBuyPrice();
                cost19.GetComponent<Text>().text = (total * price).ToString();
            }

            // water
            b = order20.GetComponent<InputField>().text;
            //print(b.ToString());
            if (b.Length > 0)
            {
                total = int.Parse(b); // convert input text to int
                item = GameItem.Items.Water;

                // new stuff
                GameItem pro = new GameItem((int)item);
                price = pro.getBuyPrice();
                cost20.GetComponent<Text>().text = (total * price).ToString();
            }

            // orange juice
            b = order21.GetComponent<InputField>().text;
            //print(b.ToString());
            if (b.Length > 0)
            {
                total = int.Parse(b); // convert input text to int
                item = GameItem.Items.Orange_Juice;

                // new stuff
                GameItem pro = new GameItem((int)item);
                price = pro.getBuyPrice();
                cost21.GetComponent<Text>().text = (total * price).ToString();
            }

            // beer
            b = order22.GetComponent<InputField>().text;
            //print(b.ToString());
            if (b.Length > 0)
            {
                total = int.Parse(b); // convert input text to int
                item = GameItem.Items.Beer;

                // new stuff
                GameItem pro = new GameItem((int)item);
                price = pro.getBuyPrice();
                cost22.GetComponent<Text>().text = (total * price).ToString();
            }

            // coffee
            b = order23.GetComponent<InputField>().text;
            //print(b.ToString());
            if (b.Length > 0)
            {
                total = int.Parse(b); // convert input text to int
                item = GameItem.Items.Coffee;

                // new stuff
                GameItem pro = new GameItem((int)item);
                price = pro.getBuyPrice();
                cost23.GetComponent<Text>().text = (total * price).ToString();
            }

            // milk
            b = order24.GetComponent<InputField>().text;
            //print(b.ToString());
            if (b.Length > 0)
            {
                total = int.Parse(b); // convert input text to int
                item = GameItem.Items.Milk;

                // new stuff
                GameItem pro = new GameItem((int)item);
                price = pro.getBuyPrice();
                cost24.GetComponent<Text>().text = (total * price).ToString();
            }
        }


        // when Place Order button is clicked
        public void placeOrder()
        {
            int i = 0;
            int total = 0;
            double price = 0.00;
            GameItem.Items item;
            
            // apples
            var b = order.GetComponent<InputField>().text;
            //print(b.ToString());
            if (b.Length > 0)
            {
                total = int.Parse(b); // convert input text to int
                ////print("The total for Apples is " + total);
                item = GameItem.Items.Apples;

                for (i = 0; i < total; i++)
                {
                    GameItem produce = new GameItem((int)item);
                    simState.sim.player.addItem(produce);
                }

                // new stuff
                GameItem pro = new GameItem((int)item);
                price = pro.getBuyPrice();
                cost.GetComponent<Text>().text = (total * price).ToString();
            }

            // bananas
            b = order1.GetComponent<InputField>().text;
            //print(b.ToString());
            if (b.Length > 0)
            {
                total = int.Parse(b); // convert input text to int
                item = GameItem.Items.Bananas;

                for (i = 0; i < total; i++)
                {
                    GameItem produce = new GameItem((int)item);
                    simState.sim.player.addItem(produce);
                }
            }

            // grapes
            b = order2.GetComponent<InputField>().text;
            //print(b.ToString());
            if (b.Length > 0)
            {
                total = int.Parse(b); // convert input text to int
                item = GameItem.Items.Grapes;

                for (i = 0; i < total; i++)
                {
                    GameItem produce = new GameItem((int)item);
                    simState.sim.player.addItem(produce);
                }
            }

            // oranges
            b = order3.GetComponent<InputField>().text;
            //print(b.ToString());
            if (b.Length > 0)
            {
                total = int.Parse(b); // convert input text to int
                item = GameItem.Items.Oranges;

                for (i = 0; i < total; i++)
                {
                    GameItem produce = new GameItem((int)item);
                    simState.sim.player.addItem(produce);
                }
            }

            // tomatoes
            b = order4.GetComponent<InputField>().text;
            //print(b.ToString());
            if (b.Length > 0)
            {
                total = int.Parse(b); // convert input text to int
                item = GameItem.Items.Tomatoes;

                for (i = 0; i < total; i++)
                {
                    GameItem produce = new GameItem((int)item);
                    simState.sim.player.addItem(produce);
                }
            }

            // potatoes
            b = order5.GetComponent<InputField>().text;
            //print(b.ToString());
            if (b.Length > 0)
            {
                total = int.Parse(b); // convert input text to int
                item = GameItem.Items.Potatoes;

                for (i = 0; i < total; i++)
                {
                    GameItem produce = new GameItem((int)item);
                    simState.sim.player.addItem(produce);
                }
            }

            // asparagus
            b = order6.GetComponent<InputField>().text;
            //print(b.ToString());
            if (b.Length > 0)
            {
                total = int.Parse(b); // convert input text to int
                item = GameItem.Items.Asparagus;

                for (i = 0; i < total; i++)
                {
                    GameItem produce = new GameItem((int)item);
                    simState.sim.player.addItem(produce);
                }
            }

            // corn
            b = order7.GetComponent<InputField>().text;
            //print(b.ToString());
            if (b.Length > 0)
            {
                total = int.Parse(b); // convert input text to int
                item = GameItem.Items.Corn;

                for (i = 0; i < total; i++)
                {
                    GameItem produce = new GameItem((int)item);
                    simState.sim.player.addItem(produce);
                }
            }

            // zucchini
            b = order8.GetComponent<InputField>().text;
            //print(b.ToString());
            if (b.Length > 0)
            {
                total = int.Parse(b); // convert input text to int
                item = GameItem.Items.Zucchini;

                for (i = 0; i < total; i++)
                {
                    GameItem produce = new GameItem((int)item);
                    simState.sim.player.addItem(produce);
                }
            }

            // carrots
            b = order9.GetComponent<InputField>().text;
            //print(b.ToString());
            if (b.Length > 0)
            {
                total = int.Parse(b); // convert input text to int
                item = GameItem.Items.Carrots;

                for (i = 0; i < total; i++)
                {
                    GameItem produce = new GameItem((int)item);
                    simState.sim.player.addItem(produce);
                }
            }

            // chicken
            b = order10.GetComponent<InputField>().text;
            //print(b.ToString());
            if (b.Length > 0)
            {
                total = int.Parse(b); // convert input text to int
                item = GameItem.Items.Chicken;

                for (i = 0; i < total; i++)
                {
                    GameItem produce = new GameItem((int)item);
                    simState.sim.player.addItem(produce);
                }
            }

            // beef
            b = order11.GetComponent<InputField>().text;
            //print(b.ToString());
            if (b.Length > 0)
            {
                total = int.Parse(b); // convert input text to int
                item = GameItem.Items.Beef;

                for (i = 0; i < total; i++)
                {
                    GameItem produce = new GameItem((int)item);
                    simState.sim.player.addItem(produce);
                }
            }

            // pork
            b = order12.GetComponent<InputField>().text;
            //print(b.ToString());
            if (b.Length > 0)
            {
                total = int.Parse(b); // convert input text to int
                item = GameItem.Items.Pork;

                for (i = 0; i < total; i++)
                {
                    GameItem produce = new GameItem((int)item);
                    simState.sim.player.addItem(produce);
                }
            }

            // eggs
            b = order13.GetComponent<InputField>().text;
            //print(b.ToString());
            if (b.Length > 0)
            {
                total = int.Parse(b); // convert input text to int
                item = GameItem.Items.Eggs;

                for (i = 0; i < total; i++)
                {
                    GameItem produce = new GameItem((int)item);
                    if(produce == null)
                    {
                        //print("null produce");
                    }

                    simState.sim.player.addItem(produce);
                }
            }

            // fish
            b = order14.GetComponent<InputField>().text;
            //print(b.ToString());
            if (b.Length > 0)
            {
                total = int.Parse(b); // convert input text to int
                item = GameItem.Items.Fish;

                for (i = 0; i < total; i++)
                {
                    GameItem produce = new GameItem((int)item);
                    simState.sim.player.addItem(produce);
                }
            }

            // pasta
            b = order15.GetComponent<InputField>().text;
            //print(b.ToString());
            if (b.Length > 0)
            {
                total = int.Parse(b); // convert input text to int
                item = GameItem.Items.Pasta;

                for (i = 0; i < total; i++)
                {
                    GameItem produce = new GameItem((int)item);
                    simState.sim.player.addItem(produce);
                }
            }

            // cereal
            b = order16.GetComponent<InputField>().text;
            //print(b.ToString());
            if (b.Length > 0)
            {
                total = int.Parse(b); // convert input text to int
                item = GameItem.Items.Cereal;

                for (i = 0; i < total; i++)
                {
                    GameItem produce = new GameItem((int)item);
                    simState.sim.player.addItem(produce);
                }
            }

            // bread
            b = order17.GetComponent<InputField>().text;
            //print(b.ToString());
            if (b.Length > 0)
            {
                total = int.Parse(b); // convert input text to int
                item = GameItem.Items.Bread;

                for (i = 0; i < total; i++)
                {
                    GameItem produce = new GameItem((int)item);
                    simState.sim.player.addItem(produce);
                }
            }

            // cookies
            b = order18.GetComponent<InputField>().text;
            //print(b.ToString());
            if (b.Length > 0)
            {
                total = int.Parse(b); // convert input text to int
                item = GameItem.Items.Cookies;

                for (i = 0; i < total; i++)
                {
                    GameItem produce = new GameItem((int)item);
                    simState.sim.player.addItem(produce);
                }
            }

            // tortillas
            b = order19.GetComponent<InputField>().text;
            //print(b.ToString());
            if (b.Length > 0)
            {
                total = int.Parse(b); // convert input text to int
                item = GameItem.Items.Tortillas;

                for (i = 0; i < total; i++)
                {
                    GameItem produce = new GameItem((int)item);
                    simState.sim.player.addItem(produce);
                }
            }

            // water
            b = order20.GetComponent<InputField>().text;
            //print(b.ToString());
            if (b.Length > 0)
            {
                total = int.Parse(b); // convert input text to int
                item = GameItem.Items.Water;

                for (i = 0; i < total; i++)
                {
                    GameItem produce = new GameItem((int)item);
                    simState.sim.player.addItem(produce);
                }
            }

            // orange juice
            b = order21.GetComponent<InputField>().text;
            //print(b.ToString());
            if (b.Length > 0)
            {
                total = int.Parse(b); // convert input text to int
                item = GameItem.Items.Orange_Juice;

                for (i = 0; i < total; i++)
                {
                    GameItem produce = new GameItem((int)item);
                    simState.sim.player.addItem(produce);
                }
            }

            // beer
            b = order22.GetComponent<InputField>().text;
            //print(b.ToString());
            if (b.Length > 0)
            {
                total = int.Parse(b); // convert input text to int
                item = GameItem.Items.Beer;

                for (i = 0; i < total; i++)
                {
                    GameItem produce = new GameItem((int)item);
                    simState.sim.player.addItem(produce);
                }
            }

            // coffee
            b = order23.GetComponent<InputField>().text;
            //print(b.ToString());
            if (b.Length > 0)
            {
                total = int.Parse(b); // convert input text to int
                item = GameItem.Items.Coffee;

                for (i = 0; i < total; i++)
                {
                    GameItem produce = new GameItem((int)item);
                    simState.sim.player.addItem(produce);
                }
            }

            // milk
            b = order24.GetComponent<InputField>().text;
            //print(b.ToString());
            if (b.Length > 0)
            {
                total = int.Parse(b); // convert input text to int
                item = GameItem.Items.Milk;

                for (i = 0; i < total; i++)
                {
                    GameItem produce = new GameItem((int)item);
                    simState.sim.player.addItem(produce);
                }
            }
            //List<GameItem>[] items = simState.sim.player.getInventory();

            //for(int k = 0; k < items.Length;k++)
            //{
            //    foreach(GameItem printitem in items[k])
            //    {
            //        print(printitem.getName());
            //    }
            //}
            //print(simState.sim.player.getMoney());
        }


        public void showItemQuanity()
        {
            GameItem.Items item;

            // apples
            item = GameItem.Items.Apples;
            GameItem produce = new GameItem((int)item);
            quanText.GetComponent<Text>().text = simState.sim.player.getQuantity(produce).ToString();

            // bananas
            item = GameItem.Items.Bananas;
            produce = new GameItem((int)item);
            quanText1.GetComponent<Text>().text = simState.sim.player.getQuantity(produce).ToString();

            // grapes
            item = GameItem.Items.Grapes;
            produce = new GameItem((int)item);
            quanText2.GetComponent<Text>().text = simState.sim.player.getQuantity(produce).ToString();

            // oranges
            item = GameItem.Items.Oranges;
            produce = new GameItem((int)item);
            quanText3.GetComponent<Text>().text = simState.sim.player.getQuantity(produce).ToString();

            // tomatoes
            item = GameItem.Items.Tomatoes;
            produce = new GameItem((int)item);
            quanText4.GetComponent<Text>().text = simState.sim.player.getQuantity(produce).ToString();

            // potatoes
            item = GameItem.Items.Potatoes;
            produce = new GameItem((int)item);
            quanText5.GetComponent<Text>().text = simState.sim.player.getQuantity(produce).ToString();

            // asparagus
            item = GameItem.Items.Asparagus;
            produce = new GameItem((int)item);
            quanText6.GetComponent<Text>().text = simState.sim.player.getQuantity(produce).ToString();

            // corn
            item = GameItem.Items.Corn;
            produce = new GameItem((int)item);
            quanText7.GetComponent<Text>().text = simState.sim.player.getQuantity(produce).ToString();

            // zucchini
            item = GameItem.Items.Zucchini;
            produce = new GameItem((int)item);
            quanText8.GetComponent<Text>().text = simState.sim.player.getQuantity(produce).ToString();

            // carrots
            item = GameItem.Items.Carrots;
            produce = new GameItem((int)item);
            quanText9.GetComponent<Text>().text = simState.sim.player.getQuantity(produce).ToString();

            // chicken
            item = GameItem.Items.Chicken;
            produce = new GameItem((int)item);
            quanText10.GetComponent<Text>().text = simState.sim.player.getQuantity(produce).ToString();

            // beef
            item = GameItem.Items.Beef;
            produce = new GameItem((int)item);
            quanText11.GetComponent<Text>().text = simState.sim.player.getQuantity(produce).ToString();

            // pork
            item = GameItem.Items.Pork;
            produce = new GameItem((int)item);
            quanText12.GetComponent<Text>().text = simState.sim.player.getQuantity(produce).ToString();

            // eggs
            item = GameItem.Items.Eggs;
            produce = new GameItem((int)item);
            quanText13.GetComponent<Text>().text = simState.sim.player.getQuantity(produce).ToString();

            // fish
            item = GameItem.Items.Fish;
            produce = new GameItem((int)item);
            quanText14.GetComponent<Text>().text = simState.sim.player.getQuantity(produce).ToString();

            // pasta
            item = GameItem.Items.Pasta;
            produce = new GameItem((int)item);
            quanText15.GetComponent<Text>().text = simState.sim.player.getQuantity(produce).ToString();

            // cereal
            item = GameItem.Items.Cereal;
            produce = new GameItem((int)item);
            quanText16.GetComponent<Text>().text = simState.sim.player.getQuantity(produce).ToString();

            // bread
            item = GameItem.Items.Bread;
            produce = new GameItem((int)item);
            quanText17.GetComponent<Text>().text = simState.sim.player.getQuantity(produce).ToString();

            // cookies
            item = GameItem.Items.Cookies;
            produce = new GameItem((int)item);
            quanText18.GetComponent<Text>().text = simState.sim.player.getQuantity(produce).ToString();

            // tortillas
            item = GameItem.Items.Tortillas;
            produce = new GameItem((int)item);
            quanText19.GetComponent<Text>().text = simState.sim.player.getQuantity(produce).ToString();

            // water
            item = GameItem.Items.Water;
            produce = new GameItem((int)item);
            quanText20.GetComponent<Text>().text = simState.sim.player.getQuantity(produce).ToString();

            // orange juice
            item = GameItem.Items.Orange_Juice;
            produce = new GameItem((int)item);
            quanText21.GetComponent<Text>().text = simState.sim.player.getQuantity(produce).ToString();

            // beer
            item = GameItem.Items.Beer;
            produce = new GameItem((int)item);
            quanText22.GetComponent<Text>().text = simState.sim.player.getQuantity(produce).ToString();

            // coffee
            item = GameItem.Items.Coffee;
            produce = new GameItem((int)item);
            quanText23.GetComponent<Text>().text = simState.sim.player.getQuantity(produce).ToString();

            // milk
            item = GameItem.Items.Milk;
            produce = new GameItem((int)item);
            quanText24.GetComponent<Text>().text = simState.sim.player.getQuantity(produce).ToString();
        }


        // submit score and go to leaderboard webpage
        public void showLeaderboard()
        {
            /*string name = nameInput.GetComponent<Text>().text;
            int date = simState.sim.player.day;
            int cash = (int) simState.sim.player.getMoney();

            string query = "INSERT INTO leaderboard (GroceryName, Day, Money)";
            query += " VALUES (@GroceryName, @Day, @Money)";

            SqlConnection conn = new SqlConnection("Server=databases.000webhost.com;Database=id277545_gtleaderboard;User Id=id277545_root;Password=asdfasdf;");
            conn.Open();
            SqlCommand myCommand = new SqlCommand(query, conn);
            myCommand.Parameters.AddWithValue("@GroceryName", name);
            myCommand.Parameters.AddWithValue("@Day", date);
            myCommand.Parameters.AddWithValue("@Money", cash );
            myCommand.ExecuteNonQuery();
            conn.Close();*/


            Application.OpenURL("https://grocerytycoon.000webhostapp.com");
        }

        // display proper item in ItemPanel
        public void displayItemMenu()
        {
            string itemName = buttonText.GetComponent<Text>().text;

            for (int i = 0; i < 5; i++)
            {
                // for the item text
                GameObject listItemText = (GameObject)Instantiate(prefabItemText);
                listItemText.transform.SetParent(ParentPanel, false);
                listItemText.transform.localScale = new Vector3(1, 1, 1);

                //Text tempText = listItemText.GetComponent<Text>();
                int tempInt = i;

                //tempText.onClick.AddListener(() => ButtonClicked(tempInt));

                // for "Remove" buttons
                GameObject goButton = (GameObject)Instantiate(prefabButton);
                goButton.transform.SetParent(ParentPanel, false);
                goButton.transform.localScale = new Vector3(1, 1, 1);

                Button tempButton = goButton.GetComponent<Button>();

                tempButton.onClick.AddListener(() => ButtonClicked(tempInt));

            }
        }

        // set ItemPanel header text to match the item clicked in the InventoryPanel
        public void readType()
        {
            if (buttonText.GetComponent<Text>().text == "Orange Juice")
            {
                itemHeader.GetComponent<Text>().text = "OJ";
            }
            else
            {
                itemHeader.GetComponent<Text>().text = buttonText.GetComponent<Text>().text;
            }

        }

        void ButtonClicked(int buttonNo)
        {
            Debug.Log("Button clicked = " + buttonNo);
        }
    }
}
