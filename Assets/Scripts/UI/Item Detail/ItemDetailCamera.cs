using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDetailCamera : MonoBehaviour
{
    private Camera _camera;
    private float _distance;
    private Vector3 _frontPosition = new Vector3(0f, 0f, -5f);

    private void Awake()
    {
        _camera = GetComponent<Camera>();
        _distance = 4000f;
    }

    private void Update()
    {
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction * _distance, Color.yellow);
        RaycastHit hit;
        int layerMask = 1 << LayerMask.NameToLayer("Detail Item");

        if (Physics.Raycast(ray, out hit, _distance, layerMask))
        {
            if (Input.GetMouseButton(0))
            {
                hit.transform.position = Input.mousePosition + _frontPosition;
            }
            if (Input.GetMouseButtonUp(0))
            {
                hit.transform.position = Input.mousePosition;
            }
        }
    }
}
