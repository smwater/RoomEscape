using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyLock : MonoBehaviour
{
    public bool IsLock { get; private set; }

    private void Awake()
    {
        IsLock = true;
    }

    private void OnEnable()
    {
        GameManager.Instance.Unlock.AddListener(Unlock);
    }

    public void Unlock()
    {
        IsLock = false;
    }

    private void OnDisable()
    {
        GameManager.Instance.Unlock.RemoveListener(Unlock);
    }
}
