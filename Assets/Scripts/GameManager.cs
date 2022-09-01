using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : SingletonBehaviour<GameManager>
{
    public int SetPuzzleCount = 0;
    public bool PlayerCanMovement;
    public Dictionary<InventoryItem.ItemNames, bool> ItemDictionary = new Dictionary<InventoryItem.ItemNames, bool>();

    public UnityEvent Unlock = new UnityEvent();
    public UnityEvent UseKey = new UnityEvent();
    public UnityEvent MergePaper = new UnityEvent();
    public UnityEvent ViewItemDetail = new UnityEvent();
    public UnityEvent CloseItemDetail = new UnityEvent();
    public UnityEvent OnPuzzleBoard = new UnityEvent();

    private void Start()
    {
        PlayerCanMovement = true;
    }
}

