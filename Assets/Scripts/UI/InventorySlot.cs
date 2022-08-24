using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    private Image _slotImage;

    private void Awake()
    {
        _slotImage = GetComponent<Image>();
    }

    public void Select()
    {
        _slotImage.color = Color.green;
    }

    public void UnSelect()
    {
        _slotImage.color = Color.white;
    }
}
