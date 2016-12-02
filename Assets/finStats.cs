using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace tycoon
{
    public class finStats : MonoBehaviour
    {

        // Use this for initialization
        public Text text;

        // Update is called once per frame
        void Update()
        {
            SimState.Instance.sim.fin.calculateNetWorth(SimState.Instance.player.getMoney(), SimState.Instance.player.getInventory());
            setText(SimState.Instance.sim.fin.getNetWorth().ToString());
            //setText("100");
        }
        public void setText(string newtext)
        {
            var myText = gameObject.GetComponent<Text>();
            myText.text = newtext;
        }
    }
}
