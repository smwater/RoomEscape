using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperDetailMove : MonoBehaviour
{
    private Camera Camera;

    private void Awake()
    {
        Camera = GetComponentInParent<Transform>().GetComponentInParent<Camera>();
    }

    private void OnMouseDrag()
    {
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 5f);
        Vector3 objectPosition = Camera.ScreenToWorldPoint(mousePosition);
        transform.position = objectPosition;
    }
}
