using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Close : MonoBehaviour
{
    public GameObject[] Components = new GameObject[3];

    public void Click()
    {
        for (int i = 0; i < 3; i++)
        {
            Components[i].SetActive(false);
        }
    }
}
