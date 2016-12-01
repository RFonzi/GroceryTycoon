using UnityEngine;
using System.Collections;
using System;

namespace tycoon
{
    public class SimState
    {
        private static SimState instance;

        private SimState() { }

        public Simulation sim;
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