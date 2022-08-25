using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseButton : MonoBehaviour
{
    public void CloseItemDetail()
    {
        GameManager.Instance.CloseItemDetail.Invoke();
    }
}
