using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NumberLock : MonoBehaviour
{
    public bool IsLock { get; private set; }
    public string Password;
    [HideInInspector] public int InputNumber;
    public TextMeshPro InsertText;

    private int[] _inputPassword = new int[4];
    private int _blankNumberIndex;
    private string _inputedPassword;
    private bool _onErrorLog;

    private void Awake()
    {
        IsLock = true;
        InputNumber = -1;
        _blankNumberIndex = 0;
        _onErrorLog = false;
    }

    private void Update()
    {
        if (InputNumber != -1 && _blankNumberIndex <= 3 && !_onErrorLog)
        {
            _inputPassword[_blankNumberIndex] = InputNumber;
            _blankNumberIndex++;
            InputNumber = -1;

            _inputedPassword = ArrayToString();

            InsertText.text = _inputedPassword;
        }
        else
        {
            InputNumber = -1;
        }
    }

    private string ArrayToString()
    {
        string password = "";

        for (int i = 0; i < _inputPassword.Length; i++)
        {
            if (_inputPassword[i] == 0)
            {
                password += "0";
                continue;
            }
            
            password += _inputPassword[i].ToString();
        }

        return password;
    }

    public void Confirm()
    {
        if (Password.Equals(_inputedPassword))
        {
            InsertText.text = "Success";
            IsLock = false;
        }
        else
        {
            StartCoroutine(Error());

            for (int i = 0; i < _inputPassword.Length; i++)
            {
                _inputPassword[i] = 0;
            }
            _blankNumberIndex = 0;
        }
    }

    private IEnumerator Error()
    {
        _onErrorLog = true;
        InsertText.text = "Error";
        yield return new WaitForSeconds(1f);
        InsertText.text = "0000";
        _onErrorLog = false;
    }

    public void Erase()
    {
        if (_blankNumberIndex <= 0)
        {
            return;
        }

        _inputPassword[--_blankNumberIndex] = 0;

        _inputedPassword = ArrayToString();

        InsertText.text = _inputedPassword;
    }
}
