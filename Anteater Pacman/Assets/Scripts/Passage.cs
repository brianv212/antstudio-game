
using UnityEngine;

public class Passage : MonoBehaviour
{
    public Transform connection;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Vector3 position = collision.transform.position;
        position.x = this.connection.position.x;
        position.y = this.connection.position.y;
        // WE DO NOT USE Z. ONLY X AND Y. DO NOT ADD Z.
        collision.transform.position = position;
    }
}
