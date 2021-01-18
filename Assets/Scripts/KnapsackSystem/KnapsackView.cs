using System;
using System.Collections;
using System.Collections.Generic;
using UIFramework.MVVM;
using UnityEngine;

/// <summary>
/// 格子数据和格子物体
/// </summary>
[System.Serializable]
public class DictionaryOfGridAndGridView : UnityUtility.SerializableDictionary<Grid, GridView>
{

}
/// <summary>
/// 物品数据和物品物体
/// </summary>
[System.Serializable]
public class DictionaryOfItemAndItemView : UnityUtility.SerializableDictionary<Item, ItemView>
{

}

public class KnapsackView : MonoBehaviour
{
    [Header("格子父物体")] [SerializeField] private Transform gridParent;
    [Header("")] [SerializeField] private KnapsackManager knapsackManager;
    [Header("")] [SerializeField] private DictionaryOfGridAndGridView gridViewDic = new DictionaryOfGridAndGridView();
    [Header("")] [SerializeField] private DictionaryOfItemAndItemView itemViewDic = new DictionaryOfItemAndItemView();
   
    public KnapsackManager GetKnapsackManager { get => knapsackManager; }



    #region  物品事件回调
    private void OnEnable()
    {
        if (knapsackManager == null) knapsackManager = new KnapsackManager();

        knapsackManager.CreateGridEvent += CreateGridCallback;
        knapsackManager.TakeOutItemEvent += TakeOutItemCallback;
        knapsackManager.PutInItemEvent += PutInItemCallback;
        knapsackManager.ExchangeItemEvent += ExchangeItemCallback;
        knapsackManager.OnEnableNew();
    }
    private void OnDisable()
    {
        knapsackManager.OnDisableNew();
        knapsackManager.ExchangeItemEvent -= ExchangeItemCallback;
        knapsackManager.PutInItemEvent += PutInItemCallback;
        knapsackManager.TakeOutItemEvent += TakeOutItemCallback;
        knapsackManager.CreateGridEvent += CreateGridCallback;
    }
    /// <summary>
    /// 创建物品格子回调
    /// </summary>
    private void CreateGridCallback(Grid grid)
    {
        GridView gridView = FactorySystem.FactoryManager.Instance.GetUIPanelFactory.CreateUIPanel<GridView>("GridView", gridParent);
        gridView.SetGrid(grid);
        gridViewDic.Add(grid, gridView);
    }
    /// <summary>
    /// 取出物品回调
    /// </summary>
    private void TakeOutItemCallback(Item item)
    {
        if (itemViewDic.ContainsKey(item))
        {
            Destroy(itemViewDic[item].gameObject);
            itemViewDic.Remove(item);
        }
        else
        {
            Debug.Log($"KnapsackView -> TakeOutItemCallback() -> itemViewDic不存在该item");
        }
    }
    /// <summary>
    /// 放入物品回调
    /// </summary>
    private void PutInItemCallback(Grid grid, Item item)
    {
        GridView gridView = null;
        if (gridViewDic.ContainsKey(grid))
        {
            gridView = gridViewDic[grid];
        }
        else
        {
            Debug.Log($"KnapsackView -> PutInItemCallback() -> gridViewDic不存在该grid------");
            return;
        }
        ItemView itemView = FactorySystem.FactoryManager.Instance.GetUIPanelFactory.CreateUIPanel<ItemView>(item.perfabName, gridView.transform);
        itemView.InitItemView(item, gridView, knapsackManager);
        itemViewDic.Add(item, itemView);
    }
    /// <summary>
    /// 交换物品回调 将字典itemViewDic中的item1/2 移除, 重新创建
    /// </summary>
    private void ExchangeItemCallback(Grid grid1, Item item1, Grid grid2, Item item2)
    {
        GridView gridView1 = null;
        GridView gridView2 = null;
        if (gridViewDic.ContainsKey(grid1))
        {
            gridView1 = gridViewDic[grid1];
        }
        else
        {
            Debug.Log($"KnapsackView -> ExchangeItemCallback() -> gridViewDic不存在该grid1------");
            return;
        }

        if (gridViewDic.ContainsKey(grid2))
        {
            gridView2 = gridViewDic[grid2];
        }
        else
        {
            Debug.Log($"KnapsackView -> ExchangeItemCallback() -> gridViewDic不存在该grid2------");
            return;
        }


        if (item1 != null)
        {
            if (itemViewDic.ContainsKey(item1))
            {
                Destroy(itemViewDic[item1].gameObject);
                itemViewDic.Remove(item1);
            }
            else
            {
                Debug.Log($"KnapsackView -> ExchangeItemCallback() -> itemViewDic不存在该item1");
                return;
            }

            ItemView itemView1 = FactorySystem.FactoryManager.Instance.GetUIPanelFactory.CreateUIPanel<ItemView>(item1.perfabName, gridView1.transform);
            itemView1.InitItemView(item1, gridView1, knapsackManager);
            itemViewDic.Add(item1, itemView1);
        }

        if (item2 != null)
        {
            if (itemViewDic.ContainsKey(item2))
            {
                Destroy(itemViewDic[item2].gameObject);
                itemViewDic.Remove(item2);
            }
            else
            {
                Debug.Log($"KnapsackView -> ExchangeItemCallback() -> itemViewDic不存在该item2");
                return;
            }

            ItemView itemView2 = FactorySystem.FactoryManager.Instance.GetUIPanelFactory.CreateUIPanel<ItemView>(item2.perfabName, gridView2.transform);
            itemView2.InitItemView(item2, gridView2, knapsackManager);
            itemViewDic.Add(item2, itemView2);
        }
    }
    #endregion


    void Start()
    {
        knapsackManager.InitKnapsack();
    }

    void Update()
    {
        //if (Input.GetKeyDown("1"))
        //{
        //    CreateItemData();
        //}
    }


    void CreateItemData()
    {
        string path = System.IO.Path.Combine(Application.streamingAssetsPath, "ItemInfo", "ItemInfo.json");
        Item item1 = new Item("旗门1", 1, "ItemView", "icon1", 1, "高山回转旗门");
        Item item2 = new Item("旗门2", 2, "ItemView", "icon1", 1, "高山回转旗门");
        Item item3 = new Item("旗门3", 3, "ItemView", "icon2", 1, "高山回转旗门");
        Item item4 = null;
        Item item5 = null;
        Item item6 = null;
        Item item7 = null;
        Item item8 = null;
        Item item9 = null;
        Item item10 = null;
        Item item11 = null;
        Item item12 = null;
        Item item13 = null;
        Item item14 = null;
        Item item15 = null;
        Item item16 = null;
        Item item17 = null;
        Item item18 = null;
        Item item19 = null;
        Item item20 = null;
        List<Item> itemList = new List<Item>() { item1, item2, item3, item4, item5, item6, item7, item8, item9, item10, item11, item12, item13, item14, item15, item16, item17, item18, item19, item20 };
        UnityUtility.ReadJson.WriteJson(itemList, path);
    }
}
