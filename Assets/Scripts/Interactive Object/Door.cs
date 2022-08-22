using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    private Outline _outline;
    private float _timer;
    private Animator _animator;
    private bool _onoff;

    private void Awake()
    {
        _outline = gameObject.AddComponent<Outline>();

        _outline.OutlineMode = Outline.Mode.OutlineAll;
        _outline.OutlineColor = Color.magenta;
        _outline.OutlineWidth = 5f;

        _animator = GetComponent<Animator>();

        Inactive();
    }

    private void FixedUpdate()
    {
        _timer += Time.fixedDeltaTime;

        if (_timer >= 0.1f)
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
        _onoff = !_onoff;
        _animator.SetBool("open", _onoff);
    }
}
