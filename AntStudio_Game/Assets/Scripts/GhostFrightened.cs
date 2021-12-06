using UnityEngine;
using UnityEngine.SceneManagement;

public class GhostFrightened : GhostBehavior
{
    public SpriteRenderer body;
    public SpriteRenderer eyes;
    public SpriteRenderer blue;
    public SpriteRenderer white;
    public SpriteRenderer bearBody;
    //public SpriteRenderer bearMove;

    public bool eaten { get; private set; }

    private bool isBear = false;

    public override void Enable(float duration)
    {
        base.Enable(duration);

        this.body.enabled = false;
        this.eyes.enabled = false;
        this.blue.enabled = true;
        this.white.enabled = false; // not needed but just to be safe

        Invoke(nameof(Flash), duration / 2.0f);
    }

    public override void Disable()
    {
        base.Disable();
        this.body.enabled = true;
        if (!isBear)
        {
            this.eyes.enabled = true;
        }
        this.blue.enabled = false;
        this.white.enabled = false; // not needed but just to be safe
        //this.bearBody.enabled = true;
    }

    private void Flash()
    {
        if (!this.eaten)
        {
            this.blue.enabled = false;
            this.white.enabled = true;
            this.white.GetComponent<AnimatedSprite>().Restart();
        }
    }

    private void Eaten()
    {
        this.eaten = true;
        this.isBear = true;

        if (SceneManager.GetActiveScene().name == "Pacman")
        {
            Vector3 position = this.ghost.home.inside.position;
            position.z = this.ghost.transform.position.z; // leave z alone!
            this.ghost.transform.position = position;
            this.ghost.home.Enable(this.duration);

            //this.body.enabled = false;
            this.eyes.enabled = false;
            this.blue.enabled = false;
            this.white.enabled = false;
            //this.bearBody.enabled = true;
            this.body = this.bearBody;
            this.body.enabled = true;
        }
        else
        {
            this.gameObject.SetActive(false);
        }
        
    }

    private void OnEnable()
    {
        this.ghost.movement.speedMultiplier = 0.5f;
        this.eaten = false;
    }

    private void OnDisable()
    {
        this.ghost.movement.speedMultiplier = 1.0f;
        //this.eaten = false; // doesn't need to be here and in OnEnable() technically but let's be safe
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Pacman"))
        {
            if (this.enabled)
            {
                Eaten();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Node node = collision.GetComponent<Node>();

        // TO-DO: Try to not make this a little less random. Make a ghost run to a specific corner (1 corner per ghost) and then run randomly in that corner (but try to keep it in that corner, random directions for only n count of nodes?)
        if (node != null && this.enabled)
        {
            Vector2 direction = Vector2.zero;
            float maxDistance = float.MinValue;

            foreach (Vector2 availableDirection in node.availableDirections)
            {
                Vector3 newPosition = this.transform.position + new Vector3(availableDirection.x, availableDirection.y, 0.0f); // do NOT use z!
                float distance = (this.ghost.target.position - newPosition).sqrMagnitude;

                if (distance > maxDistance)
                {
                    direction = availableDirection;
                    maxDistance = distance;
                }
            }

            this.ghost.movement.SetDirection(direction);
        }
    }
}
