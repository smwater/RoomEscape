using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseUI : MonoBehaviour
{
    public PlayerInput PlayerInput;

    private GameObject[] _childs;
    private int _childCount;
    private bool _isOnPause;

    private void Awake()
    {
        _isOnPause = false;

        _childCount = transform.childCount;
        _childs = new GameObject[_childCount];

        for (int i = 0; i < _childCount; i++)
        {
            _childs[i] = transform.GetChild(i).gameObject;
        }
    }

    private void Update()
    {
        if (PlayerInput.Pause && !_isOnPause)
        {
            On();
            GameManager.Instance.PlayerCanMovement = false;
            _isOnPause = true;
        }
        else if (PlayerInput.Pause && _isOnPause)
        {
            Off();
            GameManager.Instance.PlayerCanMovement = true;
            _isOnPause = false;
        }    
    }

    public void On()
    {
        for (int i = 0; i < _childCount; i++)
        {
            _childs[i].SetActive(true);
        }
    }

    public void Off()
    {
        for (int i = 0; i < _childCount; i++)
        {
            _childs[i].SetActive(false);
        }
    }
}
