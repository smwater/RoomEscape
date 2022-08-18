using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public float X { get; private set; }
    public float Y { get; private set; }
    public float LeftClick { get; private set; }
    public bool RightClick { get; private set; }
    public float MouseMoveX { get; private set; }
    public float MouseMoveY { get; private set; }

    private void Update()
    {
        X = Input.GetAxis("Horizontal");
        Y = Input.GetAxis("Vertical");
        LeftClick = Input.GetAxis("Fire1");
        MouseMoveX = Input.GetAxis("Mouse X");
        MouseMoveY = Input.GetAxis("Mouse Y");

        if (Input.GetMouseButton(1))
        {
            RightClick = true;
        }
        else
        {
            RightClick = false;
        }
    }
}
