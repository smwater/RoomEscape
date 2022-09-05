using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperPuzzle : MonoBehaviour
{
    public float FixedCoordX;
    public float FixedCoordY;
    public enum PuzzleNames
    {
        Paper1 = 1,
        Paper2,
        Paper3,
        Paper4
    }

    public PuzzleNames PuzzleName;

    private bool _isCount = false;
    private Transform _parentTransform;
    private BoxCollider _parentBoxCollider;

    private void Awake()
    {
        _parentTransform = transform.parent.GetComponent<Transform>();
        _parentBoxCollider = _parentTransform.GetComponent<BoxCollider>();
    }

    private void Update()
    {
        if (_isCount)
        {
            _parentTransform.localPosition = new Vector3(FixedCoordX, FixedCoordY, 0f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!_isCount && other.transform.GetComponent<PaperLocation>()?.LocationName == (PaperLocation.LocationNames)PuzzleName)
        {
            GameManager.Instance.SetPuzzleCount++;
            _isCount = true;
            _parentBoxCollider.enabled = false;
        }
    }
}
