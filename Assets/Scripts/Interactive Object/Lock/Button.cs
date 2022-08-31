using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour, IInteractable
{
    public enum Type
    {
        Zero,
        One,
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Confirm,
        Erase
    };

    public Type Name;

    private NumberLock _numberLock;
    private Outline _outline;
    private float _timer;
    private readonly float _timeLimit = 0.1f;
    private AudioSource _audioSource;

    private void Awake()
    {
        _numberLock = GetComponentInParent<NumberLock>();
        _audioSource = GetComponent<AudioSource>();
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
            _timer = 0;
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
        _audioSource.Play();

        if (Name == Type.Confirm)
        {
            _numberLock.Confirm();
            return;
        }

        if (Name == Type.Erase)
        {
            _numberLock.Erase();
            return;
        }

        _numberLock.InputNumber = (int)Name;
    }
}
