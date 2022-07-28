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
            // 현재시간
            currentTime += Time.deltaTime;
            percent = currentTime / fadeTime;
            // 이미지의 color를 getcomponent
            Color color = teamLogo.GetComponent<Image>().color;
            // lerp로 알파값 변경 (1에서 0로 서서히) 
            color.a = Mathf.Lerp(start, end, percent);
            // 변경된 컬러(알파값) 적용
            teamLogo.GetComponent<Image>().color = color;

            yield return null;
        }
        teamLogo.SetActive(false);

    }
}

