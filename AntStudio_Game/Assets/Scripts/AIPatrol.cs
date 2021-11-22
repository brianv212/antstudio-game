using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPatrol : MonoBehaviour
{
    // Start is called before the first frame update

    public bool mustPatrol;
    public Rigidbody2D rb;
    public float walkSpeed;

    private bool mustFlip;
    public Transform groundCheckPos;
    public LayerMask groundLayer;
    public LayerMask enemyLayer;

    public Collider2D bodyCollider;

    void Start()
    {
        mustPatrol = true;

    }

    // Update is called once per frame
    void Update()
    {
        if (mustPatrol) {
            Patrol();
        }
    }

    void FixedUpdate() {
        if (mustPatrol) {
            mustFlip = !Physics2D.OverlapCircle(groundCheckPos.position, 0.1f, groundLayer);
        }
    }

    void Patrol() {
        if (mustFlip || bodyCollider.IsTouchingLayers(groundLayer) || bodyCollider.IsTouchingLayers(enemyLayer)) {
            Flip();
        }
        rb.velocity = new Vector2(walkSpeed * Time.fixedDeltaTime, rb.velocity.y);
    }

    void Flip() {
        mustPatrol = false;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        walkSpeed *= -1;
        mustPatrol = true;
    }
}
