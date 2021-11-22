using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    // Start is called before the first frame update
    public void Setup() {
        gameObject.SetActive(true);
    }

    public void Remove() {
        gameObject.SetActive(false);
    }
}
