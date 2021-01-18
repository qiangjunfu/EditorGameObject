using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace FactorySystem.Factory
{
    public  class SpriteFactory
    {
        /// <summary>
        /// 加载图片
        /// </summary>
        public Sprite LoadSprite(string name)
        {
            return AssetSystem.AssetManager.Instance.ResourcesAssetLoad.LoadSprite(name);
        }

        /// <summary>
        /// 加载图集
        /// </summary>
        public Sprite[] LoadAtlas(string path)
        {
            return AssetSystem.AssetManager.Instance.ResourcesAssetLoad.LoadAtlas(path);
        }
    }
}