using UnityEngine;

[RequireComponent(typeof(Movement))]

public class Pacman : MonoBehaviour
{
    public Movement movement { get; private set; }
    public AnimatedSprite deathSequence;
    public SpriteRenderer spriteRenderer { get; private set; }
    public new Collider2D collider { get; private set; }
    public CircleCollider2D collide { get; private set; }
    public SpriteRenderer death;
    //public new Rigidbody2D rigidbody { get; private set; }

    private void Awake()
    {
        this.movement = GetComponent<Movement>();
    }
    private void Update()
    {
        // TO-DO: Check for Unity built in movement (don't need to manually put in every key, just "Up" or something I swear it exists) <= also good for controller support!
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            this.movement.SetDirection(Vector2.up);
        }
        else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            this.movement.SetDirection(Vector2.down);
        }
        else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            this.movement.SetDirection(Vector2.left);
        }
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            this.movement.SetDirection(Vector2.right);
        }

        float angle = Mathf.Atan2(this.movement.direction.y, this.movement.direction.x);
        this.transform.rotation = Quaternion.AngleAxis(angle * Mathf.Rad2Deg, Vector3.forward);
    }

    public void ResetState()
    {
        /*this.enabled = true;
        //this.spriteRenderer.enabled = true;
        //this.collider.enabled = true;
        //this.deathSequence.enabled = false;
        this.death.enabled = false;
        //this.deathSequence.spriteRenderer.enabled = false;
        this.movement.rigidbody.isKinematic = false;
        this.movement.speed = 8.0f;
        //this.movement.rigidbody.gravityScale = 0f;*/
        this.gameObject.SetActive(true);
        this.movement.ResetState();
    }

    public void DeathSequence() // Make Petr/Pacman do a little jump then fall through the stage in a 3s animation.
    {
        this.enabled = false;
        this.transform.rotation = Quaternion.AngleAxis(0, Vector3.forward);
        //this.spriteRenderer.enabled = false;
        this.collide.enabled = false;
        this.movement.rigidbody.isKinematic = true;
        this.movement.SetDirection(Vector2.up);
        Invoke(nameof(DeathUp), 0.5f);
        //this.movement.enabled = false;
        //this.deathSequence.enabled = true;
        this.death.enabled = true;
        //this.deathSequence.spriteRenderer.enabled = true;
        //this.deathSequence.Restart();
        //this.gameObject.SetActive(false);
    }

    private void DeathUp()
    {
        this.movement.SetDirection(Vector2.down);
        this.movement.speed = 12.0f;
    }
}
