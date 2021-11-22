using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIBullet : MonoBehaviour
{

    public float speed = 5f;
    public int damage = 40;
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start(){
        rb.velocity = transform.right * speed;
    }

    void OnTriggerEnter2D (Collider2D hitInfo) {
        if(hitInfo.gameObject.name == "Anteater" || hitInfo.gameObject.name == "Anteater(Clone)")        
        {
            PlayerDeath pd = hitInfo.GetComponent<PlayerDeath>();
            pd.TakeDamage(damage);
        }
        Destroy(gameObject);
    }
}