using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paper : MonoBehaviour
{
    private int _paperIndex = 1;
    private GameObject[] _papers;
    private int _paperCount;

    private void Awake()
    {
        _paperCount = transform.childCount;
        _papers = new GameObject[_paperCount];

        for (int i = 0; i < _paperCount; i++)
        {
            _papers[i] = transform.GetChild(i).gameObject;
        }
    }

    private void OnEnable()
    {
        GameManager.Instance.MergePaper.AddListener(Add);
    }

    private void OnDisable()
    {
        GameManager.Instance.MergePaper.RemoveListener(Add);
    }

    public void Add()
    {
        if (_paperIndex >= _paperCount - 1)
        {
            return;
        }

        _papers[_paperIndex].SetActive(true);
        _paperIndex++;
    }
}