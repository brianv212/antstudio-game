using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sammy_Wins : MonoBehaviour
{
    public GameOver GameOverScreen;

    private void OnTriggerEnter2D(Collider2D collision) {
        GameObject collisionGameObject = collision.gameObject;
        if (collisionGameObject.name == "Sammy_Slug") {
            startGameOverScreen();
        }
    }

    public void startGameOverScreen () {
        Destroy(GameObject.FindWithTag("Player"));
        GameObject[] audios = GameObject.FindGameObjectsWithTag("Background Music");
        foreach (GameObject audio in audios) {
            audio.SetActive(false);
        }
        GameOverScreen.Setup();
        // LevelManager.instance.Respawn();
    }
}
