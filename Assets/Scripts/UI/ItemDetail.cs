using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDetail : MonoBehaviour
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
    }

    private void OnDisable()
    {
        GameManager.Instance.ViewItemDetail.RemoveListener(OnItemDetailUI);
    }

    public void OnItemDetailUI()
    {
        for (int i = 0; i < _childCount; i++)
        {
            _childs[i].SetActive(true);
        }
    }
}
