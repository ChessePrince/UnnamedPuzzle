using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public GameObject goDoor;

    bool doorIsOpen;

    void Start()
    {
        doorIsOpen = false;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            OpenDoor();
        }
    }
    void OpenDoor()
    {
        Debug.Log("door opened");
        goDoor.SetActive(false);
        doorIsOpen = true;
    }
}
