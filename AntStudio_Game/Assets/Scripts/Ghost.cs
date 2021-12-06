using UnityEngine;

[RequireComponent(typeof(Movement))]

public class Ghost : MonoBehaviour
{
    // public AnimatedSprite animatedSprite { get; private set; }
    public Movement movement { get; private set; }
    public GhostChase chase { get; private set; }
    public GhostFrightened frightened { get; private set; }
    public GhostHome home { get; private set; }
    public GhostScatter scatter { get; private set; }
    public GhostBehavior initialBehavior;
    public Transform target; // in theory this could be anything

    public int points = 200;

    private void Awake()
    {
        this.movement = GetComponent<Movement>();
        this.chase = GetComponent<GhostChase>();
        this.frightened = GetComponent<GhostFrightened>();
        this.home = GetComponent<GhostHome>();
        this.scatter = GetComponent<GhostScatter>();
    }

    public void Start()
    {
        ResetState();
    }

    public void ResetState()
    {
        this.gameObject.SetActive(true);
        this.movement.ResetState();
        
        this.chase.Disable();
        this.frightened.Disable();
        // this.home.Disable(); // depends
        this.scatter.Enable();

        if (this.home != this.initialBehavior)
        {
            this.home.Disable();
        }

        if (this.initialBehavior != null)
        {
            this.initialBehavior.Enable();
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Pacman"))
        {
            if (this.frightened.enabled)
            {
                FindObjectOfType<GameManager>().GhostEaten(this);
            }
            else
            {
                FindObjectOfType<GameManager>().PacmanEaten();
            }
        }
    }
}
