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

    public void Unlock()
    {
        IsLock = false;
    }
}
