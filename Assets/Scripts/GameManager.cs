using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : SingletonBehaviour<GameManager>
{
    public bool PlayerCanMovement;
    public Dictionary<InventoryItem.ItemNames, bool> ItemHashmap = new Dictionary<InventoryItem.ItemNames, bool>();

    public UnityEvent Unlock = new UnityEvent();
    public UnityEvent UseKey = new UnityEvent();
    public UnityEvent MergePaper = new UnityEvent();
    public UnityEvent ViewItemDetail = new UnityEvent();
    public UnityEvent CloseItemDetail = new UnityEvent();
}
