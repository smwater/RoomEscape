using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Book : MonoBehaviour, IInteractable
{
    private Outline _outline;
    private float _timer;
    private readonly float _timeLimit = 0.3f;

    private void Awake()
    {
        _outline = gameObject.AddComponent<Outline>();

        _outline.OutlineMode = Outline.Mode.OutlineAll;
        _outline.OutlineColor = Color.magenta;
        _outline.OutlineWidth = 5f;

        Inactive();
    }

    private void Update()
    {
        _timer += Time.deltaTime;

        if (_timer >= _timeLimit)
        {
            Inactive();
            _timer = 0f;
        }
    }

    public void Active()
    {
        _outline.enabled = true;
    }

    public void Inactive()
    {
        _outline.enabled = false;
    }

    public void Interact()
    {
        
    }

    private float _distance = 2.5f;

    private void OnMouseDrag()
    {
        if (GameManager.Instance.PlayerCanMovement)
        {
            Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, _distance);
            Vector3 objectPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            transform.position = objectPosition;
            transform.rotation = Quaternion.Euler(0f, 90f, 0f);
        }
    }
}
