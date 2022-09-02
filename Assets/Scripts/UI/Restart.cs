using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    public void Click()
    {
        GameManager.Instance.PlayerCanMovement = true;
        SceneManager.LoadScene(0);
    }
}
