using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour, IInteractable
{
    public Inventory Inventory;

    private Outline _outline;
    private float _timer;
    private readonly float _timeLimit = 0.1f;

    public enum ItemNames
    {
        Key,
        Paper1,
        Paper2,
        Paper3,
        Paper4
    }

    public ItemNames ItemName;

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
        if (Inventory.Store(ItemName))
        {
            gameObject.SetActive(false);
        }
    }
}
