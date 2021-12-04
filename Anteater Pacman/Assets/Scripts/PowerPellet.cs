using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerPellet : Pellet
{
    public float duration = 8.0f;
    // public new int points = 50;

    protected override void Eat()
    {
        FindObjectOfType<GameManager>().PowerPelletEaten(this);
        // this.gameObject.SetActive(false);
    }
}
