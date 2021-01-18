using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// item物品对应的3D物体
/// </summary>
public class ItemObject : MonoBehaviour, IClickable
{
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

        UnityUtility.MessageManager.Broadcast<Item>(UnityUtility.GameEventType.PickUpItemObj, item);
        CloseRecycleCanvas();
        Destroy(this.gameObject);
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
