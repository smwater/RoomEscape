using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveObject : MonoBehaviour
{
    private Outline _outline;
    private float _timer;

    private void Awake()
    {
        _outline = gameObject.AddComponent<Outline>();

        _outline.OutlineMode = Outline.Mode.OutlineAll;
        _outline.OutlineColor = Color.magenta;
        _outline.OutlineWidth = 5f;

        Inactive();
    }

    public void Active()
    {
        
            _outline.enabled = true;
            _timer += Time.deltaTime;

            Debug.Log(_timer);

            if (_timer >= 0.5f)
            {
                Inactive();
                _timer = 0f;
            }
    }

    public void Inactive()
    {
        _outline.enabled = false;
    }
}
