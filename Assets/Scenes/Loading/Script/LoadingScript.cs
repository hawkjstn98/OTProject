using System;
using System.Collections;
using System.Collections.Generic;
using GameSystem.Service;
using UnityEngine;
using UnityEngine.UI;

public class LoadingScript : MonoBehaviour
{
    public GameObject progressBar;
    private Image image;
    private bool canJump;
    private int itr;

    private void Awake()
    {
        canJump = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        image = progressBar.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        image.fillAmount = SceneService.Instance.GetProgress();
        if (0.9f == image.fillAmount)
        {
            image.fillAmount += 0.1f;
            StartCoroutine(Delay());
        }
    }

    private IEnumerator Delay()
    {
        yield return new WaitForSeconds(1);
        SceneService.Instance.JumpToScene();
    }
}
