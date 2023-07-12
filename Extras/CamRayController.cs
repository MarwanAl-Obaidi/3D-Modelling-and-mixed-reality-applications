using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class CamRayController : MonoBehaviour
{

    public Text infoText;
    public Slider delaySlider;

    private float delayTimer = 0;

    // Start is called before the first frame update
    void Start()
    {
        infoText.enabled = false;
        delaySlider.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //UnityEngine.Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 30, Color.red);

        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 50f))
        {
            //UnityEngine.Debug.Log("Hit: " + hit);
            if (hit.collider.CompareTag("InfoBox"))
            {
                //UnityEngine.Debug.Log("Hitting with InfoBox");
                // TODO: Display some info text box
                infoText.enabled = true;
                if (hit.collider.name == "PrinterInfo")
                {
                    infoText.text = "This is a printer!";
                    //infoText.text = "This is a printer!" + hit.collider.name;
                }
                else if (hit.collider.name == "SomeInfoObject")
                {
                    infoText.text = "Some other text.";
                    //infoText.text = "Some other text." + hit.collider.name;
                }
                else if (hit.collider.name == "Bird_UV")
                {
                    infoText.text = "BIRD!";
                    //infoText.text = "Some other text." + hit.collider.name;
                }

            }
            else if (hit.collider.CompareTag("Teleport"))
            {
                //UnityEngine.Debug.Log("Teleporting to other room");
                // TODO: move to another scene (room)

                delayTimer = delayTimer + Time.deltaTime;
                infoText.enabled = true;
                delaySlider.gameObject.SetActive(true);
                delaySlider.value = delayTimer;
                infoText.text = "Teleporting to " + hit.collider.name + " in " + Math.Round(delayTimer, 1) + " seconds";
                if (delayTimer > 2)
                {
                    SceneManager.LoadScene(hit.collider.name);
                }
            }
        }
        else
        {
            infoText.enabled = false;
            delaySlider.gameObject.SetActive(false);
            delayTimer = 0;
        }
    }
}
