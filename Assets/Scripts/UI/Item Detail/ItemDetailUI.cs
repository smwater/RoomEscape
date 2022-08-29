using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDetailUI : MonoBehaviour
{
    private GameObject[] _childs;
    private int _childCount;

    private void Awake()
    {
        _childCount = transform.childCount;
        _childs = new GameObject[_childCount];

        for (int i = 0; i < _childCount; i++)
        {
            _childs[i] = transform.GetChild(i).gameObject;
        }
    }

    private void OnEnable()
    {
        GameManager.Instance.ViewItemDetail.AddListener(OnItemDetailUI);
        GameManager.Instance.CloseItemDetail.AddListener(OffItemDetailUI);
    }

    private void OnDisable()
    {
        GameManager.Instance.ViewItemDetail.RemoveListener(OnItemDetailUI);
        GameManager.Instance.CloseItemDetail.RemoveListener(OffItemDetailUI);
    }

    public void OnItemDetailUI()
    {
        for (int i = 0; i < _childCount; i++)
        {
            _childs[i].SetActive(true);
        }
    }

    public void OffItemDetailUI()
    {
        for (int i = 0; i < _childCount; i++)
        {
            _childs[i].SetActive(false);
        }

        GameManager.Instance.ItemHashmap.Remove(InventoryItem.ItemNames.Paper1);
    }
}
