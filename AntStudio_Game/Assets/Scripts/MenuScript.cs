using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public string sLevelToLoad;        // if we want to load it via indexing
    // Start is called before the first frame update
    public void LoadScene()
    {
        SceneManager.LoadScene(sLevelToLoad);
    }
}
