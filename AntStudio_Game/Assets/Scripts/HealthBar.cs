using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Image hbar;
    private float CurrentHealth;
    private float MaxHealth;
    GameObject enemy;
    GameObject door;


    private void Start() {
        hbar = GetComponent<Image>();
        enemy = GameObject.Find("Triton");
        MaxHealth = enemy.GetComponent<Enemy>().health;

        door = GameObject.Find("Door");
        door.SetActive(false);
    }

    private void Update() {
        if (enemy) {
            CurrentHealth = enemy.GetComponent<Enemy>().health;
            hbar.fillAmount = CurrentHealth / MaxHealth;            
        }
        else {
            hbar.fillAmount = 0 / MaxHealth;
            enabled = false;
            Debug.Log("Dead");
            door.SetActive(true);
        }
    }
}