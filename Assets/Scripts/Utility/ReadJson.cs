using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace UnityUtility
{
    public class ReadJson
    {
        /// <summary>
        /// 写入json文件
        /// </summary>
        /// <param name="t">T 类型实例类/List集合类</param>
        /// <param name="path">路径</param>
        public static void WriteJson<T>(T t, string path) where T : new()
        {
            string str = Newtonsoft.Json.JsonConvert.SerializeObject(t);
            Debug.Log (str);
            ReadTxt.WriteInTxtByStream(path, str);
        }


        /// <summary>
        /// 读取json文件单个类
        /// </summary>
        public static T ReadJsonData<T>(string path) where T : new()
        {
            string s = ReadTxt.ReadTxtByAllText(path);
            T t = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(s);
            return t;
        }


        /// <summary>
        /// 读取json文件多个类 到List<T>
        /// </summary>
        public static List<T> ReadJsonArray<T>(string path) where T : new()
        {
            string s = ReadTxt.ReadTxtByAllText(path);
            Debug.LogFormat("{1} 读取信息: {0}", s , path );
            List<T> t = Newtonsoft.Json.JsonConvert.DeserializeObject<List<T>>(s);
            return t;
        }
        
    }
}