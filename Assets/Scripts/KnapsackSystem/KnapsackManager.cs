using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public delegate void CreateGridDelegate(Grid grid);
public delegate void TakeOutItemDelegate(Item item);
public delegate void PutIniItemDelegate(Grid grid, Item item);
public delegate void ExchangeItemDelegate(Grid grid1, Item item1, Grid grid2, Item item2);


[System.Serializable]
/// <summary>
/// 背包管理器
/// </summary>
public class KnapsackManager
{
    /// <summary>
    /// 创建背包格子事件
    /// </summary>
    public event CreateGridDelegate CreateGridEvent;
    /// <summary>
    /// 取出物品事件
    /// </summary>
    public event TakeOutItemDelegate TakeOutItemEvent;
    /// <summary>
    /// 放入物品事件
    /// </summary>
    public event PutIniItemDelegate PutInItemEvent;
    /// <summary>
    /// 交换物品事件
    /// </summary>
    public event ExchangeItemDelegate ExchangeItemEvent;
    /// <summary>
    /// 背包格子列表
    /// </summary>
    [SerializeField] private List<Grid> gridList;
    /// <summary>
    /// 物品列表
    /// </summary>
    [SerializeField] private List<Item> itemList;



    public KnapsackManager()
    {
        gridList = new List<Grid>();
        itemList = new List<Item>();
    }


    #region  拾取物品回调
    public void OnEnableNew()
    {
        ItemObject.PickUpItemEvent += PickUpItemCallback;
    }
    public void OnDisableNew()
    {
        ItemObject.PickUpItemEvent -= PickUpItemCallback;
    }
    private bool PickUpItemCallback(Item item)
    {
        return PutInGrid(item);
    }
    #endregion


    public void InitKnapsack()
    {
        //初始化背包物品
        string itemInfoPath = System.IO.Path.Combine(Application.streamingAssetsPath, "ItemInfo", "ItemInfo.json");
        itemList = UnityUtility.ReadJson.ReadJsonArray<Item>(itemInfoPath);

        gridList = new List<Grid>(itemList.Count);

        //初始化背包格子
        for (int i = 0; i < itemList.Count; i++)
        {
            Grid grid = new Grid();
            grid.Item = itemList[i];
            gridList.Add(grid);
            CreateGridEvent?.Invoke(grid);

            if (itemList[i] != null)
            {
                PutInItemEvent?.Invoke(gridList[i], itemList[i]);
            }
        }
    }



    /// <summary>
    /// 将拾取item放入物品格子
    /// </summary>
    public bool PutInGrid(Item item)
    {
        if (item == null)
        {
            Debug.Log($"KnapsackManager -> PutInItem() ->  item == null -------");
            return false;
        }

        if (IsContainsItem(item) == false)
        {
            //寻找空格子 放入Item
            for (int i = 0; i < gridList.Count; i++)
            {
                if (gridList[i].Item == null)
                {
                    itemList[i] = item;
                    gridList[i].Item = item;
                    PutInItemEvent?.Invoke(gridList[i], gridList[i].Item);
                    return true;
                }
            }
            Debug.Log($"KnapsackManager -> PutInItem() -> 背包格子已经被沾满 -------");
        }
        return false;
    }

    /// <summary>
    /// 将item放入指定grid格子
    /// </summary>
    public bool PutInAssignGrid(Grid grid, Item item)
    {
        if (item == null)
        {
            Debug.Log($"KnapsackManager -> PutInAssignGrid() ->  item == null -------");
            return false;
        }

        if (IsContainsItem(item) == false)
        {
            for (int i = 0; i < gridList.Count; i++)
            {
                if (gridList[i] == grid)
                {
                    itemList[i] = item;
                    gridList[i].Item = item;
                    PutInItemEvent?.Invoke(gridList[i], itemList[i]);
                    return true;
                }
            }
            Debug.Log($"KnapsackManager -> PutInAssignGrid() -> 背包格子列表不包含{grid}-------");
        }
        return false;
    }

    /// <summary>
    /// 通过id取出item 
    /// </summary>
    public void TakeOutItemById(int itemId)
    {
        for (int i = 0; i < itemList.Count; i++)
        {
            if (itemList[i].id == itemId)
            {
                TakeOutItemEvent?.Invoke(itemList[i]);
                itemList[i] = null;
                gridList[i].Item = itemList[i];
                return;
            }
        }
        Debug.Log($"KnapsackManager -> TakeOutItemById() -> 物品列表没有该Id:{itemId } 的Item");
    }
    /// <summary>
    /// 取出item
    /// </summary>
    public void TakeOutItem(Item item)
    {
        for (int i = 0; i < itemList.Count; i++)
        {
            if (itemList[i] == item)
            {
                TakeOutItemEvent?.Invoke(itemList[i]);
                itemList[i] = null;
                gridList[i].Item = itemList[i];
                return;
            }
        }
        Debug.Log($"KnapsackManager -> TakeOutItem() -> 物品列表没有该Item:{item.ToString()  } ");
    }

    /// <summary>
    /// 交换物品
    /// </summary>
    public void ExchangeItem(Grid grid1, Item item1, Grid grid2, Item item2)
    {
        //交换itemList列表数据
        int index1 = -1;
        int index2 = -1;
        for (int i = 0; i < gridList.Count; i++)
        {
            if (gridList[i] == grid1)
            {
                index1 = i;
            }
            if (gridList[i] == grid2)
            {
                index2 = i;
            }
        }

        if (index1 == -1 || index2 == -1)
        {
            Debug.Log($"KnapsackManager -> ExchangeItem() -> (index1 =={index1 } || index2 =={index2 }");
            return;
        }


        itemList[index1] = item2;
        itemList[index2] = item1;
        gridList[index1].Item = itemList[index1];
        gridList[index2].Item = itemList[index2];
        ExchangeItemEvent?.Invoke(gridList[index1], itemList[index1], gridList[index2], itemList[index2]);
        ////再交换gridList列表数据
        //grid1.Item = item2;
        //grid2.Item = item1;
        //ExchangeItemEvent?.Invoke(grid1, item2, grid2, item1);
    }



    /// <summary>
    /// 当前Grid格子是否包含Item
    /// </summary>
    public bool isContainsItem(Grid grid)
    {
        for (int i = 0; i < gridList.Count; i++)
        {
            if (gridList[i] == grid)
            {
                if (gridList[i].Item == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
        Debug.Log($"KnapsackManager -> isContainsItem() -> 不存在该Grid:{grid}");
        return false;
    }

    /// <summary>
    /// 背包是否存在相同物品
    /// </summary>
    bool IsContainsItem(Item item)
    {
        ////一个格子只放一个
        //for (int i = 0; i < itemList.Count; i++)
        //{
        //    if (itemList[i].id == item.id)
        //    {
        //        //背包里有相同物品, 只个数加1
        //        return true;
        //    }
        //}
        return false;
    }
}
