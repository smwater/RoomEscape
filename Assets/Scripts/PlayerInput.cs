using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public float InputX { get; private set; }
    public float InputY { get; private set; }
    public float LeftClick { get; private set; }
    public bool RightClick { get; private set; }

    private void Update()
    {
        InputX = Input.GetAxis("Horizontal");
        InputY = Input.GetAxis("Vertical");
        LeftClick = Input.GetAxis("Fire1");

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
