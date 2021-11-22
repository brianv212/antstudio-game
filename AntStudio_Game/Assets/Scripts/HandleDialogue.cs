using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleDialogue : MonoBehaviour
{
    public Dialogue dialogue;
    private void OnTriggerEnter2D(Collider2D collision) {
        GameObject collisionGameObject = collision.gameObject;
        if (collisionGameObject.name == "Anteater") {
            dialogue.Setup();
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        GameObject collisionGameObject = collision.gameObject;
        if (collisionGameObject.name == "Anteater") {
            dialogue.Remove();
        }
    }
}
