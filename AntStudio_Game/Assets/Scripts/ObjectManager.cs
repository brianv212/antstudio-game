using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.transform.tag == "Respawn") {
            for (int i = 0; i < collision.transform.childCount; i++) {
                collision.transform.GetChild(i).gameObject.SetActive(true);
            }
        }
    }
    void OnTriggerExit2D(Collider2D collision) {
        if (collision.transform.tag == "Respawn") {
            for (int i = 0; i < collision.transform.childCount; i++) {
                collision.transform.GetChild(i).gameObject.SetActive(false);
            }
        }
    }
}
