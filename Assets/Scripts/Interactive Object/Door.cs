using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    private Outline _outline;
    private float _timer;
    private float _timeLimit = 0.1f;
    private Animator _animator;
    private bool _onoff;
    private int _doorNum;

    private void Awake()
    {
        _outline = gameObject.AddComponent<Outline>();

        _outline.OutlineMode = Outline.Mode.OutlineAll;
        _outline.OutlineColor = Color.magenta;
        _outline.OutlineWidth = 5f;

        Inactive();

        _animator = GetComponentInParent<Transform>().GetComponentInParent<Animator>();

        if (_animator == null)
        {
            _animator = GetComponentInParent<Transform>().GetComponentInParent<Transform>().GetComponentInParent<Animator>();
        }
    }

    private void FixedUpdate()
    {
        _timer += Time.fixedDeltaTime;

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
        string keyword = "open";
        if (gameObject.GetComponent<DoorNumber>() != null)
        {
            _doorNum = gameObject.GetComponent<DoorNumber>().Number;
            keyword += _doorNum.ToString();
        }

        _onoff = !_onoff;

        _animator.SetBool(keyword, _onoff); 
    }
}
