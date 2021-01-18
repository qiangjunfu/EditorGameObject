using System;
using System.Collections;
using System.Collections.Generic;
using UIFramework.MVVM;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class ItemView : BaseView<ItemViewModel>, IDragHandler, IEndDragHandler, IBeginDragHandler, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler
{
    private ItemViewModel viewModel;
    /// <summary>
    /// itemView对应数据信息
    /// </summary>
    [SerializeField] private Item item;
    /// <summary>
    /// itemView的上级格子
    /// </summary>
    private GridView gridView;
    /// <summary>
    /// 背包管理器(物品放入取出通过管理器)
    /// </summary>
    private KnapsackManager knapsackManager;
    [SerializeField] private GraphicRaycaster graphicRaycaster;
    [SerializeField] private RectTransform rect;
    [SerializeField] private Image image;
    [SerializeField] private Text countText;
    [SerializeField] private Text describeText;


    /// <summary>
    /// 初始化ItemView
    /// </summary>
    public void InitItemView(Item item, GridView gridView, KnapsackManager knapsackManager)
    {
        this.item = item;
        this.gridView = gridView;
        SetParentGridView(gridView);
        this.knapsackManager = knapsackManager;
        if (graphicRaycaster == null) graphicRaycaster = GameObject.Find("Canvas").GetComponent<GraphicRaycaster>();
        if (rect == null) rect = GetComponent<RectTransform>();
        UnityUtility.UITool.FullRectParent(rect);

        ItemViewModel itemViewModel = new ItemViewModel(item.name, item.id, item.perfabName, item.iconName, item.count, item.describe);
        BindViewModel(itemViewModel);

        AddListener();
        UpdateItemView(item);
    }


    void UpdateItemView(Item item)
    {
        viewModel.NameChanged(item.name);
        viewModel.IdChanged(item.id);
        viewModel.PerfabNameChanged(item.perfabName);
        viewModel.IconNameChanged(item.iconName);
        viewModel.CountChanged(item.count);
        viewModel.DescribeChanged(item.describe);
    }

    #region  拖拽 点击
    public void OnBeginDrag(PointerEventData eventData)
    {
        Transform tempParent = GameObject.Find("Canvas").transform;
        Vector2 defultSizeDelta = new Vector2(90, 90);
        rect.SetParent(tempParent);
        rect.SetAsLastSibling();
        rect.anchoredPosition = eventData.position - new Vector2(Screen.currentResolution.width, Screen.currentResolution.height) * 0.5f;
        rect.sizeDelta = defultSizeDelta;
        rect.anchorMin = new Vector2(0.5f, 0.5f);
        rect.anchorMax = new Vector2(0.5f, 0.5f);
        rect.pivot = new Vector2(0.5f, 0.5f);
        rect.localRotation = Quaternion.Euler(Vector3.zero);
        rect.localScale = Vector3.one;
    }
    public void OnDrag(PointerEventData eventData)
    {
        //Debug.Log($"ItemView -> OnDrag() -> 屏幕位置:{eventData.position }");
        rect.anchoredPosition = eventData.position - new Vector2(Screen.currentResolution.width, Screen.currentResolution.height) * 0.5f;
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        GridView _gridView = UnityUtility.UITool.GetMouseUIComponent<GridView>(graphicRaycaster, eventData);
        //Debug.Log($"ItemView -> OnEndDrag() -> gridView:{gridView}");

        if (_gridView == null)  //判断是否丢地上
        {
            IPlaceable placeable = UnityUtility.UITool.GetObjComponentByRay<IPlaceable>(Camera.main);
            if (placeable == null)  //返回初始父物体格子
            {
                SetParentGridView(this.gridView);
                UnityUtility.UITool.FullRectParent(rect);
            }
            else   //丢地上
            {
                ItemObject itemObject = FactorySystem.FactoryManager.Instance.GetAssetFactory.CreateTObject<ItemObject>(item.name);
                itemObject.SetItem(item);
                itemObject.transform.position = UnityUtility.UITool.GetMouseWorldPos(Camera.main);
                knapsackManager.TakeOutItem(item);
            }
        }
        else  //交换
        {
            knapsackManager.ExchangeItem(gridView.GetGrid, item, _gridView.GetGrid, _gridView.GetGrid.Item);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        //鼠标进入 显示描述信息
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        //鼠标退出 关闭描述信息
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        //鼠标按下
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        //鼠标抬起
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        //鼠标点击（按下+抬起）
    }
    #endregion


    #region  事件监听
    private void AddListener()
    {
        viewModel.Name.AddListener(NameChangeCallback);
        viewModel.Id.AddListener(IdChangeCallback);
        viewModel.PerfabName.AddListener(PerfabNameChangeCallback);
        viewModel.IconName.AddListener(IconNameChangeCallback);
        viewModel.Count.AddListener(CountChangeCallback);
        viewModel.Describe.AddListener(DescribeChangeCallback);
    }
    private void NameChangeCallback(string oldValue, string newValue)
    {

    }
    private void IdChangeCallback(int oldValue, int newValue)
    {

    }
    private void PerfabNameChangeCallback(string oldValue, string newValue)
    {

    }
    private void IconNameChangeCallback(string oldValue, string newValue)
    {
        Debug.Log($"ItemView -> IconNameChangeCallback() -> 图片名改变:{oldValue }--{newValue}");
        Sprite sprite = FactorySystem.FactoryManager.Instance.GetSpriteFactory.LoadSprite(newValue);
        image.sprite = sprite;
    }
    private void CountChangeCallback(int oldValue, int newValue)
    {
        Debug.Log($"ItemView -> CountChangeCallback() -> 个数改变:{oldValue }--{newValue}");
        countText.text = newValue.ToString();
    }
    private void DescribeChangeCallback(string oldValue, string newValue)
    {
        Debug.Log($"ItemView -> DescribeChangeCallback() -> 描述改变{oldValue }--{newValue}");
        describeText.text = newValue;
    }
    #endregion


    /// <summary>
    /// 修改ItemView的父物体(格子)
    /// </summary>
    public void SetParentGridView(GridView gridView)
    {
        this.gridView = gridView;
        transform.SetParent(gridView.transform);
        transform.SetAsLastSibling();
    }


    public override void BindViewModel(ItemViewModel viewModel)
    {
        this.viewModel = viewModel;
    }

}
