using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;

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


        // Use this for initialization
        void Start()
        {
            // set default values for all item types
            GameItem.Items[] values = (GameItem.Items[])System.Enum.GetValues(typeof(GameItem.Items));
            foreach (GameItem.Items n in values)
                simState.gameItem.setDefaults(n); // uses Singleton "SimState" class 
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
            playerMoneyText.GetComponent<Text>().text = money.ToString();

            // show quantities in InventoryPanel
            // quanText.GetComponent<Text>().text = simState.gameItem.getQuantity.ToString; // needs a method from backend

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
        public void remove(tycoon.GameItem itemType)
        {
            //tycoon.Player.deleteItem(itemType);

            // adjust UI

            // if there is no value to display for the item panel, hide it. This makes a "dynamic" list

        }

        // takes all user inputs from order screen and adds those items to their inventory
        /*public void placeOrder()
        {
            //int i = 0;
            //int total = 0;
            //GameItem.Items item;
            //if (order1.GetComponent<Text>().text != null)
            //{
            //    total = int.Parse(order1.GetComponent<Text>().text); // convert input text to int
            //    item = GameItem.Items.Bananas;
            //    GameItem produce = new GameItem((int)item);
            //    for (i = 0; i < total; i++)
            //    {
            //        simState.sim.player.addItem(produce);
            //    }
            //}
        }*/

        public void placeOrder()
        {
            int i = 0;
            int total = 0;
            GameItem.Items item;

            // apples
            var b = order.GetComponent<InputField>().text;
            print(b.ToString());
            if (b.Length > 0)
            {
                total = int.Parse(b); // convert input text to int
                print("The total for Apples is " + total);
                item = GameItem.Items.Apples;

                for (i = 0; i < total; i++)
                {
                    GameItem produce = new GameItem((int)item);
                    simState.sim.player.addItem(produce);
                }
            }

            // bananas
            b = order1.GetComponent<InputField>().text;
            print(b.ToString());
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
            print(b.ToString());
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
            print(b.ToString());
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
            print(b.ToString());
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
            print(b.ToString());
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
            print(b.ToString());
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
            print(b.ToString());
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
            print(b.ToString());
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
            print(b.ToString());
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
            print(b.ToString());
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
            print(b.ToString());
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
            print(b.ToString());
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
            print(b.ToString());
            if (b.Length > 0)
            {
                total = int.Parse(b); // convert input text to int
                item = GameItem.Items.Eggs;

                for (i = 0; i < total; i++)
                {
                    GameItem produce = new GameItem((int)item);
                    simState.sim.player.addItem(produce);
                }
            }

            // fish
            b = order14.GetComponent<InputField>().text;
            print(b.ToString());
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
            print(b.ToString());
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
            print(b.ToString());
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
            print(b.ToString());
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
            print(b.ToString());
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
            print(b.ToString());
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
            print(b.ToString());
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
            print(b.ToString());
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
            print(b.ToString());
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
            print(b.ToString());
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
            print(b.ToString());
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


        }


        public void showItemQuanity()
        {
            GameItem.Items item;

            // bananas
            item = GameItem.Items.Bananas;
            GameItem produce = new GameItem((int)item);
            quanText1.GetComponent<Text>().text = simState.sim.player.getQuantity(produce).ToString();
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
