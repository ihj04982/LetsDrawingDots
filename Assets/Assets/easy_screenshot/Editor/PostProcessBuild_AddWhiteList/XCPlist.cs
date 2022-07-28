using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Epoching_Sober
{
    /// <summary>
    /// 用于实现对Ios里info.plist的读写操作
    /// </summary>
    public class XCPlist : System.IDisposable
    {
        private string filePath;
        List<string> contents = new List<string>();

        public XCPlist(string projPath)
        {
             filePath = Path.Combine(projPath, "info.plist");
            if (!File.Exists(filePath))
            {
                Debug.LogError(filePath + "路径下文件不存在");
                return;
            }
            FileInfo info = new FileInfo(filePath);
            StreamReader sr = info.OpenText();
            if (sr != null)
            {
                while (sr.Peek() > -1)
                {
                    contents.Add(sr.ReadLine());
                }
            }
            sr.Close();
        }

        public void AddKey(string key)
        {
            if (contents.Count < 2)
                return;
            contents.Insert(contents.Count - 2, key);
        }



        public void ReplaceKey(string key, string replace)
        {
            for (int i = 0; i < contents.Count; i++)
            {
                if (contents[i].IndexOf(key) != -1)
                {
                    contents[i] = contents[i].Replace(key, replace);
                }
            }
        }

        public void Save()
        {
            StreamWriter sw = File.CreateText(filePath);
            Debug.Log(filePath);
            foreach (string item in contents)
            {
                sw.WriteLine(item);
            }
            sw.Close();
        }

        public void Dispose()
        {

        }
    }
}

