using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GreenhouseController : MonoBehaviour
{
    public GameObject Popup;
    public Text PopupText;

    void OnTriggerEnter2D(Collider2D other){
        PlayerController player = other.GetComponent<PlayerController>();

        Popup.SetActive(true);
        PopupText.text = "Press 'F' to Enter";
        if(player != null){
            player.SetGreenhouse(this);
        }
    }

    void OnTriggerExit2D(Collider2D other){
        PlayerController player = other.GetComponent<PlayerController>();

        Popup.SetActive(false);
        if(player != null){
            player.SetGreenhouse(null);
        }
    }
}
