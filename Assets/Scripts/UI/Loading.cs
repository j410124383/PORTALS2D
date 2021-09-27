using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Loading : MonoBehaviour
{
    public Image fill;
    public float value;
    private AsyncOperation ao;
    public Text text;

    private void Start()
    {
        value = 0f;
        Time.timeScale = 1f;
        if (SceneManager.GetActiveScene().name == "LoadScene") 
        {
            StartCoroutine(Load());
        }

    }

    IEnumerator Load()
    {
        ao = SceneManager.LoadSceneAsync("MainWorld");
        ao.allowSceneActivation = false;
        yield return 0;
    }

    private void Update()
    {
        value = ao.progress;
        if (ao.progress >= 0.9f) value = 1f;

        if (value != fill.fillAmount)
        {
            fill.fillAmount = Mathf.Lerp(fill.fillAmount,value,Time.deltaTime);
            if (value - fill.fillAmount <= 0.01f) fill.fillAmount = value;
            text.text = "LOADING " + Mathf.Round(fill.fillAmount*100)+"%";
        }
        if (fill.fillAmount==1)
        {
            text.text = "PRESS ANYKEY";
            if (Input.anyKeyDown)
            {
                ao.allowSceneActivation = true;
            }
        }
    }


}
