using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour//, IDragHandler, IEndDragHandler
{
    public enum ItemType
    {
        Key,
        Paper
    };

    public ItemType ItemName;

    public bool _itemActive { get; private set; }

    private void OnEnable()
    {
        GameManager.Instance.UseKey.AddListener(Use);
    }

    private void Awake()
    {
        _itemActive = false;
    }

    private void OnDisable()
    {
        GameManager.Instance.UseKey.RemoveListener(Use);
    }

    public void Use()
    {
        if (ItemName == ItemType.Key && _itemActive)
        {
            GameManager.Instance.Unlock.Invoke();
            Destroy(gameObject);
        }
    }

    public void ItemActiveInactive()
    {
        _itemActive = !_itemActive;
    }
}
