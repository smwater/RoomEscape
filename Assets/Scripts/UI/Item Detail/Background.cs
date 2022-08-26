using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    public void Click()
    {
        GameManager.Instance.MergePaper.Invoke();
    }
}
