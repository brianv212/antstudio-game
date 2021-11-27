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
        SceneManager.LoadScene(sLevelToLoad);
    }

    public void ExitButton() {
        SceneManager.LoadScene("Menu");
    }
}
