using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace tycoon {
    public class Bootstrap : MonoBehaviour {
        public static Simulation sim;
        SimState simState = SimState.Instance;
        public Player player;

        public void Update() {
            float currentTime = Time.time;
            simState = SimState.Instance;
            if(simState == null)
            {
                //print("simstate null");
            }
            if(simState.sim == null)
            {
               // print("sim null");
            }
            if (simState.sim.player == null)
            {
                //print("player null");
            }
            //incase we load game and player.timelast is a really high number
            if(currentTime < simState.sim.player.timeLast)
            {
                simState.sim.player.timeLast = 0;
            }

            //days / hours for player
            simState.sim.player.timeElapsed += (currentTime - simState.sim.player.timeLast);

            if (simState.sim.player.timeElapsed >= simState.sim.player.secondsPerDay / 24)
            {
                if (simState.sim.player.hour < 23)
                {
                    simState.sim.player.hour++;
                }
                else
                {
                    simState.sim.player.day++;
                    simState.sim.player.addExpiration();
                    simState.sim.player.removeExpired();
                    simState.sim.player.hour = 0;
                    simState.sim.player.subtractMoney(simState.sim.player.operatingCost);
                }

                simState.sim.player.timeElapsed = 0;
            }

            simState.sim.player.timeLast = currentTime;

            //customer shopping based on store opening/closing hours
            if (currentTime - simState.sim.last >= simState.sim.timeBetweenCustomers) 
            {
                if(simState.sim.player.closingHour == simState.sim.player.openingHour)
                {
                    simState.sim.generateCustomer();
                }
                else if(simState.sim.player.openingHour < simState.sim.player.closingHour)
                {
                    if(simState.sim.player.hour >= simState.sim.player.openingHour && simState.sim.player.hour <= simState.sim.player.closingHour)
                    {
                        simState.sim.generateCustomer();
                    }
                }
                else 
                {
                    if(simState.sim.player.hour <= simState.sim.player.closingHour)
                    {
                        simState.sim.generateCustomer();
                    }
                    else if(simState.sim.player.hour >= simState.sim.player.openingHour)
                    {
                        simState.sim.generateCustomer();
                    }
                    else
                    {

                    }
                }
                simState.sim.last = currentTime;
            }
        }

        public void Start() {
             simState.sim = new Simulation();
            simState.player = new Player();

            /*
            int counter = 0;

            var stopwatch = new System.Diagnostics.Stopwatch();
            stopwatch.Start();

            sim.player.addMoney(2000);

            for (int i = 0; i < 25; i++) {
                sim.player.addItem(new Item(i));
                sim.player.addItem(new Item(i));
                sim.player.addItem(new Item(i));
                sim.player.addItem(new Item(i));
                sim.player.addItem(new Item(i));
                sim.player.addItem(new Item(i));
                sim.player.addItem(new Item(i));
                sim.player.addItem(new Item(i));
                sim.player.addItem(new Item(i));
                sim.player.addItem(new Item(i));
                sim.player.addItem(new Item(i));
                sim.player.addItem(new Item(i));
                sim.player.addItem(new Item(i));
                sim.player.addItem(new Item(i));

            }

            while (counter < 35) {
                TimeSpan currentTime = stopwatch.Elapsed;

                if (currentTime.TotalSeconds - sim.last >= sim.timeBetweenCustomers) {
                    sim.generateCustomer();
                    sim.last = currentTime.TotalSeconds;
                    counter++;


                    Console.WriteLine(counter + " " + sim.timeBetweenCustomers + " $" + sim.player.getMoney());
                }

            }

            Console.WriteLine(sim.player.getOrderHistory().ToArray().ToString());

            Console.Read();

            */

        }
    }

}
