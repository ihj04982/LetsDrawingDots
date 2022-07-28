using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace epoching.easy_screenshot
{

    public class Demo : MonoBehaviour
    {

        [Header("effect image")]
        public Image transition_effect;

        [Header("kaca audio source")]
        public AudioSource audio_source;

        [Header("bg image")]
        public Image image_bg;

        [Header("bg sprite")]
        public Sprite[] sprite_bg;

        private int bg_index = 0;


        //screen shot btn clicked 
        public void on_screenshot_btn_click()
        {
            print("clicked screenshot btn");

            //play effect
            StartCoroutine(this.show_effect());

            //play audio
            this.audio_source.Play();

            //scren ca
            SavePhotoManager.Instance.SavePhoto(this.callback);
        }


        //switch bg btn clicked
        public void on_switch_bg_btn_click()
        {
            this.bg_index++;
            if (this.bg_index >= sprite_bg.Length)
                this.bg_index = 0;

            this.image_bg.sprite = this.sprite_bg[this.bg_index];
        }

        public void callback()
        {
            print("screenshot over");
        }


        //显示屏幕闪烁的效果
        private IEnumerator show_effect()
        {

            this.transition_effect.color = new Color(255, 255, 255, 255);

            this.transition_effect.CrossFadeAlpha(1, 0.01f, true);

            yield return new WaitForSeconds(0.01f);

            this.transition_effect.CrossFadeAlpha(0, 0.8f, true);

            yield return null;
        }
    }

}
