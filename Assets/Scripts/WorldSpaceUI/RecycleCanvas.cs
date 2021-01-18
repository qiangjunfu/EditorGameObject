using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public delegate void RecycleDelegate();
public class RecycleCanvas : WorldSpaceCanvas
{
    [SerializeField] private Button recycleBtn;
    [SerializeField] private Button closeBtn;
    [SerializeField] private bool isClickRecycle;


    public void NewStart()
    {
        recycleBtn.onClick.AddListener(() =>
        {
            isClickRecycle = true;
        });
        closeBtn.onClick.AddListener(() =>
        {
            CloseCanvas();
        });
    }


    public void OnClickRecycleBtn(RecycleDelegate recycleDelegate)
    {
        if (isClickRecycle)
        {
            recycleDelegate();
            isClickRecycle = false;
        }
    }


    public override void OpenCanvas()
    {
        base.OpenCanvas();
        isClickRecycle = false;
    }

    public override void CloseCanvas()
    {
        isClickRecycle = false;
        base.CloseCanvas();
    }


}
