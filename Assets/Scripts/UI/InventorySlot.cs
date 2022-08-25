using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    private Image _slotImage;
    private Color _originColor;

    private void Awake()
    {
        _slotImage = GetComponent<Image>();
        _originColor = _slotImage.color;
    }

    public void Select()
    {
        _slotImage.color = Color.green;
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
