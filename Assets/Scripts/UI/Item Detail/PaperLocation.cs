using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperLocation : MonoBehaviour
{
    public enum LocationNames
    {
        Paper1 = 1,
        Paper2,
        Paper3,
        Paper4
    }

    public LocationNames LocationName;

    private bool _isEnter;
    private Transform _otherTransform;

    private void Update()
    {
        if (_isEnter)
        {
            _otherTransform.GetComponentInParent<BoxCollider>().enabled = false;
            _otherTransform.GetComponent<BoxCollider>().enabled = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.GetComponent<PaperPuzzle>()?.PuzzleName == (PaperPuzzle.PuzzleNames)LocationName)
        {
            _isEnter = true;

            _otherTransform = other.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.GetComponent<PaperPuzzle>()?.PuzzleName == (PaperPuzzle.PuzzleNames)LocationName)
        {
            _isEnter = false;

            _otherTransform = null;
        }
    }
}
