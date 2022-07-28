using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Events;

namespace epoching.easy_screenshot
{
    public class SavePhotoManager
    {

        #if UNITY_IOS && !UNITY_EDITOR
        [DllImport("__Internal")]
        private static extern void _SavePhoto(string readAddr);
        #endif


        public static SavePhotoManager _instance;

        //private void Awake()
        //{

        //    Instance = this;
        //}
        public static SavePhotoManager Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new SavePhotoManager();
                return _instance;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="call">回调函数</param>
        /// <param name="isAnimation">是否需要过场动画</param>
        public void SavePhoto(UnityAction call = null)
        {
            DateTime saveTime = DateTime.Now;
            //一定要加文件后缀！！！！！
            string fileName = string.Format("image{0}:{1}:{2}.png", saveTime.Hour, saveTime.Minute, saveTime.Second);

            Rect re = new Rect(0, 0, Screen.width, Screen.height);
            RenderTexture texture = new RenderTexture(Screen.width, Screen.height, 24);

            Camera.main.targetTexture = texture;
            Camera.main.Render();

            RenderTexture.active = texture;
            Texture2D image = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);

            image.ReadPixels(re, 0, 0);
            image.Apply();
            Camera.main.targetTexture = null;
            RenderTexture.active = null;
            GameObject.Destroy(texture);

            byte[] byts = image.EncodeToPNG();
            switch (Application.platform)
            {
                case RuntimePlatform.Android:
                    string destination = "/mnt/sdcard/Pictures/Screenshots/";
                    if (!Directory.Exists(destination))
                    {
                        Directory.CreateDirectory(destination);
                    }
                    string pathsave = destination + "/" + fileName;

                    try
                    {
                        File.WriteAllBytes(pathsave, byts);

                        string[] paths = new string[1];
                        paths[0] = pathsave;
                        ScanFile(paths);
                    }
                    catch (Exception e)
                    {
                        Debug.Log(e.ToString());
                    }
                    break;
                case RuntimePlatform.IPhonePlayer:
                    pathsave = Application.persistentDataPath + "/" + fileName;

                    File.WriteAllBytes(pathsave, byts);

#if UNITY_IOS && !UNITY_EDITOR
                   _SavePhoto(path_save);
#endif


                    break;
            }
            if (call != null)
            {
                call.Invoke();
            }
        }

        void CameraShootScreen(string name, UnityAction call)
        {
            //yield return new WaitForEndOfFrame();

        }

        static void ScanFile(string[] path)
        {
            using (AndroidJavaClass PlayerActivity = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
            {
                AndroidJavaObject playerActivity = PlayerActivity.GetStatic<AndroidJavaObject>("currentActivity");
                using (AndroidJavaObject Conn = new AndroidJavaObject("android.media.MediaScannerConnection", playerActivity, null))
                {
                    Conn.CallStatic("scanFile", playerActivity, path, null, null);
                }
            }
        }
    }
}

