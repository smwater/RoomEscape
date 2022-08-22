using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamp : MonoBehaviour, IInteractable
{
    private Outline _outline;
    private float _timer;
    private GameObject[] _childs;
    private int _childCount;
    private bool _onoff;

    private void Awake()
    {
        _outline = gameObject.AddComponent<Outline>();

        _outline.OutlineMode = Outline.Mode.OutlineAll;
        _outline.OutlineColor = Color.magenta;
        _outline.OutlineWidth = 5f;

        _childCount = transform.childCount;
        _childs = new GameObject[_childCount];

        for (int i = 0; i < _childCount; i++)
        {
            _childs[i] = transform.GetChild(i).gameObject;
        }

        _onoff = false;

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
        _childs[1].SetActive(_onoff);
    }
}
