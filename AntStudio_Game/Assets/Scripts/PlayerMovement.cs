using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public int playerSpeed = 10;
    public int playerJumpPower = 10;
    private float moveX;
    private bool facingRight = true;

    // isGrounded
    public bool isGrounded;
    public bool isInAir = false;
    public LayerMask groundLayers;

    public Animator animator;

    // Update is called once per frame
    void Update() {
        PlayerMove();
        isGrounded = Physics2D.OverlapArea(new Vector2(transform.position.x - 0.5f, transform.position.y - 0.5f),
                                           new Vector2(transform.position.x + 0.5f, transform.position.y - 0.51f),
                                           groundLayers);
        if (!isGrounded && isInAir == false) {
            isInAir = !isGrounded;
            animator.SetBool("isJumping", isInAir);
        }
        else if (isGrounded && isInAir == true) {
            isInAir = !isGrounded;
            animator.SetBool("isJumping", isInAir);
        }
    }

    void PlayerMove() {
        // Controls
        moveX = Input.GetAxis("Horizontal");
        animator.SetFloat("Speed", Mathf.Abs(moveX));

        if (Input.GetButtonDown("Jump") && isGrounded) {
            Jump();
        }

        if (moveX > 0.0f && facingRight == false) {
            FlipPlayer();
        }
        else if (moveX < 0.0f && facingRight == true) {
            FlipPlayer();
        }

        // Physics
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2 (moveX * playerSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
    }

    void Jump() {
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * playerJumpPower);
    }

    void FlipPlayer() {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }


}