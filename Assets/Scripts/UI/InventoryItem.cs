using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour
{
    public enum ItemNames
    {
        Key,
        Paper1,
        Paper2,
        Paper3,
        Paper4,
        PaperFinal
    };

    public ItemNames ItemName;

    public bool _itemActive { get; private set; }

    private InventorySlot _slot;

    private void OnEnable()
    {
        GameManager.Instance.UseKey.AddListener(UseKey);
        GameManager.Instance.CloseItemDetail.AddListener(ItemInactive);
    }

    private void Awake()
    {
        _itemActive = false;
        _slot = GetComponentInParent<InventorySlot>();
    }

    private void Update()
    {
        if (_itemActive)
        {
            _slot.Select();
        }
        else
        {
            _slot.Deselect();
        }
    }

    private void OnDisable()
    {
        GameManager.Instance.UseKey.RemoveListener(UseKey);
        GameManager.Instance.CloseItemDetail.RemoveListener(ItemInactive);
    }

    public void UseKey()
    {
        if (ItemName == ItemNames.Key && _itemActive)
        {
            GameManager.Instance.Unlock.Invoke();
            _slot.NotExsited();
            Destroy(gameObject);
        }
    }

    public void ItemActiveInactive()
    {
        _itemActive = !_itemActive;
    }

    public void ItemInactive()
    {
        _itemActive = false;
    }

    public void ShowDetail()
    {
        if (ItemName == ItemNames.Paper1 && _itemActive)
        {
            GameManager.Instance.ViewItemDetail.Invoke();
        }
    }
}
