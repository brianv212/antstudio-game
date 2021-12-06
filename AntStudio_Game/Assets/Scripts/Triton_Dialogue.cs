using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Triton_Dialogue : MonoBehaviour
{
    // public void Setup () {
    //     gameObject.SetActive(true);
    // }

    public string[] dialogue = new string[] {};
    private int idx;
    private GameObject x;
    private GameObject x_img;
    private GameObject y;
    private GameObject y_img;
    private GameObject triton;

    public bool anteaterSpeaksFirst;

    public void Start() {
        idx = 0;
        GameObject parent = transform.parent.gameObject;
        Transform[] trs= parent.GetComponentsInChildren<Transform>(true);
        foreach(Transform t in trs){
            if (t.name == "Nameplate_Anteater") {
                x = t.gameObject;
            }
            if (t.name == "Nameplate_Triton") {
                y = t.gameObject;
            }
            if (t.name == "Image_Anteater") {
                x_img = t.gameObject;
            }
            if (t.name == "Image_Triton") {
                y_img = t.gameObject;
            }
        }

        if (anteaterSpeaksFirst) {
            y.SetActive(false);
            y_img.SetActive(false);
        }
        else {
            x.SetActive(false);
            x_img.SetActive(false);   
        }

        try
        {
            triton = GameObject.Find("Triton");
            triton.SetActive(false);
        }
        catch
        {
            Debug.Log("Triton-b-gone!");
        }
    }

    public void Switch_Speaker() {
        // For the anteater
        if (x.activeSelf == true) {
            x.SetActive(false);
            x_img.SetActive(false);
        }
        else {
            x.SetActive(true);
            x_img.SetActive(true);
        }

        // For the Triton
        if (y.activeSelf == true) {
            y.SetActive(false);
            y_img.SetActive(false);
        }
        else {
            y.SetActive(true);
            y_img.SetActive(true);
        }   
    }

    public void End_Of_Dialogue() {
        try
        {
            triton.SetActive(true);
            GameObject.Find("Boss_Dialogue").SetActive(false);
        }
        catch
        {
            Debug.Log("Triton is gone!");
            GameObject.Find("End_Dialogue").SetActive(false);
        }
        // gameObject.SetActive(false);
    }

    public void Next_Text () {
        // Get the text and update it
        idx += 1;
        GameObject d = GameObject.Find("Dialogue");
        Text dtext = d.GetComponent<Text>();
        if (idx < dialogue.Length) {
            dtext.text = this.dialogue[idx];
            Switch_Speaker();
        }
        else {
            End_Of_Dialogue();
        }
    }
}