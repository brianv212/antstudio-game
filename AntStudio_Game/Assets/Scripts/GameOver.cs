using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public string sLevelToLoad;
    public void Setup () {
        gameObject.SetActive(true);
    }

    public void RestartButton () {
        Debug.Log("Restarting");
        SceneManager.LoadScene(sLevelToLoad);
    }

    public void ExitButton() {
        Debug.Log("Returning to Menu");
        SceneManager.LoadScene("Menu");
    }
}
