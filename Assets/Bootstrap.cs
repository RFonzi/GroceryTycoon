using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace tycoon {
    class Bootstrap : MonoBehaviour {
        Simulation sim;

        public void Update() {
            float currentTime = Time.time;
            
            //incase we load game and player.timelast is a really high number
            if(currentTime < sim.player.timeLast)
            {
                sim.player.timeLast = 0;
            }

            //days / hours for player
            sim.player.timeElapsed += (currentTime - sim.player.timeLast);

            if (sim.player.timeElapsed >= sim.player.secondsPerDay / 24)
            {
                if (sim.player.hour < 23)
                {
                    sim.player.hour++;
                }
                else
                {
                    sim.player.day++;
                    sim.player.addExpiration();
                    sim.player.removeExpired();
                    sim.player.hour = 0;
                    sim.player.subtractMoney(sim.player.operatingCost);
                }

                sim.player.timeElapsed = 0;
            }

            sim.player.timeLast = currentTime;

            //customer shopping based on store opening/closing hours
            if (currentTime - sim.last >= sim.timeBetweenCustomers) 
            {
                if(sim.player.closingHour == sim.player.openingHour)
                {
                    sim.generateCustomer();
                }
                else if(sim.player.openingHour < sim.player.closingHour)
                {
                    if(sim.player.hour >= sim.player.openingHour && sim.player.hour <= sim.player.closingHour)
                    {
                        sim.generateCustomer();
                    }
                }
                else 
                {
                    if(sim.player.hour <= sim.player.closingHour)
                    {
                        sim.generateCustomer();
                    }
                    else if(sim.player.hour >= sim.player.openingHour)
                    {
                        sim.generateCustomer();
                    }
                    else
                    {

                    }
                }
                sim.last = currentTime;
            }
        }

        public void Start() {
            sim = new Simulation();

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
