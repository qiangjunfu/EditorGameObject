using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public delegate bool PickUpItemDelegate(Item item);
/// <summary>
/// item物品对应的3D物体
/// </summary>
public class ItemObject : MonoBehaviour, IClickable
{
    /// <summary>
    /// 拾取物品事件 返回是否成功放入背包
    /// </summary>
    public static PickUpItemDelegate PickUpItemEvent;
    [SerializeField] private Item item;
    [SerializeField] private RecycleCanvas recycleCanvas;
    public Item GetItem { get => item; }


    public void SetItem(Item item)
    {
        this.item = item;
        if (recycleCanvas == null) recycleCanvas = transform.Find("RecycleCanvas").GetComponent<RecycleCanvas>();
        recycleCanvas.NewStart();
    }



    private void Update()
    {
        recycleCanvas.OnClickRecycleBtn(ClickRecycleCallback);
    }

    /// <summary>
    /// 点击回收按钮的回调
    /// </summary>
    private void ClickRecycleCallback()
    {
        Debug.Log($"点击回收按钮的回调");
        if (PickUpItemEvent != null)
        {
            bool isPickUp = PickUpItemEvent(item);
            if (isPickUp)
            {
                CloseRecycleCanvas();
                Destroy(this.gameObject);
            }
            else
            {
                Debug.Log($"不能拾取物品: {item.ToString() }");
            }
        }
    }


    /// <summary>
    /// 打开回收UI界面
    /// </summary>
    public void OpenRecycleCanvas()
    {
        recycleCanvas.OpenCanvas();
    }
    /// <summary>
    /// 关闭回收UI界面
    /// </summary>
    void CloseRecycleCanvas()
    {
        recycleCanvas.CloseCanvas();
    }

}
