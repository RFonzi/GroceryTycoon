using UnityEngine;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using tycoon;

    public class Save : MonoBehaviour
    {

        public void saveData()
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/save.txt", FileMode.Create);

            Player data = SimState.Instance.sim.player; //REPLACE THIS WITH REAL DATA OBJECT

            bf.Serialize(file, data); // Data obj goes into second param
            file.Close();
        }

        public void loadData()
        {
            if (File.Exists(Application.persistentDataPath + "/save.dat"))
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream file = File.Open(Application.persistentDataPath + "/save.txt", FileMode.Open);

                SimState.Instance.sim.player = (Player)bf.Deserialize(file); //REPLACE THIS WITH REAL DATA OBJECT
                file.Close();
            }
        }
    }
