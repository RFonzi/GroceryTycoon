using UnityEngine;
using System;

[Serializable]
public class PlayerData {
    private static PlayerData instance = new PlayerData();

    /*
     * This will be populated with the data we want to save. All of this MUST be serializable
     * */

    private PlayerData() { }

    public static PlayerData getInstance() {
        return instance;
    }
    
}
