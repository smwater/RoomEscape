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

    public bool _active { get; private set; }

    private InventorySlot _slot;

    private void OnEnable()
    {
        GameManager.Instance.UseItem.AddListener(Use);
        GameManager.Instance.CloseItemDetail.AddListener(Inactive);
    }

    private void Awake()
    {
        _active = false;
        _slot = GetComponentInParent<InventorySlot>();
    }

    private void Update()
    {
        if (_active)
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
        GameManager.Instance.UseItem.RemoveListener(Use);
        GameManager.Instance.CloseItemDetail.RemoveListener(Inactive);
    }

    public void Use()
    {
        if (ItemName == ItemNames.Key && _active)
        {
            GameManager.Instance.Unlock.Invoke();
            _slot.NotExsited();
            Destroy(gameObject);
        }
    }

    public void ActiveInactive()
    {
        _active = !_active;
    }

    public void Inactive()
    {
        _active = false;
    }

    public void ShowDetail()
    {
        if (ItemName == ItemNames.Paper1 && _active)
        {
            GameManager.Instance.ViewItemDetail.Invoke();
        }
    }
}
