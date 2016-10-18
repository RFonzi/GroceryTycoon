using UnityEngine;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class Save : MonoBehaviour {

	public void saveData() {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(Application.persistentDataPath + "/save.dat", FileMode.Open);

        Object replaceme = new Object(); //REPLACE THIS WITH REAL DATA OBJECT

        bf.Serialize(file, replaceme); // Data obj goes into second param
        file.Close();
    }

    public void loadData() {
        if(File.Exists(Application.persistentDataPath + "/save.dat")) {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/save.dat", FileMode.Open);

            Object replaceme = (Object)bf.Deserialize(file); //REPLACE THIS WITH REAL DATA OBJECT
            file.Close();
        }
    }
}
