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

            if (order1.GetComponent<InputField>().text != null)
            {
                total = int.Parse(order1.GetComponent<InputField>().text); // convert input text to int
                item = GameItem.Items.Bananas;
                GameItem produce = new GameItem((int)item);

                for (i = 0; i < total; i++)
                {
                    if(produce == null)
                    {
                        print("null produce");
                    }

                    simState.sim.player.addItem(produce);
                }
            }
        }


        public void showItemQuanity()
        {
            GameItem.Items item;

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
