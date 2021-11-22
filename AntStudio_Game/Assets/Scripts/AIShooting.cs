using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIShooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public Animator animator;
    public bool active;

    // Update is called once per frame
    void Start() {
        InvokeRepeating("CreateShot", 0, 3);
        active = true;
    }

    void Update() {
        if (gameObject.activeSelf && active == false) {
            Start();
            active = true;
        }
    }

    void Shoot () {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }

    void SetShooting () {
        animator.SetBool("isShooting", false);
    }

    void CreateShot()
    {
        if (!gameObject.activeSelf) {
            CancelInvokingActions();
            active = false;
        }

        animator.SetBool("isShooting", true);
        Shoot();
        Invoke("SetShooting", 0.25f);
    }

    void CancelInvokingActions() {
        CancelInvoke();
    }
}
