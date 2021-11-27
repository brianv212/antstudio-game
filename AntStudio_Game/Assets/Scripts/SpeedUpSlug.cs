using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUpSlug : MonoBehaviour
{
    public AIPatrol slug;

    private void OnTriggerExit2D(Collider2D collision) {
        GameObject collisionGameObject = collision.gameObject;
        if (collisionGameObject.name == "Anteater") {
            slug.SpeedUp(10f);
        }
    }
}
