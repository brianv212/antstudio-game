using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript_Triton : MonoBehaviour
{
    public float maxTime = 10.0f;
    public Transform[] spawnpoints;
    public GameObject crab;
    public GameObject crabShootLeft;
    public GameObject crabShootRight;
    private List<int> randomList;

    public int enemyCap;


    // Update is called once per frame
    void Start() {
        Invoke("RandomSpawning", 0.5f);
        randomList = new List<int>();
    }

    void RandomSpawning() {
      float randomTime = Random.Range(3.0f, maxTime);
      Invoke("SpawnCrabs", randomTime);
    }

    void SpawnCrabs() {
        var enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemies.Length < enemyCap) {
            for(int i = 0; i < 2; i++){
                int numToAdd = Random.Range(0,spawnpoints.Length);

                while(randomList.Contains(numToAdd)){
                    numToAdd = Random.Range(0,spawnpoints.Length);
                }

                randomList.Add(numToAdd);
                if (numToAdd <= 3) {
                    Instantiate(crabShootRight,spawnpoints[numToAdd].position,transform.rotation);
                }
                else if (numToAdd >= 4) {
                    Instantiate(crabShootLeft,spawnpoints[numToAdd].position,transform.rotation);
                }
                else {
                    Instantiate(crab,spawnpoints[numToAdd].position,transform.rotation);
                }
            }
            randomList.Clear();            
        }
        Invoke("RandomSpawning", 0);
    }
}
