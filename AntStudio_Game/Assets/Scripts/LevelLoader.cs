using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public int iLevelToLoad;        // if we want to load it via indexing
    public string sLevelToLoad;     // if we want to load it by name

    public bool useIntegerToLoadLevel = false;  // the breaker used to decide which of the two vars above to use
    public bool playerDetected = false;

    private PlayerMovement thePlayer;

    // Start is called before the first frame update
    void Start()
    {
        thePlayer = FindObjectOfType<PlayerMovement>();
    }

    void LoadScene()
    {
        if (useIntegerToLoadLevel) // if we want to load it via indexing
        {
            SceneManager.LoadScene(iLevelToLoad);
        }
        else // if we want to load it by name
        {
            SceneManager.LoadScene(sLevelToLoad);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!thePlayer) {
            thePlayer = FindObjectOfType<PlayerMovement>();
        }
        if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) && playerDetected) {
            LoadScene();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        GameObject collisionGameObject = collision.gameObject;

        if (collisionGameObject.name == "Anteater") {
             playerDetected = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        GameObject collisionGameObject = collision.gameObject;

        if (collisionGameObject.name == "Anteater") {
             playerDetected = false;
        }
    }
}