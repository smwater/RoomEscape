using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public GameObject[] Prefabs;

    private GameObject[] _slots;
    private int _slotCount;

    private void Awake()
    {
        _slotCount = transform.childCount;
        _slots = new GameObject[_slotCount];

        for (int i = 0; i < _slotCount; i++)
        {
            _slots[i] = transform.GetChild(i).gameObject;
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
}
