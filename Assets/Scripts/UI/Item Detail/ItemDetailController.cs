using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDetailController : MonoBehaviour
{
    private Camera _camera;
    private float _distance;

    private void Awake()
    {
        _camera = GetComponent<Camera>();
        _distance = 10f;
    }

    private void Update()
    {
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction * _distance, Color.blue);
        RaycastHit hit;
        int layerMask = 1 << LayerMask.NameToLayer("Detail Item");

        if (Physics.Raycast(ray, out hit, _distance, layerMask))
        {
            if (Input.GetMouseButton(0))
            {
                hit.transform.position = Input.mousePosition;
            }
        }
    }
}
