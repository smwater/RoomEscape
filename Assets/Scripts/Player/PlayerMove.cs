using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public Transform HeadTransform;

    private bool _isMovement;

    private float _moveSpeed = 5f;
    private float _positionX;
    private float _positionZ;

    private float _rotateSpeed = 500f;
    private float _rotateMoveX;
    private float _rotateX = 0f;
    private float _rotateMoveY;
    private float _rotateY;

    private PlayerInput _input;

    private void Awake()
    {
        _input = GetComponent<PlayerInput>();
        _isMovement = true;
    }

    private void OnEnable()
    {
        GameManager.Instance.ViewItemDetail.AddListener(MovementOff);
        GameManager.Instance.CloseItemDetail.AddListener(MovementOn);
    }

    private void Update()
    {
        if (_isMovement)
        {
            _positionX = _input.X * _moveSpeed * Time.deltaTime;
            _positionZ = _input.Y * _moveSpeed * Time.deltaTime;

            transform.Translate(_positionX, 0f, _positionZ, Space.Self);

            if (_input.RightClick)
            {
                _rotateMoveY = _input.MouseMoveX * _rotateSpeed * Time.deltaTime;
                _rotateMoveX = -_input.MouseMoveY * _rotateSpeed * Time.deltaTime;

                _rotateX += _rotateMoveX;
                _rotateY = transform.eulerAngles.y + _rotateMoveY;

                _rotateX = Mathf.Clamp(_rotateX, -90, 90);

                transform.eulerAngles = new Vector3(0f, _rotateY, 0f);
                HeadTransform.eulerAngles = new Vector3(_rotateX, _rotateY, 0f);
            }
        }
    }

    private void OnDisable()
    {
        GameManager.Instance.ViewItemDetail.RemoveListener(MovementOff);
        GameManager.Instance.CloseItemDetail.RemoveListener(MovementOn);
    }

    public void MovementOn()
    {
        _isMovement = true;
    }

    public void MovementOff()
    {
        _isMovement = false;
    }
}
