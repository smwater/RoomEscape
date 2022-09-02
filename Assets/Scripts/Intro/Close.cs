using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Close : MonoBehaviour
{
    public GameObject ManualObject;
    public GameObject HideComponents;
    public GameObject ShowComponents;

    public void Click()
    {
        ManualObject.SetActive(false);
        HideComponents.SetActive(false);
        ShowComponents.SetActive(true);
    }
}
