using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manual : MonoBehaviour
{
    public GameObject[] Component = new GameObject[3];

    public void On()
    {
        for (int i = 0; i < 3; i++)
        {
            Component[i].SetActive(true);
        }
    }
}
