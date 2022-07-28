using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class IntroScene : MonoBehaviour
{
    public GameObject teamLogo;

    public float fadeTime = 3.0f;

    void Start()
    {

    }
    void Update()
    {
        if (Input.touchCount > 0)
        {
            StartCoroutine(FadeOut(1, 0));
            //StartCoroutine(FadeOutBackground(1, 0));
        }
    }

    IEnumerator FadeOut(float start, float end)
    {
        float currentTime = 0.0f;
        float percent = 0.0f;

        while (percent <= 1)
        {
            // ����ð�
            currentTime += Time.deltaTime;
            percent = currentTime / fadeTime;
            // �̹����� color�� getcomponent
            Color color = teamLogo.GetComponent<Image>().color;
            // lerp�� ���İ� ���� (1���� 0�� ������) 
            color.a = Mathf.Lerp(start, end, percent);
            // ����� �÷�(���İ�) ����
            teamLogo.GetComponent<Image>().color = color;

            yield return null;
        }
        teamLogo.SetActive(false);

    }
}

