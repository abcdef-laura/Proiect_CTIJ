using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Inventory
{

    [System.Serializable]
    public class Slot
    {
        public CollectableType type;
        public int count;
        public int maxAllowed;

        public Sprite icon;

        public Slot()
        {
            type = CollectableType.NONE;
            count = 0;
            maxAllowed = 99;
        }

        public bool canAddItem()
        {
            if (count < maxAllowed)
            {
                return true;
            }
            return false;     
        }

        public void addItem(WeaponCollect item)
        {
            this.type = item.type;
            this.icon = item.icon;
            count++;
        }
    }

    public List<Slot> slots = new List<Slot>();

    public Inventory(int numSlots)
    {
        for (int i = 0; i < numSlots; i++)
        {
            Slot slot = new Slot();
            slots.Add(slot);
        }
    }

    public void  Add(WeaponCollect item)
    {
        foreach(Slot slot in slots)
        {
            if (slot.type == item.type && slot.canAddItem())
            {
                slot.addItem(item);
                return;
            }
        }

        foreach(Slot slot in slots)
        {
            if (slot.type == CollectableType.NONE)
            {
                slot.addItem(item);
                return;
            }
        }
    }
}
