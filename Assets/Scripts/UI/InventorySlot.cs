using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public int SlotIndex;

    private Image _slotImage;
    private Color _originColor;
    private Inventory _inventory;

    private void Awake()
    {
        _slotImage = GetComponent<Image>();
        _originColor = _slotImage.color;
        _inventory = GetComponentInParent<Inventory>();
    }

    public void Select()
    {
        _slotImage.color = Color.green;
        _inventory.SingleSelect(SlotIndex);
    }

    public void Deselect()
    {
        _slotImage.color = Color.white;
    }

    public void NotExsited()
    {
        _slotImage.color = _originColor;
    }
}
