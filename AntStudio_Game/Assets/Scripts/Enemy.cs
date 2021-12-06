using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 100;
    public bool facingLeft;
    // public GameObject deathEffect;

    void Start(){
        if (facingLeft) {
            transform.Rotate(0f, 180f, 0f);
        }
    }

    public void TakeDamage(int damage) {
        health -= damage;

        if (name == "Sammy_Slug")
        {
            Debug.Log("sammy shot");
        }
        else if (health <= 0) {
            Die();
        }
    }

    void Die() {
        // Instantiate(deathEffect, transform.position, Quaternion.identity);
        if (name == "Triton")
        {
            GameObject.Find("End").GetComponent<BoxCollider2D>().enabled = true;
        }
        Destroy(gameObject);
    }
}
