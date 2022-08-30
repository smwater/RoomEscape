using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperPuzzle : MonoBehaviour
{
    public enum PuzzleNames
    {
        Paper1 = 1,
        Paper2,
        Paper3,
        Paper4
    }

    public PuzzleNames PuzzleName;

    private bool _isCount = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!_isCount && other.transform.GetComponent<PaperLocation>()?.LocationName == (PaperLocation.LocationNames)PuzzleName)
        {
            GameManager.Instance.SetPuzzleCount++;
            _isCount = true;
        }
    }
}
