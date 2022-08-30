using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paper : MonoBehaviour
{
    private GameObject[] _papers;
    private int _paperCount;
    private int _mergeCount = 0;

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

    private void Update()
    {
        if (GameManager.Instance.SetPuzzleCount == 4)
        {
            Finished();
        }
    }

    private void OnDisable()
    {
        GameManager.Instance.MergePaper.RemoveListener(Add);
    }

    public void Add()
    {
        int index = 0;

        foreach (var item in GameManager.Instance.ItemHashmap)
        {
            if (item.Value == true && item.Key != InventoryItem.ItemNames.Paper1)
            {
                index = (int)item.Key - 1;
                _mergeCount++;
            }
        }

        GameManager.Instance.ItemHashmap.Remove((InventoryItem.ItemNames)index + 1);

        _papers[index].SetActive(true);

        if (_mergeCount == 3)
        {
            GameManager.Instance.OnPuzzleBoard.Invoke();
        }
    }

    public void Finished()
    {
        for (int i = 0; i < _paperCount; i++)
        {
            _papers[i].SetActive(false);
        }

        _papers[4].SetActive(true);
    }
}
