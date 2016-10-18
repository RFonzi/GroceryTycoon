using UnityEngine;
using System.Collections;

public class PlayerData {
    private static PlayerData instance = new PlayerData();

    private PlayerData() { }

    public static PlayerData getInstance() {
        return instance;
    }
    
}
