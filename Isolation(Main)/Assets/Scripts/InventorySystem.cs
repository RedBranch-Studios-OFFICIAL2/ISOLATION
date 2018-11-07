﻿using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySystem : MonoBehaviour {

    public GameObject InventoryGui;
    public GameObject SlotParent;

    public Image[] Slots;
    public GameObject Cam;
    bool Open;

    void Start()
    {
        Open = false;
        Slots = SlotParent.GetComponentsInChildren<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        // Open and Closes the Inventory
        if (Input.GetKeyDown(KeyCode.E) && Open == false)
        {
            Open = true;
            InventoryGui.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cam.GetComponent<CamLook>().enabled = false;
        }
        else if (Input.GetKeyDown(KeyCode.E) && Open == true)
        {
            Open = false;
            InventoryGui.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            Cam.GetComponent<CamLook>().enabled = true;
        }
    }
    // Method that will be called by items that can be picked up
    public void PickUp(GameObject item)
    {
        Debug.Log("You picked up "+ item.name);

        // Sets i to x, in order to keep track of the value of slots being inputted
        


        for (int i = 0; i < Slots.Length; i++)
        {
            if (Slots[i].GetComponent<SlotScript>().StoredObject == null)
            {
                // Sets slot to a random color to display its use
                Slots[i].GetComponent<Image>().color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));

                // Stores the Object Collected
                Slots[i].GetComponent<SlotScript>().StoredObject = item;
                item.transform.parent = Slots[i].transform;
                item.SetActive(false);

                
                return;
            }
            else if(Slots[i].GetComponent<SlotScript>().StoredObject != null)
            {
                i = i + 1;
            }
        }
    }

}