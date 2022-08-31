using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public Transform HeadTransform;

    private float _moveSpeed = 5f;
    private float _positionX;
    private float _positionZ;

    private bool _sitDown = false;
    private float _upDownSpeed = 0.03f;

    private float _rotateSpeed = 500f;
    private float _rotateMoveX;
    private float _rotateX = 0f;
    private float _rotateMoveY;
    private float _rotateY;

    private PlayerInput _input;

    private void Awake()
    {
        _input = GetComponent<PlayerInput>();
    }

    private void OnEnable()
    {
        GameManager.Instance.ViewItemDetail.AddListener(MovementOff);
        GameManager.Instance.CloseItemDetail.AddListener(MovementOn);
    }

    private void Update()
    {
        if (!GameManager.Instance.PlayerCanMovement)
        {
            return;
        }

        _positionX = _input.X * _moveSpeed * Time.deltaTime;
        _positionZ = _input.Y * _moveSpeed * Time.deltaTime;

        transform.Translate(_positionX, 0f, _positionZ, Space.Self);

        if (_input.RightClick)
        {
            _rotateMoveY = _input.MouseMoveX * _rotateSpeed * Time.deltaTime;
            _rotateMoveX = -_input.MouseMoveY * _rotateSpeed * Time.deltaTime;

            _rotateX += _rotateMoveX;
            _rotateY = transform.eulerAngles.y + _rotateMoveY;

            _rotateX = Mathf.Clamp(_rotateX, -90, 50);

            transform.eulerAngles = new Vector3(0f, _rotateY, 0f);
            HeadTransform.eulerAngles = new Vector3(_rotateX, _rotateY, 0f);
        }

        if (_input.BowDown && !_sitDown)
        {
            StartCoroutine(SitDown());
            _sitDown = true;
        }
        if (_input.BowDown && _sitDown)
        {
            StartCoroutine(StandUp());
            _sitDown = false;
        }
    }

    private void OnDisable()
    {
        GameManager.Instance.ViewItemDetail.RemoveListener(MovementOff);
        GameManager.Instance.CloseItemDetail.RemoveListener(MovementOn);
    }

    public void MovementOn()
    {
        GameManager.Instance.PlayerCanMovement = true;
    }

    public void MovementOff()
    {
        GameManager.Instance.PlayerCanMovement = false;
    }

    private IEnumerator StandUp()
    {
        for (float y = HeadTransform.position.y; y <= 3.5f; y += _upDownSpeed)
        {
            MovementOff();
            _moveSpeed = 5f;
            HeadTransform.position = new Vector3(HeadTransform.position.x, y, HeadTransform.position.z);
            yield return null;
            MovementOn();
        }
    }

    private IEnumerator SitDown()
    {
        for (float y = HeadTransform.position.y; y >= 1.9f; y -= _upDownSpeed)
        {
            MovementOff();
            _moveSpeed = 1f;
            HeadTransform.position = new Vector3(HeadTransform.position.x, y, HeadTransform.position.z);
            yield return null;
            MovementOn();
        }
    }
}
