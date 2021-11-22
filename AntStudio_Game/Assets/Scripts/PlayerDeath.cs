using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    public GameOver GameOverScreen;

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Enemy")) {
           startGameOverScreen();
        }
    }

    public void TakeDamage(int damage) {
        startGameOverScreen();
    }

    public void startGameOverScreen () {
        Destroy(gameObject);
        GameObject[] audios = GameObject.FindGameObjectsWithTag("Background Music");
        foreach (GameObject audio in audios) {
            audio.SetActive(false);
        }
        GameOverScreen.Setup();
        // LevelManager.instance.Respawn();
    }
}
