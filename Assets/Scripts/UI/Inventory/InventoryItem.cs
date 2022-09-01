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
        PaperMerge
    };

    public ItemNames ItemName;

    public bool Active { get; private set; }

    private InventorySlot _slot;

    private void OnEnable()
    {
        GameManager.Instance.UseKey.AddListener(UseKey);
        GameManager.Instance.CloseItemDetail.AddListener(Inactive);
        GameManager.Instance.MergePaper.AddListener(MergePaper);
    }

    private void Awake()
    {
        Active = false;
        _slot = GetComponentInParent<InventorySlot>();
    }

    private void Update()
    {
        if (Active)
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
        GameManager.Instance.CloseItemDetail.RemoveListener(Inactive);
        GameManager.Instance.MergePaper.RemoveListener(MergePaper);
    }

    public void UseKey()
    {
        if (ItemName == ItemNames.Key && Active)
        {
            GameManager.Instance.Unlock.Invoke();
            _slot.NotExsited();
            Destroy(gameObject);
        }
    }

    public void MergePaper()
    {
        if (ItemName == ItemNames.Paper2 && Active)
        {
            _slot.NotExsited();
            Destroy(gameObject);
        }

        if (ItemName == ItemNames.Paper3 && Active)
        {
            _slot.NotExsited();
            Destroy(gameObject);
        }

        if (ItemName == ItemNames.Paper4 && Active)
        {
            _slot.NotExsited();
            Destroy(gameObject);
        }

    }

    public void TogleActive()
    {
        Active = !Active;

        if (Active)
        {
            GameManager.Instance.ItemDictionary.Add(ItemName, true);
        }
        else
        {
            GameManager.Instance.ItemDictionary.Remove(ItemName);
        }
    }

    public void Inactive()
    {
        Active = false;
    }

    public void ShowDetail()
    {
        if (ItemName == ItemNames.Paper1 && Active)
        {
            GameManager.Instance.ViewItemDetail.Invoke();
        }
    }
}
