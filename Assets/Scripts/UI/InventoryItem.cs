using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour//, IDragHandler, IEndDragHandler
{
    public enum EquipmentType
    {
        Key,
        Paper
    };

    public EquipmentType EquipmentName;

    public bool _itemActive { get; private set; }

    private void OnEnable()
    {
        GameManager.Instance.UseKey.AddListener(Use);
    }

    private void Awake()
    {
        _itemActive = false;
    }

    private void OnDisable()
    {
        GameManager.Instance.UseKey.RemoveListener(Use);
    }

    //private float pivotIntervalY = 30f;
    //private float parentIntervalY = 40f;

    //private void OnMouseDrag()
    //{
    //    Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0f);
    //    Vector3 objectPosition = Camera.main.ScreenToViewportPoint(mousePosition);
    //    transform.position = objectPosition;
    //}

    //public void OnDrag(PointerEventData eventData)
    //{
    //    transform.position = new Vector3(eventData.position.x, eventData.position.y + pivotIntervalY, 0f);
    //}

    //public void OnEndDrag(PointerEventData eventData)
    //{
    //    transform.position = new Vector3(transform.parent.position.x, transform.parent.position.y + parentIntervalY, 0f);
    //}

    public void Use()
    {
        if (EquipmentName == EquipmentType.Key && _itemActive)
        {
            GameManager.Instance.Unlock.Invoke();
            Destroy(gameObject);
        }
    }

    public void ItemActiveInactive()
    {
        _itemActive = !_itemActive;
    }
}
