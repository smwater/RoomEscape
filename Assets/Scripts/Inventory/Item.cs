using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour, IInteractable
{
    public Inventory Inventory;

    private Outline _outline;
    private float _timer;
    private readonly float _timeLimit = 0.1f;

    public enum ItemType
    {
        Key,
        Paper
    }

    public ItemType ItemName;

    private void Awake()
    {
        _outline = gameObject.AddComponent<Outline>();

        _outline.OutlineMode = Outline.Mode.OutlineAll;
        _outline.OutlineColor = Color.magenta;
        _outline.OutlineWidth = 5f;

        Inactive();
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
        Inventory.Store(ItemName);
        gameObject.SetActive(false);
    }
}
