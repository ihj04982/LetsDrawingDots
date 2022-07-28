using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TapCountTest : MonoBehaviour
{
    public Text tapText;

    private Vector2 touchPosition;
    // Start is called before the first frame update
    void Start()
    {
        tapText.text = "터치 미작동";
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount >0)
        {
            Touch temptouch = Input.GetTouch(0);
  
         if (temptouch.tapCount > 0)
                tapText.text = "터치 작동"+ temptouch.tapCount;// Input.GetTouch(0).tapCount;

        }


    }
}
