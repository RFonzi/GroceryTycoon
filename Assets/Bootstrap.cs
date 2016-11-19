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

            if(currentTime - sim.last >= sim.timeBetweenCustomers) 
            {
                sim.generateCustomer();
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
