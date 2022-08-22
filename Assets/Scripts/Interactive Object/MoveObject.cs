using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    private float _distance = 2.5f;

    private void OnMouseDrag()
    { 
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, _distance);
        Vector3 objectPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        transform.position = objectPosition;
    }
}
