using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// This file is not used in the game
public class CrabSpawner : MonoBehaviour
{
    public Transform[] spawnpoints;
    public GameObject crab;
    public GameObject crabShootLeft;
    public GameObject crabShootRight;
    private List<int> randomList;

    void Start(){
        randomList = new List<int>();
    }

    void Spawn() {
        if (Input.GetMouseButtonDown(0)) {
            for(int i = 0; i < 3; i++){
                int numToAdd = Random.Range(0,spawnpoints.Length);

                while(randomList.Contains(numToAdd)){
                    numToAdd = Random.Range(0,spawnpoints.Length);
                }

                randomList.Add(numToAdd);
                if (numToAdd <= 3) {
                    Instantiate(crabShootLeft,spawnpoints[numToAdd].position,transform.rotation);
                }
                else if (numToAdd >= 5) {
                    Instantiate(crabShootRight,spawnpoints[numToAdd].position,transform.rotation);
                }
                else {
                    Instantiate(crab,spawnpoints[numToAdd].position,transform.rotation);
                }
            }
        }
        Debug.Log(randomList);
    }
}
