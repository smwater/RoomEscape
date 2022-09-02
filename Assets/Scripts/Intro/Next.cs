using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Next : MonoBehaviour
{
    public GameObject HideComponents;
    public GameObject ShowComponents;

    public void Click()
    {
        HideComponents.SetActive(false);
        ShowComponents.SetActive(true);
    }
}
