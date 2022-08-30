using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberLock : MonoBehaviour
{
    public bool IsLock { get; private set; }

    private void Awake()
    {
        IsLock = true;
    }
}
