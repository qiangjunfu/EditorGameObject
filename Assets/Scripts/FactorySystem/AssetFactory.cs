using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace FactorySystem.Factory
{
    public class AssetFactory
    {
        /// <summary>
        /// 创建3d物体
        /// </summary>
        public GameObject CreateGameObject(string name)
        {
            GameObject go = AssetSystem.AssetManager.Instance.ResourcesAssetLoad.LoatAsset(name);
            go.name = name;
            return go;
        }


        /// <summary>
        /// 创建T类型3d物体
        /// </summary>
        public T CreateTObject<T>(string name) where T : Component  
        { 
            T t = default(T);
            GameObject go = AssetSystem.AssetManager.Instance.ResourcesAssetLoad.LoatAsset(name);
            go.name = name;
            t = go.GetComponent<T>();
            return t;
        }
    }
}