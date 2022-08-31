using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public float X { get; private set; }
    public float Y { get; private set; }
    public bool LeftClick { get; private set; }
    public bool RightClick { get; private set; }
    public float MouseMoveX { get; private set; }
    public float MouseMoveY { get; private set; }
    public bool BowDown { get; private set; }

    private float _distance = 4f;

    private void Update()
    {
        X = Y = MouseMoveX = MouseMoveY = 0f;

        X = Input.GetAxis("Horizontal");
        Y = Input.GetAxis("Vertical");
        MouseMoveX = Input.GetAxis("Mouse X");
        MouseMoveY = Input.GetAxis("Mouse Y");

        if (Input.GetMouseButtonDown(0))
        {
            LeftClick = true;
        }
        else
        {
            LeftClick = false;
        }

        if (Input.GetMouseButton(1))
        {
            RightClick = true;
        }
        else
        {
            RightClick = false;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            BowDown = true;
        }
        else
        {
            BowDown = false;
        }

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction * _distance, Color.green);
        RaycastHit hit;
        int layerMask = 1 << LayerMask.NameToLayer("Interactive Item");

        if (Physics.Raycast(ray, out hit, _distance, layerMask) && GameManager.Instance.PlayerCanMovement)
        {
            if (hit.transform.GetComponent<IInteractable>() == null)
            {
                return;
            }

            IInteractable interactable = hit.transform.GetComponent<IInteractable>();

            interactable.Active();

            if (LeftClick)
            {
                interactable.Interact();
            }

            if (LeftClick && hit.transform.tag == "KeyLock")
            {
                GameManager.Instance.UseKey.Invoke();
            }
        }
    }
}
