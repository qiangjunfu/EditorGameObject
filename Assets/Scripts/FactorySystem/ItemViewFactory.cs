using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FactorySystem.Factory
{
    public class ItemViewFactory
    {
        ////暂时只创建 ItemView
        //public T CreateItemView<T>(KnapsackSystem.IItemInfo itemInfo) where T : KnapsackSystem.ItemView
        //{
        //    T t = default(T);
        //    GameObject go = AssetSystem.AssetManager.Instance.ResourcesAssetLoad.LoadItemViewObj(itemInfo.perfabName);
        //    go.name = itemInfo.name + itemInfo.id;
        //    t = go.GetComponent<T>();
        //    t.InitItemView(itemInfo);
        //    return t;
        //}

    }
}