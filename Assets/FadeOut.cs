using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class FadeOut : MonoBehaviour {
    
    public void LoadGameScreen() {
        SceneManager.LoadSceneAsync(1);
    }

    public void LoadInventoryScreen() {
        SceneManager.LoadSceneAsync(2);
    }

    public void LoadManagementScreen() {
        SceneManager.LoadSceneAsync(3);
    }
}
