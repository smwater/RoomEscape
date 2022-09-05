using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    public GameObject EndComponent;

    private Image _image;

    private void Awake()
    {
        _image = GetComponentInChildren<Image>();
        StartCoroutine(Out());
    }

    private void OnEnable()
    {
        GameManager.Instance.Escape.AddListener(FadeIn);
    }

    private void OnDisable()
    {
        GameManager.Instance.Escape.RemoveListener(FadeIn);
    }

    private void FadeIn()
    {
        StartCoroutine(In());
    }    

    private IEnumerator In()
    {
        _image.gameObject.SetActive(true);

        float fadeCount = 0.01f;
        while (fadeCount < 1)
        {
            GameManager.Instance.PlayerCanMovement = false;

            fadeCount += 0.01f;
            yield return new WaitForSeconds(0.05f);
            _image.color = new Color(255, 255, 255, fadeCount);
        }

        EndComponent.gameObject.SetActive(true);
    }

    private IEnumerator Out()
    {
        float fadeCount = 1f;
        while (fadeCount > 0)
        {
            GameManager.Instance.PlayerCanMovement = false;

            fadeCount -= 0.01f;
            yield return new WaitForSeconds(0.05f);
            _image.color = new Color(0, 0, 0, fadeCount);
        }

        GameManager.Instance.PlayerCanMovement = true;

        _image.gameObject.SetActive(false);
    }
}
