using UnityEngine;
using System.Collections;
using System;
using tycoon;

public class setHours : MonoBehaviour {

	public void setOpenHours(string openHour)
    {
        SimState.Instance.sim.player.openingHour = Int32.Parse(openHour);
        print(SimState.Instance.sim.player.closingHour);
    }

    public void setCloseHours(string closeHour)
    {
        SimState.Instance.sim.player.closingHour = Int32.Parse(closeHour);
        print(SimState.Instance.sim.player.openingHour);
    }

    public void setMultiplier(string mult)
    {
        double dmult = Double.Parse(mult);
        for(int i = 0; i < 25; i++)
        {
            SimState.Instance.sim.player.setItemPrice(i, dmult);
        }
    }
}
