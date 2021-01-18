//using KnapsackSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FactorySystem.Factory
{
    /// <summary>
    /// 物品信息数据工厂, 根据不同id得到ItemInfo
    /// </summary>
    public class ItemInfoFactory
    {
        ///// <summary>
        ///// 根据不同id得到ItemInfo
        ///// </summary>
        //public T GetItemInfo<T>(int id ) where T : IItemInfo , new () 
        //{
        //    T t = new T();

        //    switch (id )
        //    {
        //        case 1:
        //            t = new ItemInfo_Weapon("大剑", 1, "BackpackItem", "Atlas_Texture1_15", 1, 100, 50, "这是一把大剑", ItemType.Weapon, 10) as T;
        //            break;
        //        case 2:
        //            t = new ItemInfo_Weapon("斧子", 2, "BackpackItem", "Atlas_Texture1_12", 1, 100, 40, "这是一把斧子", ItemType.Weapon, 8) as T;
        //            break;
        //        case 101:
        //            t = new ItemInfo_Material("材料1", 101, "BackpackItem", "Atlas_Texture1_1", 1, 80, 40, "这是打造装备的材料1", ItemType.Material, "功能1") as T;
        //            break;
        //        case 102:
        //            t = new ItemInfo_Material("材料2", 102, "BackpackItem", "Atlas_Texture1_10", 1, 88, 44, "这是打造装备的材料2", ItemType.Material, "功能2") as T;
        //            break;
        //        case 1001:
        //            t = new ItemInfo_Drag("红药", 1001, "BackpackItem", "Atlas_Texture1_4", 1, 10, 5, "这是回血用的", ItemType.Drug, 10, 0, 0, 0) as T;
        //            break;
        //        case 1002:
        //            t = new ItemInfo_Drag("蓝药", 1002, "BackpackItem", "Atlas_Texture1_2", 1, 10, 5, "这是回蓝用的", ItemType.Drug, 0, 10, 0, 0) as T;
        //            break;
        //        default:
        //            Debug.LogError($"没有该id {id} 对应的ItemInfo");
        //            break;
        //    }
        //    return t;
        //}

    }
}