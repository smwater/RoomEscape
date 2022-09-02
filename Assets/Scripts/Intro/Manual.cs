using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manual : MonoBehaviour
{
    public GameObject ManualObject;

    public void On()
    {
        ManualObject.SetActive(true);
    }
}
