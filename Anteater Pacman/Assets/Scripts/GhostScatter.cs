using UnityEngine;

public class GhostScatter : GhostBehavior
{
    private void OnDisable()
    {
        this.ghost.chase.Enable();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Node node = collision.GetComponent<Node>();

        // TO-DO: Try to not make this a little less random. Make a ghost run to a specific corner (1 corner per ghost) and then run randomly in that corner (but try to keep it in that corner, random directions for only n count of nodes?)
        if (node != null && this.enabled && !this.ghost.frightened.enabled)
        {
            int index = Random.Range(0, node.availableDirections.Count);

            if (node.availableDirections[index] == -this.ghost.movement.direction && node.availableDirections.Count > 1)
            {
                index++;

                if (index >= node.availableDirections.Count)
                {
                    index = 0; // catch overflows
                }
            }

            this.ghost.movement.SetDirection(node.availableDirections[index]);
        }
    }
}
