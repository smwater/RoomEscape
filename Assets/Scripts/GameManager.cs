using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : SingletonBehaviour<GameManager>
{
    public UnityEvent Unlock = new UnityEvent();
    public UnityEvent UseKey = new UnityEvent();
}
