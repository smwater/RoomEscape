using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleBoard : MonoBehaviour
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
        GameManager.Instance.OnPuzzleBoard.AddListener(On);
    }

    private void OnDisable()
    {
        GameManager.Instance.OnPuzzleBoard.RemoveListener(On);
    }

    private void On()
    {
        for (int i = 0; i < _childCount; i++)
        {
            _childs[i].SetActive(true);
        }
    }
}
