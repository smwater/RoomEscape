using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public GameObject[] Prefabs;

    private GameObject[] _slots;
    private InventorySlot[] _inventorySlots;
    private int _slotCount;
    private int _selectedSlotIndex = -1;

    private void Awake()
    {
        _slotCount = transform.childCount;
        _slots = new GameObject[_slotCount];
        _inventorySlots = new InventorySlot[_slotCount];

        for (int i = 0; i < _slotCount; i++)
        {
            _slots[i] = transform.GetChild(i).gameObject;
            _inventorySlots[i] = transform.GetChild(i).gameObject.GetComponent<InventorySlot>();
        }
    }

    public bool Store(Item.ItemNames itemName)
    {
        int blankSlotIndex = CheckCapacity();

        if (blankSlotIndex == -1)
        {
            return false;
        }

        GameObject item = Instantiate(Prefabs[(int)itemName], _slots[blankSlotIndex].transform);

        return true;
    }

    private int CheckCapacity()
    {
        int blankSlotIndex;

        for (blankSlotIndex = 0; blankSlotIndex < _slotCount; blankSlotIndex++)
        {
            if (_slots[blankSlotIndex].transform.childCount == 0)
            {
                break;
            }
        }

        if (blankSlotIndex == _slotCount)
        {
            return -1;
        }

        return blankSlotIndex;
    }

    public void Select(int slotIndex)
    {
        if (_selectedSlotIndex != -1)
        {
            _inventorySlots[_selectedSlotIndex].UnSelect();
        }    

        _selectedSlotIndex = slotIndex;
        _inventorySlots[_selectedSlotIndex].Select();
    }
}
