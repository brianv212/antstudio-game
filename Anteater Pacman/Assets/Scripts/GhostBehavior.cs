using UnityEngine;

[RequireComponent(typeof(Ghost))]
public abstract class GhostBehavior : MonoBehaviour
{
    public Ghost ghost { get; private set; }
    public float duration;

    private void Awake()
    {
        this.ghost = GetComponent<Ghost>();
        //this.enabled = false;
    }

    public virtual void Enable()
    {
        Enable(this.duration);
    }

    // We have two Enable() because there's times we want to use differing durations, like PowerPellet duration for example.
    public virtual void Enable(float duration)
    {
        this.enabled = true;

        CancelInvoke();
        Invoke(nameof(Disable), duration);
    }

    public virtual void Disable()
    {
        this.enabled = false;

        CancelInvoke(); // just in case, maybe not necessary
    }
}
