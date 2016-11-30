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

        public GameObject quanText;
        public GameObject quanText1;
        public GameObject quanText2;
        public GameObject quanText3;


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
            double money = simState.sim.player.getMoney(); // uses Singleton "SimState" class 
            playerMoneyText.GetComponent<Text>().text = money.ToString();

            // show quantities in InventoryPanel
            // quanText.GetComponent<Text>().text = simState.gameItem.getQuantity.ToString; // needs a method from backend

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

        public void placeOrder()
        {
            // make an array for each item type and pass that
        }

        // go to leaderboard webpage
        public void showLeaderboard()
        {
            Application.OpenURL("http://unity3d.com/");
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
