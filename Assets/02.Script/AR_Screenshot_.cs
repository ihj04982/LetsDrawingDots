using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;


public class AR_Screenshot_ : MonoBehaviour
{
    public GameObject UI; // UI 전체 묶어서 스크린샷 찍을때 한번에 꺼지도록 설정할거야
    //public GameObject panel; // 찍은 사진이 보여질 곳 
    bool changed;
    public Image flashImage;
    GameObject screen;
    public float flashSpeed = 5f;
    public Color flashColour = new Color(1f, 1f, 1f, 1f);

    // Start is called before the first frame update
    void Start()
    {
        screen = GameObject.Find("Image screenflash");
        screen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //Update Flash image once changed   
        if (changed)
        {
            screen.SetActive(true);
            flashImage.color = flashColour;
        }
        else
        {
            //screen.SetActive(false);
            flashImage.color = Color.Lerp(flashImage.color, Color.clear, flashSpeed * Time.deltaTime);
            if(flashImage.color == Color.clear)
            {
                screen.SetActive(false);
            }
        }
        // Change back to false
        changed = false;
    }



    private IEnumerator Screenshot()
    {
        yield return new WaitForEndOfFrame();
        Texture2D texture = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);

        texture.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0,0);
        texture.Apply();

        string name = "Screenshot" + System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + ".png";

        changed = true; // 카메라 플래쉬
        //screen.SetActive(true);

        //Mobile
        NativeGallery.SaveImageToGallery(texture, "Myapp pictures", name); 
       

        Destroy(texture);
        UI.SetActive(true);
    }
    public void TakeScreenshot()
    {
        UI.SetActive(false);
        StartCoroutine("Screenshot");
    }

    /*
    // 찍은 사진을 Panel에 보여준다.
    void GetPirctureAndShowIt()
    {
        string pathToFile = GetPicture.GetLastPicturePath();
        if (pathToFile == null)
        {
            return;
        }
        Texture2D texture = GetScreenshotImage(pathToFile);
        Sprite sp = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
        panel.SetActive(true);
        panel.GetComponent<Image>().sprite = sp;
    }
    // 찍은 사진을 불러온다.
    Texture2D GetScreenshotImage(string filePath)
    {
        Texture2D texture = null;
        byte[] fileBytes;
        if (File.Exists(filePath))
        {
            fileBytes = File.ReadAllBytes(filePath);
            texture = new Texture2D(2, 2, TextureFormat.RGB24, false);
            texture.LoadImage(fileBytes);
        }
        return texture;
    }
    */
}
