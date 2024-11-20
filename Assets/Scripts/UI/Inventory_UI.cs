using JetBrains.Annotations;
using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class Inventory_UI : MonoBehaviour
{
    public GameObject inventoryPanel;

    public Player player;

    public List<Slot_UI> slots = new List<Slot_UI>();

    private void Awake()
    {
        CloseInventory();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            ToggleInventory(KeyCode.Tab);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleInventory(KeyCode.Escape);
        }
    }

    public void ToggleInventory(KeyCode val)
    {
        if (!inventoryPanel.activeSelf && val == KeyCode.Tab)
        {
            inventoryPanel.SetActive(true);
            Setup();
        }
        else
        {
            inventoryPanel.SetActive(false);
        }
    }
    public void CloseInventory()
    {
        inventoryPanel.SetActive(false);
    }

    void Setup()
    {
        Debug.Log("In Setup()");
        Debug.Log("slots.Count:" + slots.Count);
        Debug.Log("player.inventory.slots.Count:" + player.inventory.slots.Count);
            if (slots.Count == player.inventory.slots.Count)
        {
            for (int i = 0; i < slots.Count; i++)
            {

                Debug.Log("player.inventory.slots[i].type: " + player.inventory.slots[i].type);
                if (player.inventory.slots[i].type != CollectableType.NONE)
                {
                    slots[i].SetItem(player.inventory.slots[i]);
                }
                else
                {
                    slots[i].SetEmpty();
                }
            }
        }
    }
}
