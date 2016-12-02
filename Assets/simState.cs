using UnityEngine;
using System.Collections;
using System;

namespace tycoon
{
    [System.Serializable]
    public class SimState
    {
        private static SimState instance;

        public Simulation sim;
        public Player player;
        //public GameItem gameItem;
        
        public static SimState Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SimState();

                 
                }
                return instance;
            }
        }

    }
}